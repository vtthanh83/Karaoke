using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BKIT.Model;
using BKIT.Entities;

namespace Karaoke.MDIForms
{
    public partial class frmQuanLyLoaiVanDe : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanLyLoaiVanDe()
        {
            InitializeComponent();
        }

        private void frmQuanLyLoaiVanDe_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void loadData()
        {
            DataSet ds = null;
            ds = new DataAccess().getAllLoaiVD();
            gridControlLoaiVanDe.DataSource = ds.Tables[0];
        }

        private void gridViewLoaiVanDe_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteLoaiVD)
                {
                    //do nothing
                }
                else
                {
                   

                    //update here
                    LoaiVD objLoaiVD = new LoaiVD();

                    objLoaiVD.IDLoaiVD = Convert.ToInt32(gridViewLoaiVanDe.GetRowCellValue(e.RowHandle, "IDLoaiVD"));
                    objLoaiVD.TenVD = Convert.ToString(gridViewLoaiVanDe.GetRowCellValue(e.RowHandle, "TenVD"));
                    objLoaiVD.GhiChu = Convert.ToString(gridViewLoaiVanDe.GetRowCellValue(e.RowHandle, "Ghichu"));//Convert.ToString(new DataAccess().getIDSanPhamByTenSP(gridViewLoaiVanDe.GetRowCellValue(e.RowHandle, "Ghichu").ToString()).Tables[0].Rows[0][0]);

                    if (objLoaiVD.IDLoaiVD == 0 || objLoaiVD.IDLoaiVD == 1)
                    {
                        MessageBox.Show(this, "Đây là loại vấn đề cố định không được chỉnh sửa hoặc xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadData();
                        return;
                    }

                    if (new DataAccess().updateLoaiVD(objLoaiVD) == true)
                    {
                        ((frmMain)(this.MdiParent)).setStatus("Cập nhật dữ liệu bảng sự cố thành công");
                    }
                    else
                    {
                        MessageBox.Show(this, "Cập nhật dữ liệu bảng sự cố không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                   
                }
            }
        }

        private void gridViewLoaiVanDe_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteLoaiVD)
                {
                    LoaiVD objLoaiVD = new LoaiVD();
                    objLoaiVD.IDLoaiVD = Convert.ToInt32(gridViewLoaiVanDe.GetRowCellValue(e.RowHandle, "IDLoaiVD"));
                    if (objLoaiVD.IDLoaiVD == 0 || objLoaiVD.IDLoaiVD == 1)
                    {
                        MessageBox.Show(this,"Đây là loại vấn đề cố định không được chỉnh sửa hoặc xóa.","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        loadData();
                        return;
                    }

                    if (Convert.ToBoolean(gridViewLoaiVanDe.GetRowCellValue(e.RowHandle, colDeleteLoaiVD)) == true)
                    {                        
                        //warnning
                        if (MessageBox.Show(this, "Bạn có muốn xóa loại sự cố này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (new DataAccess().deleteLoaiVD(objLoaiVD) == true)
                            {
                                lblStatus.Text="Xóa sự cố thành công";
                                gridViewLoaiVanDe.DeleteRow(e.RowHandle);
                            }
                            else
                            {
                                MessageBox.Show(this, "Xóa sự cố không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                lblStatus.Text = "";
                            }
                        }
                        else
                        {
                          
                        }
                    }
                }
            }
            
        }

        private void gridViewLoaiVanDe_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                colDeleteLoaiVD.OptionsColumn.ReadOnly = true;
            }
            else
            {
                colDeleteLoaiVD.OptionsColumn.ReadOnly = false;
            }
           
        }

        private void gridViewLoaiVanDe_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRowView aRowView = (DataRowView)(e.Row);
            DataRow aRow = aRowView.Row;
            if (aRow.RowState == DataRowState.Added)
            {
                //insert command here
                LoaiVD objLoaiVD = new LoaiVD();
                              
                
                if (Convert.ToString(aRow["TenVD"]) == "")
                {                    
                    MessageBox.Show(this, "Chưa nhập tên sự cố!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    objLoaiVD.TenVD = Convert.ToString(aRow["TenVD"]);
                    
                }
                objLoaiVD.GhiChu = Convert.ToString(aRow["GhiChu"]);


                if (new DataAccess().insertLoaiVD(objLoaiVD) >= 0)
                {

                    lblStatus.Text = "Thêm mới thành công";

                }
                else
                {
                    lblStatus.Text = "Thêm mới không thành công";                   
                }

            }
           
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
    }
}