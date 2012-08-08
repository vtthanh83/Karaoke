using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Karaoke.MDIForms
{
    public partial class frmWarningRoom : Form
    {
        
        private string mess;
        private DataTable warnReceipt = new DataTable();
        #region Init
        public frmWarningRoom()
        {
            InitializeComponent();
            warnReceipt.Columns.Add("IDPhong", typeof(int));
            warnReceipt.Columns.Add("IDHoadonXuat", typeof(int));
            warnReceipt.Columns.Add("Phong", typeof(string));
            warnReceipt.Columns.Add("Tinhtrang", typeof(string));
            warnReceipt.Columns.Add("TgConlai", typeof(int));
            warnReceipt.Columns.Add("Hoadon", typeof(string));
            warnReceipt.Columns.Add("Dongphong", typeof(Boolean));
            warnReceipt.Columns.Add("Taomoi", typeof(Boolean));

        }
        private void InitData()
        {
            DataSet ds = new DataAccess().getAllWarningOpenningHoadonxuat();
            if (ds == null) return;
            if (ds.Tables[0].Rows.Count <= 0) return;
            int i;
            for (i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                DataRow aRow = oldProduct.NewRow();
                aRow["IDSanpham"] = dsBillProduct.Tables[0].Rows[i]["IDSanpham"];
                aRow["IDChitietHDXuat"] = dsBillProduct.Tables[0].Rows[i]["IDchitietHDXuat"];
                aRow["Soluong"] = dsBillProduct.Tables[0].Rows[i]["Soluong"];
                aRow["Gia"] = dsBillProduct.Tables[0].Rows[i]["Gia"];
                aRow["Giam"] = dsBillProduct.Tables[0].Rows[i]["Giam"];
                aRow["TenSanPham"] = dsBillProduct.Tables[0].Rows[i]["TenSanPham"];
                aRow["Ghichu"] = dsBillProduct.Tables[0].Rows[i]["Ghichu"];
                aRow["Trangthai"] = dsBillProduct.Tables[0].Rows[i]["Trangthai"];
                aRow["Transfer"] = 0;
                oldProduct.Rows.Add(aRow);
            }
        }
        #endregion

        private void frmReturnProduct_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
