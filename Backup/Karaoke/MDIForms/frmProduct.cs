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
    public partial class frmProduct : DevExpress.XtraEditors.XtraForm
    {
        public frmProduct()
        {
            InitializeComponent();
        }
        private void getAllNhomSP()
        {
            DataSet ds = new DataAccess().getAllNhomSP();
            NhomSPRowsCount = ds.Tables[0].Rows.Count;
            gridControlNhomSP.DataSource = ds.Tables[0];
            
           
        }
        private void frmProduct_Load(object sender, EventArgs e)
        {
            getAllNhomSP();
            AddItemForComboboxTenNguyenLieu();
            getBangNguyenLieu(-1);
        }

       

        #region NhomSP
        private int NhomSPRowsCount = -1;
        private void gridViewNhomSP_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteNhomSP)
                {
                    //do nothing
                }
                else
                {
                   
                    //update here
                    //NhomSP objNhomSP = new NhomSP();
                    //objNhomSP.IDNhomSP = Convert.ToInt32(gridViewNhomSP.GetRowCellValue(e.RowHandle, "IDNhomSP"));
                    //objNhomSP.TenNhomSP = Convert.ToString(gridViewNhomSP.GetRowCellValue(e.RowHandle, "TenNhomSP"));
                    //objNhomSP.Ghichu = Convert.ToString(gridViewNhomSP.GetRowCellValue(e.RowHandle, "Ghichu"));
                    //if (NhomSPValidation(objNhomSP) == true)
                    //{
                    //    if (new DataAccess().updateNhomSP(objNhomSP) == true)
                    //    {
                    //        ((frmMain)(this.MdiParent)).setStatus("Cập nhật dữ liệu Nhóm sản phẩm thành công");
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show(this, "Cập nhật dữ liệu Nhóm sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    }
                    //}
                    //else
                    //{
                    //    getAllNhomSP();
                    //    MessageBox.Show(this, "Dữ liệu cho Tên nhóm sản phẩm không hợp lệ!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
            }

        }
        private bool NhomSPValidation(NhomSP objNhomSP)
        {
            if (objNhomSP.TenNhomSP != "")
            {
                return true;
            }
            return false;
        }
        private void gridViewNhomSP_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRowView aRowView = (DataRowView)(e.Row);
            DataRow aRow = aRowView.Row;
            if (aRow.RowState == DataRowState.Added)
            {
                //insert command here
                NhomSP objNhomSP = new NhomSP();
                objNhomSP.TenNhomSP = Convert.ToString(aRow["TenNhomSP"]);
                objNhomSP.Ghichu = Convert.ToString(aRow["Ghichu"]);

                if (NhomSPValidation(objNhomSP) == true)
                {

                    if (new DataAccess().insertNhomSP(objNhomSP) >= 0)
                    {
                        getAllNhomSP();
                        ((frmMain)(this.MdiParent)).setStatus("Thêm mới Nhóm sản phẩm thành công");

                    }
                    else
                    {
                        getAllNhomSP();
                        MessageBox.Show(this, "Thêm mới Nhóm sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    getAllNhomSP();
                    MessageBox.Show(this, "Chưa có dữ liệu cho Tên nhóm sản phẩm!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gridViewNhomSP_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteNhomSP)
                {
                    ////delete here
                    NhomSP objNhomSP = new NhomSP();
                    objNhomSP.IDNhomSP = Convert.ToInt32(gridViewNhomSP.GetRowCellValue(e.RowHandle, "IDNhomSP"));

                    if (Convert.ToBoolean(gridViewNhomSP.GetRowCellValue(e.RowHandle, colDeleteNhomSP)) == true)
                    {
                        //warnning
                        if (MessageBox.Show(this, "Bạn có muốn xóa Nhóm sản phẩm này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (new DataAccess().deleteNhomSP(objNhomSP) == true)
                            {
                                ((frmMain)(this.MdiParent)).setStatus("Xóa Nhóm sản phẩm thành công");
                                gridViewNhomSP.DeleteRow(e.RowHandle);
                                NhomSPRowsCount--;
                            }
                            else
                            {
                                MessageBox.Show(this, "Xóa Nhóm sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            //set the image to uncheck
                            gridViewNhomSP.SetRowCellValue(e.RowHandle, colDeleteNhomSP, true);
                        }
                    }
                }
                
            }

        }
        
        private void gridViewNhomSP_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0 && e.FocusedRowHandle < NhomSPRowsCount)
            {
                //list all products by ID
                
                int ID = Convert.ToInt32(gridViewNhomSP.GetRowCellValue(e.FocusedRowHandle, "IDNhomSP"));
                if (ID == 0) //Tat ca
                {
                    DataSet ds = new DataAccess().getAllSanPham();
                    SanPhamRowsCount = ds.Tables[0].Rows.Count;
                    gridControlSanPham.DataSource = ds.Tables[0];
                    
                    colDeleteNhomSP.OptionsColumn.ReadOnly = true;
                    colNhomSP.OptionsColumn.ReadOnly = true;
                    colGhiChuNhomSP.OptionsColumn.ReadOnly = true;
                    //this line never be deleted
                    colDeleteNhomSP.OptionsColumn.ReadOnly = true;

                    //disable Them moi San pham
                    colTenSanPham.OptionsColumn.AllowFocus = false;
                    colDonVi.OptionsColumn.AllowFocus = false;
                    colTonKho.OptionsColumn.AllowFocus = false;
                    colGhiChu.OptionsColumn.AllowFocus = false;
                    colDeleteSanPham.OptionsColumn.AllowFocus = false;
                }
                else //By ID
                {
                    curIDNhomSP = ID; //update current ID for SanPham processing
                    DataSet ds = new DataAccess().getSanPhamByIDNhomSP(ID);
                    SanPhamRowsCount = ds.Tables[0].Rows.Count;
                    gridControlSanPham.DataSource = ds.Tables[0];
                    colDeleteNhomSP.OptionsColumn.ReadOnly = false;
                    colNhomSP.OptionsColumn.ReadOnly = false;
                    colGhiChuNhomSP.OptionsColumn.ReadOnly = false;

                    colDeleteNhomSP.OptionsColumn.ReadOnly = false;


                    //enable Them moi San pham
                    colTenSanPham.OptionsColumn.AllowFocus = true;
                    colDonVi.OptionsColumn.AllowFocus = true;
                    colTonKho.OptionsColumn.AllowFocus = true;
                    colGhiChu.OptionsColumn.AllowFocus = true;
                    colDeleteSanPham.OptionsColumn.AllowFocus = true;
                }
                
            }
            else
            {
                gridControlSanPham.DataSource = null;
                SanPhamRowsCount = -1;
                colDeleteNhomSP.OptionsColumn.ReadOnly = true;
                
                colNhomSP.OptionsColumn.ReadOnly = false;
                colGhiChuNhomSP.OptionsColumn.ReadOnly = false;
            }
            if (gridViewSanPham.RowCount != 0)
            {
                gridViewSanPham_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, 0));
            }
            AddItemForComboboxTenNguyenLieu();
        }
        #endregion

        #region SanPham
        private bool SanPhamValidation(SanPham objSanPham)
        {
            if (objSanPham.TenSanPham == "")
            {
                if (curIDNhomSP == 0)
                {
                    gridControlSanPham.DataSource = new DataAccess().getAllSanPham().Tables[0];
                }
                else
                {
                    gridControlSanPham.DataSource = new DataAccess().getSanPhamByIDNhomSP(curIDNhomSP).Tables[0];
                }
                MessageBox.Show(this, "Tên sản phẩm không hợp lệ!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (objSanPham.DVT == "")
            {
                if (curIDNhomSP == 0)
                {
                    gridControlSanPham.DataSource = new DataAccess().getAllSanPham().Tables[0];
                }
                else
                {
                    gridControlSanPham.DataSource = new DataAccess().getSanPhamByIDNhomSP(curIDNhomSP).Tables[0];
                }
                MessageBox.Show(this, "Đơn vị tính không hợp lệ!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
            
        }

        private int curIDNhomSP = -1;
        private int SanPhamRowsCount = -1;
        private void gridViewSanPham_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column.Name == "colDeleteSanPham")
                {
                    //do nothing
                }
                else if (e.Column.Name == "colTonKho")
                {
                    
                    //update here
                    SanPham objSanPham = new SanPham();
                    objSanPham.IDSanPham = Convert.ToInt32(gridViewSanPham.GetRowCellValue(e.RowHandle, "IDSanPham"));
                    objSanPham.TenSanPham = Convert.ToString(gridViewSanPham.GetRowCellValue(e.RowHandle, "TenSanPham"));
                    objSanPham.DVT = Convert.ToString(gridViewSanPham.GetRowCellValue(e.RowHandle, "DVT"));
                    objSanPham.Ghichu = Convert.ToString(gridViewSanPham.GetRowCellValue(e.RowHandle, "Ghichu"));
                    objSanPham.TonKho = Convert.ToInt32(gridViewSanPham.GetRowCellValue(e.RowHandle, "TonKho"));

                    if (SanPhamValidation(objSanPham) == true)
                    {
                        //warning
                        if (MessageBox.Show(this, "Bạn có muốn cập nhật tồn kho cho Sản phẩm này không? Khi cập nhật, các hóa đơn trước ngày " + DateTime.Now.Date.ToString("dd/MM/yyy") + " sẽ không được tính!", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {

                            //insert for TonKho
                            TonKho objTonKho = new TonKho();
                            objTonKho.IDSanPham = objSanPham.IDSanPham;
                            objTonKho.SoLuong = objSanPham.TonKho;
                            objTonKho.Ngay = DateTime.Now.Date;
                            if (new DataAccess().insertTonKho(objTonKho) >= 0)
                            {
                                if (new DataAccess().updateSanPham(objSanPham) == true)
                                {
                                    ((frmMain)(this.MdiParent)).setStatus("Cập nhật dữ liệu Sản phẩm thành công");
                                }
                                else
                                {
                                    MessageBox.Show(this, "Cập nhật dữ liệu Sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Cập nhật dữ liệu Sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }//end for insert new TonKho item
                        else
                        {
                            //do nothing
                        }
                    }//end for validation
                }
                else
                {
                    //update here
                    SanPham objSanPham = new SanPham();
                    objSanPham.IDSanPham = Convert.ToInt32(gridViewSanPham.GetRowCellValue(e.RowHandle, "IDSanPham"));
                    objSanPham.TenSanPham = Convert.ToString(gridViewSanPham.GetRowCellValue(e.RowHandle, "TenSanPham"));
                    objSanPham.DVT = Convert.ToString(gridViewSanPham.GetRowCellValue(e.RowHandle, "DVT"));
                    objSanPham.Ghichu = Convert.ToString(gridViewSanPham.GetRowCellValue(e.RowHandle, "Ghichu"));
                    objSanPham.TonKho = Convert.ToInt32(gridViewSanPham.GetRowCellValue(e.RowHandle, "TonKho"));

                    if (SanPhamValidation(objSanPham) == true)
                    {
                        if (new DataAccess().updateSanPham(objSanPham) == true)
                        {
                            ((frmMain)(this.MdiParent)).setStatus("Cập nhật dữ liệu Sản phẩm thành công");
                        }
                        else
                        {
                            MessageBox.Show(this, "Cập nhật dữ liệu Sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        //reload data
                        if (curIDNhomSP == 0)
                        {
                            gridControlSanPham.DataSource = new DataAccess().getAllSanPham().Tables[0];
                        }
                        else 
                        {
                            gridControlSanPham.DataSource = new DataAccess().getSanPhamByIDNhomSP(curIDNhomSP).Tables[0];
                        }
                    }
                }
            }
            AddItemForComboboxTenNguyenLieu();

        }
       
        private void gridViewSanPham_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteSanPham)
                {
                    SanPham objSanPham = new SanPham();
                    objSanPham.IDSanPham = Convert.ToInt32(gridViewSanPham.GetRowCellValue(e.RowHandle, "IDSanPham"));
                    if (Convert.ToBoolean(gridViewSanPham.GetRowCellValue(e.RowHandle, colDeleteSanPham)) == true)
                    {
                        //warnning
                        if (MessageBox.Show(this, "Bạn có muốn xóa Sản phẩm này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (new DataAccess().deleteSanPham(objSanPham) == true)
                            {
                                ((frmMain)(this.MdiParent)).setStatus("Xóa Sản phẩm thành công");
                                gridViewSanPham.DeleteRow(e.RowHandle);
                                SanPhamRowsCount--;
                            }
                            else
                            {
                                MessageBox.Show(this, "Xóa Sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            //set the image to uncheck
                            gridViewSanPham.SetRowCellValue(e.RowHandle, colDeleteSanPham, true);
                        }
                    }
                }
            }
        }
        
        private void gridViewSanPham_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRowView aRowView = (DataRowView)(e.Row);
            DataRow aRow = aRowView.Row;
            if (aRow.RowState == DataRowState.Added)
            {
                //insert command here
                SanPham objSanPham = new SanPham();
                objSanPham.TenSanPham = Convert.ToString(aRow["TenSanPham"]);
                objSanPham.DVT = Convert.ToString(aRow["DVT"]);
                if (Convert.ToString(aRow["TonKho"]) == "")
                    objSanPham.TonKho = 0;
                else
                    objSanPham.TonKho = Convert.ToInt32(aRow["TonKho"]);
                objSanPham.Ghichu = Convert.ToString(aRow["Ghichu"]);
                objSanPham.IDNhomSP = curIDNhomSP;

                if (SanPhamValidation(objSanPham) == true)
                {
                    int IDSanPham = new DataAccess().insertSanPham(objSanPham);
                    if ( IDSanPham >= 0)
                    {
                        DataSet ds = new DataAccess().getSanPhamByIDNhomSP(curIDNhomSP);
                        SanPhamRowsCount = ds.Tables[0].Rows.Count;
                        gridControlSanPham.DataSource = ds.Tables[0];
                        ((frmMain)(this.MdiParent)).setStatus("Thêm mới Sản phẩm thành công");
                        //insert to TonKho
                        BKIT.Entities.TonKho objTonKho = new TonKho();
                        objTonKho.IDSanPham = IDSanPham;
                        objTonKho.SoLuong = objSanPham.TonKho;
                        objTonKho.Ngay = DateTime.Now.Date;
                        if (new DataAccess().insertTonKho(objTonKho) < 0)
                        {
                            MessageBox.Show(this, "Thêm mới Tồn kho không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        DataSet ds = new DataAccess().getSanPhamByIDNhomSP(curIDNhomSP);
                        SanPhamRowsCount = ds.Tables[0].Rows.Count;
                        gridControlSanPham.DataSource = ds.Tables[0];
                        MessageBox.Show(this, "Thêm mới Sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    //do nothing
                    
                }

            }
            AddItemForComboboxTenNguyenLieu();
        }

        private void gridViewSanPham_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0 && e.FocusedRowHandle < SanPhamRowsCount)
            {
                curIDSanPham = Convert.ToInt32(gridViewSanPham.GetRowCellValue(e.FocusedRowHandle, "IDSanPham"));
                gridControlGiaXuatSP.DataSource = new DataAccess().getGiaXuatSPByIDSanPham(curIDSanPham).Tables[0];
                getBangNguyenLieu(curIDSanPham);
                colDeleteSanPham.OptionsColumn.ReadOnly = false;
            }
            else
            {
                getBangNguyenLieu(-1);
                gridControlGiaXuatSP.DataSource = null;
                colDeleteSanPham.OptionsColumn.ReadOnly = true;
            }
        }
        #endregion

        #region GiaXuatSP
        private bool GiaXuatSPValidation(GiaXuatSP objGiaXuatSP)
        {
            if (objGiaXuatSP.Gia <= 0)
            {
                return false;
            }
            return true;
        }

        private int curIDSanPham = -1;
        private void gridViewGiaXuatSP_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteGia)
                {
                    //do nothing
                }
                else
                {
                    //update here
                    GiaXuatSP objGiaXuatSP = new GiaXuatSP();
                    objGiaXuatSP.IDGiaXuatSP = Convert.ToInt32(gridViewGiaXuatSP.GetRowCellValue(e.RowHandle, "IDGiaXuatSP"));
                    objGiaXuatSP.IDSanPham = Convert.ToInt32(gridViewGiaXuatSP.GetRowCellValue(e.RowHandle, "IDSanPham"));
                    objGiaXuatSP.Gia = Convert.ToDecimal(gridViewGiaXuatSP.GetRowCellValue(e.RowHandle, "Gia"));
                    objGiaXuatSP.NgayXuatSP = Convert.ToDateTime(gridViewGiaXuatSP.GetRowCellValue(e.RowHandle, "NgayXuatSP"));
                    objGiaXuatSP.Ghichu = Convert.ToString(gridViewGiaXuatSP.GetRowCellValue(e.RowHandle, "Ghichu"));

                    if (objGiaXuatSP.Gia >= 0)
                    {
                        if (new DataAccess().updateGiaXuatSP(objGiaXuatSP) == true)
                        {
                            ((frmMain)(this.MdiParent)).setStatus("Cập nhật dữ liệu Giá sản phẩm thành công");
                        }
                        else
                        {
                            MessageBox.Show(this, "Cập nhật dữ liệu Giá sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        gridControlGiaXuatSP.DataSource = new DataAccess().getGiaXuatSPByIDSanPham(curIDSanPham).Tables[0];
                        getBangNguyenLieu(curIDSanPham);
                        MessageBox.Show(this, "Giá sản phẩm không hợp lệ.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
        private void gridViewGiaXuatSP_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteGia)
                {
                    GiaXuatSP objGiaXuatSP = new GiaXuatSP();
                    objGiaXuatSP.IDGiaXuatSP = Convert.ToInt32(gridViewGiaXuatSP.GetRowCellValue(e.RowHandle, "IDGiaXuatSP"));

                    if (Convert.ToBoolean(gridViewGiaXuatSP.GetRowCellValue(e.RowHandle, colDeleteGia)) == true)
                    {
                        //warnning
                        if (MessageBox.Show(this, "Bạn có muốn xóa Giá sản phẩm này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (new DataAccess().deleteGiaXuatSP(objGiaXuatSP) == true)
                            {
                                ((frmMain)(this.MdiParent)).setStatus("Xóa Giá sản phẩm thành công");
                                gridViewGiaXuatSP.DeleteRow(e.RowHandle);
                            }
                            else
                            {
                                MessageBox.Show(this, "Xóa Giá sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ((frmMain)(this.MdiParent)).setStatus("");
                            }
                        }
                        else
                        {
                            //set the image to uncheck
                            gridViewSanPham.SetRowCellValue(e.RowHandle, colDeleteSanPham, true);
                        }
                    }
                }
            }
        }
        private void gridViewGiaXuatSP_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRowView aRowView = (DataRowView)(e.Row);
            DataRow aRow = aRowView.Row;
            if (aRow.RowState == DataRowState.Added)
            {
                //insert command here
                GiaXuatSP objGiaXuatSP = new GiaXuatSP();

                objGiaXuatSP.IDSanPham = curIDSanPham;
                if (Convert.ToString(aRow["NgayXuatSP"]) == "")
                {
                    gridControlGiaXuatSP.DataSource = new DataAccess().getGiaXuatSPByIDSanPham(curIDSanPham).Tables[0];
                    MessageBox.Show(this, "Chưa nhập Ngày Giá sản phẩm!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else {
                    objGiaXuatSP.NgayXuatSP = Convert.ToDateTime(aRow["NgayXuatSP"]);
                }
                if(Convert.ToString(aRow["Gia"]) == "")
                {
                    gridControlGiaXuatSP.DataSource = new DataAccess().getGiaXuatSPByIDSanPham(curIDSanPham).Tables[0];
                    MessageBox.Show(this, "Chưa nhập Giá sản phẩm!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    objGiaXuatSP.Gia = Convert.ToDecimal(aRow["Gia"]);
                    if(objGiaXuatSP.Gia <=0)
                    {
                        gridControlGiaXuatSP.DataSource = new DataAccess().getGiaXuatSPByIDSanPham(curIDSanPham).Tables[0];
                        MessageBox.Show(this, "Giá sản phẩm chưa hợp lệ!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                objGiaXuatSP.Ghichu = Convert.ToString(aRow["Ghichu"]);


                if (new DataAccess().insertGiaXuatSP(objGiaXuatSP) >= 0)
                {
                    gridControlGiaXuatSP.DataSource = new DataAccess().getGiaXuatSPByIDSanPham(curIDSanPham).Tables[0];
                    ((frmMain)(this.MdiParent)).setStatus("Thêm mới Giá sản phẩm thành công");

                }
                else
                {
                    gridControlGiaXuatSP.DataSource = new DataAccess().getGiaXuatSPByIDSanPham(curIDSanPham).Tables[0];
                    MessageBox.Show(this, "Thêm mới Giá sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ((frmMain)(this.MdiParent)).setStatus("");
                }

            }
        }
        private void gridViewGiaXuatSP_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                colDeleteGia.OptionsColumn.ReadOnly = true;
            }
            else
            {
                colDeleteGia.OptionsColumn.ReadOnly = false;
            }
        }
        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            gridViewNhomSP.SetRowCellValue(0, colDeleteNhomSP, false);
        }

        #region CongThucPhaChe
        private void AddItemForComboboxTenNguyenLieu()
        {
            int i, rowcount;
            DataSet ds1 = new DataAccess().getAllSanPham();
            rowcount = Convert.ToInt32(ds1.Tables[0].Rows.Count);
            repositoryItemcboTenNguyenLieu.Items.Clear();
            if (ds1 == null || ds1.Tables[0].Rows.Count < 0)
            {
                return;
            }
            for (i = 0; i < rowcount; i++)
                repositoryItemcboTenNguyenLieu.Items.Add(Convert.ToString(ds1.Tables[0].Rows[i]["TenSanPham"]));
        }
        private void getBangNguyenLieu(int IDSanPham)
        {
            if (IDSanPham == -1)
            {
                gridControlCongThucPhaChe.DataSource = null;
                return;
            }
            DataSet ds = new DataAccess().getAllSPPhaCheByIDSanPham(IDSanPham);
            gridControlCongThucPhaChe.DataSource = ds.Tables[0];
        }
        private void gridViewCongThucPhaChe_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteCTPhaChe)
                {
                    //do nothing
                }
                else
                {
                    //update here
                    SPPhaChe objSPPhaChe = new SPPhaChe();

                    objSPPhaChe.IDSPPhaChe = Convert.ToInt32(gridViewCongThucPhaChe.GetRowCellValue(e.RowHandle, "IDSPPhaChe"));
                    objSPPhaChe.IDSanPham = Convert.ToInt32(gridViewCongThucPhaChe.GetRowCellValue(e.RowHandle, "IDSanPham"));
                    objSPPhaChe.IDSPCha = Convert.ToInt32(new DataAccess().getIDSanPhamByTenSP(gridViewCongThucPhaChe.GetRowCellValue(e.RowHandle, "TenSanPham").ToString()).Tables[0].Rows[0][0]);
                    objSPPhaChe.GhiChu = Convert.ToString(gridViewCongThucPhaChe.GetRowCellValue(e.RowHandle,"GhiChu"));
                    objSPPhaChe.ThanhPhan = Convert.ToInt32(gridViewCongThucPhaChe.GetRowCellValue(e.RowHandle,"ThanhPhan"));
                    

                    if (objSPPhaChe.ThanhPhan >= 0)
                    {
                        if (new DataAccess().updateSPPhaChe(objSPPhaChe) == true)
                        {
                            ((frmMain)(this.MdiParent)).setStatus("Cập nhật dữ liệu bảng nguyên liệu thành công");
                        }
                        else
                        {
                            MessageBox.Show(this, "Cập nhật dữ liệu bảng nguyên liệu không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {                        
                        getBangNguyenLieu(curIDSanPham);
                        MessageBox.Show(this, "Thành phần nguyên liệu không hợp lệ.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gridViewCongThucPhaChe_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteCTPhaChe)
                {
                    SPPhaChe objSPPhaChe = new SPPhaChe();
                    objSPPhaChe.IDSPPhaChe = Convert.ToInt32(gridViewCongThucPhaChe.GetRowCellValue(e.RowHandle, "IDSPPhaChe"));
                    

                    if (Convert.ToBoolean(gridViewCongThucPhaChe.GetRowCellValue(e.RowHandle, colDeleteCTPhaChe)) == true)
                    {
                        //warnning
                        if (MessageBox.Show(this, "Bạn có muốn xóa Thành phần nguyên liệu này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (new DataAccess().deleteSPPhaChe(objSPPhaChe) == true)
                            {
                                ((frmMain)(this.MdiParent)).setStatus("Xóa thành phần nguyên liệu thành công");
                                gridViewCongThucPhaChe.DeleteRow(e.RowHandle);
                            }
                            else
                            {
                                MessageBox.Show(this, "Xóa thành phần nguyên liệu không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ((frmMain)(this.MdiParent)).setStatus("");
                            }
                        }
                        else
                        {
                            //set the image to uncheck
                            gridViewSanPham.SetRowCellValue(e.RowHandle, colDeleteSanPham, true);
                        }
                    }
                }
            }
        }

        private void gridViewCongThucPhaChe_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRowView aRowView = (DataRowView)(e.Row);
            DataRow aRow = aRowView.Row;
            if (aRow.RowState == DataRowState.Added)
            {
                //insert command here
                SPPhaChe objSPPhaChe = new SPPhaChe();                

                objSPPhaChe.IDSanPham = curIDSanPham;
                if (Convert.ToString(aRow["TenSanPham"]) == "")
                {
                    getBangNguyenLieu(curIDSanPham);
                    MessageBox.Show(this, "Chưa nhập tên thành phần nguyên liệu cho sản phẩm!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    objSPPhaChe.IDSPCha = Convert.ToInt32(new DataAccess().getIDSanPhamByTenSP(aRow["TenSanPham"].ToString()).Tables[0].Rows[0][0]);
                }
                if (Convert.ToString(aRow["ThanhPhan"]) == "")
                {
                    getBangNguyenLieu(curIDSanPham);
                    MessageBox.Show(this, "Chưa nhập thành phần nguyên liệu cho sản phẩm!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    objSPPhaChe.ThanhPhan = Convert.ToInt32(aRow["ThanhPhan"]);
                    if (objSPPhaChe.ThanhPhan < 0)
                    {
                        getBangNguyenLieu(curIDSanPham);
                        MessageBox.Show(this, "Thành phần pha chế chưa hợp lệ!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                objSPPhaChe.GhiChu = Convert.ToString(aRow["GhiChu"]);


                if (new DataAccess().insertSPPhaChe(objSPPhaChe) >= 0)
                {
                    getBangNguyenLieu(curIDSanPham);
                    ((frmMain)(this.MdiParent)).setStatus("Thêm mới Thành phần nguyên liệu thành công");

                }
                else
                {
                    getBangNguyenLieu(curIDSanPham);
                    MessageBox.Show(this, "Thêm mới thành phần nguyên liệu không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ((frmMain)(this.MdiParent)).setStatus("");
                }

            }
        }

        private void gridViewCongThucPhaChe_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle < 0)
            {
                colDeleteCTPhaChe.OptionsColumn.ReadOnly = true;
            }
            else
            {
                colDeleteCTPhaChe.OptionsColumn.ReadOnly = false;
            }
        }
        #endregion CongThucPhaChe

       
    }
}