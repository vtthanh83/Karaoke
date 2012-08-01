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
using DevExpress.XtraGrid.Views.Grid;

namespace Karaoke.MDIForms
{
    public partial class frmAddHoaDonNhap : DevExpress.XtraEditors.XtraForm
    {
        public MDIForms.frmInvoice fInvoice;
       
        public frmAddHoaDonNhap()
        {
            InitializeComponent();
        }
        private int[] arrIDNhomSP;
        private int[] arrIDSanPham;
        private int[] arrIDNhanvien;
        DataTable table = new DataTable();
        private void frmAddHoaDonNhap_Load(object sender, EventArgs e)
        {
            //load Nhom SP
            DataSet ds = new DataAccess().getAllNhomSP();
            int intRowsCount = ds.Tables[0].Rows.Count;
            arrIDNhomSP = new int[intRowsCount];
            cboNhomSP.Properties.Items.Clear();
            for (int i = 0; i < intRowsCount; i++)
            {
                arrIDNhomSP[i] = Convert.ToInt32(ds.Tables[0].Rows[i]["IDNhomSP"]);
                cboNhomSP.Properties.Items.Add(Convert.ToString(ds.Tables[0].Rows[i]["TenNhomSP"]));
            }
            if (intRowsCount > 0)
            {
                cboNhomSP.SelectedIndex = intRowsCount - 1;
                cboNhomSP.Enabled = true;
            }
            else
            {
                cboNhomSP.Text = "Không có";
                cboNhomSP.Enabled = false;
            }
            //load Nhanvien
            DataSet dsNhanvien = new DataAccess().getAllNhanvien();
            intRowsCount = dsNhanvien.Tables[0].Rows.Count;
            arrIDNhanvien = new int[intRowsCount];
            cboNhanvien.Properties.Items.Clear();
            for (int i = 0; i < intRowsCount; i++)
            {
                arrIDNhanvien[i] = Convert.ToInt32(dsNhanvien.Tables[0].Rows[i]["IDNhanvien"]);
                cboNhanvien.Properties.Items.Add(Convert.ToString(dsNhanvien.Tables[0].Rows[i]["Ten"]));
            }
            if (intRowsCount > 0)
            {
                cboNhanvien.SelectedIndex = 0;
                cboNhanvien.Enabled = true;
            }
            else
            {
                cboNhanvien.Text = "Không có";
                cboNhanvien.Enabled = false;
            }

            //create datatable for ChiTietHoaDon
            table.Columns.Add("IDHoaDonNhap", typeof(int));
            table.Columns.Add("IDChiTietHoaDonNhap", typeof(int));
            table.Columns.Add("IDSanPham", typeof(int));
            table.Columns.Add("TenSanPham", typeof(string));
            table.Columns.Add("SoLuong", typeof(int));
            table.Columns.Add("GiaNhap", typeof(decimal));
            table.Columns.Add("TongTien", typeof(decimal));
            table.Columns.Add("DeleteChiTiet", typeof(bool));
            gridControlChiTietHoaDonNhap.DataSource = table;
            dateNgay.DateTime = DateTime.Now.Date;
        }

        private void cboNhomSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDNhomSP = arrIDNhomSP[cboNhomSP.SelectedIndex];
            DataSet ds;
           
            if (IDNhomSP == 0)
            {
                //list all SP
                ds = new DataAccess().getAllSanPham();
            }
            else
            {
                ds = new DataAccess().getSanPhamByIDNhomSP(IDNhomSP);
            }

            int intRowsCount = ds.Tables[0].Rows.Count;
            arrIDSanPham = new int[intRowsCount];
            cboSanPham.Properties.Items.Clear();
            for (int i = 0; i < intRowsCount; i++)
            {
                arrIDSanPham[i] = Convert.ToInt32(ds.Tables[0].Rows[i]["IDSanPham"]);
                cboSanPham.Properties.Items.Add(Convert.ToString(ds.Tables[0].Rows[i]["TenSanPham"]));
            }
            if (intRowsCount > 0)
            {
                cboSanPham.SelectedIndex = 0;
                cboSanPham.Enabled = true;
            }
            else
            {
                cboSanPham.Text = "Không có";
                cboSanPham.Enabled = false;
            }
        }

        private void btnAddChiTietHD_Click(object sender, EventArgs e)
        {
            DataRow aRow = table.NewRow();
            aRow["IDSanPham"] = arrIDSanPham[cboSanPham.SelectedIndex];
            aRow["TenSanPham"] = cboSanPham.Text;
            aRow["SoLuong"] = txtSoLuong.Text;
            if (txtGiaNhap.Text != "")
            {
                aRow["GiaNhap"] = txtGiaNhap.Text;
                if (Convert.ToDecimal(txtGiaNhap.Text) < 0)
                {
                    MessageBox.Show(this, "Giá nhập không hợp lệ.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtGiaNhap.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show(this, "Giá nhập không hợp lệ.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGiaNhap.Text = "";
                return;
            }
            aRow["TongTien"] =  Convert.ToInt32(txtSoLuong.Text) * Convert.ToDecimal(txtGiaNhap.Text);
            aRow["DeleteChiTiet"] = false;
            table.Rows.Add(aRow);
        }

        private void gridViewChiTietHoaDonNhap_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colDeleteChiTiet)
            {
                if (Convert.ToBoolean(gridViewChiTietHoaDonNhap.GetRowCellValue(e.RowHandle, colDeleteChiTiet)) == false)
                {
                    //warnning
                    if (MessageBox.Show(this, "Bạn có muốn xóa Chi tiết hóa đơn này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        
                        table.Rows.RemoveAt(e.RowHandle);
                        gridControlChiTietHoaDonNhap.DataSource = null;
                        gridControlChiTietHoaDonNhap.DataSource = table;
                        //if (new DataAccess().deleteGiaXuatSP(objGiaXuatSP) == true)
                        //{
                        //    ((frmMain)(this.MdiParent)).setStatus("Xóa Giá sản phẩm thành công");
                        //    gridViewGiaXuatSP.DeleteRow(e.RowHandle);
                        //}
                        //else
                        //{
                        //    MessageBox.Show(this, "Xóa Giá sản phẩm không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    ((frmMain)(this.MdiParent)).setStatus("");
                        //}
                    }
                    else
                    {
                        //set the image to uncheck
                        
                        table.Rows[e.RowHandle]["DeleteChiTiet"] = false;
                        gridControlChiTietHoaDonNhap.DataSource = null;
                        gridControlChiTietHoaDonNhap.DataSource = table;

                    }
                }
            }
        }

        private void gridViewChiTietHoaDonNhap_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                int SoLuong = 0;
                decimal GiaNhap = 0;
                bool isValid = true;
                if (e.Column == colSoLuong || e.Column == colGiaNhap)
                {
                    try
                    {
                        SoLuong = Convert.ToInt32(table.Rows[e.RowHandle]["SoLuong"]);
                        if (SoLuong <= 0)
                        {
                            MessageBox.Show(this, "Số lượng không hợp lệ.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isValid = false;
                            
                        }
                    }
                    catch
                    {
                        MessageBox.Show(this, "Số lượng không hợp lệ.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                    }
                    try
                    {
                        GiaNhap = Convert.ToDecimal(table.Rows[e.RowHandle]["GiaNhap"]);
                        if (GiaNhap <= 0)
                        {
                            MessageBox.Show(this, "Giá nhập không hợp lệ.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            isValid = false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show(this, "Giá nhập không hợp lệ.", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        isValid = false;
                    }
                    if (isValid == true)
                    {
                        decimal TongTien = SoLuong * GiaNhap;
                        table.Rows[e.RowHandle]["TongTien"] = TongTien;
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        btnSave.Enabled = false;
                    }
                    gridControlChiTietHoaDonNhap.DataSource = null;
                    gridControlChiTietHoaDonNhap.DataSource = table;

                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //save Hoa Don
            HoaDonNhap objHoaDonNhap = new HoaDonNhap();
            objHoaDonNhap.Ngay = dateNgay.DateTime;
            objHoaDonNhap.IDNhanvien = arrIDNhanvien[cboNhanvien.SelectedIndex];
            objHoaDonNhap.Ghichu = txtGhiChu.Text;
            int IDHoaDonNhap = new DataAccess().insertHoaDonNhap(objHoaDonNhap);
            if (IDHoaDonNhap >= 0)
            {
                foreach (DataRow aRow in table.Rows)
                {
                    ChiTietHoaDonNhap objChiTiet = new ChiTietHoaDonNhap();
                    objChiTiet.IDHoaDonNhap = IDHoaDonNhap;
                    objChiTiet.IDSanPham = Convert.ToInt32(aRow["IDSanPham"]);
                    objChiTiet.GiaNhap = Convert.ToDecimal(aRow["GiaNhap"]);
                    objChiTiet.SoLuong = Convert.ToInt32(aRow["SoLuong"]);
                    if (new DataAccess().insertChiTietHoaDonNhap(objChiTiet) < 0)
                    {
                        //error
                        MessageBox.Show(this, "Thêm mới Chi tiết hóa đơn nhập không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //delete
                        new DataAccess().deleteHoaDonNhap(objHoaDonNhap);
                    }
                }
            }
            else
            {
                //error
                MessageBox.Show(this, "Thêm mới Hóa đơn nhập không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btnAddChiTietHD.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = true;
        }

        private void frmAddHoaDonNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (fInvoice != null)
            {
                fInvoice.frmInvoice_Load(null, null);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtGhiChu.Text = "";
            table.Rows.Clear();
            btnClear.Enabled = false;
            btnAddChiTietHD.Enabled = true;
            btnSave.Enabled = true;
        }
        private string formatCurrentcy(string text)
        {
            string result = "";
            int count = 1;
            for (int i = text.Length - 1; i > 0; i--)
            {
                result = text[i] + result;
                if (count++ % 3 == 0)
                    result = "," + result;
            }
            result = text[0] + result;
            return result;
        }
        private void gridViewChiTietHoaDonNhap_CustomDrawFooterCell(object sender, DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column == colTongTien)
            {
                string text = e.Info.DisplayText;
                if (text.Length > 3 && text.IndexOf(',') > 0)
                {
                   
                }
                else
                {
                    e.Appearance.Font = new Font("Tahoma", 10F);

                    e.Info.DisplayText = formatCurrentcy(text);
                    e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Top, e.Info.Bounds.Width, e.Info.Bounds.Height + 10);
                    this.gridViewChiTietHoaDonNhap.CustomDrawFooterCell -= new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridViewChiTietHoaDonNhap_CustomDrawFooterCell);
                }
            }
            else
            {
                e.Handled = true;
            }            
        }

        
    }
}