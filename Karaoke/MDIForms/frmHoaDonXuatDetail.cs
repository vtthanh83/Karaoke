using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BKIT.Model;
using DevExpress.XtraGrid.Views.Grid;
using System.IO.Ports;
using System.IO;
using BKIT.Entities;
using Karaoke.DataSets;

namespace Karaoke.MDIForms
{
    public partial class frmHoaDonXuatDetail : Form
    {
        private int iCurrentReceiptID = -1;
        public frmHoaDonXuatDetail()
        {
            InitializeComponent();
        }
        public frmHoaDonXuatDetail(int IDHoadon)
        {
            InitializeComponent();
            DataSet ds = new DataAccess().getAllIDandNameNhanvien();
            cboEmployee.DataSource = ds.Tables[0];
            cboEmployee.DisplayMember = "Ten";
            cboEmployee.ValueMember = "IDNhanvien";
            updateBillDisplay(IDHoadon);
            iCurrentReceiptID = IDHoadon;
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
                return false;
            }
            DataSet dsBill = new DataAccess().getHoadonxuatByIDHoadonXuat(IDHoadon);
            
            if (dsBill == null)
            {
                MessageBox.Show("Không có Hóa đơn mã số " + IDHoadon.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //get room price
            DataSet dsPrice = new DataAccess().getGiaLoaiPhongByIDGiaLoaiPhong(Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDGiaLoaiphong"]));
            if (dsPrice.Tables[0].Rows.Count <= 0)
            {
                //MessageBox.Show("Không có giá niêm iết cho hóa đơn mã số " + IDHoadon.ToString(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //get room 
            DataSet dsRoom = new DataAccess().getPhongByIDPhong(Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDPhong"]));
            if (dsRoom.Tables[0].Rows.Count <= 0)
            {
                MessageBox.Show("Không có phòng theo yêu cầu" , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //check the status of this Bill
            // 0 : is open //1: is close //2: could not modify
            int status = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Trangthai"]);
            //get current Bill
            txtDate.Text = Convert.ToDateTime(dsBill.Tables[0].Rows[0]["Ngayxuat"]).ToShortDateString();
            
            int roomMoney = 0;
            if (status == 0)
            {
                //new bill



                cboEmployee.SelectedValue = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDNhanvien"]);
                txtReduce.Text = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Giam"]).ToString("###,###,##0");
                txtTax.Text = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Thue"]).ToString("##0");
                txtExtra.Text = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Phuthu"]).ToString("###,###,##0");
                txtRoom.Text = Convert.ToString(dsRoom.Tables[0].Rows[0]["TenPhong"]);
                txtRoomPrice.Text = Convert.ToString(dsPrice.Tables[0].Rows[0]["Gia"]);
                string strtime = "Ngày " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["Ngayxuat"]).ToShortDateString();
                strtime = strtime + " - Bắt đầu lúc " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]).ToShortTimeString();
                txtTime.Text = strtime;
                TimeSpan ts = DateTime.Now.TimeOfDay.Subtract(Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]).TimeOfDay);
                int playmin = ts.Hours * 60 + ts.Minutes;
                roomMoney = Convert.ToInt32(txtRoomPrice.Text) * playmin / 60;
                txtHourMoney.Text = roomMoney.ToString("###,###,##0");
            }
            else
            {
                //old bill
                cboEmployee.SelectedValue = Convert.ToInt32(dsBill.Tables[0].Rows[0]["IDNhanvien"]);
                txtReduce.Text = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Giam"]).ToString("###,###,##0");
                txtTax.Text = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Thue"]).ToString("##0");
                txtExtra.Text = Convert.ToInt32(dsBill.Tables[0].Rows[0]["Phuthu"]).ToString("###,###,##0");
                txtRoom.Text = Convert.ToString(dsRoom.Tables[0].Rows[0]["TenPhong"]);
                txtRoomPrice.Text = Convert.ToString(dsPrice.Tables[0].Rows[0]["Gia"]);
                string strtime = "Ngày " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["Ngayxuat"]).ToShortDateString();
                strtime = strtime + " - Bắt đầu: " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]).ToShortTimeString();
                strtime = strtime + " - Kết thúc: " + Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioKT"]).ToShortTimeString();
                txtTime.Text = strtime;
                TimeSpan ts = Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioKT"]).TimeOfDay.Subtract(Convert.ToDateTime(dsBill.Tables[0].Rows[0]["GioBD"]).TimeOfDay);
                int playmin = ts.Hours * 60 + ts.Minutes;
                roomMoney = Convert.ToInt32(txtRoomPrice.Text) * playmin / 60;
                txtHourMoney.Text = roomMoney.ToString("###,###,###,##0");
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
            totalBill = roomMoney + productMoney + Convert.ToInt32(txtExtra.Text) - Convert.ToInt32(txtReduce.Text);
            totalBill = Convert.ToInt32(totalBill + totalBill * Convert.ToInt32(txtTax.Text) / 100);
            txtBilltotal.Text = totalBill.ToString("###,###,###,##0");
            return true;
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
                    dr1["Soluong"] = dsSP.Tables[0].Rows[i]["Soluong"].ToString();
                    dr1["ThanhTien"] = Convert.ToDecimal(dsSP.Tables[0].Rows[i]["Thanhtien"]).ToString("###,###,###,###");

                    dsBill.Tables["RDatadetail"].Rows.Add(dr1);
                }
                DataRow dr2 = dsBill.Tables["RDatadetail"].NewRow();
                dr2["STT"] = (i + 2).ToString();
                dr2["TenSanPham"] = "Tiền phòng";
                dr2["DVT"] = ("Giờ").ToString();
                dr2["DonGia"] = txtRoomPrice.Text;
                TimeSpan ts = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioKT"]).
                    TimeOfDay.Subtract(Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioBD"]).TimeOfDay);
                double playmin = ts.Hours + Convert.ToDouble(ts.Minutes) / 60;
                dr2["Soluong"] = playmin.ToString("##.00");
                dr2["ThanhTien"] = txtHourMoney.Text;
                dsBill.Tables["RDatadetail"].Rows.Add(dr2);

                DataRow dr3 = dsBill.Tables["RDatadetail"].NewRow();
                dr3["STT"] = (i + 3).ToString();
                dr3["TenSanPham"] = "Phụ thu";
                //dr3["DVT"] = ("").ToString();
                dr3["DonGia"] = txtExtra.Text;
                dr3["Soluong"] = "1";
                dr3["ThanhTien"] = txtExtra.Text;
                dsBill.Tables["RDatadetail"].Rows.Add(dr3);

                DataRow dr4 = dsBill.Tables["RDatadetail"].NewRow();
                dr4["STT"] = (i + 4).ToString();
                dr4["TenSanPham"] = "Thuế";
                dr4["DVT"] = ("%").ToString();
                // dr4["DonGia"] = "Phần Trăm";
                dr4["Soluong"] = txtTax.Text;
                if (txtBilltotal.Text == "")
                {
                    dr4["ThanhTien"] = "0";
                }
                else
                {
                    dr4["ThanhTien"] = (Convert.ToDouble(txtBilltotal.Text) * Convert.ToDouble(txtTax.Text) /
                        (100 + Convert.ToDouble(txtTax.Text))).ToString("###,###,##0");
                }
                dsBill.Tables["RDatadetail"].Rows.Add(dr4);
                //read Company Information form file
                StreamReader reader = null;
                string strCompanyName = "";
                string strCompanyAddress = "";
                string strCompanyPhone = "";
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
                                break;
                            case "[BAUDRATE]":
                                break;
                            case "[STOPBITS]":
                                break;
                            case "[PARITY]":
                                break;
                            case "[DATABITS]":
                                break;
                            case "[CompanyName]":
                                strCompanyName = Convert.ToString(data);
                                break;
                            case "[Address]":
                                strCompanyAddress = Convert.ToString(data);
                                break;
                            case "[Phone]":
                                strCompanyPhone = Convert.ToString(data);
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
                DataRow dr = dsBill.Tables["HeaderData"].NewRow();
                dr["Ngayxuat"] = txtTime.Text;
                dr["Phong"] = txtRoom.Text;
                dr["GiaPhong"] = txtRoomPrice.Text;
                dr["HoadonID"] = iCurrentReceiptID.ToString();
                dr["GioBD"] = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioBD"]).ToShortTimeString();
                dr["GioKT"] = Convert.ToDateTime(dsHD.Tables[0].Rows[0]["GioKT"]).ToShortTimeString();
                dr["Nhanvien"] = cboEmployee.Text;
                dr["Thue"] = txtTax.Text;
                dr["Tiengiam"] = txtReduce.Text;
                dr["Phuthu"] = txtExtra.Text;
                dr["Tiengio"] = txtHourMoney.Text;
                dr["Tienhang"] = txtProductMoney.Text;
                dr["Tongcong"] = txtBilltotal.Text;
                dr["TenCongTy"] = strCompanyName;
                dr["DiaChi"] = "ĐC: " + strCompanyAddress;
                dr["SoDT"] = "ĐT: " + strCompanyPhone;
                dsBill.Tables["HeaderData"].Rows.Add(dr);

                if (dsBill != null)
                {
                    frmViewReport frmView = new frmViewReport(dsBill);
                    frmView.Show();
                }
            }
        }
    }
}
