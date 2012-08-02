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
    public partial class frmListRoom : Form
    { 
        private int iCurrentFreeRoomID;
        private int iCurrentBusyRoomID;
        private int iCurrentFreeRoomGroupID;
        private int iCurrentBusyRoomGroupID;
        private int iCurrentReceiptID;
        private int iEffectedRoomID;
        private bool bNewReceipt;
        public frmListRoom()
        {
            InitializeComponent();
            initDataGrid();
            bNewReceipt = false;
            iCurrentFreeRoomID = -1;
            iCurrentBusyRoomID = -1;
            iCurrentFreeRoomGroupID = -1;
            iCurrentBusyRoomGroupID = -1;
            iCurrentReceiptID = -1;
            iEffectedRoomID = -1;
        }
        #region PublicAccess
        public bool getState()
        {
            return bNewReceipt;
        }
        public int getEffectedRoomID()
        {
            return iEffectedRoomID;
        }
        public int getEffectedReceiptID()
        {
            return iCurrentReceiptID;
        }
        #endregion
        #region FormLoad
        private void initDataGrid()
        {
                //get all Room
                DataSet dsRoom = new DataAccess().getAllFreePhongAndLoaiPhong(-1);
                gridRoom.DataSource = dsRoom.Tables[0];
                gridViewRoom.ExpandAllGroups();
                DataSet ds = new DataAccess().getAllBusyPhongAndLoaiPhong(-1);
                gridBusyRoom.DataSource = ds.Tables[0];
                gridViewBusyRoom.ExpandAllGroups();
                
        }
        #endregion
        
        #region local
        private void AddSPBD(int IDReceipt, int IDLoaiSP, int IDSanPham, string TenSP, int num)
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
                try
                {
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
                obj.Trangthai = false;
                int res = new DataAccess().insertChitietHDXuat(obj);
                if (res < 0)
                {
                    MessageBox.Show("Không thêm sản phẩm ban đầu vào hóa đơn hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


            }
        }
        private void Start()
        {
            //open or close selected room
            //first search if selected room is available
            DataSet ds = new DataAccess().getPhongByIDPhong(iCurrentFreeRoomID);

            if (ds.Tables[0].Rows.Count > 0)
            {
                iCurrentFreeRoomGroupID = Convert.ToInt32(ds.Tables[0].Rows[0]["IDLoaiphong"]);
                Hoadonxuat currentReceipt = new Hoadonxuat();
                    //in case of the room is available
                    //ask to open room and create new receipt for this room
                    if (MessageBox.Show("Bạn có muốn mở phòng " + Convert.ToString(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "TenPhong")) + "?", "Thông báo mở phòng", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                        return;
                    //get khuyen mai tang gio cua phong
                    DataSet dsKM = new DataAccess().getKhuyenmaiByIDLoaiPhong(iCurrentFreeRoomGroupID, DateTime.Now.Date);
                    //Hoadonxuat currentReceipt = new Hoadonxuat();
                    try
                    {
                        currentReceipt.Giam = Convert.ToInt32(dsKM.Tables[0].Rows[0]["Giam"]);
                    }
                    catch (Exception ex)
                    {
                        currentReceipt.Giam = 0;
                    }
                    currentReceipt.TenHoadon = Convert.ToString(ds.Tables[0].Rows[0]["TenPhong"]) + " " + DateTime.Now.ToString("dd/MM/yy-hh:mm");
                    currentReceipt.GioBD = DateTime.Now;
                    currentReceipt.GioKT = DateTime.Now;
                    currentReceipt.Tratruoc = 0;
                    currentReceipt.Nhacnho = false;
                    currentReceipt.IDPhong = iCurrentFreeRoomID;
                    currentReceipt.Ngayxuat = DateTime.Now.Date;
                    currentReceipt.Phuthu = 0;
                    currentReceipt.Thue = 0;
                    currentReceipt.Trangthai = 0;
                    currentReceipt.Thue = 0;
                    currentReceipt.Phuthu = 0;
                    currentReceipt.IDNhanvien = 0;
                    currentReceipt.IDNhanvienXuatHD = Program.IDNhanvien;
                    currentReceipt.IDKhachhang = 0;
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

                    DataSet ds1 = new DataAccess().getGiaLoaiPhongByIDLoaiPhongAndIDKhunggio(iCurrentFreeRoomGroupID, idkhunggio);
                    if (ds1.Tables[0].Rows.Count > 0)
                        currentReceipt.IDGiaLoaiphong = Convert.ToInt32(ds1.Tables[0].Rows[0]["IDGiaLoaiphong"]);
                    else
                    {
                        MessageBox.Show("Chưa có bảng giá cho phòng " + Convert.ToString(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "TenPhong")) +
                            " vào khung giờ này. Mở phòng không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    int res = new DataAccess().insertHoadonxuat(currentReceipt);
                    if (res > -1)
                    {
                        //wait for databa is update
                        //ContactAction(0xbf, Convert.ToInt32(ds.Tables[0].Rows[0]["Congtac"]));
                        //open electric cb
                        //MessageBox.Show("Mở Phòng " + Convert.ToInt32(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "TenPhong")) +
                        //    " thành công", "Thông báo");
                        iCurrentReceiptID = res;
                        iEffectedRoomID = iCurrentFreeRoomID;
                        //add starting product for the room
                        DataSet dsSPBD = new DataAccess().getAllSPBandauIDLoaiPhong(Convert.ToInt32(ds.Tables[0].Rows[0]["IDLoaiPhong"]));
                        for (i = 0; i < dsSPBD.Tables[0].Rows.Count; i++)
                        {
                            int IDSanPham = Convert.ToInt32(dsSPBD.Tables[0].Rows[i]["IDSanPham"]);
                            int IDLoaiSP = Convert.ToInt32(dsSPBD.Tables[0].Rows[i]["IDNhomSP"]);
                            string TenSanPham = Convert.ToString(dsSPBD.Tables[0].Rows[i]["TenSanPham"]);
                            int num = Convert.ToInt32(dsSPBD.Tables[0].Rows[i]["Soluong"]);
                            AddSPBD(res, IDLoaiSP, IDSanPham, TenSanPham, num);
                        }
                        bNewReceipt = true;
                        //update Hoadon group display
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
                            //update current status gridview
                            initDataGrid();

                        //return ro main
                        this.Hide();
                        //btnStart.Image = Karaoke.Properties.Resources.Status_user_busy_icon1;
                    }
                    else
                    {
                        MessageBox.Show("Mở Hóa đơn mới " + Convert.ToInt32(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "TenPhong")) +
                            " không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                
            }
        }
        private void getBusyReceipt()
        {
            iEffectedRoomID = iCurrentBusyRoomID;
        }
        #endregion
        private void gridViewRoom_DoubleClick(object sender, EventArgs e)
        {
            //Start();
            iEffectedRoomID = iCurrentFreeRoomID;
            this.Hide();
        }

        private void gridViewRoom_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            iCurrentFreeRoomID = Convert.ToInt32(gridViewRoom.GetRowCellValue(gridViewRoom.FocusedRowHandle, "IDPhong"));
        }

        private void gridViewBusyRoom_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            iCurrentBusyRoomID = Convert.ToInt32(gridViewBusyRoom.GetRowCellValue(gridViewBusyRoom.FocusedRowHandle, "IDPhong"));
        }

        private void gridViewBusyRoom_DoubleClick(object sender, EventArgs e)
        {
            iEffectedRoomID = iCurrentBusyRoomID;
            this.Hide();
        }

        private void gridViewBusyRoom_DoubleClick_1(object sender, EventArgs e)
        {
            iEffectedRoomID = iCurrentBusyRoomID;
            this.Hide();
        }


    }

}
