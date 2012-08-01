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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace Karaoke.MDIForms
{
    public partial class frmInvoice : DevExpress.XtraEditors.XtraForm
    {
        public frmInvoice()
        {
            InitializeComponent();
        }
        private int HoaDonNhapRowsCount = -1;
        public void frmInvoice_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataAccess().getAllHoaDonNhap();
            HoaDonNhapRowsCount = ds.Tables[0].Rows.Count;
            gridControlHoaDonNhap.DataSource = ds.Tables[0];
            dateEditFrom.DateTime = DateTime.Now.Date;
            dateEditTo.DateTime = DateTime.Now.Date;

        }

        private void gridViewHoaDonNhap_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle >= 0 && e.FocusedRowHandle<HoaDonNhapRowsCount)
            {
                int IDHoaDonNhap = Convert.ToInt32(gridViewHoaDonNhap.GetRowCellValue(e.FocusedRowHandle, "IDHoaDonNhap"));
                gridControlChiTietHoaDonNhap.DataSource = new DataAccess().getAllChiTietHoaDonNhapByIDHoaDonNhap(IDHoaDonNhap).Tables[0];

                this.gridViewChiTietHoaDonNhap.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridViewChiTietHoaDonNhap_CustomDrawFooterCell);
            }
            else if (e.FocusedRowHandle < 0)
            {
                //frmAddHoaDonNhap fAddHoaDonNhap = new frmAddHoaDonNhap();
                //fAddHoaDonNhap.ShowDialog();
            }
        }

        private void gridViewHoaDonNhap_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRowView aRowView = (DataRowView)(e.Row);
            DataRow aRow = aRowView.Row;
            if (aRow.RowState == DataRowState.Added)
            {
                gridViewHoaDonNhap.SetFocusedRowModified();
                

            }
        }

        private void btnAddHoaDonNhap_Click(object sender, EventArgs e)
        {
            frmAddHoaDonNhap fAddHoaDonNhap = new frmAddHoaDonNhap();
            fAddHoaDonNhap.fInvoice = this;
            fAddHoaDonNhap.ShowDialog();
        }

        private void gridViewHoaDonNhap_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column == colDeleteHoaDonNhap)
                {
                    HoaDonNhap objHoaDonNhap = new HoaDonNhap();
                    objHoaDonNhap.IDHoaDonNhap = Convert.ToInt32(gridViewHoaDonNhap.GetRowCellValue(e.RowHandle, "IDHoaDonNhap"));

                    if (Convert.ToBoolean(gridViewHoaDonNhap.GetRowCellValue(e.RowHandle, colDeleteHoaDonNhap)) == true)
                    {
                        //warnning
                        if (MessageBox.Show(this, "Bạn có muốn xóa Hóa đơn nhập này không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            if (new DataAccess().deleteHoaDonNhap(objHoaDonNhap) == true)
                            {
                                ((frmMain)(this.MdiParent)).setStatus("Xóa Sản phẩm thành công");
                                gridViewHoaDonNhap.DeleteRow(e.RowHandle);
                                
                            }
                            else
                            {
                                MessageBox.Show(this, "Xóa Hóa đơn nhập không thành công", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            //set the image to uncheck

                            gridViewHoaDonNhap.SetRowCellValue(e.RowHandle, colDeleteHoaDonNhap, true);
                            
                        }
                    }
                }
            }
        }
        private string formatCurrentcy(string text)
        {
            if (text.IndexOf(',') >= 0)
                return text;
            string result = "";
            int count = 1;
            for (int i = text.Length - 1; i > 0; i--)
            {
                result = text[i] + result;
                if(count++ % 3 == 0)
                    result = "," + result;
            }
            result = text[0] + result;
            return result;
        }
        private void gridViewChiTietHoaDonNhap_CustomDrawFooterCell(object sender, FooterCellCustomDrawEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Column == colTongTien)
            {
                string text = e.Info.DisplayText;
                e.Appearance.Font = new Font("Tahoma", 10);
                if (text != "")
                {
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

        private void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dateFrom = dateEditFrom.DateTime;
                DateTime dateTo = dateEditTo.DateTime;
                DataSet ds = new DataAccess().getHoaDonNhap(dateFrom,dateTo);
                HoaDonNhapRowsCount = ds.Tables[0].Rows.Count;
                gridControlHoaDonNhap.DataSource = ds.Tables[0];
            }
            catch
            {
            }
        }

        
    }
}