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
    public partial class frmReceiptProduct : Form
    {
        #region LocalVirableFunciton
        private int iCurrentProductID;
        private int iCurrentReceiptID;
        private bool isTimedepositChange = false;
        private Hoadonxuat currentReceipt;
        public frmReceiptProduct()
        {
            InitializeComponent();
            currentReceipt = new Hoadonxuat();
        }
        private void getAllSP()
        {
            DataSet ds = new DataAccess().getAllSanPhamAndIDGia();
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
        private void frmReceiptProduct_Load(object sender, EventArgs e)
        {
            iCurrentReceiptID = -1;
            getAllSP();
            //displayProductPrice();

            getAllNhanvien();
            getAllKhachhang();
            updateReceiptGrid(0);
        }
        private void updateReceiptGrid(int id)
        {
            DataSet dsHDSP = new DataAccess().getAllHoadonxuatSanpham();
            gridControlDMHD.DataSource = dsHDSP.Tables[0];
            gridViewDMHD.ExpandAllGroups();
            //get focus to current
            int i;
            for (i = 0; i < gridViewDMHD.RowCount; i++)
            {
                if (Convert.ToInt32(gridViewDMHD.GetRowCellValue(i, "IDHoadonXuat")) == id)
                    break;
            }
            gridViewDMHD.FocusedRowHandle = i;
        }
        private bool updateBillDisplay(int IDHoadon)
        {
            //this function will get all infomation about the receipt by its ID
            //txtBilltotal.Text = "0";
            //txtHourMoney.Text = "0";
            //txtProductMoney.Text = "0";
            //get Bill infomation
            if (IDHoadon < 0)
            {
                lbStatus.Text = "Lựa chọn Mã hóa đơn không hợp lệ";
                cboEmployee.SelectedValue = 0;
                txtBilltotal.Text = "0";
                txtProductMoney.Text = "0";
                numExtra.Value = 0;
                numTax.Value = 0;
                numDeposit.Value = 0;
                txtReturnMoney.Text = "0";
                gridBillProduct.DataSource = null;
                txtReturnMoney.Text = "0";
                lbGioMP.Text = "00:00";
                lbGioKT.Text = "00:00";
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
            //check the status of this Bill
            // 0 : is open //1: is close //2: could not modify
            int status = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Trangthai"]);
            //get current Bill
            currentReceipt.IDNhanvien = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDNhanvien"]);
            currentReceipt.IDPhong = -1;
            currentReceipt.Giam = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Giam"]);
            currentReceipt.Thue = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Thue"]);
            currentReceipt.Phuthu = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Phuthu"]);
            currentReceipt.IDGiaLoaiphong = -1;
            currentReceipt.Ngayxuat = Convert.ToDateTime(dsBill.Tables[0].Rows[0]["Ngayxuat"]);
            currentReceipt.GioBD = Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]);
            currentReceipt.GioKT = Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioKT"]);
            currentReceipt.Tratruoc = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Tratruoc"]);
            currentReceipt.Ghichu = Convert.ToString(dsBill.Tables[0].Rows[0]["Ghichu"]);
            currentReceipt.Trangthai = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Trangthai"]);
            currentReceipt.IDHoadonXuat = IDHoadon;
            currentReceipt.IDNhanvien = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDNhanvien"]);
            currentReceipt.Nhacnho = Convert.ToBoolean(dsBill.Tables[0].Rows[0]["Nhacnho"]);
            currentReceipt.IDKhachhang = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDKhachhang"]);
            
            if (status == 0)
            {
                //new bill
                cboEmployee.SelectedValue = currentReceipt.IDNhanvien;
                cboCustomer.SelectedValue = currentReceipt.IDKhachhang;
                numTax.Value = currentReceipt.Thue;
                numExtra.Value = currentReceipt.Phuthu;
                numDeposit.Value = currentReceipt.Tratruoc;
                
                string strtime = "Ngày " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["Ngayxuat"]).ToShortDateString();
                strtime = strtime + " - Bắt đầu lúc " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]).ToShortTimeString();
                lbStatus.Text = strtime;
                lbGioMP.Text = currentReceipt.GioBD.ToString("hh:mm");
                lbGioKT.Text = DateTime.Now.TimeOfDay.Hours.ToString("00") + ":" + DateTime.Now.TimeOfDay.Minutes.ToString("00");
                currentReceipt.GioKT = DateTime.Now;
                if (new DataAccess().updateHoadonxuat(currentReceipt) == false)
                {
                    MessageBox.Show("Lỗi cơ sở dữ liệu!", "Lỗi");
                }
            }
            else
            {
                //old bill

                cboEmployee.SelectedValue = currentReceipt.IDNhanvien;
                cboCustomer.SelectedValue = currentReceipt.IDKhachhang;
                numTax.Value = currentReceipt.Thue;
                numExtra.Value = currentReceipt.Phuthu;
                
                numDeposit.Value = currentReceipt.Tratruoc;
                
                string strtime = "Ngày " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["Ngayxuat"]).ToShortDateString();
                strtime = strtime + " - Bắt đầu: " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]).ToShortTimeString();
                strtime = strtime + " - Kết thúc: " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioKT"]).ToShortTimeString();
                lbStatus.Text = strtime;
                lbGioMP.Text = currentReceipt.GioBD.ToString("hh:mm");
                lbGioKT.Text = currentReceipt.GioKT.ToString("hh:mm");

            }
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
            totalBill = productMoney + Convert.ToInt32(numExtra.Value);
            totalBill = Convert.ToInt32(totalBill + totalBill * numTax.Value / 100);
            txtBilltotal.Text = totalBill.ToString("###,###,###,##0");
            txtReturnMoney.Text = (totalBill - Convert.ToInt32(dsBill.Tables[0].Rows[0]["Tratruoc"])).ToString("###,###,##0");
            return true;
        }
        #endregion
        #region DMHD
        private void gridViewDMHD_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                iCurrentReceiptID = Convert.ToInt32(gridViewDMHD.GetRowCellValue(gridViewDMHD.FocusedRowHandle, "IDHoadonXuat"));
                updateBillDisplay(iCurrentReceiptID);
            }
        }
        private void StartNewReceipt()
        {
            //open or close selected room
            //first search if selected room is available
            
             
           //in case of the room is available
            //ask to open room and create new receipt for this room
            if (MessageBox.Show("Bạn có muốn mở hóa đơn bán lẻ mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;
            //get khuyen mai tang gio cua phong
            currentReceipt.TenHoadon = "BL" + DateTime.Now.ToString("dd/MM/yy-hh:mm");
            currentReceipt.Giam = 0;
            currentReceipt.GioBD = DateTime.Now;
            currentReceipt.GioKT = DateTime.Now;
            currentReceipt.Tratruoc = 0;
            currentReceipt.Nhacnho = false;
            currentReceipt.IDPhong = -1;
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
            
            int res = new DataAccess().insertHoadonxuat(currentReceipt);
            if (res > -1)
            {
                //wait for databa is update
                
                iCurrentReceiptID = res;
                
                //update Hoadon group display
                if (updateBillDisplay(res))
                {
                    updateReceiptGrid(res);
                    
                }
                //btnStart.Image = Karaoke.Properties.Resources.Status_user_busy_icon1;
            }
            else
            {
                MessageBox.Show("Mở Hóa đơn mới không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void CloseOpenReceipt()
        {
            //open or close selected room
            //first search if selected room is available


            //in case of the room is available
            //ask to open room and create new receipt for this room
            if (MessageBox.Show("Bạn có muốn mở hóa đơn bán lẻ mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                return;
            //get khuyen mai tang gio cua phong
            
            currentReceipt.GioKT = DateTime.Now;
            currentReceipt.Trangthai = 1;
            
            if (new DataAccess().updateHoadonxuat(currentReceipt))
            {
                if (updateBillDisplay(iCurrentReceiptID))
                {
                    updateReceiptGrid(iCurrentReceiptID);

                }
                //btnStart.Image = Karaoke.Properties.Resources.Status_user_busy_icon1;
            }
            else
            {
                MessageBox.Show("Đóng Hóa đơn không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion
        #region DMSP
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
        private void gridViewSanPham_DoubleClick(object sender, EventArgs e)
        {
            if (gridViewSanPham.FocusedRowHandle >= 0)
            {
                AddSP(1);
            }
        }

        private void AddSP(int num)
        {
            //add a quantity of a product to current bill
            //check if the parameters are legal

            if (gridViewSanPham.FocusedRowHandle >= 0)
            {
                //list all products by ID
                int ID = Convert.ToInt32(gridViewSanPham.GetRowCellValue(gridViewSanPham.FocusedRowHandle, "IDSanPham"));
                iCurrentProductID = ID;
                int IDLoaiSP = Convert.ToInt32(gridViewSanPham.GetRowCellValue(gridViewSanPham.FocusedRowHandle, "IDNhomSP"));
                //DataSet prdPrice = new DataAccess().getGiaXuatSPByIDSanPham(ID);
                //if ((prdPrice != null) && (prdPrice.Tables[0].Rows.Count > 0))
                //{
                //txtPrice.Text = prdPrice.Tables[0].Rows[0][1].ToString();
                if (iCurrentReceiptID >= 0)
                {
                    if (currentReceipt.Trangthai > 1)
                    {
                        MessageBox.Show("Hóa đơn này đã đóng, không được thay đổi", "Thông báo");
                        return;
                    }
                    else if ((currentReceipt.Trangthai > 0) && (Program.userLevel != Level.Admin))
                    {
                        MessageBox.Show("Đăng nhập với quyền Quản lý để thay đổi", "Thông báo");
                        return;
                    }
                    if(currentReceipt.Trangthai > 0)
                    {
                        if (MessageBox.Show("Bạn có muốn thêm sản phẩm vào hóa đơn đã đóng", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.No)
                            return;
                    }
                    //get khuyen mai with this product ID
                    DataSet ds = new DataAccess().getKhuyenmaiByIDLoaiSP(IDLoaiSP, DateTime.Now.Date);
                    //if (ds == null)
                    //    return;
                    //if (ds.Tables[0].Rows.Count == 0)
                    //{
                    //get the number of added product
                    frmReturnProduct rt = new frmReturnProduct(true, 0, Convert.ToString(gridViewSanPham.GetRowCellValue(gridViewSanPham.FocusedRowHandle, "TenSanPham")));
                    rt.ShowDialog();
                    int rtnum = rt.getReturnNum();
                    // bool directRet = rt.getDirectRet();
                    string text = rt.getText();
                    rt.Close();
                    if (rtnum <= 0) return;
                    ChitietHDXuat obj = new ChitietHDXuat();
                    obj.IDHoadonXuat = iCurrentReceiptID;
                    obj.IDSanpham = iCurrentProductID;
                    obj.Gia = Convert.ToInt32(gridViewSanPham.GetRowCellValue(gridViewSanPham.FocusedRowHandle, "Gia"));
                    obj.Soluong = rtnum;
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
                        MessageBox.Show("Không thêm sản phẩm " + gridViewSanPham.GetRowCellValue(gridViewSanPham.FocusedRowHandle, "TenSanPham") + " vào hóa đơn hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    
                    updateBillDisplay(iCurrentReceiptID);
                    int i;
                    for (i = 0; i < gridViewBillProduct.RowCount; i++)
                    {
                        if (Convert.ToInt32(gridViewBillProduct.GetRowCellValue(i, "IDSanpham")) == iCurrentProductID)
                            break;
                    }
                    gridViewBillProduct.Focus();
                    gridViewBillProduct.FocusedRowHandle = i;
                    gridViewBillProduct.FocusedColumn = colBillNum;

                }
            }
        }
        #endregion
        #region Receipt
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
                        obj.Soluong = -rtnum;
                        obj.Ghichu = text;
                        if (new DataAccess().insertChitietHDXuat(obj) < 0)
                            MessageBox.Show(this, "Trả sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            updateBillDisplay(iCurrentReceiptID);

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
            obj.Trangthai = Convert.ToBoolean(gridViewBillProduct.GetRowCellValue(e.RowHandle, "Trangthai"));
            if (new DataAccess().updateChitietHDXuat(obj) == false)
                MessageBox.Show(this, "Cập nhật sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            updateBillDisplay(iCurrentReceiptID);
        }
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateBillDisplay(iCurrentReceiptID);
        }

        private void btnNewReceipt_Click(object sender, EventArgs e)
        {
            StartNewReceipt();
        }
        private void btnCloseReceipt_Click(object sender, EventArgs e)
        {
            if (iCurrentReceiptID < 0)
                return;
            if (currentReceipt.Trangthai > 0)
                return;
            CloseOpenReceipt();
        }
        private void numExtra_ValueChanged(object sender, EventArgs e)
        {
            if (iCurrentReceiptID > -1)
            {
                //check if cached bill is the same
                if (iCurrentReceiptID != currentReceipt.IDHoadonXuat)
                    return;

                if ((currentReceipt.Trangthai > 0) && (Program.userLevel != Level.Admin))
                {
                    MessageBox.Show("Liên hệ quản lý để thay đổi Hóa đơn này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                currentReceipt.Phuthu = Convert.ToInt32(numExtra.Value);
                //update DB
                bool res = new DataAccess().updateHoadonxuat(currentReceipt);
                if (!res)
                {
                    MessageBox.Show("Không cập nhật được CSDL", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                updateBillDisplay(iCurrentReceiptID);
            }
        }

        private void numTax_ValueChanged(object sender, EventArgs e)
        {
            if (iCurrentReceiptID > -1)
            {
                //check if cached bill is the same
                if (iCurrentReceiptID != currentReceipt.IDHoadonXuat)
                    return;
                if ((currentReceipt.Trangthai > 0) && (Program.userLevel != Level.Admin))
                {
                    MessageBox.Show("Liên hệ quản lý để thay đổi Hóa đơn này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                currentReceipt.Thue = Convert.ToInt32(numExtra.Value);
                //update DB
                bool res = new DataAccess().updateHoadonxuat(currentReceipt);
                if (!res)
                {
                    MessageBox.Show("Không cập nhật được CSDL", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                updateBillDisplay(iCurrentReceiptID);
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
            updateBillDisplay(iCurrentReceiptID);
        }
        private void gridViewDMHD_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteDMHD)
                {
                    if (Program.userLevel != Level.Admin)
                    {
                        MessageBox.Show("Liên hệ quản lý để xóa Hóa đơn này", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Hoadonxuat objKMSP = new Hoadonxuat();
                    objKMSP.IDHoadonXuat = Convert.ToInt32(gridViewDMHD.GetRowCellValue(e.RowHandle, "IDHoadonXuat"));

                    if (Convert.ToBoolean(gridViewDMHD.GetRowCellValue(e.RowHandle, colDeleteDMHD)) == true)
                    {
                        //warnning
                        if (MessageBox.Show(this, "Bạn có muốn xóa hóa đơn này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (new DataAccess().deleteChitietHDXuatOfHDXuat(objKMSP) == true)
                            {
                                if (new DataAccess().deleteHoadonxuat(objKMSP) == true)
                                {
                                    ((frmMain)(this.MdiParent)).setStatus("Xóa khuyến mãi thành công");
                                    gridViewDMHD.DeleteRow(e.RowHandle);
                                    iCurrentReceiptID = Convert.ToInt32(gridViewDMHD.GetRowCellValue(gridViewDMHD.FocusedRowHandle, "IDHoadonXuat"));
                                    updateReceiptGrid(iCurrentReceiptID);
                                }
                                else
                                {
                                    MessageBox.Show(this, "Xóa hóa đơn không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    ((frmMain)(this.MdiParent)).setStatus("");
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Xóa sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ((frmMain)(this.MdiParent)).setStatus("");
                            }
                        }
                        else
                        {
                            //set the image to uncheck
                            gridViewDMHD.SetRowCellValue(e.RowHandle, colDeleteDMHD, true);
                        }
                    }
                }
            }
        }
        #endregion

        private void btnJoinRoom_Click(object sender, EventArgs e)
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
                dr["Ngayxuat"] = currentReceipt.Ngayxuat.ToString("dd/MM/yyyy");
                dr["Phong"] = "";
                dr["GiaPhong"] = "";
                dr["HoadonID"] = iCurrentReceiptID.ToString();
                dr["GioBD"] = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioBD"]).ToShortTimeString();
                dr["GioKT"] = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioKT"]).ToShortTimeString();
                dr["Nhanvien"] = cboEmployee.Text;
                dr["Thue"] = numTax.Value.ToString();
                dr["Tiengiam"] = numExtra.Value.ToString();
                dr["Phuthu"] = numExtra.Value.ToString();
                dr["Tiengio"] = "0";
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
                    string printer="";
                    try
                    {
                        printer = Convert.ToString(ds.Tables[0].Rows[0]["MayInKho"]);
                        myPrinters.SetDefaultPrinter(printer);
                    }
                    catch
                    {
                        MessageBox.Show("Chưa cài đặt máy in!", "Thông báo");
                    }
                    frmViewReport frmView = new frmViewReport(dsBill, false, printer);
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

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            if (iCurrentReceiptID >= 0)
            {
                int i;
                DataSetHoaDon dsBill = new DataSetHoaDon();
                DataSet dsSP = new DataAccess().getChitietHDXuatByID(iCurrentReceiptID);
                DataSet dsHD = new DataAccess().getHoadonxuatByIDHoadonXuat(iCurrentReceiptID);


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
                

                DataRow dr3 = dsBill.Tables["RDatadetail"].NewRow();
                dr3["STT"] = (i + 3).ToString();
                dr3["TenSanPham"] = "Phụ thu";
                //dr3["DVT"] = ("").ToString();
                dr3["DonGia"] = numExtra.Value.ToString();
                dr3["Soluong"] = "1";
                dr3["ThanhTien"] = numExtra.Value.ToString();
                dr3["Giam"] = "0%";
                dsBill.Tables["RDatadetail"].Rows.Add(dr3);

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
                dr["Ngayxuat"] =currentReceipt.Ngayxuat.ToString("dd/MM/yyyy HH:mm:ss tt");
                dr["Phong"] = "";
                dr["GiaPhong"] = "";
                dr["HoadonID"] = iCurrentReceiptID.ToString();
                dr["GioBD"] = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioBD"]).ToShortTimeString();
                dr["GioKT"] = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioKT"]).ToShortTimeString();
                dr["Nhanvien"] = cboEmployee.Text;
                dr["Thue"] = numTax.Value.ToString();
                dr["Tiengiam"] = numExtra.Value.ToString();
                dr["Phuthu"] = numExtra.Value.ToString();
                dr["Tiengio"] = "";
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
                        currentReceipt.Trangthai = 1;
                        if (new DataAccess().updateHoadonxuat(currentReceipt) == false)
                            MessageBox.Show("Lỗi dữ liệu", "Thông báo");
                        updateBillDisplay(iCurrentReceiptID);
                    }
                }
            }
        }

        private void btnPrintCooking_Click(object sender, EventArgs e)
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
                dr["Ngayxuat"] = currentReceipt.Ngayxuat.ToString("dd/MM/yyyy HH:mm:ss tt");
                dr["Phong"] = "";
                dr["GiaPhong"] = "";
                dr["HoadonID"] = iCurrentReceiptID.ToString();
                dr["GioBD"] = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioBD"]).ToShortTimeString();
                dr["GioKT"] = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioKT"]).ToShortTimeString();
                dr["Nhanvien"] = cboEmployee.Text;
                dr["Thue"] = numTax.Value.ToString();
                dr["Tiengiam"] = numExtra.Value.ToString();
                dr["Phuthu"] = numExtra.Value.ToString();
                dr["Tiengio"] = "";
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
                    string printer="";
                    try
                    {
                        printer = Convert.ToString(ds.Tables[0].Rows[0]["MayInBep"]);
                        myPrinters.SetDefaultPrinter(printer);
                    }
                    catch
                    {
                        MessageBox.Show("Chưa cài đặt máy in!", "Thông báo");
                    }
                    frmViewReport frmView = new frmViewReport(dsBill, true, printer);
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

       

        

        
    }
}
