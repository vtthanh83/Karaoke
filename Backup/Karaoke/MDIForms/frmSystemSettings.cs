using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BKIT.Entities;
using BKIT.Model;
using System.Drawing.Printing;

namespace Karaoke.MDIForms
{
    public partial class frmSystemSettings : DevExpress.XtraEditors.XtraForm
    {
        public frmSystemSettings()
        {
            InitializeComponent();

        }

        public void UpdateSetting(Setting objSetting)
        {
            dateNgayCaidat.Text = Convert.ToString(objSetting.Ngay);
            txtTenCT.Text = objSetting.TenCT;
            txtPhone.Text = objSetting.Phone;
            txtMobile.Text = objSetting.Mobile;
            txtDiachi.Text = objSetting.Diachi;
            txtEmail.Text = objSetting.Email;
            txtKhuyenMai.Text = objSetting.Khuyenmai;
            txtLoiChao.Text = objSetting.Loichao1;
            txtThongBao.Text = objSetting.Loichao2;
            cboMayInBep.Text = objSetting.MayInBep;
            cboMayInKho.Text = objSetting.MayInKho;
            cboMayInHD.Text = objSetting.MayInHoadon;
        }
        public void UpdateQuyenTruycap(QuyenTruycap objQuyenTruycap)
        {
            dateNgaythietlap.Text = Convert.ToString(objQuyenTruycap.Ngaythietlap);
            cboxTenLoaiNV.Text = objQuyenTruycap.TenLoaiNV;
            ckboxVanhanh.Checked = Convert.ToBoolean(objQuyenTruycap.Vanhanh);
            ckboxHoadonNhap.Checked = Convert.ToBoolean(objQuyenTruycap.HoadonNhap);
            ckboxSetting.Checked = Convert.ToBoolean(objQuyenTruycap.Setting);
            ckboxNhanvien.Checked = Convert.ToBoolean(objQuyenTruycap.Nhanvien);
            ckboxHoadonxuat.Checked = Convert.ToBoolean(objQuyenTruycap.HoadonxuatSP);
            ckboxSanpham.Checked = Convert.ToBoolean(objQuyenTruycap.Sanpham);
            ckboxPhong.Checked = Convert.ToBoolean(objQuyenTruycap.Phong);
            ckboxReport.Checked = Convert.ToBoolean(objQuyenTruycap.Report);
            ckboxKhachhang.Checked = Convert.ToBoolean(objQuyenTruycap.Khachhang);
            ckboxKhuyenmai.Checked = Convert.ToBoolean(objQuyenTruycap.Khuyenmai);
            ckboxTonkho.Checked = Convert.ToBoolean(objQuyenTruycap.Tonkho);

        }
        public void Load_Setting(string dt)
        {
            if (dt == "")
            {
                //load last setting
                DataSet ds = new DataAccess().getSettingByDate(dt);
                Setting objSetting = new Setting();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    objSetting.Ngay = Convert.ToDateTime(ds.Tables[0].Rows[0]["Ngay"]);
                    objSetting.TenCT = Convert.ToString(ds.Tables[0].Rows[0]["TenCT"]);
                    objSetting.Phone = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]);
                    objSetting.Mobile = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]);
                    objSetting.Diachi = Convert.ToString(ds.Tables[0].Rows[0]["Diachi"]);
                    objSetting.Email = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                    objSetting.Khuyenmai = Convert.ToString(ds.Tables[0].Rows[0]["Khuyenmai"]);
                    objSetting.Loichao1 = Convert.ToString(ds.Tables[0].Rows[0]["Loichao1"]);
                    objSetting.Loichao2 = Convert.ToString(ds.Tables[0].Rows[0]["Loichao2"]);
                    objSetting.MayInBep = Convert.ToString(ds.Tables[0].Rows[0]["MayInBep"]);
                    objSetting.MayInKho = Convert.ToString(ds.Tables[0].Rows[0]["MayInKho"]);
                    objSetting.MayInHoadon = Convert.ToString(ds.Tables[0].Rows[0]["MayInHoadon"]);
                    UpdateSetting(objSetting);
                }
            }
            else
            {
                //load setting by date
                if (new DataAccess().IsSetting(dt))
                {
                    //update setting
                    DataSet ds = new DataAccess().getSettingByDate(dt);
                    Setting objSetting = new Setting();
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        objSetting.Ngay = Convert.ToDateTime(dt);
                        objSetting.TenCT = Convert.ToString(ds.Tables[0].Rows[0]["TenCT"]);
                        objSetting.Phone = Convert.ToString(ds.Tables[0].Rows[0]["Phone"]);
                        objSetting.Mobile = Convert.ToString(ds.Tables[0].Rows[0]["Mobile"]);
                        objSetting.Diachi = Convert.ToString(ds.Tables[0].Rows[0]["Diachi"]);
                        objSetting.Email = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                        objSetting.Khuyenmai = Convert.ToString(ds.Tables[0].Rows[0]["Khuyenmai"]);
                        objSetting.Loichao1 = Convert.ToString(ds.Tables[0].Rows[0]["Loichao1"]);
                        objSetting.Loichao2 = Convert.ToString(ds.Tables[0].Rows[0]["Loichao2"]);
                        objSetting.MayInBep = Convert.ToString(ds.Tables[0].Rows[0]["MayInBep"]);
                        objSetting.MayInKho = Convert.ToString(ds.Tables[0].Rows[0]["MayInKho"]);
                        objSetting.MayInHoadon = Convert.ToString(ds.Tables[0].Rows[0]["MayInHoadon"]);
                        UpdateSetting(objSetting);
                    }
                }
                else
                {
                    //insert new setting
                    Setting objSetting = new Setting();
                    objSetting.Ngay = Convert.ToDateTime(dt);
                    objSetting.TenCT = "";
                    objSetting.Phone = "";
                    objSetting.Mobile = "";
                    objSetting.Diachi = "";
                    objSetting.Email = "";
                    objSetting.Khuyenmai = "";
                    objSetting.Loichao1 = "";
                    objSetting.Loichao2 = "";
                    objSetting.MayInBep = "";
                    objSetting.MayInKho = "";
                    objSetting.MayInHoadon = "";
                    UpdateSetting(objSetting);
                }
            }
        }
        public void Load_Quyentruycap(string dt, string tenloainhanvien)
        {

            if (dt == "")
            {
                //load last setting quyen truy cap

                DataSet ds = new DataAccess().getQuyenTruycapByDate(dt, tenloainhanvien);
                QuyenTruycap objQuyenTruycap = new QuyenTruycap();
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
                    UpdateQuyenTruycap(objQuyenTruycap);
                }
            }
            else
            {
                //load setting quyen truy cap by date
                if (new DataAccess().IsSettingQuyenTruycap(dt, tenloainhanvien))
                {
                    //update setting
                    DataSet ds = new DataAccess().getQuyenTruycapByDate(dt, tenloainhanvien);
                    QuyenTruycap objQuyenTruycap = new QuyenTruycap();
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        objQuyenTruycap.Ngaythietlap = Convert.ToDateTime(dt);
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
                        UpdateQuyenTruycap(objQuyenTruycap);
                    }
                }
                else
                {
                    //insert new setting
                    QuyenTruycap objQuyenTruycap = new QuyenTruycap();
                    objQuyenTruycap.Ngaythietlap = Convert.ToDateTime(dt);
                    objQuyenTruycap.TenLoaiNV = "";
                    objQuyenTruycap.Vanhanh = 0;
                    objQuyenTruycap.HoadonNhap = 0;
                    objQuyenTruycap.Setting = 0;
                    objQuyenTruycap.Nhanvien = 0;
                    objQuyenTruycap.HoadonxuatSP = 0;
                    objQuyenTruycap.Sanpham = 0;
                    objQuyenTruycap.Phong = 0;
                    objQuyenTruycap.Report = 0;
                    objQuyenTruycap.Khachhang = 0;
                    objQuyenTruycap.Khuyenmai = 0;
                    objQuyenTruycap.Tonkho = 0;
                    UpdateQuyenTruycap(objQuyenTruycap);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Setting objSetting = new Setting();
            

            //load setting quyen truy cap by date
            //if (new DataAccess().IsSetting(dateNgayCaidat.Text))
            //{
                //update setting
            //    DataSet ds = new DataAccess().getSettingByDate(dateNgayCaidat.Text);
            //    objSetting.IDSetting = Convert.ToInt32(ds.Tables[0].Rows[0]["IDSetting"]);
            //    objSetting.Ngay = Convert.ToDateTime(dateNgayCaidat.Text);
            //    objSetting.TenCT = txtTenCT.Text;
            //    objSetting.Phone = txtPhone.Text;
            //    objSetting.Mobile = txtMobile.Text;
            //    objSetting.Diachi = txtDiachi.Text;
            //    objSetting.Email = txtEmail.Text;
            //    objSetting.Khuyenmai = txtKhuyenMai.Text;
            //    objSetting.Loichao1 = txtLoiChao.Text;
            //    objSetting.Loichao2 = txtThongBao.Text;
            //    if (new DataAccess().updateSetting(objSetting) == true)
            //    {
            //        ((frmMain)(this.MdiParent)).setStatus("Cập nhật Cài đặt thành công");
            //    }
            //    else
            //    {
            //        MessageBox.Show(this, "Cập nhật Cài đặt không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
           // else
            {
                //insert new setting
                objSetting.Ngay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second); 
                //if (DateTime.Compare(objSetting.Ngay, DateTime.Now) < 0) // ngay earlier than now
                //{
                //    MessageBox.Show(this, "Nhập sai ngày", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    Load_Setting("");
                //    return;
                //}
                objSetting.TenCT = txtTenCT.Text;
                if (objSetting.TenCT == "")
                {
                    MessageBox.Show(this, "Bạn không nhập tên chương trình?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                objSetting.Phone = txtPhone.Text;
                if (objSetting.Phone == "")
                {
                    MessageBox.Show(this, "Bạn không nhập số điện thoại bàn?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                }
                else
                {
                    try
                    {
                        Int64.Parse(objSetting.Phone);
                    }
                    catch// (Exception ex)
                    {
                        MessageBox.Show(this, "Số điện thoại bàn nhập không hợp lệ!", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        return;
                    }
                }

                objSetting.Mobile = txtMobile.Text;
                if (objSetting.Mobile == "")
                {
                    MessageBox.Show(this, "Bạn không nhập số điện thoại di động?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        Int64.Parse(objSetting.Mobile);
                        //kiem tra tinh hop le cua so dien thoai di dong, neu can
                    }
                    catch// (Exception ex)
                    {
                        MessageBox.Show(this, "Số điện thoại di động nhập không hợp lệ!", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        return;
                    }


                }
                objSetting.Diachi = txtDiachi.Text;
                if (objSetting.Diachi == "")
                {
                    if (!(MessageBox.Show(this, "Bạn không nhập địa chỉ?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes))
                    {
                        return;
                    }
                }
                objSetting.Email = txtEmail.Text;
                if (objSetting.Email == "")
                {
                    MessageBox.Show(this, "Bạn không nhập địa chỉ email?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                }
                objSetting.Khuyenmai = txtKhuyenMai.Text;
                objSetting.Loichao1 = txtLoiChao.Text;
                objSetting.Loichao2 = txtThongBao.Text;
                objSetting.MayInBep = cboMayInBep.Text;
                objSetting.MayInKho = cboMayInKho.Text;
                objSetting.MayInHoadon = cboMayInHD.Text;
                if (new DataAccess().insertSetting(objSetting) >= 0)
                {
                    ((frmMain)(this.MdiParent)).setStatus("Thêm mới Cài đặt thành công");
                    Load_Setting("");
                }
                else
                {
                    MessageBox.Show(this, "Thêm mới Cài đặt không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //load setting quyen truy cap by date

            Setting objSetting = new Setting();

            if (new DataAccess().IsSetting(dateNgayCaidat.Text))
            {
                //setting
                if (MessageBox.Show(this, "Bạn có muốn xóa cài đặt này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    DataSet ds = new DataAccess().getSettingByDate(dateNgayCaidat.Text);
                    objSetting.IDSetting = Convert.ToInt32(ds.Tables[0].Rows[0]["IDSetting"]);
                    if (new DataAccess().deleteSetting(objSetting) == true)
                    {
                        ((frmMain)(this.MdiParent)).setStatus("Xóa Cài đặt thành công");
                        Load_Setting("");
                    }
                    else
                    {
                        MessageBox.Show(this, "Xóa Cài đặt không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ((frmMain)(this.MdiParent)).setStatus("");
                    }
                }
            }
            else
            {
                //do nothing
            }

            
        }

        private void frmSystemSettings_Load(object sender, EventArgs e)
        {
            int i = 0;

            listAllPrinters();
            Load_Setting("");
            Load_Quyentruycap("", "");
            DataSet ds = new DataAccess().getAllLoaiNhanvien();
            for (i = 0; i < Convert.ToInt32(ds.Tables[0].Rows.Count); i++)
            {
                cboxTenLoaiNV.Properties.Items.Add(Convert.ToString(ds.Tables[0].Rows[i]["TenLoaiNV"]));
            }
            
            AddItemForComboboxLoaiPhong();
            AddItemForComboboxLoaiSP();
            getKMSP();
            getKMPhong();
            //load printer name
        }
        private void listAllPrinters()
        {
            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                this.cboMayInBep.Properties.Items.Add(item.ToString());
                this.cboMayInKho.Properties.Items.Add(item.ToString());
                this.cboMayInHD.Properties.Items.Add(item.ToString());
            }
        }
        private void dateNgayCaidat_EditValueChanged(object sender, EventArgs e)
        {
            Load_Quyentruycap(dateNgaythietlap.Text, cboxTenLoaiNV.Text);
        }

        private void cboxTenLoaiNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_Quyentruycap("", cboxTenLoaiNV.Text);
        }

        private void dateNgaythietlap_EditValueChanged(object sender, EventArgs e)
        {
            Load_Setting(dateNgayCaidat.Text);
        }
        #region Khuyenmai
        private void AddItemForComboboxLoaiPhong()
        {
            int i, rowcount;
            DataSet ds1 = new DataAccess().getAllLoaiPhong();
            rowcount = Convert.ToInt32(ds1.Tables[0].Rows.Count);
            repositoryItemComboBox4.Items.Clear();
            for (i = 0; i < rowcount; i++)
                repositoryItemComboBox4.Items.Add(Convert.ToString(ds1.Tables[0].Rows[i]["TenLoaiPhong"]));
        }
        private void AddItemForComboboxLoaiSP()
        {
            int i, rowcount;
            DataSet ds = new DataAccess().getAllNhomSP();
            repositoryItemComboBox2.Items.Clear();
            rowcount = Convert.ToInt32(ds.Tables[0].Rows.Count);
            for (i = 0; i < rowcount; i++)
                repositoryItemComboBox2.Items.Add(Convert.ToString(ds.Tables[0].Rows[i]["TenNhomSP"]));
           
        }
        private void gridViewKM_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteKMSP)
                {
                    //do nothing
                }
                else
                {
                    //update here
                    Khuyenmai objKMSP = new Khuyenmai();
                    objKMSP.IDKhuyenmai = Convert.ToInt32(gridViewKM.GetRowCellValue(e.RowHandle, "IDKhuyenmai"));
                    objKMSP.Giam = Convert.ToInt32(gridViewKM.GetRowCellValue(e.RowHandle, "Giam"));
                    objKMSP.NgayBD = Convert.ToDateTime(gridViewKM.GetRowCellValue(e.RowHandle, "NgayBD"));
                    objKMSP.NgayKT = Convert.ToDateTime(gridViewKM.GetRowCellValue(e.RowHandle, "NgayKT"));
                    objKMSP.Ghichu = "";
                    DataSet dsSP = new DataAccess().getNhomSPByTenSP(Convert.ToString(gridViewKM.GetRowCellValue(e.RowHandle, "TenNhomSP")));
                    try
                    {
                        objKMSP.IDNhomSP = Convert.ToInt32(dsSP.Tables[0].Rows[0]["IDNhomSP"]);
                    }
                    catch
                    {
                        objKMSP.IDNhomSP = -1;
                    }

                    if ((objKMSP.IDNhomSP == -1) || (objKMSP.Giam <= 0))
                    {
                        getKMSP();
                        MessageBox.Show(this, "Thông tin khuyến mãi không hợp lệ (không có nhóm sản phẩm cùng tên hoặc giảm <= 0)", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (new DataAccess().updateKhuyenmai(objKMSP) == true)
                    {

                        getKMSP();
                        ((frmMain)(this.MdiParent)).setStatus("Cập nhật dữ liệu khuyến mãi thành công");
                    }
                    else
                    {
                        getKMSP(); 
                        MessageBox.Show(this, "Cập nhật dữ liệu khuyến mãi không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gridViewKM_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteKMSP)
                {
                    Khuyenmai objKMSP = new Khuyenmai();
                    objKMSP.IDKhuyenmai = Convert.ToInt32(gridViewKM.GetRowCellValue(e.RowHandle, "IDKhuyenmai"));

                    if (Convert.ToBoolean(gridViewKM.GetRowCellValue(e.RowHandle, colDeleteKMSP)) == true)
                    {
                        //warnning
                        if (MessageBox.Show(this, "Bạn có muốn xóa khuyến mãi này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (new DataAccess().deleteKhuyenmai(objKMSP) == true)
                            {
                                ((frmMain)(this.MdiParent)).setStatus("Xóa khuyến mãi thành công");
                                gridViewKM.DeleteRow(e.RowHandle);
                            }
                            else
                            {
                                MessageBox.Show(this, "Xóa khuyến mãi không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ((frmMain)(this.MdiParent)).setStatus("");
                            }
                        }
                        else
                        {
                            //set the image to uncheck
                            gridViewKM.SetRowCellValue(e.RowHandle, colDeleteKMSP, true);
                        }
                    }
                }
            }
        }
        private void gridViewKM_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRowView aRowView = (DataRowView)(e.Row);
            DataRow aRow = aRowView.Row;
            if (aRow.RowState == DataRowState.Added)
            {
                //insert command here
                //update here
                Khuyenmai objKMSP = new Khuyenmai();
                objKMSP.Giam = Convert.ToInt32(aRow["Giam"]);
                objKMSP.NgayBD = Convert.ToDateTime(aRow["NgayBD"]);
                objKMSP.NgayKT = Convert.ToDateTime(aRow["NgayKT"]);
                objKMSP.Ghichu = "";
                DataSet dsSP = new DataAccess().getNhomSPByTenSP(Convert.ToString(aRow["TenNhomSP"]));
                try
                {
                    objKMSP.IDNhomSP = Convert.ToInt32(dsSP.Tables[0].Rows[0]["IDNhomSP"]);
                }
                catch
                {
                    objKMSP.IDNhomSP = -1;
                }

                if ((objKMSP.IDNhomSP == -1) || (objKMSP.Giam <= 0))
                {
                    getKMSP();
                    MessageBox.Show(this, "Thông tin khuyến mãi không hợp lệ (không có nhóm sản phẩm cùng tên hoặc giảm <= 0)", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (new DataAccess().insertKhuyenmai(objKMSP) >= 0)
                {

                    getKMSP();
                    ((frmMain)(this.MdiParent)).setStatus("Cập nhật dữ liệu khuyến mãi thành công");
                }
                else
                {
                    getKMSP();
                    MessageBox.Show(this, "Cập nhật dữ liệu khuyến mãi không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void getKMSP()
        {
            DataSet ds = new DataAccess().getAllKhuyenmai();
            gridControlKM.DataSource = ds.Tables[0];
        }
        private void getKMPhong()
        {
            DataSet ds = new DataAccess().getAllKhuyenmaiPhong();
            gridControlKMPhong.DataSource = ds.Tables[0];
        }
        private void gridViewKMPhong_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteKMPhong)
                {
                    //do nothing
                }
                else
                {
                    //update here
                    KhuyenmaiPhong objKMSP = new KhuyenmaiPhong();
                    objKMSP.IDKhuyenmai = Convert.ToInt32(gridViewKMPhong.GetRowCellValue(e.RowHandle, "IDKhuyenmai"));
                    objKMSP.Giam = Convert.ToInt32(gridViewKMPhong.GetRowCellValue(e.RowHandle, "Giam"));
                    objKMSP.NgayBD = Convert.ToDateTime(gridViewKMPhong.GetRowCellValue(e.RowHandle, "NgayBD"));
                    objKMSP.NgayKT = Convert.ToDateTime(gridViewKMPhong.GetRowCellValue(e.RowHandle, "NgayKT"));
                    objKMSP.Ghichu = "";
                    DataSet dsPhong = new DataAccess().getLoaiPhongByTenLoaiPhong(Convert.ToString(gridViewKMPhong.GetRowCellValue(e.RowHandle, "TenLoaiPhong")));
                    try
                    {
                        objKMSP.IDNhomSP = Convert.ToInt32(dsPhong.Tables[0].Rows[0]["IDLoaiPhong"]);
                    }
                    catch
                    {
                        objKMSP.IDNhomSP = -1;
                    }

                    if ((objKMSP.IDNhomSP == -1) || (objKMSP.Giam <= 0))
                    {
                        getKMPhong();
                        MessageBox.Show(this, "Thông tin khuyến mãi không hợp lệ (không có nhóm sản phẩm cùng tên hoặc giảm <= 0)", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (new DataAccess().updateKhuyenmaiPhong(objKMSP) == true)
                    {

                        getKMPhong();
                        ((frmMain)(this.MdiParent)).setStatus("Cập nhật dữ liệu khuyến mãi thành công");
                    }
                    else
                    {
                        getKMPhong();
                        MessageBox.Show(this, "Cập nhật dữ liệu khuyến mãi không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gridViewKMPhong_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteKMPhong)
                {
                    KhuyenmaiPhong objKMSP = new KhuyenmaiPhong();
                    objKMSP.IDKhuyenmai = Convert.ToInt32(gridViewKMPhong.GetRowCellValue(e.RowHandle, "IDKhuyenmai"));

                    if (Convert.ToBoolean(gridViewKMPhong.GetRowCellValue(e.RowHandle, colDeleteKMPhong)) == true)
                    {
                        //warnning
                        if (MessageBox.Show(this, "Bạn có muốn xóa khuyến mãi này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (new DataAccess().deleteKhuyenmaiPhong(objKMSP) == true)
                            {
                                ((frmMain)(this.MdiParent)).setStatus("Xóa khuyến mãi thành công");
                                gridViewKMPhong.DeleteRow(e.RowHandle);
                            }
                            else
                            {
                                MessageBox.Show(this, "Xóa khuyến mãi không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ((frmMain)(this.MdiParent)).setStatus("");
                            }
                        }
                        else
                        {
                            //set the image to uncheck
                            gridViewKMPhong.SetRowCellValue(e.RowHandle, colDeleteKMPhong, true);
                        }
                    }
                }
            }
        }

        private void gridViewKMPhong_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRowView aRowView = (DataRowView)(e.Row);
            DataRow aRow = aRowView.Row;
            if (aRow.RowState == DataRowState.Added)
            {
                //insert command here
                //update here
                KhuyenmaiPhong objKMSP = new KhuyenmaiPhong();
                objKMSP.Giam = Convert.ToInt32(aRow["Giam"]);
                objKMSP.NgayBD = Convert.ToDateTime(aRow["NgayBD"]);
                objKMSP.NgayKT = Convert.ToDateTime(aRow["NgayKT"]);
                objKMSP.Ghichu = "";
                DataSet dsSP = new DataAccess().getLoaiPhongByTenLoaiPhong(Convert.ToString(aRow["TenLoaiPhong"]));
                try
                {
                    objKMSP.IDNhomSP = Convert.ToInt32(dsSP.Tables[0].Rows[0]["IDLoaiPhong"]);
                }
                catch
                {
                    objKMSP.IDNhomSP = -1;
                }

                if ((objKMSP.IDNhomSP == -1) || (objKMSP.Giam <= 0))
                {
                    getKMPhong();
                    MessageBox.Show(this, "Thông tin khuyến mãi không hợp lệ (không có nhóm sản phẩm cùng tên hoặc giảm <= 0)", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (new DataAccess().insertKhuyenmaiPhong(objKMSP) >= 0)
                {

                    getKMPhong();
                    ((frmMain)(this.MdiParent)).setStatus("Cập nhật dữ liệu khuyến mãi thành công");
                }
                else
                {
                    getKMPhong();
                    MessageBox.Show(this, "Cập nhật dữ liệu khuyến mãi không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        #endregion

        private void btnUpdateAccessRight_Click(object sender, EventArgs e)
        {
            QuyenTruycap objQuyenTruycap = new QuyenTruycap();
            //load setting quyen truy cap by date
            //if (new DataAccess().IsSettingQuyenTruycap(dateNgaythietlap.Text, cboxTenLoaiNV.Text))
            //{
            //    //update setting
            //    DataSet ds = new DataAccess().getQuyenTruycapByDate(dateNgaythietlap.Text, cboxTenLoaiNV.Text);
            //    objQuyenTruycap.IDQuyentruycap = Convert.ToInt32(ds.Tables[0].Rows[0]["IDQuyentruycap"]);
            //    objQuyenTruycap.Ngaythietlap = Convert.ToDateTime(dateNgaythietlap.Text);
            //    objQuyenTruycap.TenLoaiNV = Convert.ToString(cboxTenLoaiNV.Text);
            //    objQuyenTruycap.Vanhanh = Convert.ToInt32(ckboxVanhanh.Checked);
            //    objQuyenTruycap.HoadonNhap = Convert.ToInt32(ckboxHoadonNhap.Checked);
            //    objQuyenTruycap.Setting = Convert.ToInt32(ckboxSetting.Checked);
            //    objQuyenTruycap.Nhanvien = Convert.ToInt32(ckboxNhanvien.Checked);
            //    objQuyenTruycap.HoadonxuatSP = Convert.ToInt32(ckboxHoadonxuat.Checked);
            //    objQuyenTruycap.Sanpham = Convert.ToInt32(ckboxSanpham.Checked);
            //    objQuyenTruycap.Phong = Convert.ToInt32(ckboxPhong.Checked);
            //    objQuyenTruycap.Report = Convert.ToInt32(ckboxReport.Checked);
            //    objQuyenTruycap.Khachhang = Convert.ToInt32(ckboxKhachhang.Checked);
            //    objQuyenTruycap.Khuyenmai = Convert.ToInt32(ckboxKhuyenmai.Checked);
            //    objQuyenTruycap.Tonkho = Convert.ToInt32(ckboxTonkho.Checked);
            //    if (new DataAccess().updateQuyenTruycap(objQuyenTruycap) == true)
            //    {
            //        ((frmMain)(this.MdiParent)).setStatus("Cập nhật Quyền truy cập thành công");
            //    }
            //    else
            //    {
            //        MessageBox.Show(this, "Cập nhật Quyền truy cập không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            {
                //insert new setting
                objQuyenTruycap.Ngaythietlap = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
                objQuyenTruycap.TenLoaiNV = Convert.ToString(cboxTenLoaiNV.Text);
                if (objQuyenTruycap.TenLoaiNV == "")
                {
                    MessageBox.Show("Tên loại nhân viên chưa được nhập!");
                    return;
                }
                objQuyenTruycap.Vanhanh = Convert.ToInt32(ckboxVanhanh.Checked);
                objQuyenTruycap.HoadonNhap = Convert.ToInt32(ckboxHoadonNhap.Checked);
                objQuyenTruycap.Setting = Convert.ToInt32(ckboxSetting.Checked);
                objQuyenTruycap.Nhanvien = Convert.ToInt32(ckboxNhanvien.Checked);
                objQuyenTruycap.HoadonxuatSP = Convert.ToInt32(ckboxHoadonxuat.Checked);
                objQuyenTruycap.Sanpham = Convert.ToInt32(ckboxSanpham.Checked);
                objQuyenTruycap.Phong = Convert.ToInt32(ckboxPhong.Checked);
                objQuyenTruycap.Report = Convert.ToInt32(ckboxReport.Checked);
                objQuyenTruycap.Khachhang = Convert.ToInt32(ckboxKhachhang.Checked);
                objQuyenTruycap.Khuyenmai = Convert.ToInt32(ckboxKhuyenmai.Checked);
                objQuyenTruycap.Tonkho = Convert.ToInt32(ckboxTonkho.Checked);

                if (new DataAccess().insertQuyenTruycap(objQuyenTruycap) >= 0)
                {
                    ((frmMain)(this.MdiParent)).setStatus("Thêm mới Quyền truy cập thành công");
                    Load_Quyentruycap("", objQuyenTruycap.TenLoaiNV);
                }
                else
                {
                    MessageBox.Show(this, "Thêm mới Quyền truy cập không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

            QuyenTruycap objQuyenTruycap = new QuyenTruycap();
            //load setting quyen truy cap by date
            if (new DataAccess().IsSettingQuyenTruycap(dateNgaythietlap.Text, cboxTenLoaiNV.Text))
            {
                //delete setting quyen truy cap
                if (MessageBox.Show(this, "Bạn có muốn xóa Quyền truy cập này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DataSet ds = new DataAccess().getQuyenTruycapByDate(dateNgaythietlap.Text, cboxTenLoaiNV.Text);
                    objQuyenTruycap.IDQuyentruycap = Convert.ToInt32(ds.Tables[0].Rows[0]["IDQuyentruycap"]);
                    if (new DataAccess().deleteQuyenTruycap(objQuyenTruycap) == true)
                    {
                        ((frmMain)(this.MdiParent)).setStatus("Xóa Quyền truy cập thành công");
                        Load_Quyentruycap("", "");
                    }
                    else
                    {
                        MessageBox.Show(this, "Xóa Quyền truy cập không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ((frmMain)(this.MdiParent)).setStatus("");
                    }
                }
            }
            else
            {
                //do nothing 
            }
        }
    }
}