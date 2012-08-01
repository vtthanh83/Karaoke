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
    public partial class frmHoaDonNhapDetail : DevExpress.XtraEditors.XtraForm
    {
        public frmHoaDonNhapDetail()
        {
            InitializeComponent();
        }
        private int IDHoaDonNhap;
        public frmHoaDonNhapDetail(int ID)
        {
            InitializeComponent();
            IDHoaDonNhap = ID;
        }
        DataTable table = new DataTable();
        private void frmHoaDonNhapDetail_Load(object sender, EventArgs e)
        {
            //Load Data
            DataSet ds = new DataAccess().getAllChiTietHoaDonNhapByIDHoaDonNhap(IDHoaDonNhap);
            gridControlChiTietHoaDonNhap.DataSource = ds.Tables[0];
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
                e.Appearance.Font = new Font("Arial", 14);
                e.Info.DisplayText = formatCurrentcy(text);
                e.Info.Bounds = new Rectangle(e.Info.Bounds.Left, e.Info.Bounds.Top, e.Info.Bounds.Width, e.Info.Bounds.Height + 10);
            }
            else
            {
                e.Handled = true;
            }
        }
        
    }
}