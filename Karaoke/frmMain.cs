using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BKIT.Entities;
using System.Net.Mail;
using BKIT.Model;
namespace Karaoke
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
            loadSkin("Style.txt");
            MDIForms.frmLogin login = new MDIForms.frmLogin();
            login.ShowDialog();
            setAuthority();
            UnLoadForm();
            if (btnReceipt.Enabled)
                btnReceipt_ItemClick(null, null);
        }
        #region LoadForm function
        private void LoadForm(Form frmIsLoaded)
        {
            bool isLoaded = false;
            foreach (Form child in MdiChildren)
            {
                if (child.Text == frmIsLoaded.Text)
                {
                    isLoaded = true;
                    frmIsLoaded = child;
                    break;
                }
            }

            if (!isLoaded)
            {
                frmIsLoaded.MdiParent = this;
                frmIsLoaded.Show();
            }
            else
            {
                frmIsLoaded.Activate();
            }
        }
        #endregion
        private void setAuthority()
        {
            if (Program.isLogin)
            {
                this.btnLogIn.Enabled = false;
                this.btnLogOut.Enabled = true;
            }
            else
            {
                this.btnLogIn.Enabled = true;
                this.btnLogOut.Enabled = false;
            }
            DataAccess da = new DataAccess();
            QuyenTruycap objQuyenTruycap = new QuyenTruycap();
            DataSet ds = null;
            this.btnProduct.Enabled = false;
            this.btnEmployee.Enabled = false;
            this.btnRoom.Enabled = false;
            this.btnInvoice.Enabled = false;
            this.btnAddInvoice.Enabled = false;
            this.btnTonKho.Enabled = false;
            this.btnReceipt.Enabled = false;
            this.btnReport.Enabled = false;
            this.btnChart.Enabled = false;
            this.btnSetting.Enabled = false;
            if (Program.userLevel == Level.Admin)
            {
                ds = new DataAccess().getQuyenTruycapByDate("", "Quản lý");
            }
            else if (Program.userLevel == Level.User)
            {
                ds = new DataAccess().getQuyenTruycapByDate("", "Người dùng");
            }
            else if (Program.userLevel == Level.Guest)
            {
                ds = new DataAccess().getQuyenTruycapByDate("", "Khách");
            }
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                objQuyenTruycap.Ngaythietlap = Convert.ToDateTime(ds.Tables[0].Rows[0]["Ngaythietlap"]);
                objQuyenTruycap.TenLoaiNV = Convert.ToString(ds.Tables[0].Rows[0]["TenLoaiNV"]);
                objQuyenTruycap.Vanhanh = Convert.ToInt32(ds.Tables[0].Rows[0]["Vanhanh"]);
                objQuyenTruycap.HoadonNhap = Convert.ToInt32(ds.Tables[0].Rows[0]["HoadonNhap"]);
                objQuyenTruycap.Setting = Convert.ToInt32(ds.Tables[0].Rows[0]["Setting"]);
                objQuyenTruycap.Nhanvien = Convert.ToInt32(ds.Tables[0].Rows[0]["Nhanvien"]);
                objQuyenTruycap.HoadonxuatSP = Convert.ToInt32(ds.Tables[0].Rows[0]["HoadonxuatSP"]);
                objQuyenTruycap.Sanpham = Convert.ToInt32(ds.Tables[0].Rows[0]["Sanpham"]);
                objQuyenTruycap.Phong = Convert.ToInt32(ds.Tables[0].Rows[0]["Phong"]);
                objQuyenTruycap.Report = Convert.ToInt32(ds.Tables[0].Rows[0]["Report"]);
                objQuyenTruycap.Khachhang = Convert.ToInt32(ds.Tables[0].Rows[0]["Khachhang"]);
                objQuyenTruycap.Khuyenmai = Convert.ToInt32(ds.Tables[0].Rows[0]["Khuyenmai"]);
                objQuyenTruycap.Tonkho = Convert.ToInt32(ds.Tables[0].Rows[0]["Tonkho"]);
                this.btnEmployee.Enabled = (objQuyenTruycap.Nhanvien == 1);
                this.btnTonKho.Enabled = (objQuyenTruycap.Tonkho == 1);
                this.btnReport.Enabled = (objQuyenTruycap.Report == 1);
                this.btnReceipt.Enabled = (objQuyenTruycap.Vanhanh == 1);//Van hanh
                this.btnAddInvoice.Enabled = (objQuyenTruycap.HoadonNhap == 1);
                this.btnInvoice.Enabled = (objQuyenTruycap.HoadonNhap == 1);
                this.btnRoom.Enabled = (objQuyenTruycap.Phong == 1);
                this.btnProduct.Enabled = (objQuyenTruycap.Sanpham == 1);
                this.btnSetting.Enabled = (objQuyenTruycap.Setting == 1);
                this.btnChart.Enabled = (objQuyenTruycap.HoadonxuatSP == 1);
            }
        }
        private void UnLoadForm()
        {
            DataAccess da = new DataAccess();
            QuyenTruycap objQuyenTruycap = new QuyenTruycap();
            DataSet ds = null;
            switch (Program.userLevel)
            {
                case Level.Admin:
                    //Do nothing
                    break;
                case Level.User:
                    //UnLoad all admin forms
                    ds = new DataAccess().getQuyenTruycapByDate("", "Người dùng");
                    break;
                case Level.Guest:
                    //UnLoad all admin and User forms
                    ds = new DataAccess().getQuyenTruycapByDate("", "Khách");
                    //foreach (Form child in MdiChildren)
                    //{
                    //    if (child.Text == "Nhân viên" || child.Text == "Thống kê Tồn kho"
                    //        || child.Text == "Thống kê" || child.Text == "Quản lý Hóa đơn"
                    //        || child.Text == "Thêm Hóa đơn nhập" || child.Text == "Hóa đơn nhập hàng"
                    //        || child.Text == "Quản lý Phòng" || child.Text == "Quản lý Sản phẩm")
                    //    {
                    //        child.Close();
                    //    }
                    //}
                    break;
                default:
                    break;
            }
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                objQuyenTruycap.Ngaythietlap = Convert.ToDateTime(ds.Tables[0].Rows[0]["Ngaythietlap"]);
                objQuyenTruycap.TenLoaiNV = Convert.ToString(ds.Tables[0].Rows[0]["TenLoaiNV"]);
                objQuyenTruycap.Vanhanh = Convert.ToInt32(ds.Tables[0].Rows[0]["Vanhanh"]);
                objQuyenTruycap.HoadonNhap = Convert.ToInt32(ds.Tables[0].Rows[0]["HoadonNhap"]);
                objQuyenTruycap.Setting = Convert.ToInt32(ds.Tables[0].Rows[0]["Setting"]);
                objQuyenTruycap.Nhanvien = Convert.ToInt32(ds.Tables[0].Rows[0]["Nhanvien"]);
                objQuyenTruycap.HoadonxuatSP = Convert.ToInt32(ds.Tables[0].Rows[0]["HoadonxuatSP"]);
                objQuyenTruycap.Sanpham = Convert.ToInt32(ds.Tables[0].Rows[0]["Sanpham"]);
                objQuyenTruycap.Phong = Convert.ToInt32(ds.Tables[0].Rows[0]["Phong"]);
                objQuyenTruycap.Report = Convert.ToInt32(ds.Tables[0].Rows[0]["Report"]);
                objQuyenTruycap.Khachhang = Convert.ToInt32(ds.Tables[0].Rows[0]["Khachhang"]);
                objQuyenTruycap.Khuyenmai = Convert.ToInt32(ds.Tables[0].Rows[0]["Khuyenmai"]);
                objQuyenTruycap.Tonkho = Convert.ToInt32(ds.Tables[0].Rows[0]["Tonkho"]);
                foreach (Form child in MdiChildren)
                {
                    if (child.Text == "Quản lý nhân viên" && objQuyenTruycap.Nhanvien == 0)
                        child.Close();
                    if (child.Text == "Thống kê Tồn kho" && objQuyenTruycap.Tonkho == 0)
                        child.Close();
                    if (child.Text == "Thống kê" && objQuyenTruycap.Report == 0)
                        child.Close();
                    if (child.Text == "Quản lý Hóa đơn" && objQuyenTruycap.Vanhanh == 0)//Van hanh
                        child.Close();
                    if (child.Text == "Thêm Hóa đơn nhập" && objQuyenTruycap.HoadonNhap == 0)
                        child.Close();
                    if (child.Text == "Hóa đơn nhập hàng" && objQuyenTruycap.HoadonNhap == 0)
                        child.Close();
                    if (child.Text == "Quản lý Phòng" && objQuyenTruycap.Phong == 0)
                        child.Close();
                    if (child.Text == "Quản lý Sản phẩm" && objQuyenTruycap.Sanpham == 0)
                        child.Close();
                    if (child.Text == "Cài đặt" && objQuyenTruycap.Setting == 0)
                        child.Close();
                    if (child.Text == "Biểu đồ" && objQuyenTruycap.HoadonxuatSP == 0)
                        child.Close();
                }
            }
        }
        #region Skin Functions
        private void cboSkin_EditValueChanged(object sender, EventArgs e)
        {
            dfLookAndFeel.LookAndFeel.SkinName = cboSkin.EditValue.ToString();
            saveSkin("Style.txt");
        }
        private void saveSkin(string filePath)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filePath);
                writer.WriteLine(dfLookAndFeel.LookAndFeel.ActiveSkinName);
            }
            catch (Exception) { }
            finally
            {
                writer.Close();
            }
        }
        private void loadSkin(string filePath)
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                dfLookAndFeel.LookAndFeel.SkinName = reader.ReadLine().Trim();
            }
            catch (Exception)
            {
                dfLookAndFeel.LookAndFeel.SetDefaultStyle();
            }
            finally
            {
                reader.Close();
            }
        }
        #endregion

        public void setStatus(string message)
        {
            status.Caption = message;
        }

        private void btnProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new MDIForms.frmProduct());
        }

        private void btnEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //LoadForm(new MDIForms.frmEmployee());
            LoadForm(new MDIForms.frmEmployeeManager());
        }

        private void btnRoom_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new MDIForms.frmRoom());
        }

        private void btnReceipt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new MDIForms.frmReceipt());
        }

        private void btnInvoice_CheckedChanged(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new MDIForms.frmInvoice());
        }

        private void btnAddInvoice_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MDIForms.frmAddHoaDonNhap fAddHoaDonNhap = new Karaoke.MDIForms.frmAddHoaDonNhap();
            fAddHoaDonNhap.ShowDialog();
        }

        private void btnTonKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new MDIForms.frmTonKho());
        }

        private void btnReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new MDIForms.frmReport());
        }

        private void btnLogIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MDIForms.frmLogin login = new MDIForms.frmLogin();
            login.ShowDialog();
            setAuthority();
            UnLoadForm();
        }

        private void btnLogOut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Program.isLogin = false;
            Program.userLevel = Level.Guest;
            Program.username = "Guest";
            Program.password = "123";
            MDIForms.frmLogin login = new MDIForms.frmLogin();
            login.ShowDialog();
            setAuthority();
            UnLoadForm();
        }

        private void btnChart_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new MDIForms.frmChart());
        }

        private void btnSetting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new MDIForms.frmSystemSettings());
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            //Submit E-Mail on click of Button
            MailMessage theMailMessage = new MailMessage("phammemkaraoke@gmail.com", "tonthatdaihai@gmail.com");
            
            try
            {
                //Build body of text
                string message1 = "Hello" + Environment.NewLine;  // Text in textBox
                message1 += "Custom Text:  Testing" + Environment.NewLine;  // Custom Text And Text in comboBox
                message1 += "" + Environment.NewLine;  // Blank Line

                //Set the property of the message body and subject body
                
                theMailMessage.IsBodyHtml = true;
                theMailMessage.Body = message1;
                //Add attachments in listBox (Note, entire file location is listed in the listbox in this example) (This is not necessary if attachments are not applicable)
                //foreach (string item in listBox2.Items)
                //{
                //    theMailMessage.Attachments.Add(new Attachment(item));
                //}
                theMailMessage.Subject = "Testing E-Mail ";  // Subject is a Custom Text and the text from a label

                //E-Mail Credentials and Sending
                SmtpClient theClient = new SmtpClient("smtp.gmail.com");
                System.Net.NetworkCredential theCredential = new
                System.Net.NetworkCredential("phanmemkaraoke@gmail.com", "phanmemkaraoke");
                theClient.Credentials = theCredential;
                theClient.UseDefaultCredentials = false;
                theClient.EnableSsl = false;
                theClient.Port = 25;
                theClient.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;
                theClient.Send(theMailMessage);

                MessageBox.Show("E-Mail Sent Successfully!" + Environment.NewLine + "Thank You", "Confirmation",
                MessageBoxButtons.OK);
            }
            catch (SmtpException smtpex)
            {
                MessageBox.Show("An error occured when trying to send a mail.  You appear to be disconnected from the Internet.  Please confirm that you are connected to the Internet and Resubmit the data.  " + smtpex.Message);
            }

            catch (System.Exception ex)
            {
                MessageBox.Show("An unexpected error occured. " + ex.Message);
            }


        }

        private void btnItemDieuChinhTonKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new MDIForms.frmDieuChinhTonKho());
        }

        private void btnReceiptProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
			LoadForm(new MDIForms.frmReceiptProduct());
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnVanDe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadForm(new MDIForms.frmThongKeSuCo());
        }
    }
}
