using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BKIT.Entities;
using Karaoke.DataSets;
using BKIT.Model;

namespace Karaoke.MDIForms
{
    public partial class frmDivideRoom : Form
    {
        private int oldIDHoadonXuat = -1;
        private int newIDHoadonXuat = -1;
        private int oldRoom = -1;
        private int newRoom = -1;
        private DataTable oldProduct = new DataTable();
        private DataTable newProduct = new DataTable();
        private Queue<int> turnOnRoom;
        public frmDivideRoom(int IDRoom, int IDHoadonXuat)
        {
            InitializeComponent();
            oldProduct.Columns.Add("IDSanpham", typeof(int));
            oldProduct.Columns.Add("IDChitietHDXuat", typeof(int));
            oldProduct.Columns.Add("IDGiaxuatSP", typeof(int));
            oldProduct.Columns.Add("Giam", typeof(int));
            oldProduct.Columns.Add("Soluong", typeof(int));
            oldProduct.Columns.Add("Transfer", typeof(int));
            oldProduct.Columns.Add("TenSanPham", typeof(string));
            oldProduct.Columns.Add("Go", typeof(Boolean));

            oldProduct.Rows.Clear();
            newProduct.Columns.Add("IDSanpham", typeof(int));
            newProduct.Columns.Add("IDChitietHDXuat", typeof(int));
            newProduct.Columns.Add("IDGiaxuatSP", typeof(int));
            newProduct.Columns.Add("Giam", typeof(int));
            newProduct.Columns.Add("Soluong", typeof(int));
            newProduct.Columns.Add("Transfer", typeof(int));
            newProduct.Columns.Add("TenSanPham", typeof(string));
            newProduct.Columns.Add("Go", typeof(Boolean));
            newProduct.Rows.Clear();
            oldIDHoadonXuat = IDHoadonXuat;
            oldRoom = IDRoom;
            turnOnRoom = new Queue<int>();
        }
        private void initDataGrid()
        {
            if ((oldIDHoadonXuat > -1) && (oldRoom >-1))
            {
                //get all Room
                DataSet dsRoom = new DataAccess().getAllPhongAndLoaiPhong(oldRoom);
                gridRoom.DataSource = dsRoom.Tables[0];
                gridViewRoom.ExpandAllGroups();
                DataSet ds = new DataAccess().getPhongByIDPhong(oldRoom);
                if (ds != null)
                    //lblOldRoom.Text = "Sản phẩm của phòng " + ds.Tables[0].Rows[0]["TenPhong"].ToString() + "";
                gcOldRoomproduct.Text = "Sản phẩm của phòng " + ds.Tables[0].Rows[0]["TenPhong"].ToString() + "";
                //get all product with this bill
                /*
                DataSet dsBillProduct = new DataAccess().getChitietHDXuatByID(oldIDHoadonXuat);
                oldProduct.Rows.Clear();
                int i;
                for (i = 0; i < dsBillProduct.Tables[0].Rows.Count;i++ )
                {
                    DataRow aRow = oldProduct.NewRow();
                    aRow["IDSanpham"] = dsBillProduct.Tables[0].Rows[i]["IDSanpham"];
                    aRow["IDChitietHDXuat"] = dsBillProduct.Tables[0].Rows[i]["IDchitietHDXuat"];
                    aRow["Soluong"] = dsBillProduct.Tables[0].Rows[i]["Soluong"];
                    aRow["IDGiaxuatSP"] = dsBillProduct.Tables[0].Rows[i]["IDGiaxuatSP"];
                    aRow["Giam"] = dsBillProduct.Tables[0].Rows[i]["Giam"];
                    aRow["TenSanPham"] = dsBillProduct.Tables[0].Rows[i]["TenSanPham"];
                    aRow["Transfer"] = 0;
                    aRow["Go"] = false;
                    oldProduct.Rows.Add(aRow);
                }
                gridBillProduct.DataSource = oldProduct;
                */
            }
        }
        private void refreshProduct()
        {
            //get all product with this bill
            DataSet dsBillProduct = new DataAccess().getChitietHDXuatByID(oldIDHoadonXuat);
            int i;
            if ((oldIDHoadonXuat > -1) && (oldRoom > -1))
            {
                oldProduct.Rows.Clear();
                for (i = 0; i < dsBillProduct.Tables[0].Rows.Count; i++)
                {
                    DataRow aRow = oldProduct.NewRow();
                    aRow["IDSanpham"] = dsBillProduct.Tables[0].Rows[i]["IDSanpham"];
                    aRow["IDChitietHDXuat"] = dsBillProduct.Tables[0].Rows[i]["IDchitietHDXuat"];
                    aRow["Soluong"] = dsBillProduct.Tables[0].Rows[i]["Soluong"];
                    aRow["IDGiaxuatSP"] = dsBillProduct.Tables[0].Rows[i]["IDGiaxuatSP"];
                    aRow["Giam"] = dsBillProduct.Tables[0].Rows[i]["Giam"];
                    aRow["TenSanPham"] = dsBillProduct.Tables[0].Rows[i]["TenSanPham"];
                    aRow["Transfer"] = 0;
                    aRow["Go"] = false;
                    oldProduct.Rows.Add(aRow);
                }
            }
            //get status of this room
            newProduct.Rows.Clear();
            if (Convert.ToBoolean(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "Trangthai")))
            {
                //get last Receipt of this room
                DataSet dsBill = new DataAccess().getLastHoadonxuatByIDPhong(newRoom);
                newIDHoadonXuat = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDHoadonXuat"]);
                DataSet dsBillProductNew = new DataAccess().getChitietHDXuatByID(newIDHoadonXuat);

                for (i = 0; i < dsBillProductNew.Tables[0].Rows.Count; i++)
                {
                    DataRow aRow = newProduct.NewRow();
                    aRow["IDSanpham"] = dsBillProductNew.Tables[0].Rows[i]["IDSanpham"];
                    aRow["IDChitietHDXuat"] = dsBillProductNew.Tables[0].Rows[i]["IDchitietHDXuat"];
                    aRow["Soluong"] = dsBillProductNew.Tables[0].Rows[i]["Soluong"];
                    aRow["IDGiaxuatSP"] = dsBillProductNew.Tables[0].Rows[i]["IDGiaxuatSP"];
                    aRow["Giam"] = dsBillProductNew.Tables[0].Rows[i]["Giam"];
                    aRow["TenSanPham"] = dsBillProductNew.Tables[0].Rows[i]["TenSanPham"];
                    aRow["Transfer"] = 0;
                    aRow["Go"] = false;
                    newProduct.Rows.Add(aRow);
                }
            }
            else
                newIDHoadonXuat = -1;
        }
        private void frmDivideRoom_Load(object sender, EventArgs e)
        {

            initDataGrid();
        }

        private void gridViewBillProduct_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                int SP = -1;
                if (e.Column == colGo)
                {
                    SP = TransferDown(e.RowHandle);
                    gridBillProduct.DataSource = oldProduct;
                    gridTransferedProductControlNew.DataSource = newProduct;
                    gridViewBillProduct.FocusedRowHandle = e.RowHandle;
                    gotoNewProductRow(SP);
                }
            }
        }
        int TransferDown(int row)
        {
            //search if this product has already in new list
            int i,j;
            bool found = false;
            int IDSP = Convert.ToInt32(gridViewBillProduct.GetRowCellValue(row, "IDSanpham"));
            for (i = 0; i < newProduct.Rows.Count; i++)
            {
                if (Convert.ToInt32(newProduct.Rows[i]["IDSanpham"]) == IDSP)
                {
                    found = true;
                    break;
                }
            }
            for (j = 0; j < oldProduct.Rows.Count; j++)
            {
                if (Convert.ToInt32(oldProduct.Rows[j]["IDSanpham"]) == IDSP)
                {
                    break;
                }
            }
            int num = 0;
            if (Convert.ToInt32(gridViewBillProduct.GetRowCellValue(row, "Transfer")) <= Convert.ToInt32(gridViewBillProduct.GetRowCellValue(row, "Soluong")))
                num = Convert.ToInt32(gridViewBillProduct.GetRowCellValue(row, "Transfer"));
            else
                num = Convert.ToInt32(gridViewBillProduct.GetRowCellValue(row, "Soluong"));
            if (!found)
            {
                DataRow aRow = newProduct.NewRow();
                aRow["IDSanpham"] = gridViewBillProduct.GetRowCellValue(row, "IDSanpham");
                aRow["IDChitietHDXuat"] = -1;
                aRow["Soluong"] = num;
                
                aRow["IDGiaxuatSP"] = gridViewBillProduct.GetRowCellValue(row, "IDGiaxuatSP");
                aRow["Giam"] = gridViewBillProduct.GetRowCellValue(row, "Giam");
                aRow["TenSanPham"] = gridViewBillProduct.GetRowCellValue(row, "TenSanPham");
                aRow["Transfer"] = 0 ;
                aRow["Go"] = false;
                newProduct.Rows.Add(aRow);
            }
            else
            {
                newProduct.Rows[i]["Soluong"] = Convert.ToInt32(newProduct.Rows[i]["Soluong"]) + num;
                newProduct.Rows[i]["Transfer"] = 0;
            }
            oldProduct.Rows[j]["Soluong"] = Convert.ToInt32(oldProduct.Rows[j]["Soluong"]) - num;
            gridViewBillProduct.SetRowCellValue(row,"Soluong",oldProduct.Rows[j]["Soluong"]);
            gridViewBillProduct.SetRowCellValue(row, "Transfer", 0);
            return IDSP;
        }
        int TransferUp(int row)
        {
            //search if this product has already in new list
            int i, j;
            bool found = false;
            int IDSP = Convert.ToInt32(gridViewTransferedProductNew.GetRowCellValue(row, "IDSanpham"));
            for (j = 0; j < oldProduct.Rows.Count; j++)
            {
                if (Convert.ToInt32(oldProduct.Rows[j]["IDSanpham"]) == IDSP)
                {
                    found = true;
                    break;
                }
            }
            for (i = 0; i < newProduct.Rows.Count; i++)
            {
                if (Convert.ToInt32(newProduct.Rows[i]["IDSanpham"]) == IDSP)
                {
                    break;
                }
            }
            int num = 0;
            if (Convert.ToInt32(gridViewTransferedProductNew.GetRowCellValue(row, "Transfer")) <= Convert.ToInt32(gridViewBillProduct.GetRowCellValue(row, "Soluong")))
                num = Convert.ToInt32(gridViewTransferedProductNew.GetRowCellValue(row, "Transfer"));
            else
                num = Convert.ToInt32(gridViewTransferedProductNew.GetRowCellValue(row, "Soluong"));
            if (!found)
            {
                DataRow aRow = oldProduct.NewRow();
                aRow["IDSanpham"] = gridViewTransferedProductNew.GetRowCellValue(row, "IDSanpham");
                aRow["IDChitietHDXuat"] = -1;
                aRow["Soluong"] = num;

                aRow["IDGiaxuatSP"] = gridViewTransferedProductNew.GetRowCellValue(row, "IDGiaxuatSP");
                aRow["Giam"] = gridViewTransferedProductNew.GetRowCellValue(row, "Giam");
                aRow["TenSanPham"] = gridViewTransferedProductNew.GetRowCellValue(row, "TenSanPham");
                aRow["Transfer"] = 0;
                aRow["Go"] = false;
                oldProduct.Rows.Add(aRow);
            }
            else
            {
                oldProduct.Rows[j]["Soluong"] = Convert.ToInt32(oldProduct.Rows[j]["Soluong"]) + num;
                oldProduct.Rows[j]["Transfer"] = 0;
            }
            newProduct.Rows[i]["Soluong"] = Convert.ToInt32(newProduct.Rows[i]["Soluong"]) - num;
            gridViewTransferedProductNew.SetRowCellValue(row, "Soluong", newProduct.Rows[i]["Soluong"]);
            gridViewTransferedProductNew.SetRowCellValue(row, "Transfer", 0);
            return IDSP;
        }
        private void gridViewRoom_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0)
            {
                newRoom = Convert.ToInt32(gridViewRoom.GetRowCellValue(e.FocusedRowHandle, "IDPhong"));
                //lblNewRoom.Text = "Sản phẩm của phòng " + gridViewRoom.GetRowCellValue(e.FocusedRowHandle, "TenPhong").ToString() + "";
                gcNewRoomProduct.Text = "Sản phẩm của phòng " + gridViewRoom.GetRowCellValue(e.FocusedRowHandle, "TenPhong").ToString() + "";

                gridBillProduct.DataSource = oldProduct;
                gridTransferedProductControlNew.DataSource = newProduct;
            }
            refreshProduct();
        }

        private void gridViewTransferedProductNew_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                int SP = -1;
                if (e.Column == colGoUp)
                {
                    SP = TransferUp(e.RowHandle);
                    gridBillProduct.DataSource = oldProduct;
                    gridTransferedProductControlNew.DataSource = newProduct;
                    gridViewTransferedProductNew.FocusedRowHandle = e.RowHandle;
                    gotoOldProductRow(SP);
                }
            }
        }
        void gotoOldProductRow(int SP)
        {
            int i;
            for (i = 0; i < gridViewBillProduct.RowCount; i++)
            {
                if (Convert.ToInt32(gridViewBillProduct.GetRowCellValue(i, "IDSanpham")) == SP)
                {
                    gridViewBillProduct.FocusedRowHandle = i;
                    break;
                }
            }
        }
        void gotoNewProductRow(int SP)
        {
            int i;
            for (i = 0; i < gridViewTransferedProductNew.RowCount; i++)
            {
                if (Convert.ToInt32(gridViewTransferedProductNew.GetRowCellValue(i, "IDSanpham")) == SP)
                {
                    gridViewTransferedProductNew.FocusedRowHandle = i;
                    break;
                }
            }
        }
        
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshProduct();
        }

        void updateBillProduct()
        {
            //check if whether transfer column diff zero
            if (newRoom < 0)
            {
                MessageBox.Show("Bạn hãy chọn phòng để chuyển sản phẩm!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (newIDHoadonXuat < 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn mở phòng " + gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "TenPhong").ToString() + " và chuyển sản phẩm?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            bool found = false;
            int i;
            for (i = 0; i < gridViewTransferedProductNew.RowCount; i++)
            {
                if (Convert.ToInt32(gridViewTransferedProductNew.GetRowCellValue(i, "Transfer")) != 0)
                {
                    gridViewTransferedProductNew.FocusedRowHandle = i;
                    found = true;
                    break;
                }
            }

            for (i = 0; i < gridViewBillProduct.RowCount; i++)
            {
                if (Convert.ToInt32(gridViewBillProduct.GetRowCellValue(i, "Transfer")) != 0)
                {
                    gridViewBillProduct.FocusedRowHandle = i;
                    found = true;
                    break;
                }
            }
            if (found)
            {
                if (MessageBox.Show("Sản phẩm chưa được chuyển hết (Cột 'Chuyển khác 0). Bạn có muốn tiếp tục cập nhật Hóa đơn?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn cập nhật Hóa đơn?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }
            //update old chi tiet hoa don
            for (i = 0; i < oldProduct.Rows.Count; i++)
            {
                ChitietHDXuat objCTHDX = new ChitietHDXuat();
                objCTHDX.IDChitietHDXuat = Convert.ToInt32(oldProduct.Rows[i]["IDChitietHDXuat"]);
                if (Convert.ToInt32(oldProduct.Rows[i]["Soluong"]) <= 0)  
                {
                    // chuyen het san pham cua 1 row qua phong moi
                    // delete san pham nay khoi chi tiet hoa don xuat
                    if (!(new DataAccess().deleteChitietHDXuat(objCTHDX)))
                    {
                        MessageBox.Show("Lỗi Cơ sở dữ liệu!", "Lỗi");
                        return;
                    }
                }
                else
                {
                    // cap nhat lai chi tiet hoa don xuat
                    objCTHDX.IDGiaxuat = Convert.ToInt32(oldProduct.Rows[i]["IDGiaxuatSP"]);
                    objCTHDX.Giam = Convert.ToInt32(oldProduct.Rows[i]["Giam"]);
                    objCTHDX.IDHoadonXuat = oldIDHoadonXuat;
                    objCTHDX.IDSanpham = Convert.ToInt32(oldProduct.Rows[i]["IDSanpham"]);
                    objCTHDX.Soluong = Convert.ToInt32(oldProduct.Rows[i]["Soluong"]);
                    objCTHDX.Bep = false;
                    if(!(new DataAccess().updateChitietHDXuat(objCTHDX)))
                    {
                        MessageBox.Show("Lỗi Cơ sở dữ liệu!", "Lỗi");
                        return;
                    }
                }
            }

            //update new HD
            if (newIDHoadonXuat >= 0)   // hoa don da duoc mo
            {
                for (i = 0; i < newProduct.Rows.Count; i++)
                {
                    ChitietHDXuat objCTHDX = new ChitietHDXuat();
                    objCTHDX.IDChitietHDXuat = Convert.ToInt32(newProduct.Rows[i]["IDChitietHDXuat"]);
                    objCTHDX.IDGiaxuat = Convert.ToInt32(newProduct.Rows[i]["IDGiaxuatSP"]);
                    objCTHDX.Giam = Convert.ToInt32(newProduct.Rows[i]["Giam"]);
                    objCTHDX.IDHoadonXuat = newIDHoadonXuat;
                    objCTHDX.IDSanpham = Convert.ToInt32(newProduct.Rows[i]["IDSanpham"]);
                    objCTHDX.Soluong = Convert.ToInt32(newProduct.Rows[i]["Soluong"]);
                    objCTHDX.Bep = false;
                    if (objCTHDX.IDChitietHDXuat >= 0)
                    {
                        if (objCTHDX.Soluong <= 0)
                        {
                            if (!(new DataAccess().deleteChitietHDXuat(objCTHDX)))
                            {
                                MessageBox.Show("Lỗi Cơ sở dữ liệu!", "Lỗi");
                                return;
                            }
                        }
                        else
                        {

                            if (!(new DataAccess().updateChitietHDXuat(objCTHDX)))
                            {
                                MessageBox.Show("Lỗi Cơ sở dữ liệu!", "Lỗi");
                                return;
                            }
                        }
                    }
                    else
                    {
                        int id = new DataAccess().insertChitietHDXuat(objCTHDX);
                        if (id < 0)
                        {
                            MessageBox.Show("Lỗi Cơ sở dữ liệu!", "Lỗi");
                            return;
                        }
                        else
                            oldProduct.Rows[i]["IDChitietHDXuat"] = id;

                    }
                }
            }
            else //open new bill
            {
                Hoadonxuat currentReceipt = new Hoadonxuat();
                currentReceipt.Giam = 0;
                currentReceipt.GioBD = DateTime.Now;
                currentReceipt.GioKT = DateTime.Now;
                currentReceipt.Nhacnho = false;
                currentReceipt.Tratruoc = 0;
                currentReceipt.IDPhong = newRoom;
                currentReceipt.Ngayxuat = DateTime.Now.Date;
                currentReceipt.Phuthu = 0;
                currentReceipt.Thue = 0;
                currentReceipt.Trangthai = 0;
                currentReceipt.Thue = 0;
                currentReceipt.Phuthu = 0;
                currentReceipt.IDNhanvien = 0;
                currentReceipt.IDKhachhang = 0;
                currentReceipt.Ghichu = "";
                //get current hour class
                TimeSpan ctime = DateTime.Now.TimeOfDay;
                
                DataSet hourclass = new DataAccess().getAllKhunggio();
                int idkhunggio = 0;
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

                DataSet ds1 = new DataAccess().getGiaLoaiPhongByIDLoaiPhongAndIDKhunggio(Convert.ToInt32(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle,"IDLoaiPhong")), idkhunggio);
                if (ds1.Tables[0].Rows.Count > 0)
                    currentReceipt.IDGiaLoaiphong = Convert.ToInt32(ds1.Tables[0].Rows[0]["IDGiaLoaiphong"]);
                else
                {
                    MessageBox.Show("Chưa có bảng giá cho phòng " + Convert.ToString(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "TenPhong")) +
                        " vào khung giờ này. Mở phòng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                newIDHoadonXuat = new DataAccess().insertHoadonxuat(currentReceipt);
                if (newIDHoadonXuat > -1)
                {
                    //wait for databa is update
                    //ContactAction(0xbf, Convert.ToInt32(ds.Tables[0].Rows[0]["Congtac"]));
                    //open electric cb
                    //MessageBox.Show("Mở Phòng " + Convert.ToInt32(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "TenPhong")) +
                    //    " thành công", "Thông báo");
                    turnOnRoom.Enqueue(newRoom);
                        //update status for this Room
                        Phong updateRoom = new Phong();
                        updateRoom.IDPhong = newRoom;
                        updateRoom.IDLoaiPhong = Convert.ToInt32(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle,"IDLoaiPhong"));
                        updateRoom.TenPhong = Convert.ToString(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle,"TenPhong"));
                        updateRoom.Ghichu = Convert.ToString(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle,"Ghichu"));
                        updateRoom.Trangthai = true;
                        bool a = new DataAccess().updatePhong(updateRoom);
                        if (!a)
                        {
                            MessageBox.Show("Không cập nhật được trạng thái cho phòng " + updateRoom.TenPhong, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        //update current status gridview
                        gridViewRoom.SetFocusedRowCellValue(colRoomStatus, true);
                    //add chitietHDxuat
                        for (i = 0; i < newProduct.Rows.Count; i++)
                        {
                            ChitietHDXuat objCTHDX = new ChitietHDXuat();
                            objCTHDX.IDChitietHDXuat = -1;
                            objCTHDX.IDGiaxuat = Convert.ToInt32(newProduct.Rows[i]["IDGiaxuatSP"]);
                            objCTHDX.Giam = Convert.ToInt32(newProduct.Rows[i]["Giam"]);
                            objCTHDX.IDHoadonXuat = newIDHoadonXuat;
                            objCTHDX.IDSanpham = Convert.ToInt32(newProduct.Rows[i]["IDSanpham"]);
                            objCTHDX.Soluong = Convert.ToInt32(newProduct.Rows[i]["Soluong"]);
                            objCTHDX.Bep = false;
                            if (objCTHDX.Soluong > 0)
                            {
                                
                                int id = new DataAccess().insertChitietHDXuat(objCTHDX);
                                if (id < 0)
                                {
                                    MessageBox.Show("Lỗi Cơ sở dữ liệu!", "Lỗi");
                                    return;
                                }
                                else
                                    newProduct.Rows[i]["IDChitietHDXuat"] = id;
                            }
                        }
                }
                
                else
                {
                    MessageBox.Show("Mở Phòng " + Convert.ToInt32(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "TenPhong")) +
                        " không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            MessageBox.Show("Chuyển sản phẩm thành công", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public int TransferedRoomID()
        {
            return newRoom;
        }
        public int TransferedReceipt()
        {
            return newIDHoadonXuat;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateBillProduct();            
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            int i;

            for (i = 0; i < gridViewBillProduct.RowCount; i++)
            {
                gridViewBillProduct.SetRowCellValue(i, "Transfer", gridViewBillProduct.GetRowCellValue(i, "Soluong"));
                TransferDown(i);
            }
            gridBillProduct.DataSource = oldProduct;
            gridTransferedProductControlNew.DataSource = newProduct;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < gridViewTransferedProductNew.RowCount; i++)
            {
                gridViewTransferedProductNew.SetRowCellValue(i, "Transfer", gridViewTransferedProductNew.GetRowCellValue(i, "Soluong"));
                TransferUp(i);
            }
            gridBillProduct.DataSource = oldProduct;
            gridTransferedProductControlNew.DataSource = newProduct;
        }
        public int getNewOpenedRoom()
        {
            if (turnOnRoom.Count == 0)
                return -1;
            else
                return turnOnRoom.Dequeue();
        }

    }
}
