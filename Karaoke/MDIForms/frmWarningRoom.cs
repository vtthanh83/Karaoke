using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BKIT.Entities;
using Karaoke.DataSets;
using BKIT.Model;

namespace Karaoke.MDIForms
{
    public partial class frmWarningRoom : Form
    {
        
        private string mess;
        private DataTable warnReceipt = new DataTable();
        public List<int> closeReceipt;
        public List<int> continueReceipt;
        #region Init
        public frmWarningRoom()
        {
            InitializeComponent();
            closeReceipt = new List<int>();
            continueReceipt = new List<int>();
            warnReceipt.Columns.Add("IDPhong", typeof(int));
            warnReceipt.Columns.Add("IDHoadonXuat", typeof(int));
            warnReceipt.Columns.Add("TenPhong", typeof(string));
            warnReceipt.Columns.Add("Tinhtrang", typeof(string));
            warnReceipt.Columns.Add("TgConlai", typeof(int));
            warnReceipt.Columns.Add("Hoadon", typeof(string));
            warnReceipt.Columns.Add("Dongphong", typeof(Boolean));
            warnReceipt.Columns.Add("Taomoi", typeof(Boolean));
            InitData();

        }
        private void InitData()
        {
            DataSet ds = new DataAccess().getAllWarningOpenningHoadonxuat();
            if (ds == null) return;
            if (ds.Tables[0].Rows.Count <= 0) return;
            int i;
            warnReceipt.Clear();
            for (i = 0; i < ds.Tables[0].Rows.Count;i++ )
            {
                DataRow aRow = warnReceipt.NewRow();
                
                aRow["IDPhong"] = ds.Tables[0].Rows[i]["IDPhong"];
                aRow["IDHoadonXuat"] = ds.Tables[0].Rows[i]["IDHoadonXuat"];
                aRow["TenPhong"] = ds.Tables[0].Rows[i]["TenPhong"];
                aRow["Hoadon"] = ds.Tables[0].Rows[i]["TenHoadon"];
                aRow["Dongphong"] = true;
                aRow["Taomoi"] = true;
                if (Convert.ToInt32(ds.Tables[0].Rows[i]["Trangthai"]) == 3) //printed receipt
                    aRow["Tinhtrang"] = "Đã in HĐ";
                else
                    aRow["Tinhtrang"] = "Chưa in HĐ";
                if (Convert.ToDateTime(ds.Tables[0].Rows[i]["GioKT"]) <= DateTime.Now)
                    aRow["TgConlai"] = 0;
                else
                {
                    TimeSpan ts = Convert.ToDateTime(ds.Tables[0].Rows[i]["GioKT"]).Subtract(DateTime.Now);
                    aRow["TgConlai"] = ts.Hours*60 + ts.Minutes;
                }
                if(Convert.ToInt32(aRow["TgConlai"]) < 10)
                    warnReceipt.Rows.Add(aRow);  
               }
            gridWarning.DataSource = warnReceipt;
        }
        #endregion
        private bool isNeedAction()
        {
            int i;
            for (i = 0; i < gridViewWarning.RowCount; i++)
            {
                if (Convert.ToInt32(gridViewWarning.GetRowCellValue(e.RowHandle, "TgConlai")) == 0)
                    return true;
            }
            return false;
        }
        private void frmReturnProduct_KeyDown(object sender, KeyEventArgs e)
        {
            this.Hide();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void gridViewWarning_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
               if (e.Column == colCloseRoom)
                {
                    if (MessageBox.Show("Bạn có muốn đóng phòng "+gridViewWarning.GetRowCellValue(e.RowHandle, "TenPhong").ToString()+"?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                        return;
                    closeReceipt.Add(Convert.ToInt32(gridViewWarning.GetRowCellValue(e.RowHandle, "IDHoadonXuat")));
                    gridViewWarning.DeleteRow(e.RowHandle);
                }
               else if (e.Column == colContinue)
               {
                   if (MessageBox.Show("Bạn có muốn mở hóa đơn mới với phòng " + gridViewWarning.GetRowCellValue(e.RowHandle, "TenPhong").ToString() + "?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.No)
                       return;
                   continueReceipt.Add(Convert.ToInt32(gridViewWarning.GetRowCellValue(e.RowHandle, "IDHoadonXuat")));
                   gridViewWarning.DeleteRow(e.RowHandle);
               }
            }
        }

        
    }
}
