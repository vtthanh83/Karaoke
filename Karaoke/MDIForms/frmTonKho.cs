using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BKIT.Model;
using DevExpress.XtraGrid.Views.Grid;

namespace Karaoke.MDIForms
{
    public partial class frmTonKho : DevExpress.XtraEditors.XtraForm
    {
        public frmTonKho()
        {
            InitializeComponent();
            TonKho.Columns.Add("IDSanPham", typeof(int));
            TonKho.Columns.Add("IDHoaDonNhap", typeof(int));
            TonKho.Columns.Add("IDHoaDonXuat", typeof(int));
            TonKho.Columns.Add("DanhMuc", typeof(string));
            TonKho.Columns.Add("SoLuong", typeof(int));
            TonKho.Columns.Add("Ngay", typeof(DateTime));
            TonKho.Columns.Add("TenSanPham", typeof(string));
            gridControlTonKho.DataSource = TonKho;
        }
        DataTable TonKho = new DataTable();
        private void frmTonKho_Load(object sender, EventArgs e)
        {
            gridControlNhomSP.DataSource = new DataAccess().getAllNhomSP().Tables[0];
            

        }

        private void gridViewNhomSP_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            int IDNhomSP = Convert.ToInt32(gridViewNhomSP.GetRowCellValue(e.FocusedRowHandle, "IDNhomSP"));
            if (IDNhomSP != 0)
            {
                gridControlSanPham.DataSource = new DataAccess().getSanPhamByIDNhomSP(IDNhomSP).Tables[0];
            }
            else
            {
                gridControlSanPham.DataSource = new DataAccess().getAllSanPham().Tables[0];
            }
        }

       
        private void gridViewSanPham_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {            
            
        }

        private void gridViewTonKho_DoubleClick(object sender, EventArgs e)
        {
            int rowindex = gridViewTonKho.FocusedRowHandle;
            if (rowindex > 0)
            {
                int IDHoaDonNhap = Convert.ToInt32(gridViewTonKho.GetRowCellValue(rowindex, "IDHoaDonNhap"));
                int IDHoaDonXuat = Convert.ToInt32(gridViewTonKho.GetRowCellValue(rowindex, "IDHoaDonXuat"));
                if (IDHoaDonNhap != -1)
                {
                    //get HoaDonNhap info
                    frmHoaDonNhapDetail fHoaDonNhapDetail = new frmHoaDonNhapDetail(IDHoaDonNhap);
                    fHoaDonNhapDetail.ShowDialog();
                }
                else if(IDHoaDonXuat != -1)
                {
                    //get HoaDonXuat info
                }
            }
        }

       
        List<int> listIDSanPham = new List<int>();
        List<int> listSoLuong = new List<int>();
        private void gridViewSanPham_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            TonKho.Rows.Clear();
            DataSet ds;
            listIDSanPham.Clear();
            listSoLuong.Clear();
            int SoLuong = 0;
            foreach (int index in gridViewSanPham.GetSelectedRows())
            {
                int IDSanPham = Convert.ToInt32(gridViewSanPham.GetRowCellValue(index, "IDSanPham"));
                listIDSanPham.Add(IDSanPham);
                string TenSanPham = Convert.ToString(gridViewSanPham.GetRowCellValue(index, "TenSanPham"));
                DataRow aRow = TonKho.NewRow();
                aRow["IDSanPham"] = IDSanPham;
                aRow["IDHoaDonNhap"] = -1;
                aRow["IDHoaDonXuat"] = -1;
                aRow["DanhMuc"] = "Tồn kho đầu kì";
                aRow["SoLuong"] = new DataAccess().getTonKhoDauKi(IDSanPham);
                aRow["TenSanPham"] = TenSanPham;
                SoLuong = Convert.ToInt32(aRow["SoLuong"]);
                DateTime ngay = new DataAccess().getNgayTonKhoDauKi(IDSanPham);
                if (ngay != new DateTime(1900, 1, 1))
                    aRow["Ngay"] = ngay;
                TonKho.Rows.Add(aRow);

                // ton kho san pham trong hoa don (trong phong chua tinh tien) chua xuat

                DataSet temp = new DataAccess().getAllNotClosedHDXOfProductID(IDSanPham);
                if (temp != null && temp.Tables[0].Rows.Count > 0 && !string.IsNullOrEmpty(temp.Tables[0].Rows[0][0].ToString()))
                {
                    aRow = TonKho.NewRow();
                    aRow["IDSanPham"] = IDSanPham;
                    aRow["IDHoaDonNhap"] = -2;
                    aRow["IDHoaDonXuat"] = -2;
                    aRow["DanhMuc"] = "Sản phẩm chưa tính tiền";
                    aRow["SoLuong"] = temp.Tables[0].Rows[0][0];
                    aRow["TenSanPham"] = TenSanPham;
                    TonKho.Rows.Add(aRow);
                    SoLuong += Convert.ToInt32(aRow["SoLuong"]);
                }

                // san pham duoc xuat khong theo phong karaoke (ban ra khong thuoc quy trinh karaoke)
                DataSet temp1 = new DataAccess().getSoLuongSPBanRa();
                if (temp1 != null && temp1.Tables[0].Rows.Count > 0 && !string.IsNullOrEmpty(temp1.Tables[0].Rows[0][0].ToString()))
                {
                    aRow = TonKho.NewRow();
                    aRow["IDSanPham"] = IDSanPham;
                    aRow["IDHoaDonNhap"] = -2;
                    aRow["IDHoaDonXuat"] = -2;
                    aRow["DanhMuc"] = "Sản phẩm chưa tính tiền";
                    aRow["SoLuong"] = temp1.Tables[0].Rows[0][0];
                    aRow["TenSanPham"] = TenSanPham;
                    TonKho.Rows.Add(aRow);
                    SoLuong += Convert.ToInt32(aRow["SoLuong"]);
                }
                // san pham duoc dieu chinh trong phieu dieu chinh
                DataSet temp2 = new DataAccess().getSLSPPhieuDieuChinhTonKhoByIDSanPham(IDSanPham);
                if (temp2 != null && temp2.Tables[0].Rows.Count > 0 && !string.IsNullOrEmpty(temp2.Tables[0].Rows[0][0].ToString()))
                {
                    aRow = TonKho.NewRow();
                    aRow["IDSanPham"] = IDSanPham;
                    aRow["IDHoaDonNhap"] = -2;
                    aRow["IDHoaDonXuat"] = -2;
                    aRow["DanhMuc"] = "Điều chỉnh tồn kho";
                    aRow["SoLuong"] = temp2.Tables[0].Rows[0][0];
                    aRow["TenSanPham"] = TenSanPham;
                    TonKho.Rows.Add(aRow);
                    SoLuong += Convert.ToInt32(aRow["SoLuong"]);
                }

                // ----------------

                // san pham pha che....
                DataSet tmpSPPhaChe = new DataAccess().getSLSPDaDungByIDSanPham(IDSanPham);
                if (tmpSPPhaChe != null && tmpSPPhaChe.Tables[0].Rows.Count > 0 && !string.IsNullOrEmpty(tmpSPPhaChe.Tables[0].Rows[0][0].ToString()))
                {
                    aRow = TonKho.NewRow();
                    aRow["IDSanPham"] = IDSanPham;
                    aRow["IDHoaDonNhap"] = -2;
                    aRow["IDHoaDonXuat"] = -2;
                    aRow["DanhMuc"] = "Sản phẩm tiêu hao khi pha chế";
                    aRow["SoLuong"] = tmpSPPhaChe.Tables[0].Rows[0][0];
                    aRow["TenSanPham"] = TenSanPham;
                    TonKho.Rows.Add(aRow);
                    SoLuong += Convert.ToInt32(aRow["SoLuong"]);
                }
                // -------------------

                ds = new DataAccess().getHoaDonNhap(IDSanPham);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    aRow = TonKho.NewRow();
                    aRow["DanhMuc"] = "Nhập kho";
                    aRow["Ngay"] = Convert.ToDateTime(row["Ngay"]);
                    aRow["IDSanPham"] = IDSanPham;
                    aRow["IDHoaDonXuat"] = -1;
                    aRow["IDHoaDonNhap"] = Convert.ToInt32(row["IDHoaDonNhap"]);
                    aRow["SoLuong"] = Convert.ToInt32(row["SoLuong"]);
                    aRow["TenSanPham"] = Convert.ToString(row["TenSanPham"]);
                    TonKho.Rows.Add(aRow);
                    SoLuong += Convert.ToInt32(aRow["SoLuong"]);
                }
                ds = new DataAccess().getHoaDonXuat(IDSanPham);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    aRow = TonKho.NewRow();
                    aRow["DanhMuc"] = "Xuất kho";
                    aRow["Ngay"] = Convert.ToDateTime(row["Ngayxuat"]);
                    aRow["IDSanPham"] = IDSanPham;
                    aRow["IDHoaDonXuat"] = Convert.ToInt32(row["IDHoadonXuat"]);
                    aRow["IDHoaDonNhap"] = -1;
                    aRow["SoLuong"] = 0 - Convert.ToInt32(row["Soluong"]);
                    aRow["TenSanPham"] = Convert.ToString(row["TenSanPham"]);
                    TonKho.Rows.Add(aRow);


                    SoLuong += Convert.ToInt32(aRow["SoLuong"]);
                }
                listSoLuong.Add(SoLuong);
            }
            gridViewTonKho.ExpandAllGroups();
        }

        private void btnUpdateTonKho_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < listIDSanPham.Count; i++)
            {
                BKIT.Entities.TonKho objTonKho = new BKIT.Entities.TonKho();
                objTonKho.IDSanPham = listIDSanPham[i];
                objTonKho.SoLuong = listSoLuong[i];
                objTonKho.Ngay = DateTime.Now.Date;
                if (new DataAccess().insertTonKho(objTonKho) <0)
                {
                    MessageBox.Show(this, "Cập nhật tồn kho không thành công!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ((frmMain)(this.MdiParent)).setStatus("Cập nhật tồn kho thành công");


          
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }


    }
}