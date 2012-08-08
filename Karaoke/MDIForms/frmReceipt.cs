using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO.Ports;
using System.IO;
using DevExpress.XtraEditors;
using BKIT.Entities;
using Karaoke.DataSets;
using BKIT.Model;

namespace Karaoke.MDIForms
{

    public partial class frmReceipt : Form
    {
        private int iCurrentProductID;
        private int iCurrentRoomID;
        private int iCurrentRoomGroupID;
        private int iCurrentReceiptID;
        private int iReceiptIndex;
        private bool isTimedepositChange = false;
        private Hoadonxuat currentReceipt;
        List<CBReq> listCBtoTurnOff;
        public enum ReceiptStatus { Open = 0, Closing = 1, Closed = 2, Printed = 3};
        #region formLoad
        public frmReceipt()
        {
            InitializeComponent();
            currentReceipt = new Hoadonxuat();
            dateReceipt.Format = DateTimePickerFormat.Custom;
            dateReceipt.CustomFormat = "dd/MM/yyyy";
            InitCOMPort();
            listCBtoTurnOff = new List<CBReq>();
        }
        private void frmReceipt_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseComPort();
        }
        private void getAllSP()
        {
            DataSet ds = new DataAccess().getAllSanPhamAndIDGia();
            gridControlSanPham.DataSource = ds.Tables[0];
            gridViewSanPham.ExpandAllGroups();
        }
        private void getAllSPBySearchTenTemplate()
        {
            DataSet ds = new DataAccess().getAllSanPhamAndIDGia(txtSearchSanPham.Text);
            if (ds == null)
            {
                gridControlSanPham.DataSource = null;
                return;
            }
            gridControlSanPham.DataSource = ds.Tables[0];
           
            gridViewSanPham.ExpandAllGroups();
        }

        private void getAllNhanvien()
        {
            DataSet ds = new DataAccess().getAllIDandNameNhanvien();
            cboEmployee.DataSource = ds.Tables[0];
            cboEmployee.DisplayMember = "Ten";
            cboEmployee.ValueMember = "IDNhanvien";
        }
        private void getAllKhachhang()
        {
            DataSet ds = new DataAccess().getAllKhachhang();
            cboCustomer.DataSource = ds.Tables[0];
            cboCustomer.DisplayMember = "Ten";
            cboCustomer.ValueMember = "IDKhachhang";
        }
        private void frmReceipt_Load(object sender, EventArgs e)
        {
            iCurrentReceiptID = -1;
            iCurrentRoomID = -1;
            //getAllSP();
            getAllSPBySearchTenTemplate();
            //displayProductPrice();

            getAllNhanvien();
            getAllKhachhang();
            updateRoomList(-1);
            displayLastRoomReceipt();

            groupControlRoomAndProduct.Width = 52;
        }
        private void frmReceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            CloseComPort();
        }
        #endregion
        #region Product

        private void txtSearchSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddSP(0);
            }
        }

        private void gridViewSanPham_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0 && e.PrevFocusedRowHandle >= 0)
            {
                //list all products by ID
                int ID = Convert.ToInt32(gridViewSanPham.GetRowCellValue(e.FocusedRowHandle, "IDSanPham"));
                iCurrentProductID = ID;
                //DataSet prdPrice = new DataAccess().getGiaXuatSPByIDSanPham(ID);
                //if ((prdPrice != null) && (prdPrice.Tables[0].Rows.Count > 0))
                //    txtPrice.Text = prdPrice.Tables[0].Rows[0][1].ToString();
                //else
                //    MessageBox.Show("Sản phẩm " + gridViewSanPham.GetRowCellValue(e.FocusedRowHandle, "TenSanPham") + " chưa có giá bán! \nVui lòng nhập giá bán bên cửa sổ quản trị", "Thông báo giá bán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void gridViewSanPham_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colAddSP)
                {
                    AddSP(1);
                }
            }
        }
        private void AddSP(int num)
        {
            //add a quantity of a product to current bill
            //check if the parameters are legal

            
            {
                //list all products by ID
                int rowHandle;
                if (num > 0)
                {
                    if (gridViewSanPham.FocusedRowHandle >= 0)
                    {
                        rowHandle = gridViewSanPham.FocusedRowHandle;
                    }
                    else
                        return;
                }
                else
                {
                    if (gridViewBillProduct.RowCount > 0)
                        rowHandle = 0;
                    else
                        return;
                }
                iCurrentProductID= Convert.ToInt32(gridViewSanPham.GetRowCellValue(rowHandle, "IDSanPham"));
                
                int IDLoaiSP = Convert.ToInt32(gridViewSanPham.GetRowCellValue(rowHandle, "IDNhomSP"));
                //DataSet prdPrice = new DataAccess().getGiaXuatSPByIDSanPham(ID);
                //if ((prdPrice != null) && (prdPrice.Tables[0].Rows.Count > 0))
                //{
                //txtPrice.Text = prdPrice.Tables[0].Rows[0][1].ToString();
                if (iCurrentReceiptID >= 0)
                {
                    if (currentReceipt.Trangthai == 2)
                    {
                        MessageBox.Show("Hóa đơn này đã đóng, không được thay đổi", "Thông báo");
                        return;
                    }
                    else if (((currentReceipt.Trangthai == 1)||(currentReceipt.Trangthai == 3)) && (Program.userLevel != Level.Admin))
                    {
                        MessageBox.Show("Đăng nhập với quyền Quản lý để thay đổi", "Thông báo");
                        return;
                    }
                    //get khuyen mai with this product ID
                    DataSet ds = new DataAccess().getKhuyenmaiByIDLoaiSP(IDLoaiSP, DateTime.Now.Date);
                    //if (ds == null)
                    //    return;
                    //if (ds.Tables[0].Rows.Count == 0)
                    //{
                    //get the number of added product
                    frmReturnProduct rt = new frmReturnProduct(true, 0, Convert.ToString(gridViewSanPham.GetRowCellValue(rowHandle, "TenSanPham")));
                    rt.ShowDialog();
                    int rtnum = rt.getReturnNum();
                    // bool directRet = rt.getDirectRet();
                    string text = rt.getText();
                    rt.Close();
                    if (rtnum <= 0) return;
                        ChitietHDXuat obj = new ChitietHDXuat();
                        obj.IDHoadonXuat = iCurrentReceiptID;
                        obj.IDSanpham = iCurrentProductID;
                        obj.Gia = Convert.ToInt32(gridViewSanPham.GetRowCellValue(rowHandle, "Gia"));
                        obj.Soluong = rtnum;
                        obj.Ghichu = text;
                        if (ds != null)
                        {
                            try
                            {
                                obj.Giam = Convert.ToInt32(ds.Tables[0].Rows[0]["Giam"]);
                            }
                            catch (Exception ex)
                            {
                                obj.Giam = 0;
                            }
                        }
                        else
                            obj.Giam = 0;
                        obj.Trangthai = false;
                        int res = new DataAccess().insertChitietHDXuat(obj);
                        if (res < 0)
                        {
                            MessageBox.Show("Không thêm sản phẩm " + gridViewSanPham.GetRowCellValue(rowHandle, "TenSanPham") + " vào hóa đơn hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    //}
                    //else
                    //{
                    //    ChitietHDXuat obj = new ChitietHDXuat();
                    //    obj.IDChitietHDXuat = Convert.ToInt32(ds.Tables[0].Rows[0]["IDChitietHDXuat"]);
                    //    obj.IDHoadonXuat = iCurrentReceiptID;
                    //    obj.IDSanpham = iCurrentProductID;
                    //    obj.IDGiaxuat = Convert.ToInt32(gridViewSanPham.GetRowCellValue(rowHandle, "IDGiaXuatSP"));
                    //    obj.Soluong = Convert.ToInt32(ds.Tables[0].Rows[0]["Soluong"]) + 1;
                    //    obj.Giam = 0;
                    //    obj.Bep = false;
                    //    bool res = new DataAccess().updateChitietHDXuat(obj);
                    //    if (!res)
                    //    {
                    //        MessageBox.Show("Không thêm sản phẩm " + gridViewSanPham.GetRowCellValue(rowHandle, "TenSanPham") + " vào hóa đơn hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //        return;
                    //    }
                    //}
                    updateBillDisplay(iCurrentReceiptID,true);
                    int i;
                    for (i = 0; i < gridViewBillProduct.RowCount; i++)
                    {
                        if (Convert.ToInt32(gridViewBillProduct.GetRowCellValue(i, "IDSanpham")) == iCurrentProductID)
                            break;
                    }
                    //gridViewBillProduct.Focus();
                    gridViewBillProduct.FocusedRowHandle = i;
                    gridViewBillProduct.FocusedColumn = colBillNum;

                }
                //}
                //else
                //    MessageBox.Show("Sản phẩm " + gridViewSanPham.GetRowCellValue(rowHandle, "TenSanPham") + " chưa có giá bán! \nVui lòng nhập giá bán bên cửa sổ quản trị", "Thông báo giá bán", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void gridViewSanPham_DoubleClick(object sender, EventArgs e)
        {
            AddSP(1);
        }
        #endregion Product

        #region Receipt

        private void cboEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iCurrentReceiptID > -1)
            {
                //check if cached bill is the same
                if (iCurrentReceiptID != currentReceipt.IDHoadonXuat)
                    return;
                if (currentReceipt.Trangthai > 1)
                    return;
                currentReceipt.IDNhanvien = Convert.ToInt32(cboEmployee.SelectedValue);
                //update DB
                bool res = new DataAccess().updateHoadonxuat(currentReceipt);
                if (!res)
                {
                    MessageBox.Show("Không cập nhật được CSDL", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void numTax_ValueChanged(object sender, EventArgs e)
        {
            if (iCurrentReceiptID > -1)
            {
                //check if cached bill is the same
                if (iCurrentReceiptID != currentReceipt.IDHoadonXuat)
                    return;
                if (currentReceipt.Trangthai > 1)
                    return;
                currentReceipt.Thue = Convert.ToInt32(numTax.Value);
                //update DB
                bool res = new DataAccess().updateHoadonxuat(currentReceipt);
                if (!res)
                {
                    MessageBox.Show("Không cập nhật được CSDL", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                updateBillDisplay(iCurrentReceiptID,true);
            }
        }

        private void numReduce_ValueChanged(object sender, EventArgs e)
        {
            if (iCurrentReceiptID > -1)
            {
                //check if cached bill is the same
                if (iCurrentReceiptID != currentReceipt.IDHoadonXuat)
                    return;
                if (currentReceipt.Trangthai > 1)
                    return;
                currentReceipt.Giam = Convert.ToInt32(numExtra.Value);
                //update DB
                bool res = new DataAccess().updateHoadonxuat(currentReceipt);
                if (!res)
                {
                    MessageBox.Show("Không cập nhật được CSDL", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                updateBillDisplay(iCurrentReceiptID,true);
            }
        }

        private void numExtra_ValueChanged(object sender, EventArgs e)
        {
            if (iCurrentReceiptID > -1)
            {
                //check if cached bill is the same
                if (iCurrentReceiptID != currentReceipt.IDHoadonXuat)
                    return;
                if (currentReceipt.Trangthai > 1)
                    return;
                currentReceipt.Phuthu = Convert.ToInt32(numExtra.Value);
                //update DB
                bool res = new DataAccess().updateHoadonxuat(currentReceipt);
                if (!res)
                {
                    MessageBox.Show("Không cập nhật được CSDL", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                updateBillDisplay(iCurrentReceiptID,true);
            }
        }



        private void gridViewBillProduct_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if ((currentReceipt.Trangthai < 1) || (Program.userLevel == Level.Admin))
                {
                    if (e.Column == colDeleteCTHD)
                    {
                        ////delete here
                        //get the number of avalable product with this bill
                        DataSet dsCTHD = new DataAccess().getChitietHDXuatByIDSanphamAndIDHoadon(Convert.ToInt32(gridViewBillProduct.GetRowCellValue(e.RowHandle, "IDSanpham")), iCurrentReceiptID);
                        int i;
                        int sum = 0;
                        for (i = 0; i < dsCTHD.Tables[0].Rows.Count; i++)
                        {
                            sum = sum + Convert.ToInt32(dsCTHD.Tables[0].Rows[i]["Soluong"]);
                        }
                        ChitietHDXuat obj = new ChitietHDXuat();
                        obj.Giam = Convert.ToInt32(gridViewBillProduct.GetRowCellValue(e.RowHandle, "Giam"));
                        obj.Gia = Convert.ToInt32(gridViewBillProduct.GetRowCellValue(e.RowHandle, "Gia"));
                        obj.IDHoadonXuat = Convert.ToInt32(gridViewBillProduct.GetRowCellValue(e.RowHandle, "IDHoadonXuat"));
                        obj.IDSanpham = Convert.ToInt32(gridViewBillProduct.GetRowCellValue(e.RowHandle, "IDSanpham"));
                        obj.Soluong = Convert.ToInt32(gridViewBillProduct.GetRowCellValue(e.RowHandle, "Soluong"));
                        obj.Trangthai = Convert.ToBoolean(gridViewBillProduct.GetRowCellValue(e.RowHandle, "Trangthai"));
                        if (sum <= 0)
                        {
                            MessageBox.Show("Hiện tại không còn sản phầm này trong hóa đơn", "Thông báo");
                            return;
                        }
                        frmReturnProduct rt = new frmReturnProduct(false,sum, Convert.ToString(gridViewBillProduct.GetRowCellValue(e.RowHandle, "TenSanPham")));
                        rt.ShowDialog();
                        int rtnum = rt.getReturnNum();
                       // bool directRet = rt.getDirectRet();
                        string text = rt.getText();
                        rt.Close();
                        if (rtnum <= 0) return;
                        obj.Soluong = - rtnum;
                        obj.Ghichu = text;
                        if (new DataAccess().insertChitietHDXuat(obj) < 0)
                            MessageBox.Show(this, "Trả sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            updateBillDisplay(iCurrentReceiptID,true);

                    }


                }
                else
                {
                    MessageBox.Show(this, "Hóa đơn đã khóa sổ, không thay đổi được. Liên hệ quản lý để thay đổi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
        }
        private void gridViewBillProduct_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            ChitietHDXuat obj = new ChitietHDXuat();
            obj.IDChitietHDXuat = Convert.ToInt32(gridViewBillProduct.GetRowCellValue(e.RowHandle, "IDChitietHDXuat"));
            obj.Gia = Convert.ToInt32(gridViewBillProduct.GetRowCellValue(e.RowHandle, "Gia"));
            obj.IDHoadonXuat = Convert.ToInt32(gridViewBillProduct.GetRowCellValue(e.RowHandle, "IDHoadonXuat"));
            obj.IDSanpham = Convert.ToInt32(gridViewBillProduct.GetRowCellValue(e.RowHandle, "IDSanpham"));
            obj.Soluong = Convert.ToInt32(gridViewBillProduct.GetRowCellValue(e.RowHandle, "Soluong"));
            obj.Giam = Convert.ToInt32(gridViewBillProduct.GetRowCellValue(e.RowHandle, "Giam"));
            obj.Trangthai = Convert.ToBoolean(gridViewBillProduct.GetRowCellValue(e.RowHandle, "Trangthai")); ;
            if (new DataAccess().updateChitietHDXuat(obj) == false)
                MessageBox.Show(this, "Cập nhật sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            updateBillDisplay(iCurrentReceiptID,true);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (iCurrentReceiptID > -1)
            //    updateBillDisplay(iCurrentReceiptID);
            //Check if there is request to turn off cb
            int i;
            updateBillDisplay(iCurrentReceiptID, false);
            //if (listCBtoTurnOff == null) return;
            //Queue<int> offCB = new Queue<int>();
            //for (i = 0; i < listCBtoTurnOff.Count; i++)
            //{
            //    if (listCBtoTurnOff.ElementAt(i).isAction())
            //    {
            //        ContactAction(0xfb, listCBtoTurnOff.ElementAt(i).getCBNo());
            //        offCB.Enqueue(i);
            //    }
            //}
            ////remove fired cb
            //while (offCB.Count > 0)
            //{
            //    i = offCB.Dequeue();
            //    listCBtoTurnOff.RemoveAt(i);
            //}
            //update total value of current bill
            /*
            int value = getTotalValueOfBill(iCurrentReceiptID);
            if (value >= 0)
            {
                txtBilltotal.Text = value.ToString("###,###,##0");
                txtReturnMoney.Text = (value - numDeposit.Value).ToString("###,###,##0");
            }*/
            
            //search for warining to close room include printed receipt, deposit
            DataSet ds = new DataAccess().getAllWarningOpenningHoadonxuat();
            if (ds == null) return;
            if (ds.Tables[0].Rows.Count <= 0) return;
            frmWarningRoom fa = new frmWarningRoom(roomList);
            fa.ShowDialog();
            //string roomList = "";
            //for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    //int total = getTotalValueOfBill(Convert.ToInt32(ds.Tables[0].Rows[i]["IDHoadonXuat"]));
            //    DateTime  deposittime = Convert.ToDateTime(ds.Tables[0].Rows[i]["GioKT"]);
            //    if (deposittime <= (DateTime.Now.AddMinutes(10)))
            //    {
            //        DataSet room = new DataAccess().getPhongByIDPhong(Convert.ToInt32(ds.Tables[0].Rows[i]["IDPhong"]));
            //        roomList = roomList + "\n" + room.Tables[0].Rows[0]["TenPhong"];
            //    }
            //}
            //if (roomList != "")
            //{
            //    frmWarningRoom fa = new frmWarningRoom(roomList);
            //    fa.ShowDialog();
            //}
        }

        private void btnCloseBill_Click(object sender, EventArgs e)
        {
            if (iCurrentReceiptID > -1)
            {
                if (MessageBox.Show("Bạn có muốn kết thúc việc thay đổi nội dung hóa đơn (bạn sẽ không được phép thay đổi nội dung Hóa đơn này)?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    currentReceipt.Trangthai = 2;
                    if (new DataAccess().updateHoadonxuat(currentReceipt))
                        MessageBox.Show("Bạn đã kết thúc việc thay đổi hóa đơn", "Thông báo");
                    displayLastRoomReceipt();
                }
            }
        }
        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (iCurrentReceiptID > -1)
            {
                //check if cached bill is the same
                if (iCurrentReceiptID != currentReceipt.IDHoadonXuat)
                    return;
                if (currentReceipt.Trangthai > 1)
                    return;
                currentReceipt.IDKhachhang = Convert.ToInt32(cboCustomer.SelectedValue);
                //update DB
                bool res = new DataAccess().updateHoadonxuat(currentReceipt);
                if (!res)
                {
                    MessageBox.Show("Không cập nhật được CSDL", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }
        private void checkDateReceipt_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDateReceipt.Checked)
            {
                dateReceipt.Enabled = true;
                dateReceipt.Value = DateTime.Now;
                //query to select Bill of the current Room that happened on this date
            }
            else
            {
                dateReceipt.Enabled = false;
                //query to select Bills of the current Room that have happened before
            }
            displayLastRoomReceipt();
        }
        private void btnLastBill_Click(object sender, EventArgs e)
        {
            displayLastRoomReceipt();
        }



       
        

        private void btnDivideRoom_Click(object sender, EventArgs e)
        {
            //get status of this room
            if ((iCurrentRoomID < 0) || (iCurrentReceiptID < 0))
            {
                MessageBox.Show("Chọn phòng đang hoạt động để tách phòng/hợp phòng!", "Thông báo");
                return;
            }
            //if (iCurrentReceiptID>0)
            //{
            //    MessageBox.Show("Chọn phòng đang hoạt động để tách phòng/hợp phòng!", "Thông báo");
            //    return;
            //}
            frmDivideRoom a = new frmDivideRoom(iCurrentRoomID, iCurrentReceiptID);
            a.ShowDialog();
            int i;
            //compare grid with DB to open electric CB
            //updateRoomGrid(a.TransferedRoomID());
            switch (a.DevideAction())
            {
                case 1:
                    //transfer room
                    //turnoff CB
                    DataSet ds = new DataAccess().getPhongByIDPhong(iCurrentRoomID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        CBReq req = new CBReq(Convert.ToInt32(ds.Tables[0].Rows[0]["Congtac"]), 10);
                        listCBtoTurnOff.Add(req);
                        //ContactAction(0xcf, Convert.ToInt32(ds.Tables[0].Rows[0]["Congtac"]));
                    }
                    iCurrentRoomID = a.getNewOpenedRoom();
                    //add san pham mac dinh vao hoa don moi
                    //add starting product for the room
                    DataSet dsSPBD = new DataAccess().getAllSPBandauIDLoaiPhong(a.getNewOpenedRoomGroup());
                    for (i = 0; i < dsSPBD.Tables[0].Rows.Count; i++)
                    {
                        int IDSanPham = Convert.ToInt32(dsSPBD.Tables[0].Rows[i]["IDSanPham"]);
                        int IDLoaiSP = Convert.ToInt32(dsSPBD.Tables[0].Rows[i]["IDNhomSP"]);
                        string TenSanPham = Convert.ToString(dsSPBD.Tables[0].Rows[i]["TenSanPham"]);
                        int num = Convert.ToInt32(dsSPBD.Tables[0].Rows[i]["Soluong"]);
                        AddSPBD(a.TransferedReceipt(), IDLoaiSP, IDSanPham, TenSanPham, num);
                    }
                    updateBillDisplay(a.TransferedReceipt(), true);
                    ds = new DataAccess().getPhongByIDPhong(iCurrentRoomID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ContactAction(0xbf, Convert.ToInt32(ds.Tables[0].Rows[0]["Congtac"]));
                    }
                    break;
                case 2:
                    //jump to new room
                    iCurrentRoomID = a.getNewOpenedRoom();
                    updateBillDisplay(a.TransferedReceipt(), true);
                    break;
                case 3:
                                        
                    iCurrentRoomID = a.getNewOpenedRoom();
                    DataSet dsSPBD1 = new DataAccess().getAllSPBandauIDLoaiPhong(a.getNewOpenedRoomGroup());
                    for (i = 0; i < dsSPBD1.Tables[0].Rows.Count; i++)
                    {
                        int IDSanPham = Convert.ToInt32(dsSPBD1.Tables[0].Rows[i]["IDSanPham"]);
                        int IDLoaiSP = Convert.ToInt32(dsSPBD1.Tables[0].Rows[i]["IDNhomSP"]);
                        string TenSanPham = Convert.ToString(dsSPBD1.Tables[0].Rows[i]["TenSanPham"]);
                        int num = Convert.ToInt32(dsSPBD1.Tables[0].Rows[i]["Soluong"]);
                        AddSPBD(a.TransferedReceipt(), IDLoaiSP, IDSanPham, TenSanPham, num);
                    }
                    updateBillDisplay(a.TransferedReceipt(), true);
                    ds = new DataAccess().getPhongByIDPhong(iCurrentRoomID);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ContactAction(0xbf, Convert.ToInt32(ds.Tables[0].Rows[0]["Congtac"]));
                    }
                    break;
                default:
                    break;
            }
            
            a.Close();


        }

        private void btnJoinRoom_Click(object sender, EventArgs e)
        {
            
        }
        private void printCookingInvoice()
        {
            if (iCurrentReceiptID >= 0)
            {
                int i;
                DataSetHoaDon dsBill = new DataSetHoaDon();
                DataSet dsSP = new DataAccess().getChitietHDXuatByID(iCurrentReceiptID);
                DataSet dsHD = new DataAccess().getHoadonxuatByIDHoadonXuat(iCurrentReceiptID);
                ChitietHDXuat obj = new ChitietHDXuat();

                for (i = 0; i < dsSP.Tables[0].Rows.Count; i++)
                {
                    if ((Convert.ToBoolean(dsSP.Tables[0].Rows[i]["Trangthai"]) == false) &&
                                (Convert.ToString(dsSP.Tables[0].Rows[i]["Noixuat"]) == "Bếp"))
                    {
                        DataRow dr1 = dsBill.Tables["RDatadetail"].NewRow();
                        dr1["STT"] = (i + 1).ToString();
                        dr1["TenSanPham"] = dsSP.Tables[0].Rows[i]["TenSanPham"].ToString();
                        dr1["DVT"] = dsSP.Tables[0].Rows[i]["DVT"].ToString();
                        dr1["DonGia"] = dsSP.Tables[0].Rows[i]["Gia"].ToString();
                        dr1["Soluong"] = dsSP.Tables[0].Rows[i]["Soluong"].ToString();
                        dr1["ThanhTien"] = Convert.ToDecimal(dsSP.Tables[0].Rows[i]["Thanhtien"]).ToString("###,###,###,###");

                        dsBill.Tables["RDatadetail"].Rows.Add(dr1);

                    }
                }

                //read Company Information 
                string strCompanyName = "";
                string strCompanyAddress = "";
                string strCompanyPhone = "";
                string strLoiChao1 = "";
                string strLoiChao2 = "";
                DataSet dsSetting = new DataAccess().getSettingByDate("");
                if (dsSetting != null)
                {
                    if (dsSetting.Tables[0].Rows.Count > 0)
                    {
                        if (!(dsSetting.Tables[0].Rows[0]["TenCT"] is DBNull))
                            strCompanyName = Convert.ToString(dsSetting.Tables[0].Rows[0]["TenCT"]);
                        if (!(dsSetting.Tables[0].Rows[0]["Diachi"] is DBNull))
                            strCompanyAddress = Convert.ToString(dsSetting.Tables[0].Rows[0]["Diachi"]);
                        if (!(dsSetting.Tables[0].Rows[0]["Phone"] is DBNull))
                            strCompanyPhone = Convert.ToString(dsSetting.Tables[0].Rows[0]["Phone"]);
                        if (!(dsSetting.Tables[0].Rows[0]["Loichao1"] is DBNull))
                            strLoiChao1 = Convert.ToString(dsSetting.Tables[0].Rows[0]["Loichao1"]);
                        if (!(dsSetting.Tables[0].Rows[0]["Loichao2"] is DBNull))
                            strLoiChao2 = Convert.ToString(dsSetting.Tables[0].Rows[0]["Loichao2"]);
                    }
                }


                DataRow dr = dsBill.Tables["HeaderData"].NewRow();

                dr["Ngayxuat"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                dr["Phong"] = cboRoom.Text;
                dr["GiaPhong"] = txtRoomPrice.Text;
                dr["HoadonID"] = iCurrentReceiptID.ToString();
                dr["GioBD"] = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioBD"]).ToShortTimeString();
                dr["GioKT"] = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioKT"]).ToShortTimeString();
                dr["Nhanvien"] = cboEmployee.Text;
                dr["NhanvienHD"] = Program.userFullName;
                dr["TenHoaDon"] = currentReceipt.TenHoadon;
                dr["Thue"] = numTax.Value.ToString();
                dr["Tiengiam"] = numExtra.Value.ToString();
                dr["Phuthu"] = numExtra.Value.ToString();
                dr["Tiengio"] = txtHourMoney.Text;
                dr["Tienhang"] = txtProductMoney.Text;
                dr["Tongcong"] = txtBilltotal.Text;
                dr["Tratruoc"] = numDeposit.Value.ToString("###,###,##0");
                dr["Tralai"] = txtReturnMoney.Text;
                dr["TenCongTy"] = strCompanyName;
                dr["DiaChi"] = "ĐC: " + strCompanyAddress;
                dr["SoDT"] = "ĐT: " + strCompanyPhone;
                dr["Loichao1"] = strLoiChao1;
                dr["Loichao2"] = strLoiChao2;
                dsBill.Tables["HeaderData"].Rows.Add(dr);

                if (dsBill != null)
                {
                    //load last setting
                    DataSet ds = new DataAccess().getSettingByDate("");
                    string printer;
                    try
                    {
                        printer = Convert.ToString(ds.Tables[0].Rows[0]["MayInBep"]);
                        myPrinters.SetDefaultPrinter(printer);
                    }
                    catch
                    {
                        MessageBox.Show("Chưa cài đặt máy in!", "Thông báo");
                        return;
                    }
                    frmViewReport frmView = new frmViewReport(dsBill, true,printer);
                    if (frmView.ShowDialog() == DialogResult.Yes)
                    {
                        for (i = 0; i < dsSP.Tables[0].Rows.Count; i++)
                        {
                            if ((Convert.ToBoolean(dsSP.Tables[0].Rows[i]["Trangthai"]) == false) &&
                                (Convert.ToString(dsSP.Tables[0].Rows[i]["Noixuat"]) == "Bếp"))
                            {
                                //update bep
                                obj.IDChitietHDXuat = Convert.ToInt32(dsSP.Tables[0].Rows[i]["IDChitietHDXuat"]);
                                obj.IDHoadonXuat = Convert.ToInt32(dsSP.Tables[0].Rows[i]["IDHoadonXuat"]);
                                obj.IDSanpham = Convert.ToInt32(dsSP.Tables[0].Rows[i]["IDSanpham"]);
                                obj.Gia = Convert.ToInt32(dsSP.Tables[0].Rows[i]["Gia"]);
                                obj.Soluong = Convert.ToInt32(dsSP.Tables[0].Rows[i]["Soluong"]);
                                obj.Trangthai = Convert.ToBoolean(dsSP.Tables[0].Rows[i]["Trangthai"]);
                                obj.Giam = Convert.ToInt32(dsSP.Tables[0].Rows[i]["Giam"]);
                                obj.Ghichu = Convert.ToString(dsSP.Tables[0].Rows[i]["Ghichu"]);
                                obj.Trangthai = true;
                                try
                                {
                                    if (new DataAccess().updateChitietHDXuat(obj) != true)
                                        MessageBox.Show("Lỗi dữ liệu", "Thông báo");
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
        }
        private void printWarehouseInvoice()
        {
            if (iCurrentReceiptID >= 0)
            {
                int i;
                DataSetHoaDon dsBill = new DataSetHoaDon();
                DataSet dsSP = new DataAccess().getChitietHDXuatByID(iCurrentReceiptID);
                DataSet dsHD = new DataAccess().getHoadonxuatByIDHoadonXuat(iCurrentReceiptID);
                ChitietHDXuat obj = new ChitietHDXuat();

                for (i = 0; i < dsSP.Tables[0].Rows.Count; i++)
                {
                    if ((Convert.ToBoolean(dsSP.Tables[0].Rows[i]["Trangthai"]) == false) &&
                                (Convert.ToString(dsSP.Tables[0].Rows[i]["Noixuat"]) == "Kho"))
                    {
                        DataRow dr1 = dsBill.Tables["RDatadetail"].NewRow();
                        dr1["STT"] = (i + 1).ToString();
                        dr1["TenSanPham"] = dsSP.Tables[0].Rows[i]["TenSanPham"].ToString();
                        dr1["DVT"] = dsSP.Tables[0].Rows[i]["DVT"].ToString();
                        dr1["DonGia"] = dsSP.Tables[0].Rows[i]["Gia"].ToString();
                        dr1["Soluong"] = dsSP.Tables[0].Rows[i]["Soluong"].ToString();
                        dr1["Ghichu"] = dsSP.Tables[0].Rows[i]["Ghichu"].ToString();
                        dr1["ThanhTien"] = Convert.ToDecimal(dsSP.Tables[0].Rows[i]["Thanhtien"]).ToString("###,###,###,###");

                        dsBill.Tables["RDatadetail"].Rows.Add(dr1);

                    }
                }

                //read Company Information 
                string strCompanyName = "";
                string strCompanyAddress = "";
                string strCompanyPhone = "";
                string strLoiChao1 = "";
                string strLoiChao2 = "";
                DataSet dsSetting = new DataAccess().getSettingByDate("");
                if (dsSetting != null)
                {
                    if (dsSetting.Tables[0].Rows.Count > 0)
                    {
                        if (!(dsSetting.Tables[0].Rows[0]["TenCT"] is DBNull))
                            strCompanyName = Convert.ToString(dsSetting.Tables[0].Rows[0]["TenCT"]);
                        if (!(dsSetting.Tables[0].Rows[0]["Diachi"] is DBNull))
                            strCompanyAddress = Convert.ToString(dsSetting.Tables[0].Rows[0]["Diachi"]);
                        if (!(dsSetting.Tables[0].Rows[0]["Phone"] is DBNull))
                            strCompanyPhone = Convert.ToString(dsSetting.Tables[0].Rows[0]["Phone"]);
                        if (!(dsSetting.Tables[0].Rows[0]["Loichao1"] is DBNull))
                            strLoiChao1 = Convert.ToString(dsSetting.Tables[0].Rows[0]["Loichao1"]);
                        if (!(dsSetting.Tables[0].Rows[0]["Loichao2"] is DBNull))
                            strLoiChao2 = Convert.ToString(dsSetting.Tables[0].Rows[0]["Loichao2"]);
                    }
                }


                DataRow dr = dsBill.Tables["HeaderData"].NewRow();
                dr["Ngayxuat"] = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                dr["Phong"] = cboRoom.Text;
                dr["GiaPhong"] = txtRoomPrice.Text;
                dr["HoadonID"] = iCurrentReceiptID.ToString();
                dr["GioBD"] = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioBD"]).ToShortTimeString();
                dr["GioKT"] = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioKT"]).ToShortTimeString();
                dr["Nhanvien"] = cboEmployee.Text;
                dr["NhanvienHD"] = Program.userFullName;
                dr["TenHoaDon"] = currentReceipt.TenHoadon;
                dr["Thue"] = numTax.Value.ToString();
                dr["Tiengiam"] = numExtra.Value.ToString();
                dr["Phuthu"] = numExtra.Value.ToString();
                dr["Tiengio"] = txtHourMoney.Text;
                dr["Tienhang"] = txtProductMoney.Text;
                dr["Tongcong"] = txtBilltotal.Text;
                dr["Tratruoc"] = numDeposit.Value.ToString("###,###,##0");
                dr["Tralai"] = txtReturnMoney.Text;
                dr["TenCongTy"] = strCompanyName;
                dr["DiaChi"] = "ĐC: " + strCompanyAddress;
                dr["SoDT"] = "ĐT: " + strCompanyPhone;
                dr["Loichao1"] = strLoiChao1;
                dr["Loichao2"] = strLoiChao2;
                dsBill.Tables["HeaderData"].Rows.Add(dr);

                if (dsBill != null)
                {
                    //set default printer
                    //load last setting
                    DataSet ds = new DataAccess().getSettingByDate("");
                    string printer;
                    try
                    {
                        printer = Convert.ToString(ds.Tables[0].Rows[0]["MayInKho"]);
                        myPrinters.SetDefaultPrinter(printer);
                    }
                    catch
                    {
                        MessageBox.Show("Chưa cài đặt máy in!", "Thông báo");
                        return;
                    }
                    frmViewReport frmView = new frmViewReport(dsBill, false,printer);
                    if (frmView.ShowDialog() == DialogResult.Yes)
                    {
                        for (i = 0; i < dsSP.Tables[0].Rows.Count; i++)
                        {
                            if ((Convert.ToBoolean(dsSP.Tables[0].Rows[i]["Trangthai"]) == false) &&
                                (Convert.ToString(dsSP.Tables[0].Rows[i]["Noixuat"]) == "Kho"))
                            {
                                //update bep
                                obj.IDChitietHDXuat = Convert.ToInt32(dsSP.Tables[0].Rows[i]["IDChitietHDXuat"]);
                                obj.IDHoadonXuat = Convert.ToInt32(dsSP.Tables[0].Rows[i]["IDHoadonXuat"]);
                                obj.IDSanpham = Convert.ToInt32(dsSP.Tables[0].Rows[i]["IDSanpham"]);
                                obj.Gia = Convert.ToInt32(dsSP.Tables[0].Rows[i]["Gia"]);
                                obj.Soluong = Convert.ToInt32(dsSP.Tables[0].Rows[i]["Soluong"]);
                                obj.Trangthai = Convert.ToBoolean(dsSP.Tables[0].Rows[i]["Trangthai"]);
                                obj.Giam = Convert.ToInt32(dsSP.Tables[0].Rows[i]["Giam"]);
                                obj.Ghichu = Convert.ToString(dsSP.Tables[0].Rows[i]["Ghichu"]);
                                obj.Trangthai = true;
                                try
                                {
                                    if (new DataAccess().updateChitietHDXuat(obj) != true)
                                        MessageBox.Show("Lỗi dữ liệu", "Thông báo");
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
        }
        private void printReceipt()
        {
            
            if (iCurrentReceiptID >= 0)
            {
                int i;
                DataSetHoaDon dsBill = new DataSetHoaDon();
                DataSet dsSP = new DataAccess().getSumChitietHDXuatByID(iCurrentReceiptID);
                DataSet dsHD = new DataAccess().getHoadonxuatByIDHoadonXuat(iCurrentReceiptID);
                int receiptStat = Convert.ToInt32(dsHD.Tables[0].Rows[0]["Trangthai"]);
                if ((receiptStat != (int)ReceiptStatus.Open)&&(Program.userLevel != Level.Admin))
                {
                    MessageBox.Show("Hóa đơn đã được in. Liên hệ với quản lý để in lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                for (i = 0; i < dsSP.Tables[0].Rows.Count; i++)
                {
                    DataRow dr1 = dsBill.Tables["RDatadetail"].NewRow();
                    dr1["STT"] = (i + 1).ToString();
                    dr1["TenSanPham"] = dsSP.Tables[0].Rows[i]["TenSanPham"].ToString();
                    dr1["DVT"] = dsSP.Tables[0].Rows[i]["DVT"].ToString();
                    dr1["DonGia"] = dsSP.Tables[0].Rows[i]["Gia"].ToString();
                    dr1["Giam"] = dsSP.Tables[0].Rows[i]["Giam"].ToString() + "%";
                    dr1["Soluong"] = dsSP.Tables[0].Rows[i]["Soluong"].ToString();
                    dr1["ThanhTien"] = Convert.ToDecimal(dsSP.Tables[0].Rows[i]["Thanhtien"]).ToString("###,###,###,###");

                    dsBill.Tables["RDatadetail"].Rows.Add(dr1);
                }
                DataRow dr2 = dsBill.Tables["RDatadetail"].NewRow();
                dr2["STT"] = (i + 2).ToString();
                dr2["TenSanPham"] = "Tiền phòng";
                dr2["DVT"] = ("Giờ").ToString();
                dr2["DonGia"] = txtRoomPrice.Text;
                TimeSpan ts = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioKT"]).Subtract(Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioBD"]));
                //add extra 10 minutes to open receipt
                if((Convert.ToBoolean(dsHD.Tables[0].Rows[0]["Nhacnho"])==false) && (receiptStat == (int)ReceiptStatus.Open))
                    ts.Add(new TimeSpan(0,10,0));
                //double playmin = ts.Hours + Convert.ToDouble(ts.Minutes) / 60;
                dr2["Soluong"] = ts.Hours.ToString()+"h"+ts.Minutes.ToString();
                dr2["ThanhTien"] = txtHourMoney.Text;
                dr2["Giam"] = Convert.ToString(dsHD.Tables[0].Rows[0]["Giam"]) + "%";
                dsBill.Tables["RDatadetail"].Rows.Add(dr2);

                DataRow dr3 = dsBill.Tables["RDatadetail"].NewRow();
                dr3["STT"] = (i + 3).ToString();
                dr3["TenSanPham"] = "Phụ thu";
                //dr3["DVT"] = ("").ToString();
                dr3["DonGia"] = numExtra.Value.ToString();
                dr3["Soluong"] = "1";
                dr3["ThanhTien"] = numExtra.Value.ToString();
                dr3["Giam"] = "0%";
                dsBill.Tables["RDatadetail"].Rows.Add(dr3);

                DataRow dr31 = dsBill.Tables["RDatadetail"].NewRow();
                dr31["STT"] = (i + 3).ToString();
                dr31["TenSanPham"] = "KM Đặc biệt";
                //dr3["DVT"] = ("").ToString();
                dr31["DonGia"] = numExtra.Value.ToString();
                dr31["Soluong"] = "1";
                dr31["ThanhTien"] = numReduce.Value.ToString();
                dr31["Giam"] = "0%";
                dsBill.Tables["RDatadetail"].Rows.Add(dr31);

                DataRow dr4 = dsBill.Tables["RDatadetail"].NewRow();
                dr4["STT"] = (i + 4).ToString();
                dr4["TenSanPham"] = "Thuế";
                dr4["DVT"] = ("%").ToString();
                dr4["Giam"] = "0%";
                // dr4["DonGia"] = "Phần Trăm";
                dr4["Soluong"] = numTax.Value.ToString();
                if (txtBilltotal.Text == "")
                {
                    dr4["ThanhTien"] = "0";
                }
                else
                {
                    dr4["ThanhTien"] = (Convert.ToDouble(txtBilltotal.Text) * Convert.ToDouble(numTax.Value) /
                        (100 + Convert.ToDouble(numTax.Value))).ToString("###,###,###");
                }
                dsBill.Tables["RDatadetail"].Rows.Add(dr4);
                //read Company Information form file
                //StreamReader reader = null;
                string strCompanyName = "";
                string strCompanyAddress = "";
                string strCompanyPhone = "";
                string strLoiChao1 = "";
                string strLoiChao2 = "";
                DataSet dsSetting = new DataAccess().getSettingByDate("");
                if (dsSetting != null)
                {
                    if (dsSetting.Tables[0].Rows.Count > 0)
                    {
                        if (!(dsSetting.Tables[0].Rows[0]["TenCT"] is DBNull))
                            strCompanyName = Convert.ToString(dsSetting.Tables[0].Rows[0]["TenCT"]);
                        if (!(dsSetting.Tables[0].Rows[0]["Diachi"] is DBNull))
                            strCompanyAddress = Convert.ToString(dsSetting.Tables[0].Rows[0]["Diachi"]);
                        if (!(dsSetting.Tables[0].Rows[0]["Phone"] is DBNull))
                            strCompanyPhone = Convert.ToString(dsSetting.Tables[0].Rows[0]["Phone"]);
                        if (!(dsSetting.Tables[0].Rows[0]["Loichao1"] is DBNull))
                            strLoiChao1 = Convert.ToString(dsSetting.Tables[0].Rows[0]["Loichao1"]);
                        if (!(dsSetting.Tables[0].Rows[0]["Loichao2"] is DBNull))
                            strLoiChao2 = Convert.ToString(dsSetting.Tables[0].Rows[0]["Loichao2"]);
                    }
                }


                DataRow dr = dsBill.Tables["HeaderData"].NewRow();
                dr["Ngayxuat"] = dateReceipt.Value.ToString("dd/MM/yyyy HH:mm:ss tt");
                dr["Phong"] = cboRoom.Text;
                dr["GiaPhong"] = txtRoomPrice.Text;
                dr["TenHoadon"] = dsHD.Tables[0].Rows[0]["TenHoadon"].ToString();
                dr["HoadonID"] = iCurrentReceiptID.ToString();
                dr["GioBD"] = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioBD"]).ToShortTimeString();
                dr["GioKT"] = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioKT"]).ToShortTimeString();
                dr["Nhanvien"] = cboEmployee.Text;
                dr["NhanvienHD"] = Program.userFullName;
                dr["Thue"] = numTax.Value.ToString();
                dr["Tiengiam"] = numReduce.Value.ToString();
                dr["Phuthu"] = numExtra.Value.ToString();
                dr["Tiengio"] = txtHourMoney.Text;
                dr["Tienhang"] = txtProductMoney.Text;
                dr["Tongcong"] = txtBilltotal.Text;
                dr["Tratruoc"] = numDeposit.Value.ToString("###,###,##0");
                dr["Tralai"] = txtReturnMoney.Text;
                dr["TenCongTy"] = strCompanyName;
                dr["DiaChi"] = "ĐC: " + strCompanyAddress;
                dr["SoDT"] = "ĐT: " + strCompanyPhone;
                dr["Loichao1"] = strLoiChao1;
                dr["Loichao2"] = strLoiChao2;
                dsBill.Tables["HeaderData"].Rows.Add(dr);

                if (dsBill != null)
                {
                    //load last setting
                    DataSet ds = new DataAccess().getSettingByDate("");
                    string printer;
                    try
                    {
                        printer = Convert.ToString(ds.Tables[0].Rows[0]["MayInHoadon"]);
                        myPrinters.SetDefaultPrinter(printer);
                    }
                    catch
                    {
                        MessageBox.Show("Chưa cài đặt máy in!", "Thông báo");
                    }
                    frmViewReport frmView = new frmViewReport(dsBill);
                    if (frmView.ShowDialog() == DialogResult.Yes)
                    {
                        //update bill
                        //Hoadonxuat objHDXuat = new Hoadonxuat();
                        //objHDXuat.IDHoadonXuat = Convert.ToInt32(dsHD.Tables[0].Rows[0]["IDHoadonXuat"]);
                        //objHDXuat.Giam = Convert.ToInt32(dsHD.Tables[0].Rows[0]["Giam"]);
                        //objHDXuat.GioBD = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioBD"]);
                        //objHDXuat.GioKT = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioKT"]);
                        //objHDXuat.IDPhong = iCurrentRoomID;
                        //objHDXuat.Ngayxuat = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["Ngayxuat"]).Date;
                        //objHDXuat.Phuthu = Convert.ToInt32(dsHD.Tables[0].Rows[0]["Phuthu"]);
                        //objHDXuat.Thue = Convert.ToInt32(dsHD.Tables[0].Rows[0]["Thue"]);
                        //objHDXuat.IDGiaLoaiphong = Convert.ToInt32(dsHD.Tables[0].Rows[0]["IDGiaLoaiphong"]);
                        //objHDXuat.IDNhanvien = Convert.ToInt32(dsHD.Tables[0].Rows[0]["IDNhanvien"]);
                        //objHDXuat.Tratruoc = Convert.ToInt32(dsHD.Tables[0].Rows[0]["Tratruoc"]);
                        //objHDXuat.Nhacnho = Convert.ToBoolean(dsHD.Tables[0].Rows[0]["Nhacnho"]);
                        //objHDXuat.IDKhachhang = Convert.ToInt32(dsHD.Tables[0].Rows[0]["IDKhachhang"]);
                        //objHDXuat.Ghichu = Convert.ToString(dsHD.Tables[0].Rows[0]["Ghichu"]);
                        //mark status of this receipt
                        if (receiptStat == (int)ReceiptStatus.Open)
                        {
                            if (Convert.ToBoolean(dsHD.Tables[0].Rows[0]["Nhacnho"]) == false)
                            {
                                currentReceipt.GioKT.AddMinutes(10);
                                //add to list to turn off CB after 10 minutes
                                DataSet dsPhong = new DataAccess().getPhongByIDPhong(iCurrentRoomID);
                                CBReq req = new CBReq(Convert.ToInt32(dsPhong.Tables[0].Rows[0]["Congtac"]), 10);
                                listCBtoTurnOff.Add(req);
                            }
                            
                            currentReceipt.Trangthai = (int)ReceiptStatus.Printed;
                            if (new DataAccess().updateHoadonxuat(currentReceipt) == false)
                                MessageBox.Show("Lỗi dữ liệu", "Thông báo");
                            updateBillDisplay(iCurrentReceiptID, false);
                        }
                    }
                }
            }
        }
        private void btnPrintCooking_Click(object sender, EventArgs e)
        {
            printCookingInvoice();
            printWarehouseInvoice();
        }
        private void btnPrintBill_Click_1(object sender, EventArgs e)
        {
            printReceipt();
        }
        #endregion Receipt

        #region Room
        private void updateRoomList(int IDPhong)
        {
            
            cboRoom.DataSource = new DataAccess().getAllPhongAndLoaiPhong().Tables[0];
            cboRoom.DisplayMember = "TenPhong";
            cboRoom.ValueMember = "IDPhong";
            //get focus to current
            if (IDPhong >= 0)
            {
                cboRoom.SelectedValue = IDPhong;
                iCurrentRoomID = IDPhong;
            }
            else
            {
                //display last room and receipt
                DataSet ds = new DataAccess().getLastOpeningHoadonxuatByIDPhong(-1);
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        iCurrentReceiptID = Convert.ToInt32(ds.Tables[0].Rows[0]["IDHoadonXuat"]);
                        iCurrentRoomID = Convert.ToInt32(ds.Tables[0].Rows[0]["IDPhong"]);
                        cboRoom.SelectedValue = iCurrentRoomID;
                    }
                    else
                    {
                        cboRoom.SelectedIndex = 0;
                        iCurrentReceiptID = -1;
                        iCurrentRoomID = Convert.ToInt32(cboRoom.SelectedValue);
                    }
                }
            }
        }
        /*
        private void updateRoomGrid(int IDPhong)
        {
            gridRoom.DataSource = new DataAccess().getAllPhongAndLoaiPhong().Tables[0];
            gridViewRoom.ExpandAllGroups();
            //get focus to current
            int i;
            for (i = 0; i < gridViewRoom.RowCount; i++)
            {
                if (Convert.ToInt32(gridViewRoom.GetRowCellValue(i, "IDPhong")) == IDPhong)
                    break;
            }
            gridViewRoom.FocusedRowHandle = i;
            iCurrentRoomID = Convert.ToInt32(gridViewRoom.GetRowCellValue(i, "IDPhong"));
            displayLastRoomReceipt();
        }
        
        private void gridViewRoom_DoubleClick(object sender, EventArgs e)
        {
            Start(0);
            updateRoomGrid(iCurrentRoomID);
        }
        private void gridViewRoom_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {

                if (e.Column == colRoomStatus)
                {
                    Start(iCurrentRoomID);
                    updateRoomGrid(iCurrentRoomID);
                }
            }
        }
        private void gridViewRoom_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0 && e.PrevFocusedRowHandle >= 0)
            {
                {
                    displayLastRoomReceipt();
                }
            }
        }
        */
        private void Start(int roomID)
        {
            //open or close selected room
            //first search if selected room is available
            if (iCurrentRoomID < 0) return ;
            DataSet ds = new DataAccess().getPhongByIDPhong(iCurrentRoomID);

            if (ds.Tables[0].Rows.Count > 0)
            {
                iCurrentRoomGroupID = Convert.ToInt32(ds.Tables[0].Rows[0]["IDLoaiphong"]);
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Trangthai"]) == true)
                {
                    //in case of the room has been openned
                    //ask to open room and create new receipt for this room
                    if (MessageBox.Show("Bạn có muốn đóng phòng " + Convert.ToString(ds.Tables[0].Rows[0]["TenPhong"]) + "?", "Thông báo mở phòng", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                        return;
                    //ContactAction(0xfb, Convert.ToInt32(ds.Tables[0].Rows[0]["Congtac"]));
                    CBReq req = new CBReq(Convert.ToInt32(ds.Tables[0].Rows[0]["Congtac"]), 10);
                    listCBtoTurnOff.Add(req);
                    //get the last opening receipt of this rom
                    DataSet lastBill = new DataAccess().getLastHoadonxuatByIDPhong(iCurrentRoomID);
                    //Hoadonxuat currentReceipt = new Hoadonxuat();
                    currentReceipt.TenHoadon = Convert.ToString(lastBill.Tables[0].Rows[0]["TenHoadon"]);
                    currentReceipt.IDHoadonXuat = Convert.ToInt32(lastBill.Tables[0].Rows[0]["IDHoadonXuat"]);
                    currentReceipt.Giam = Convert.ToInt32(lastBill.Tables[0].Rows[0]["Giam"]);
                    currentReceipt.GioBD = Convert.ToDateTime(lastBill.Tables[0].Rows[0]["GioBD"]);
                    //currentReceipt.GioKT = DateTime.Now.TimeOfDay;
                    currentReceipt.IDPhong = iCurrentRoomID;
                    currentReceipt.Ngayxuat = Convert.ToDateTime(lastBill.Tables[0].Rows[0]["Ngayxuat"]).Date;
                    currentReceipt.Phuthu = Convert.ToInt32(lastBill.Tables[0].Rows[0]["Phuthu"]);
                    currentReceipt.Thue = Convert.ToInt32(lastBill.Tables[0].Rows[0]["Thue"]);
                    currentReceipt.IDGiaLoaiphong = Convert.ToInt32(lastBill.Tables[0].Rows[0]["IDGiaLoaiphong"]);
                    currentReceipt.IDNhanvien = Convert.ToInt32(lastBill.Tables[0].Rows[0]["IDNhanvien"]);
                    currentReceipt.IDNhanvienXuatHD = Convert.ToInt32(lastBill.Tables[0].Rows[0]["IDNhanvienXuatHD"]);
                    currentReceipt.Tratruoc = Convert.ToInt32(lastBill.Tables[0].Rows[0]["Tratruoc"]);
                    currentReceipt.Nhacnho = Convert.ToBoolean(lastBill.Tables[0].Rows[0]["Nhacnho"]);
                    currentReceipt.IDKhachhang = Convert.ToInt32(lastBill.Tables[0].Rows[0]["IDKhachhang"]);
                    currentReceipt.Ghichu = Convert.ToString(lastBill.Tables[0].Rows[0]["Ghichu"]);

                    currentReceipt.Suco = Convert.ToInt32(lastBill.Tables[0].Rows[0]["Suco"]);
                    currentReceipt.Trangthai = 1;
                    bool res = new DataAccess().updateHoadonxuat(currentReceipt);
                    if (res)
                    {
                        //wait for databa is update

                        //open electric cb
                        // MessageBox.Show("Đóng Phòng " + Convert.ToInt32(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "TenPhong")) +
                        //     " thành công", "Thông báo");
                        iCurrentReceiptID = currentReceipt.IDHoadonXuat;

                        //update Hoadon group display
                        if (updateBillDisplay(iCurrentReceiptID,false))
                        {
                            //update status for this Room
                            Phong updateRoom = new Phong();
                            updateRoom.IDPhong = Convert.ToInt32(ds.Tables[0].Rows[0]["IDPhong"]);
                            updateRoom.IDLoaiPhong = Convert.ToInt32(ds.Tables[0].Rows[0]["IDLoaiPhong"]);
                            updateRoom.TenPhong = Convert.ToString(ds.Tables[0].Rows[0]["TenPhong"]);
                            updateRoom.Ghichu = Convert.ToString(ds.Tables[0].Rows[0]["Ghichu"]);
                            updateRoom.Trangthai = false;
                            bool a = new DataAccess().updatePhong(updateRoom);
                            if (!a)
                            {
                                MessageBox.Show("Không cập nhật được trạng thái cho phòng " + updateRoom.TenPhong, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            //update current status gridview
                            //gridViewRoom.SetFocusedRowCellValue(colRoomStatus, false);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Đóng Phòng " + Convert.ToString(ds.Tables[0].Rows[0]["TenPhong"]) +
                            " không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    //in case of the room is available
                    //ask to open room and create new receipt for this room
                    if (MessageBox.Show("Bạn có muốn mở phòng " + Convert.ToString(ds.Tables[0].Rows[0]["TenPhong"]) + "?", "Thông báo mở phòng", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                        return;
                    //get khuyen mai tang gio cua phong
                    DataSet dsKM = new DataAccess().getKhuyenmaiByIDLoaiPhong(iCurrentRoomGroupID, DateTime.Now.Date);
                    //Hoadonxuat currentReceipt = new Hoadonxuat();
                    try
                    {
                        currentReceipt.Giam = Convert.ToInt32(dsKM.Tables[0].Rows[0]["Giam"]);
                    }
                    catch (Exception ex)
                    {
                        currentReceipt.Giam = 0;
                    }
                    currentReceipt.TenHoadon = Convert.ToString(ds.Tables[0].Rows[0]["TenPhong"]) + " "+DateTime.Now.ToString("dd/MM/yy-hh:mm");
                    currentReceipt.GioBD = DateTime.Now;
                    currentReceipt.GioKT = DateTime.Now;
                    currentReceipt.Tratruoc = 0;
                    currentReceipt.Nhacnho = false;
                    currentReceipt.IDPhong = iCurrentRoomID;
                    currentReceipt.Ngayxuat = DateTime.Now.Date;
                    currentReceipt.Phuthu = 0;
                    currentReceipt.Thue = 0;
                    currentReceipt.Trangthai = 0;
                    currentReceipt.Thue = 0;
                    currentReceipt.Phuthu = 0;
                    currentReceipt.IDNhanvien = 0;
                    currentReceipt.IDNhanvienXuatHD = Program.IDNhanvien;
                    currentReceipt.IDKhachhang = Convert.ToInt32(cboCustomer.SelectedValue);
                    currentReceipt.Ghichu = "";
                    currentReceipt.Suco = 0;
                    //get current hour class
                    TimeSpan ctime = DateTime.Now.TimeOfDay;
                    //TimeSpan stime = new TimeSpan();
                    //TimeSpan etime = new TimeSpan();
                    DataSet hourclass = new DataAccess().getAllKhunggio();
                    int idkhunggio = 0;
                    int i;
                    for (i = 0; i < hourclass.Tables[0].Rows.Count; i++)
                    {
                        string time = Convert.ToString(hourclass.Tables[0].Rows[i]["GioBD"]);
                        int sh = Convert.ToInt32(time.Substring(0, time.IndexOf(":")));
                        int sm = Convert.ToInt32(time.Substring(time.IndexOf(":") + 1));
                        string time1 = Convert.ToString(hourclass.Tables[0].Rows[i]["GioKT"]);
                        int eh = Convert.ToInt32(time1.Substring(0, time.IndexOf(":")));
                        int em = Convert.ToInt32(time1.Substring(time1.IndexOf(":") + 1));
                        if ((ctime.Hours < eh) || ((ctime.Hours == eh) && (ctime.Minutes <= em)))
                        {
                            if ((ctime.Hours > sh) || ((ctime.Hours == sh) && (ctime.Minutes > sm)))
                            {
                                idkhunggio = Convert.ToInt32(hourclass.Tables[0].Rows[i]["IDKhunggio"]);
                                break;
                            }
                        }
                    }
                    //get Room price

                    DataSet ds1 = new DataAccess().getGiaLoaiPhongByIDLoaiPhongAndIDKhunggio(iCurrentRoomGroupID, idkhunggio);
                    if (ds1.Tables[0].Rows.Count > 0)
                        currentReceipt.IDGiaLoaiphong = Convert.ToInt32(ds1.Tables[0].Rows[0]["Gia"]);
                    else
                    {
                        MessageBox.Show("Chưa có bảng giá cho phòng " + Convert.ToString(Convert.ToString(ds.Tables[0].Rows[0]["TenPhong"])) +
                            " vào khung giờ này. Mở phòng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    int res = new DataAccess().insertHoadonxuat(currentReceipt);
                    if (res > -1)
                    {
                        //wait for databa is update
                        ContactAction(0xbf, Convert.ToInt32(ds.Tables[0].Rows[0]["Congtac"]));
                        //open electric cb
                        //MessageBox.Show("Mở Phòng " + Convert.ToInt32(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "TenPhong")) +
                        //    " thành công", "Thông báo");
                        iCurrentReceiptID = res;
                        //add starting product for the room
                        DataSet dsSPBD = new DataAccess().getAllSPBandauIDLoaiPhong(Convert.ToInt32(ds.Tables[0].Rows[0]["IDLoaiPhong"]));
                        for(i = 0; i<dsSPBD.Tables[0].Rows.Count;i++)
                        {
                            int IDSanPham = Convert.ToInt32(dsSPBD.Tables[0].Rows[i]["IDSanPham"]);
                            int IDLoaiSP = Convert.ToInt32(dsSPBD.Tables[0].Rows[i]["IDNhomSP"]);
                            string TenSanPham = Convert.ToString(dsSPBD.Tables[0].Rows[i]["TenSanPham"]);
                            int num = Convert.ToInt32(dsSPBD.Tables[0].Rows[i]["Soluong"]);
                            AddSPBD(res, IDLoaiSP, IDSanPham, TenSanPham, num);
                        }
                        //update status for this Room
                        Phong updateRoom = new Phong();
                        updateRoom.IDPhong = Convert.ToInt32(ds.Tables[0].Rows[0]["IDPhong"]);
                        updateRoom.IDLoaiPhong = Convert.ToInt32(ds.Tables[0].Rows[0]["IDLoaiPhong"]);
                        updateRoom.TenPhong = Convert.ToString(ds.Tables[0].Rows[0]["TenPhong"]);
                        updateRoom.Ghichu = Convert.ToString(ds.Tables[0].Rows[0]["Ghichu"]);
                        updateRoom.Trangthai = true;
                        bool a = new DataAccess().updatePhong(updateRoom);
                        if (!a)
                        {
                            MessageBox.Show("Không cập nhật được trạng thái cho phòng " + updateRoom.TenPhong, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        //update Hoadon group display
                        if (updateBillDisplay(res,false))
                        {
                            
                            //update current status gridview
                            //gridViewRoom.SetFocusedRowCellValue(colRoomStatus, true);
                        }
                        //btnStart.Image = Karaoke.Properties.Resources.Status_user_busy_icon1;
                    }
                    else
                    {
                        MessageBox.Show("Mở Phòng " + Convert.ToString(ds.Tables[0].Rows[0]["TenPhong"]) +
                            " không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }
        private void AddSPBD(int IDReceipt, int IDLoaiSP,int IDSanPham, string TenSP,int num)
        {
            //add a quantity of a product to current bill
            //check if the parameters are legal
            
                //DataSet prdPrice = new DataAccess().getGiaXuatSPByIDSanPham(ID);
                //if ((prdPrice != null) && (prdPrice.Tables[0].Rows.Count > 0))
                //{
                //txtPrice.Text = prdPrice.Tables[0].Rows[0][1].ToString();
                if (IDReceipt >= 0)
                {
                    
                    
                    DataSet dsGia = new DataAccess().getGiaXuatSPByIDSanPham(IDSanPham);
                    //if (ds == null)
                    //    return;
                    //if (ds.Tables[0].Rows.Count == 0)
                    //{
                    ChitietHDXuat obj = new ChitietHDXuat();
                    obj.IDHoadonXuat = IDReceipt;
                    obj.IDSanpham = IDSanPham;
                    try{
                        obj.Gia = Convert.ToInt32(dsGia.Tables[0].Rows[0]["Gia"]);
                    }
                    catch
                    {
                        MessageBox.Show("Chưa có giá cho " + TenSP, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    obj.Soluong = num;
                    //get khuyen mai with this product ID
                    DataSet ds = new DataAccess().getKhuyenmaiByIDLoaiSP(IDLoaiSP, DateTime.Now.Date);
                    if (ds != null)
                    {
                        try
                        {
                            obj.Giam = Convert.ToInt32(ds.Tables[0].Rows[0]["Giam"]);
                        }
                        catch (Exception ex)
                        {
                            obj.Giam = 0;
                        }
                    }
                    else
                        obj.Giam = 0;
                    obj.Trangthai = true;
                    obj.Ghichu = "Sản phẩm mặc định";
                    int res = new DataAccess().insertChitietHDXuat(obj);
                    if (res < 0)
                    {
                        MessageBox.Show("Không thêm sản phẩm " + TenSP + " vào hóa đơn hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                                    

                }
        }
        #endregion Room

        #region localfunction
        private void OpenListRoom()
        {
            frmListRoom listRoom = new frmListRoom();
            listRoom.ShowDialog();
            if (listRoom.getEffectedRoomID() >= 0)
            {
                iCurrentRoomID = listRoom.getEffectedRoomID();
                cboRoom.SelectedValue = iCurrentRoomID;
            }
            listRoom.Close();
            displayLastRoomReceipt();
        }
        private int getTotalValueOfBill(int IDHoadon)
        {
            //this function will get all infomation about the receipt by its ID
            //txtBilltotal.Text = "0";
            //txtHourMoney.Text = "0";
            //txtProductMoney.Text = "0";
            //get Bill infomation
            if (IDHoadon < 0)
            {
                return -1;
            }
            //iCurrentReceiptID = IDHoadon;
            int timeout = 0;
            DataSet dsBill = new DataAccess().getHoadonxuatByIDHoadonXuat(IDHoadon);
            for (timeout = 0; timeout < 20; timeout++)
            {
                if (dsBill.Tables[0].Rows.Count <= 0)
                {
                    System.Threading.Thread.Sleep(500);
                    dsBill = new DataAccess().getLastHoadonxuatByIDPhong(IDHoadon);
                }
                else
                    break;
            }
            if (timeout >= 9)
            {
                //MessageBox.Show("Không có Hóa đơn mã số " + IDHoadon.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            //get room price
            
            int price = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDGiaLoaiphong"]);
            //get room 
            DataSet dsRoom = new DataAccess().getPhongByIDPhong(Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDPhong"]));
            if (dsRoom.Tables[0].Rows.Count <= 0)
            {
                //MessageBox.Show("Không có giá niêm iết cho hóa đơn mã số " + IDHoadon.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            //check the status of this Bill
            // 0 : is open //1: is close //2: could not modify
            int status = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Trangthai"]);
            //get current Bill

            int giam = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Giam"]);
            int thue = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Thue"]);
            int phuthu = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Phuthu"]);
            int tratruoc = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Tratruoc"]);
            bool nhacnho = Convert.ToBoolean(dsBill.Tables[0].Rows[0]["Nhacnho"]);
            int roomMoney = 0;
            if (status == 0)
            {
                //new bill


                TimeSpan ts = (Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioKT"])).Subtract(Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]));
                int playmin = ts.Hours * 60 + ts.Minutes;
                roomMoney = (price * playmin * (100 - giam) / 6000);
                txtTotalHour.Text = ts.Hours.ToString("#0") + "g" + ts.Minutes.ToString("#0") + "p";
            }
            else
            {
                //old bill

                TimeSpan ts = Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioKT"]).Subtract(Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]));
                int playmin = ts.Hours * 60 + ts.Minutes;
                roomMoney = playmin * ((price * (100 - giam)) / 6000);
                txtTotalHour.Text = ts.Hours.ToString("#0") + "g" + ts.Minutes.ToString("#0") + "p";
            }
            txtHourMoney.Text = roomMoney.ToString();
            
            //get all product with this bill
            DataSet dsBillProduct = new DataAccess().getChitietHDXuatByID(IDHoadon);
            gridBillProduct.DataSource = dsBillProduct.Tables[0];
            //calculate money
            int productMoney = 0;
            int i;
            for (i = 0; i < dsBillProduct.Tables[0].Rows.Count; i++)
                productMoney = productMoney + Convert.ToInt32(dsBillProduct.Tables[0].Rows[i]["Thanhtien"]);
            txtProductMoney.Text = productMoney.ToString("###,###,###,##0");
            int totalBill = 0;
            totalBill = roomMoney + productMoney + Convert.ToInt32(phuthu - giam);
            totalBill = Convert.ToInt32(totalBill + totalBill * thue / 100);

            return totalBill;
        }
        private bool updateBillDisplay(int IDHoadon, bool timeupdate)
        {
            // Thien code
            DataSet dsCheckOpenedOrClosed = new DataAccess().getPhongByIDPhong(iCurrentRoomID);
            if (dsCheckOpenedOrClosed.Tables[0].Rows.Count > 0)
            {
                iCurrentRoomGroupID = Convert.ToInt32(dsCheckOpenedOrClosed.Tables[0].Rows[0]["IDLoaiphong"]);
                if (Convert.ToBoolean(dsCheckOpenedOrClosed.Tables[0].Rows[0]["Trangthai"]) == false)
                {
                    // room is closed --> not display...
                    gridBillProduct.DataSource = null;

                    lbStatus.Text = "Chưa có hóa đơn nào với phòng này";
                    checkBox1.Enabled = false;
                    cboEmployee.SelectedValue = 0;
                    txtBilltotal.Text = "0";
                    txtHourMoney.Text = "0";
                    txtProductMoney.Text = "0";
                    numExtra.Value = 0;
                    numTax.Value = 0;
                    txtReduce.Text = "0";
                    checkBox1.Checked = false;
                    numDeposit.Value = 0;
                    txtReturnMoney.Text = "0";
                    gridBillProduct.DataSource = null;
                    txtReturnMoney.Text = "0";
                    lbGioMP.Text = "00:00";
                    checkBox1.Enabled = false;
                    timeDeposit.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                            DateTime.Now.Day, 0, 0, 0);
                    timeDeposit.Enabled = false;

                    return true;
                }
            }
            // end Thien code
            //this function will get all infomation about the receipt by its ID
            //txtBilltotal.Text = "0";
            //txtHourMoney.Text = "0";
            //txtProductMoney.Text = "0";
            //get Bill infomation
            if (IDHoadon < 0)
            {
                lbStatus.Text = "Chưa có hóa đơn nào với phòng này";
                checkBox1.Enabled = false;
                cboEmployee.SelectedValue = 0;
                txtBilltotal.Text = "0";
                txtHourMoney.Text = "0";
                txtProductMoney.Text = "0";
                numExtra.Value = 0;
                numTax.Value = 0;
                txtReduce.Text = "0";
                checkBox1.Checked = false;
                numDeposit.Value = 0;
                txtReturnMoney.Text = "0";
                gridBillProduct.DataSource = null;
                txtReturnMoney.Text = "0";
                lbGioMP.Text = "00:00";
                checkBox1.Enabled = false;
                timeDeposit.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                        DateTime.Now.Day, 0, 0, 0);
                timeDeposit.Enabled = false;
                return false;
            }
            iCurrentReceiptID = IDHoadon;
            int timeout = 0;
            DataSet dsBill = new DataAccess().getHoadonxuatByIDHoadonXuat(IDHoadon);
            for (timeout = 0; timeout < 20; timeout++)
            {
                if (dsBill.Tables[0].Rows.Count <= 0)
                {
                    System.Threading.Thread.Sleep(500);
                    dsBill = new DataAccess().getLastHoadonxuatByIDPhong(IDHoadon);
                }
                else
                    break;
            }
            if (timeout >= 9)
            {
                MessageBox.Show("Không có Hóa đơn mã số " + IDHoadon.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //get room price
            //DataSet dsPrice = new DataAccess().getGiaLoaiPhongByIDGiaLoaiPhong(Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDGiaLoaiphong"]));
            //if (dsPrice.Tables[0].Rows.Count <= 0)
            //{
                //MessageBox.Show("Không có giá niêm iết cho hóa đơn mã số " + IDHoadon.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //get room 
            DataSet dsRoom = new DataAccess().getPhongByIDPhong(Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDPhong"]));
            if (dsRoom.Tables[0].Rows.Count <= 0)
            {
                //MessageBox.Show("Không có giá niêm iết cho hóa đơn mã số " + IDHoadon.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //check the status of this Bill
            // 0 : is open //1: is close //2: could not modify
            int status = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Trangthai"]);
            //get current Bill
            currentReceipt.IDNhanvien = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDNhanvien"]);
            currentReceipt.IDPhong = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDPhong"]);
            currentReceipt.Giam = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Giam"]);
            currentReceipt.Thue = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Thue"]);
            currentReceipt.Phuthu = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Phuthu"]);
            currentReceipt.IDGiaLoaiphong = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDGiaLoaiphong"]);
            currentReceipt.Ngayxuat = Convert.ToDateTime(dsBill.Tables[0].Rows[0]["Ngayxuat"]);
            currentReceipt.GioBD = Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]);
            currentReceipt.GioKT = Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioKT"]);
            currentReceipt.Tratruoc = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Tratruoc"]);
            currentReceipt.Ghichu = Convert.ToString(dsBill.Tables[0].Rows[0]["Ghichu"]);
            currentReceipt.Trangthai = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Trangthai"]);
            currentReceipt.IDHoadonXuat = IDHoadon;
            currentReceipt.IDNhanvien = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDNhanvien"]);
            currentReceipt.IDNhanvienXuatHD = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDNhanvienXuatHD"]);
            currentReceipt.Nhacnho = Convert.ToBoolean(dsBill.Tables[0].Rows[0]["Nhacnho"]);
            currentReceipt.IDKhachhang = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDKhachhang"]);
            dateReceipt.Value = Convert.ToDateTime(dsBill.Tables[0].Rows[0]["Ngayxuat"]);
            int roomMoney = 0;
            if (status == 0)
            {
                //new bill
                checkBox1.Enabled = true;
                cboEmployee.SelectedValue = currentReceipt.IDNhanvien;
                cboCustomer.SelectedValue = currentReceipt.IDKhachhang;
                cboRoom.SelectedValue = currentReceipt.IDPhong;
                txtReduce.Text = currentReceipt.Giam.ToString();
                numTax.Value = currentReceipt.Thue;
                numExtra.Value = currentReceipt.Phuthu;
                //txtRoom.Text = Convert.ToString(dsRoom.Tables[0].Rows[0]["TenPhong"]);
                txtRoomPrice.Text = currentReceipt.IDGiaLoaiphong.ToString("###,###,###");
                numDeposit.Value = currentReceipt.Tratruoc;
                checkBox1.Checked = currentReceipt.Nhacnho;
                if (currentReceipt.Nhacnho)
                {
                    timeDeposit.Enabled = true;
                    isTimedepositChange = false;
                    timeDeposit.Value = currentReceipt.GioKT;
                }
                else
                {
                    timeDeposit.Enabled = false;

                    isTimedepositChange = false;
                    timeDeposit.Value = DateTime.Now;
                }
                string strtime = "Ngày " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["Ngayxuat"]).ToShortDateString();
                strtime = strtime + " - Bắt đầu lúc " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]).ToShortTimeString();
                lbStatus.Text = strtime;
                lbGioMP.Text = currentReceipt.GioBD.ToString("hh:mm");
                TimeSpan ts = currentReceipt.GioKT.Subtract(Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]));
                int playmin = ts.Hours * 60 + ts.Minutes;
                roomMoney = playmin * (currentReceipt.IDGiaLoaiphong * (100 - Convert.ToInt32(dsBill.Tables[0].Rows[0]["Giam"])) / 6000);
                txtHourMoney.Text = roomMoney.ToString("###,###,###,##0");
                txtTotalHour.Text = ts.Hours.ToString("00") + "g" + ts.Minutes.ToString("00") + "p";
            }/*
            else
            {
                //old bill

                cboEmployee.SelectedValue = currentReceipt.IDNhanvien;
                cboCustomer.SelectedValue = currentReceipt.IDKhachhang;
                txtReduce.Text = currentReceipt.Giam.ToString();
                numTax.Value = currentReceipt.Thue;
                numExtra.Value = currentReceipt.Phuthu;
                //txtRoom.Text = Convert.ToString(dsRoom.Tables[0].Rows[0]["TenPhong"]);
                txtRoomPrice.Text = Convert.ToString(dsPrice.Tables[0].Rows[0]["Gia"]);
                numDeposit.Value = currentReceipt.Tratruoc;
                checkBox1.Checked = currentReceipt.Nhacnho;
                timeDeposit.Value = currentReceipt.GioKT;
                timeDeposit.Enabled = false;
                string strtime = "Ngày " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["Ngayxuat"]).ToShortDateString();
                strtime = strtime + " - Bắt đầu: " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]).ToShortTimeString();
                strtime = strtime + " - Kết thúc: " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioKT"]).ToShortTimeString();
                lbStatus.Text = strtime;
                lbGioMP.Text = currentReceipt.GioBD.ToString("hh:mm");
                TimeSpan ts = currentReceipt.GioKT.Subtract(Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]));
                int playmin = ts.Hours * 60 + ts.Minutes;
                roomMoney = playmin * (Convert.ToInt32(txtRoomPrice.Text) * (100 - Convert.ToInt32(dsBill.Tables[0].Rows[0]["Giam"])) / 6000);
                txtHourMoney.Text = roomMoney.ToString("###,###,###,##0");
                txtTotalHour.Text = ts.Hours.ToString() + "g" + ts.Minutes.ToString() + "p";
                checkBox1.Enabled = false;

            }*/
            //get all product with this bill
            DataSet dsBillProduct = new DataAccess().getChitietHDXuatByID(IDHoadon);
            gridBillProduct.DataSource = dsBillProduct.Tables[0];
            //calculate money
            int productMoney = 0;
            int i;
            for (i = 0; i < dsBillProduct.Tables[0].Rows.Count; i++)
                productMoney = productMoney + Convert.ToInt32(dsBillProduct.Tables[0].Rows[i]["Thanhtien"]);
            txtProductMoney.Text = productMoney.ToString("###,###,###,##0");
            int totalBill = 0;
            totalBill = roomMoney + productMoney + Convert.ToInt32(numExtra.Value);
            totalBill = Convert.ToInt32(totalBill + totalBill * numTax.Value / 100);
            txtBilltotal.Text = totalBill.ToString("###,###,###,##0");
            txtReturnMoney.Text = (totalBill - Convert.ToInt32(dsBill.Tables[0].Rows[0]["Tratruoc"])).ToString("###,###,##0");
            return true;
        }
        private void displayLastRoomReceipt()
        {
            if (iCurrentRoomID >= 0)
            {
                
                DataSet ds;
                //iCurrentRoomID = Convert.ToInt32(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "IDPhong"));

                // Thien code 
                DataSet dsCheckOpenedOrClosed = new DataAccess().getPhongByIDPhong(iCurrentRoomID);
                if (dsCheckOpenedOrClosed.Tables[0].Rows.Count > 0)
                {
                    iCurrentRoomGroupID = Convert.ToInt32(dsCheckOpenedOrClosed.Tables[0].Rows[0]["IDLoaiphong"]);
                    if (Convert.ToBoolean(dsCheckOpenedOrClosed.Tables[0].Rows[0]["Trangthai"]) == false)
                    {
                        // room is closed --> not display...
                        gridBillProduct.DataSource = null;

                        lbStatus.Text = "Phòng đang rãnh";
                        checkBox1.Enabled = false;
                        cboEmployee.SelectedValue = 0;
                        txtBilltotal.Text = "0";
                        txtHourMoney.Text = "0";
                        txtProductMoney.Text = "0";
                        numExtra.Value = 0;
                        numTax.Value = 0;
                        txtReduce.Text = "0";
                        checkBox1.Checked = false;
                        numDeposit.Value = 0;
                        txtReturnMoney.Text = "0";
                        gridBillProduct.DataSource = null;
                        txtReturnMoney.Text = "0";
                        lbGioMP.Text = "00:00";
                        checkBox1.Enabled = false;
                        timeDeposit.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month,
                                DateTime.Now.Day, 0, 0, 0);
                        timeDeposit.Enabled = false;

                        return;
                    }
                    else
                    {
                        ds = new DataAccess().getLastHoadonxuatByIDPhong(iCurrentRoomID);
                        if (ds == null)
                        {
                            MessageBox.Show("Lỗi Cơ sở dữ liệu!", "Lỗi");
                            return;
                        }
                        if (ds.Tables[0].Rows.Count > 0)
                            iCurrentReceiptID = Convert.ToInt32(ds.Tables[0].Rows[0]["IDHoadonXuat"]);
                        else
                            iCurrentReceiptID = -1;

                        //iReceiptIndex = 0;
                        updateBillDisplay(iCurrentReceiptID, false);
                    }
                }
                // end Thien code

                //get the last bill associate with the room
                //check if the date picker id check
                
                
            }
        }
        private void displayFirstRoomReceipt()
        {
            if (iCurrentRoomID >= 0)
            {
                DataSet ds;
                //iCurrentRoomID = Convert.ToInt32(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "IDPhong"));
                //get the last bill associate with the room
                //check if the date picker id check
                if (checkDateReceipt.Checked == false)
                    ds = new DataAccess().getLastHoadonxuatByIDPhong(iCurrentRoomID);
                else
                    ds = new DataAccess().getLastHoadonxuatByIDPhongAndDate(iCurrentRoomID, dateReceipt.Value.Date);
                if (ds == null)
                {
                    MessageBox.Show("Lỗi Cơ sở dữ liệu!", "Lỗi");
                    return;
                }
                if (ds.Tables[0].Rows.Count > 0)
                    iCurrentReceiptID = Convert.ToInt32(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["IDHoadonXuat"]);
                else
                    iCurrentReceiptID = -1;
                /*
                if (Convert.ToBoolean(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "Trangthai")) == true)
                {
                    //in case of the room has been openned
                    btnStart.Image = Karaoke.Properties.Resources.Status_user_busy_icon1;

                }
                else
                {
                    //in case of the room is available
                    btnStart.Image = Karaoke.Properties.Resources._1325149282_button_ok;
                }*/
                iReceiptIndex = ds.Tables[0].Rows.Count - 1;
                updateBillDisplay(iCurrentReceiptID,false);
            }
        }
        /// <summary>
        /// if current room is opened --> display
        /// if not --> display nothing
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private bool displayCurrentRoomReceipt(int index)
        {
            if (iCurrentRoomID >= 0)
            {
                DataSet ds;
                //iCurrentRoomID = Convert.ToInt32(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "IDPhong"));
                //get the last bill associate with the room
                //check if the date picker id check
                if (checkDateReceipt.Checked == false)
                    ds = new DataAccess().getLastHoadonxuatByIDPhong(iCurrentRoomID);
                else
                    ds = new DataAccess().getLastHoadonxuatByIDPhongAndDate(iCurrentRoomID, dateReceipt.Value.Date);
                if (ds == null)
                {
                    MessageBox.Show("Lỗi Cơ sở dữ liệu!", "Lỗi");
                    return false;
                }
                if (ds.Tables[0].Rows.Count > index)
                {
                    iCurrentReceiptID = Convert.ToInt32(ds.Tables[0].Rows[index]["IDHoadonXuat"]);
                    /*
                    if (Convert.ToBoolean(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "Trangthai")) == true)
                    {
                        //in case of the room has been openned
                        btnStart.Image = Karaoke.Properties.Resources.Status_user_busy_icon1;

                    }
                    else
                    {
                        //in case of the room is available
                        btnStart.Image = Karaoke.Properties.Resources._1325149282_button_ok;
                    }*/
                    updateBillDisplay(iCurrentReceiptID,false);
                    return true;
                }
            }
            return false;
        }
        bool updateReceiptSuco(int IDHoaDon)
        {
            DataSet dsBill = new DataAccess().getHoadonxuatByIDHoadonXuat(IDHoaDon);
            if (dsBill == null)
                return false;
            if (dsBill.Tables[0].Rows.Count <= 0)
                return false;
            Hoadonxuat tmpReceipt = new Hoadonxuat();
            tmpReceipt.Suco = 1;
            tmpReceipt.IDNhanvien = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDNhanvien"]);
            tmpReceipt.IDPhong = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDPhong"]);
            tmpReceipt.Giam = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Giam"]);
            tmpReceipt.Thue = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Thue"]);
            tmpReceipt.Phuthu = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Phuthu"]);
            tmpReceipt.IDGiaLoaiphong = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDGiaLoaiphong"]);
            tmpReceipt.Ngayxuat = Convert.ToDateTime(dsBill.Tables[0].Rows[0]["Ngayxuat"]);
            tmpReceipt.GioBD = Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]);
            tmpReceipt.GioKT = Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioKT"]);
            tmpReceipt.Tratruoc = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Tratruoc"]);
            tmpReceipt.Ghichu = Convert.ToString(dsBill.Tables[0].Rows[0]["Ghichu"]);
            tmpReceipt.Trangthai = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Trangthai"]);
            tmpReceipt.IDHoadonXuat = IDHoaDon;
            tmpReceipt.IDNhanvienXuatHD = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDNhanvienXuatHD"]);
            tmpReceipt.IDNhanvien = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDNhanvien"]);
            tmpReceipt.Nhacnho = Convert.ToBoolean(dsBill.Tables[0].Rows[0]["Nhacnho"]);
            tmpReceipt.IDKhachhang = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDKhachhang"]);
            if (new DataAccess().updateHoadonxuat(tmpReceipt))
                return true;
            return false;
        }
        #endregion

        #region ComPort
        private SerialPort comport = new SerialPort();
        //COM receive buffer
        byte[] rx_buffer = new byte[1024];
        int rx_write, rx_read, rx_counter;
        private void InitCOMPort()
        {

            comport.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            rx_write = 0;
            rx_read = 0;
            rx_counter = 0;
            OpenComPort();
        }
        private bool OpenComPort()
        {
            bool error = false;
            //MessageBox.Show("Thiết bị đã kết nối thành công!");
            //((MDIForms.frmMainContent)(this.ParentForm)).reloadControls("ConfigurationCOMPortCompleted");
            if (comport.IsOpen)
            {
                try
                {
                    comport.Close();
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(this, "Could not open the COM port.  Most likely it is already in use, has been removed, or is unavailable.", "COM Port Unavalible", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }

            }

            // Set the port's settings
            StreamReader reader = null;
            string strCOM = "COM3";
            string strBaudrate = "0";
            string strDataBits = "0";
            string strStopBits = "0";
            string strParity = "0";
            try
            {
                reader = new StreamReader("COMConfig.txt");
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    int indexEqual = line.IndexOf('=');
                    string title = line.Substring(0, indexEqual);
                    string data = line.Substring(indexEqual + 1, line.Length - indexEqual - 1);
                    switch (title)
                    {
                        case "[COMPORT]":
                            strCOM = Convert.ToString(data);
                            break;
                        case "[BAUDRATE]":
                            strBaudrate = Convert.ToString(data);
                            break;
                        case "[STOPBITS]":
                            strStopBits = Convert.ToString(data);
                            break;
                        case "[PARITY]":
                            strParity = Convert.ToString(data);
                            break;
                        case "[DATABITS]":
                            strDataBits = Convert.ToString(data);
                            break;
                        default:
                            break;
                    }
                }
                reader.Close();
            }
            catch
            {
                MessageBox.Show("Thông tin trong file COMConfig.txt chưa đúng!. \nVui lòng cập nhật lại thông tin của file này!");

            }
            comport.BaudRate = Convert.ToInt32(strBaudrate);//9600 or 38400
            comport.DataBits = Convert.ToInt32(strDataBits);
            int StopBits = Convert.ToInt32(strStopBits);
            int intParity = Convert.ToInt32(strParity);
            if (StopBits == 1)
                comport.StopBits = System.IO.Ports.StopBits.One;
            else if (StopBits == 2)
                comport.StopBits = System.IO.Ports.StopBits.Two;
            else if (StopBits == 3)
                comport.StopBits = System.IO.Ports.StopBits.OnePointFive;
            else
                comport.StopBits = System.IO.Ports.StopBits.None;
            if (intParity == 0)
                comport.Parity = System.IO.Ports.Parity.None;
            else if (intParity == 1)
                comport.Parity = System.IO.Ports.Parity.Odd;
            else if (intParity == 2)
                comport.Parity = System.IO.Ports.Parity.Even;
            else if (intParity == 3)
                comport.Parity = System.IO.Ports.Parity.Mark;
            else if (intParity == 4)
                comport.Parity = System.IO.Ports.Parity.Space;
            else
                comport.Parity = System.IO.Ports.Parity.None;
            comport.PortName = strCOM;
            try
            {
                comport.Open();

            }
            catch (UnauthorizedAccessException) { error = true; }
            catch (IOException) { error = true; }
            catch (ArgumentException) { error = true; }

            if (error)
            {
                MessageBox.Show(this, "Kết nối không thành công", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                MessageBox.Show("Thiết bị đã kết nối thành công!");
            }
            return true;
        }
        private void CloseComPort()
        {
            //MessageBox.Show("Thiết bị đã kết nối thành công!");
            //((MDIForms.frmMainContent)(this.ParentForm)).reloadControls("ConfigurationCOMPortCompleted");
            if (comport.IsOpen)
            {
                try
                {
                    comport.Close();
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(this, "Không đóng kết nối được", "Lỗi Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
        }
        /// <summary> Convert a string of hex digits (ex: E4 CA B2) to a byte array. </summary>
        /// <param name="s"> The string containing the hex digits (with or without spaces). </param>
        /// <returns> Returns an array of bytes. </returns>
        private byte[] HexStringToByteArray(string s)
        {
            s = s.Replace(" ", "");
            byte[] buffer = new byte[s.Length / 2];
            for (int i = 0; i < s.Length; i += 2)
                buffer[i / 2] = (byte)Convert.ToByte(s.Substring(i, 2), 16);
            return buffer;
        }

        /// <summary> Converts an array of bytes into a formatted string of hex digits (ex: E4 CA B2)</summary>
        /// <param name="data"> The array of bytes to be translated into a string of hex digits. </param>
        /// <returns> Returns a well formatted string of hex digits with spacing. </returns>
        private string ByteArrayToHexString(byte[] data)
        {
            StringBuilder sb = new StringBuilder(data.Length * 3);
            foreach (byte b in data)
                sb.Append(Convert.ToString(b, 16).PadLeft(2, '0').PadRight(3, ' '));
            return sb.ToString().ToUpper();
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // If the com port has been closed, do nothing
            if (!comport.IsOpen) return;

            // This method will be called when there is data waiting in the port's buffer

            // Determain which mode (string or binary) the user is in
            // Obtain the number of bytes waiting in the port's buffer
            int bytes = comport.BytesToRead;

            // Create a byte array buffer to hold the incoming data
            byte[] buffer = new byte[bytes];

            // Read the data from the port and store it in our buffer
            comport.Read(buffer, 0, bytes);
            // write to rx buffer
            int i;
            for (i = 0; i < bytes; i++)
            {
                rx_buffer[rx_write++] = buffer[i];
                rx_write = (rx_write == 1024) ? 0 : rx_write;
            }
            rx_counter += bytes;

        }
        private byte[] receiveData(int length)
        {
            if (length <= rx_counter)
            {
                byte[] rx = new byte[length];
                int i;
                for (i = 0; i < length; i++)
                {
                    rx[i] = rx_buffer[rx_read++];
                    rx_read = (rx_read == 1024) ? 0 : rx_read;
                }
                rx_counter -= length;
                return rx;
            }
            return null;
        }
        private bool ContactAction(int action, int cb)
        {
            byte[] command = new byte[3];
            if (comport.IsOpen == false)
            {
                //MessageBox.Show("Cổng kết nối chưa sẳn sàng");
                if (OpenComPort() == false) return false;
            }

            command[0] = 0xFC;
            //2 byte sender address
            command[1] = (byte)cb;
            command[2] = (byte)action;
            rx_counter = 0;
            rx_read = 0;
            rx_write = 0;
            bool error = false;
            try
            {
                comport.Write(command, 0, 3);

            }
            catch (UnauthorizedAccessException) { error = true; }
            catch (IOException) { error = true; }
            catch (ArgumentException) { error = true; }
            if (error == true)
            {
                //MessageBox.Show("Kết nối bị lỗi");
                return false;
            }
            return true;
        }
        #endregion ComPort
        #region MiscEvent
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (iCurrentReceiptID < 0)
            {
                checkBox1.Checked = false;
                timeDeposit.Enabled = false;
                return;
            }
            if (currentReceipt.Trangthai > 0)
                return;
            if (checkBox1.Checked)
            {
                if (!currentReceipt.Nhacnho)
                {
                    timeDeposit.Enabled = true;
                    timeDeposit.Value = DateTime.Now;
                    currentReceipt.GioKT = timeDeposit.Value;
                    //get the last opening receipt of this room
                    currentReceipt.Nhacnho = checkBox1.Checked;
                    if (new DataAccess().updateHoadonxuat(currentReceipt) == false)
                    {
                        MessageBox.Show("Lỗi cơ sở dữ liệu!", "Lỗi");
                        checkBox1.Checked = false;
                    }
                }
            }
            else
            {
                if (currentReceipt.Nhacnho)
                {
                    timeDeposit.Enabled = false;
                    timeDeposit.Value = DateTime.Now;
                    currentReceipt.GioKT = timeDeposit.Value;
                    //get the last opening receipt of this room
                    currentReceipt.Nhacnho = checkBox1.Checked;
                    if (new DataAccess().updateHoadonxuat(currentReceipt) == false)
                    {
                        MessageBox.Show("Lỗi cơ sở dữ liệu!", "Lỗi");
                        checkBox1.Checked = false;
                    }
                }
            }

            //get the last opening receipt of this room
            currentReceipt.Nhacnho = checkBox1.Checked;
            if (new DataAccess().updateHoadonxuat(currentReceipt) == false)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu!", "Lỗi");
                checkBox1.Checked = false;
            }

        }

        private void numDeposit_ValueChanged(object sender, EventArgs e)
        {
            if (iCurrentReceiptID < 0)
            {

                return;
            }
            //get the last opening receipt of this room
            currentReceipt.Tratruoc = Convert.ToInt32(numDeposit.Value);
            if (new DataAccess().updateHoadonxuat(currentReceipt) == false)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu!", "Lỗi");
                return;
            }
        }

        private void timeDeposit_ValueChanged(object sender, EventArgs e)
        {
            
            if (iCurrentReceiptID < 0)
            {
                isTimedepositChange = true;
                return;
            }
            if (currentReceipt.Trangthai > 0)
            {
                isTimedepositChange = true;
                return;
            }
            //isTimedepositChange = false;
            if (isTimedepositChange)
            {
                if (timeDeposit.Value < DateTime.Now)
                    timeDeposit.Value = DateTime.Now;
            }
            isTimedepositChange = true;
            currentReceipt.GioKT = timeDeposit.Value;
            if (new DataAccess().updateHoadonxuat(currentReceipt) == false)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu!", "Lỗi");
            }
            else
            {
                TimeSpan ts = currentReceipt.GioKT.Subtract(currentReceipt.GioBD);
                int playmin = ts.Hours * 60 + ts.Minutes;
                int roomMoney = playmin * (currentReceipt.IDGiaLoaiphong * (100 - currentReceipt.Giam) / 6000); 
                txtHourMoney.Text = roomMoney.ToString("###,###,###,##0");
                txtTotalHour.Text = ts.Hours.ToString("00") + "g" + ts.Minutes.ToString("00") + "p";
                int totalBill = 0;
                
                totalBill = roomMoney + Convert.ToInt32(txtProductMoney.Text.Replace(",","")) + Convert.ToInt32(numExtra.Value + numExtra.Value);
                totalBill = Convert.ToInt32(totalBill + totalBill * numTax.Value / 100);
                txtBilltotal.Text = totalBill.ToString("###,###,###,##0");
                txtReturnMoney.Text = (totalBill - Convert.ToInt32(numDeposit.Value)).ToString("###,###,##0");
            }
        }

        private void btnIssueProcessing_Click(object sender, EventArgs e)
        {
            frmGhiChuXuLy objGhiChuXuly = new frmGhiChuXuLy();
            objGhiChuXuly.ShowDialog();
        }
        private void xtraTabControl1_Click(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                if (groupControlSanPham.Visible == false)
                {

                    groupControlSanPham.Visible = true;

                    groupControlSanPham.Width = 300;
                    groupControlRoomAndProduct.Width += 300;
                    //if (groupControlDanhSachPhong.Visible == true)
                    //{
                    //    groupControlSanPham.Location = new Point(xtraTabControl1.Width + groupControlDanhSachPhong.Width, xtraTabControl1.Location.Y);
                    //}
                    //else
                    //{
                    groupControlSanPham.Location = new Point(xtraTabControl1.Width, xtraTabControl1.Location.Y);
                    //}

                    groupControlSanPham.Height = groupControlRoomAndProduct.Height - 5;
                    txtSearchSanPham.Focus();
                }
                else
                {
                    groupControlSanPham.Visible = false;

                    groupControlRoomAndProduct.Width -= 300;

                }

            }
            else if (xtraTabControl1.SelectedTabPageIndex == 0) //Room
            {
                OpenListRoom();

            }
            else
            {
                // do nothing
                // dong tat danh sach phong va san pham
                groupControlSanPham.Visible = false;
                groupControlRoomAndProduct.Width = 52;
            }
            redrawGroupControlRoomAndProduct();
        }

        private void txtSearchSanPham_EditValueChanged(object sender, EventArgs e)
        {
            // search
            getAllSPBySearchTenTemplate();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtSearchSanPham.Text = "";
            //getAllSPBySearchTenTemplate();
        }

        private void bntOpenCloseRoom_Click(object sender, EventArgs e)
        {
            Start(0);
        }
        #endregion
        #region HOT_KEY
        private void frmReceipt_KeyDown(object sender, KeyEventArgs e)
        {
            //MessageBox.Show("KeyDown");
            if (e.KeyCode == Keys.F1)   // print kitchen
            {
                btnPrintCooking_Click(null, null);
            }
            else if (e.KeyCode == Keys.F3) // choose room by code
            {
                OpenListRoom();
                /*
                if (groupControlDanhSachPhong.Visible == false)
                {
                    groupControlDanhSachPhong.Visible = true;

                    groupControlDanhSachPhong.Width = 250;
                    groupControlRoomAndProduct.Width = 250 + 52;
                    groupControlDanhSachPhong.Location = new Point(xtraTabControl1.Width, xtraTabControl1.Location.Y);
                    groupControlDanhSachPhong.Height = groupControlRoomAndProduct.Height - 5;
                    if (groupControlSanPham.Visible == true)
                    {
                        groupControlRoomAndProduct.Width += 300;
                        groupControlSanPham.Width = 300;
                        groupControlSanPham.Location = new Point(xtraTabControl1.Width + groupControlDanhSachPhong.Width, xtraTabControl1.Location.Y);

                    }
                }
                else
                {
                    groupControlDanhSachPhong.Visible = false;
                    groupControlRoomAndProduct.Width = 52;
                    if (groupControlSanPham.Visible == true)
                    {
                        groupControlRoomAndProduct.Width += 300;
                        groupControlSanPham.Width = 300;
                        groupControlSanPham.Location = new Point(xtraTabControl1.Width, xtraTabControl1.Location.Y);

                    }
                } 
                 */
            }
            else if (e.KeyCode == Keys.F4) // choose san pham by code
            {
                if (groupControlSanPham.Visible == false)
                {
                    
                    groupControlSanPham.Visible = true;

                    groupControlSanPham.Width = 300;
                    groupControlRoomAndProduct.Width += 300;
                    
                        groupControlSanPham.Location = new Point(xtraTabControl1.Width, xtraTabControl1.Location.Y);

                    groupControlSanPham.Height = groupControlRoomAndProduct.Height - 5;
                    txtSearchSanPham.Focus();
                }
                else
                {
                    groupControlSanPham.Visible = false;
                    
                    groupControlRoomAndProduct.Width -= 300;
                               
                }
            }
            else if (e.KeyCode == Keys.F5) 
            {
                // do nothing
                // dong tat danh sach phong va san pham
                //groupControlDanhSachPhong.Visible = false;
                groupControlSanPham.Visible = false;
                groupControlRoomAndProduct.Width = 52;
            }
            else if (e.KeyCode == Keys.F10) // dong phong
            {

            }
            else if (e.KeyCode == Keys.F11)// in phieu tinh tien
            {

            }
            else if (e.KeyCode == Keys.F12) // xac nhan thu tien
            {

            }
            redrawGroupControlRoomAndProduct();
        }

        private void redrawGroupControlRoomAndProduct()
        {            
            if (groupControlRoomAndProduct.Width <=52)
            {
                groupControlRoomAndProduct.Width = 52;
            }
        }
        
        #endregion HOT_KEY

        

      
    }
    public class CBReq
    {
        private int cbNo;
        private int elapstime;
        public  CBReq(int cb, int time)
        {
            cbNo = cb;
            elapstime = time;
        }
        public bool isFired()
        {
            return (elapstime <= 0);
        }
        public bool isAction()
        {
            if (elapstime > 0)
                elapstime -= 1;
            return (elapstime <= 0);
        }
        public int getCBNo()
        {
            return cbNo;
        }
    }
    public static class myPrinters
    {
        [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetDefaultPrinter(string Name);

    }
}


