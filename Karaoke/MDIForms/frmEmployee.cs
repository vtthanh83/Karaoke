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

namespace Karaoke.MDIForms
{
    public partial class frmEmployee : DevExpress.XtraEditors.XtraForm
    {
        public frmEmployee()
        {
            InitializeComponent();
        }
        private void getAllNhanvien()
        {
            DataSet ds = new DataAccess().getAllNhanvien();
            gridControlNhanvien.DataSource = ds.Tables[0];
        }
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            getAllNhanvien();
        }

        private void gridViewNhanvien_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteNhanvien)
                {
                    //do nothing
                }
                else
                {
                    //update here
                    Nhanvien objNhanvien = new Nhanvien();
                    objNhanvien.IDNhanvien = Convert.ToInt32(gridViewNhanvien.GetRowCellValue(e.RowHandle, "IDNhanvien"));
                   try
                    { 
                        objNhanvien.Ten = Convert.ToString(gridViewNhanvien.GetRowCellValue(e.RowHandle, "Ten"));
                        if (objNhanvien.Ten == "")
                        {
                            getAllNhanvien();
                            MessageBox.Show(this, "Không có tên nhân viên", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        objNhanvien.Gioitinh = Convert.ToString(gridViewNhanvien.GetRowCellValue(e.RowHandle, "Gioitinh"));
                        if (objNhanvien.Gioitinh == "")
                        {
                            getAllNhanvien();
                            MessageBox.Show(this, "Nhân viên không có thông tin giới tính", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if (objNhanvien.Gioitinh != "Nữ" && objNhanvien.Gioitinh != "Nam")
                        {
                            getAllNhanvien();
                            MessageBox.Show(this, "Giới tính nhân viên không hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        objNhanvien.Chucvu = Convert.ToString(gridViewNhanvien.GetRowCellValue(e.RowHandle, "Chucvu"));
                        objNhanvien.Diachi = Convert.ToString(gridViewNhanvien.GetRowCellValue(e.RowHandle, "Diachi"));
                        objNhanvien.SoDT = Convert.ToString(gridViewNhanvien.GetRowCellValue(e.RowHandle, "SoDT"));
                        if (objNhanvien.SoDT == "")
                        {
                            getAllNhanvien();
                            MessageBox.Show(this, "Không có số điện thoại nhân viên", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            try
                            {
                                Int32.Parse(objNhanvien.SoDT);
                            }
                            catch// (Exception ex)
                            {
                                getAllNhanvien();
                                MessageBox.Show(this, "Số điện thoại không hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        objNhanvien.Ngaysinh = Convert.ToDateTime(gridViewNhanvien.GetRowCellValue(e.RowHandle, "Ngaysinh"));
                        objNhanvien.Loai = Convert.ToString(gridViewNhanvien.GetRowCellValue(e.RowHandle, "Loai"));
                        if (objNhanvien.Loai == "")
                        {
                            getAllNhanvien();
                            MessageBox.Show(this, "Không có loại nhân viên", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else if(objNhanvien.Loai != "Quản lý" && objNhanvien.Loai != "Người dùng" && objNhanvien.Loai != "Khách")
                        {
                            getAllNhanvien();
                            MessageBox.Show(this, "Loại nhân viên không hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                       objNhanvien.Username = Convert.ToString(gridViewNhanvien.GetRowCellValue(e.RowHandle, "Username"));
                       if (objNhanvien.Username == "")
                       {
                           getAllNhanvien();
                           MessageBox.Show(this, "Không có Username nhân viên", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           return;
                       } 
                       objNhanvien.Password = Convert.ToString(gridViewNhanvien.GetRowCellValue(e.RowHandle, "Password"));
                       if (objNhanvien.Password == "")
                       {
                           getAllNhanvien();
                           MessageBox.Show(this, "Không có Password nhân viên", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                           return;
                       } 
                    }
                    catch// (Exception ex)
                    {
                        getAllNhanvien();
                        return;       
                    }

                    if (new DataAccess().updateNhanvien(objNhanvien) == true)
                    {
                        getAllNhanvien();
                        ((frmMain)(this.MdiParent)).setStatus("Cập nhật dữ liệu Nhân viên thành công");
                    }
                    else
                    {
                        getAllNhanvien();    
                        MessageBox.Show(this, "Cập nhật dữ liệu Nhân viên không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gridViewNhanvien_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
       {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteNhanvien)
                {
                    Nhanvien objNhanvien = new Nhanvien();
                    objNhanvien.IDNhanvien = Convert.ToInt32(gridViewNhanvien.GetRowCellValue(e.RowHandle, "IDNhanvien"));

                    if (Convert.ToBoolean(gridViewNhanvien.GetRowCellValue(e.RowHandle, colDeleteNhanvien)) == true)
                    {
                        //warnning
                        if (MessageBox.Show(this, "Bạn có muốn xóa Loại phòng này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (new DataAccess().deleteNhanvien(objNhanvien) == true)
                            {
                                ((frmMain)(this.MdiParent)).setStatus("Xóa Loại phòng thành công");
                                gridViewNhanvien.DeleteRow(e.RowHandle);
                            }
                            else
                            {
                                MessageBox.Show(this, "Xóa Loại phòng không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ((frmMain)(this.MdiParent)).setStatus("");
                            }
                        }
                        else
                        {
                            //set the image to uncheck
                            gridViewNhanvien.SetRowCellValue(e.RowHandle, colDeleteNhanvien, true);
                        }
                    }
                }
            }
        }

        private void gridViewNhanvien_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRowView aRowView = (DataRowView)(e.Row);
            DataRow aRow = aRowView.Row;
            if (aRow.RowState == DataRowState.Added)
            {
                //insert command here
                Nhanvien objNhanvien = new Nhanvien();
                //objNhanvien.IDNhanvien = Convert.ToInt32(gridViewNhanvien.GetRowCellValue(e.RowHandle, "IDNhanvien"));
                try
                {
                    objNhanvien.Ten = Convert.ToString(aRow["Ten"]); 
                    objNhanvien.Gioitinh = Convert.ToString(aRow["Gioitinh"]);
                    objNhanvien.Chucvu = Convert.ToString(aRow["Chucvu"]);
                    objNhanvien.Diachi = Convert.ToString(aRow["Diachi"]);
                    objNhanvien.SoDT = Convert.ToString(aRow["SoDT"]);
                    objNhanvien.Ngaysinh = Convert.ToDateTime(aRow["Ngaysinh"]);
                    objNhanvien.Loai = Convert.ToString(aRow["Loai"]);
                    objNhanvien.Username = Convert.ToString(aRow["Username"]);
                    objNhanvien.Password = Convert.ToString(aRow["Password"]);
                    if (objNhanvien.Ten == "")
                    {
                        getAllNhanvien();
                        MessageBox.Show(this, "Không có tên nhân viên", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (objNhanvien.SoDT == "")
                    {
                        getAllNhanvien();
                        MessageBox.Show(this, "Không có số điện thoại nhân viên", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        try
                        {
                            Int32.Parse(objNhanvien.SoDT);
                        }
                        catch// (Exception ex)
                        {
                            getAllNhanvien();
                            MessageBox.Show(this, "Số điện thoại không hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (objNhanvien.Gioitinh == "")
                    {
                        getAllNhanvien();
                        MessageBox.Show(this, "Nhân viên không có thông tin giới tính", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (objNhanvien.Gioitinh != "Nữ" && objNhanvien.Gioitinh != "Nam")
                    {
                        getAllNhanvien();
                        MessageBox.Show(this, "Giới tính nhân viên không hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (objNhanvien.Loai == "")
                    {
                        getAllNhanvien();
                        MessageBox.Show(this, "Không có loại nhân viên", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else if (objNhanvien.Loai != "Quản lý" && objNhanvien.Loai != "Người dùng" && objNhanvien.Loai != "Khách")
                    {
                        getAllNhanvien();
                        MessageBox.Show(this, "Loại nhân viên không hợp lệ", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (objNhanvien.Username == "")
                    {
                        getAllNhanvien();
                        MessageBox.Show(this, "Không có Username nhân viên", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (objNhanvien.Password == "")
                    {
                        getAllNhanvien();
                        MessageBox.Show(this, "Không có Password nhân viên", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    } 
                }
                catch// (Exception ex)
                {
                    getAllNhanvien();
                    return;
                }

                if (new DataAccess().insertNhanvien(objNhanvien) >= 0)
                {
                    getAllNhanvien();
                    ((frmMain)(this.MdiParent)).setStatus("Thêm mới Nhân viên thành công");

                }
                else
                {
                    getAllNhanvien();
                    MessageBox.Show(this, "Thêm mới Nhân viên không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

       
       

        
    }
}