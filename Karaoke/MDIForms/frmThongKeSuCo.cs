using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BKIT.Model;

using Karaoke.DataSets;
namespace Karaoke.MDIForms
{
    public partial class frmThongKeSuCo : DevExpress.XtraEditors.XtraForm
    {
        private DataSetThongKeVanDe detailVanDe = null;
        public frmThongKeSuCo()
        {
            InitializeComponent();
        }

        private void frmThongKeSuCo_Load(object sender, EventArgs e)
        {
            loadAllComboBoxData();
            loadAllThongKeGhiChu();
        }

        private void loadAllComboBoxData()
        {
            try
            {
                // load Ten nhan vien
                cboNVLapGhiChu.Properties.Items.Clear();
                DataSet ds = new DataAccess().getAllNhanvien();
                if (ds != null)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        cboNVLapGhiChu.Properties.Items.Add(item["Username"].ToString());
                    }
                }
                // load Ten cac loai su co
                cboLoaiGhiChu.Properties.Items.Clear();
                DataSet dsLoaiVD = new DataAccess().getAllLoaiVD();
                if (dsLoaiVD != null)
                {
                    foreach (DataRow item in dsLoaiVD.Tables[0].Rows)
                    {
                        cboLoaiGhiChu.Properties.Items.Add(item["TenVD"]);
                    }
                }      
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tải dữ liệu về nhân viên và loại sự cố không thành công.");
            }                  
        }
        private void loadAllThongKeGhiChu()
        {
            string sqlCommand = "";
            sqlCommand = "SELECT VanDe.IDVanDe, VanDe.IDLoaiVD, VanDe.UserID, VanDe.NgayCapNhat," +
                         " Nhanvien.Username, LoaiVD.TenVD, VanDe.Tien, VanDe.GhiChu ";
            sqlCommand += " FROM VanDe,LoaiVD,Nhanvien ";
            sqlCommand += " WHERE VanDe.IDLoaiVD = LoaiVD.IDLoaiVD AND VanDe.UserID = Nhanvien.IDNhanvien";
            DataSet dsResult = null;
            dsResult = new DataAccess().getDataByQuery(sqlCommand);
            int i = 0;
            gridViewThongKeGhiChu.Columns.Clear();
            gridControlThongKeGhiChu.DataSource = null;
            if (dsResult != null)
            {
                detailVanDe = new DataSetThongKeVanDe();
                for (i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                {                    
                    DataRow dr1 = detailVanDe.Tables[0].NewRow();
                   
                    dr1["Stt"] = (i + 1).ToString();
                    if (!string.IsNullOrEmpty(dsResult.Tables[0].Rows[i]["NgayCapNhat"].ToString()))
                    {
                        dr1["NgayCapNhat"] = Convert.ToDateTime(dsResult.Tables[0].Rows[i]["NgayCapNhat"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        dr1["NgayCapNhat"] = dsResult.Tables[0].Rows[i]["NgayCapNhat"].ToString();
                    }

                    dr1["Username"] = dsResult.Tables[0].Rows[i]["Username"].ToString();
                    dr1["Ten"] = dsResult.Tables[0].Rows[i]["TenVD"].ToString();                    
                    dr1["Tien"] = dsResult.Tables[0].Rows[i]["Tien"].ToString();
                    dr1["GhiChu"] = dsResult.Tables[0].Rows[i]["GhiChu"].ToString();
                    
                    detailVanDe.Tables[0].Rows.Add(dr1);
                }
              
                
                gridControlThongKeGhiChu.DataSource = detailVanDe.Tables[0];
                modifyColumnHeaderText();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void loadSearchedGhiChu()
        {
            string sqlCommand = "";
            DataAccess daTemp = new DataAccess();
            sqlCommand = "SELECT VanDe.IDVanDe, VanDe.IDLoaiVD, VanDe.UserID, VanDe.NgayCapNhat," +
                         " Nhanvien.Username, LoaiVD.TenVD, VanDe.Tien, VanDe.GhiChu ";
            sqlCommand += " FROM VanDe,LoaiVD,Nhanvien ";
            sqlCommand += " WHERE VanDe.IDLoaiVD = LoaiVD.IDLoaiVD AND VanDe.UserID = Nhanvien.IDNhanvien";

            // them dieu kien search...
            if (!string.IsNullOrEmpty(cboLoaiGhiChu.Text))
            {
                sqlCommand += " AND LoaiVD.IDLoaiVD = " + daTemp.getIDLoaiVDByTenLoaiVD(cboLoaiGhiChu.Text).ToString();
            }
            if (!string.IsNullOrEmpty(cboNVLapGhiChu.Text))
            {
                sqlCommand += " AND Nhanvien.IDNhanvien = " + daTemp.getIDNVByUsername(cboNVLapGhiChu.Text) ;
            }
            if (chkSearchTheoNgay.Checked == true)
            {
                if (!string.IsNullOrEmpty(dateEditStartNgayLapGhiChu.Text) && !string.IsNullOrEmpty(dateEditEndNgayLapGhiChu.Text))
                {
                    sqlCommand += " AND ( Year(VanDe.NgayCapNhat) > " + dateEditStartNgayLapGhiChu.DateTime.Year +
                    " or (Year(VanDe.NgayCapNhat) = " + dateEditStartNgayLapGhiChu.DateTime.Year + " and Month(VanDe.NgayCapNhat) > " + dateEditStartNgayLapGhiChu.DateTime.Month + ") " +
                    " or (Year(VanDe.NgayCapNhat) = " + dateEditStartNgayLapGhiChu.DateTime.Year + " and Month(VanDe.NgayCapNhat) = " + dateEditStartNgayLapGhiChu.DateTime.Month + " and Day(VanDe.NgayCapNhat) >= " + dateEditStartNgayLapGhiChu.DateTime.Day + "))" +
                    " AND ( Year(VanDe.NgayCapNhat) < " + dateEditEndNgayLapGhiChu.DateTime.Year +
                    " or (Year(VanDe.NgayCapNhat) = " + dateEditEndNgayLapGhiChu.DateTime.Year + " and Month(VanDe.NgayCapNhat) < " + dateEditEndNgayLapGhiChu.DateTime.Month + ") " +
                    " or (Year(VanDe.NgayCapNhat) = " + dateEditEndNgayLapGhiChu.DateTime.Year + " and Month(VanDe.NgayCapNhat) = " + dateEditEndNgayLapGhiChu.DateTime.Month + " and Day(VanDe.NgayCapNhat) <= " + dateEditEndNgayLapGhiChu.DateTime.Day + ")) ";
                }
            }
            DataSet dsResult = null;
            dsResult = new DataAccess().getDataByQuery(sqlCommand);
            int i = 0;
            gridViewThongKeGhiChu.Columns.Clear();
            gridControlThongKeGhiChu.DataSource = null;
            if (dsResult != null)
            {
                detailVanDe = new DataSetThongKeVanDe();
                for (i = 0; i < dsResult.Tables[0].Rows.Count; i++)
                {
                    DataRow dr1 = detailVanDe.Tables[0].NewRow();

                    dr1["Stt"] = (i + 1).ToString();
                    if (!string.IsNullOrEmpty(dsResult.Tables[0].Rows[i]["NgayCapNhat"].ToString()))
                    {
                        dr1["NgayCapNhat"] = Convert.ToDateTime(dsResult.Tables[0].Rows[i]["NgayCapNhat"]).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        dr1["NgayCapNhat"] = dsResult.Tables[0].Rows[i]["NgayCapNhat"].ToString();
                    }

                    dr1["Username"] = dsResult.Tables[0].Rows[i]["Username"].ToString();
                    dr1["Ten"] = dsResult.Tables[0].Rows[i]["TenVD"].ToString();
                    dr1["Tien"] = dsResult.Tables[0].Rows[i]["Tien"].ToString();
                    dr1["GhiChu"] = dsResult.Tables[0].Rows[i]["GhiChu"].ToString();

                    detailVanDe.Tables[0].Rows.Add(dr1);
                }


                gridControlThongKeGhiChu.DataSource = detailVanDe.Tables[0];
                modifyColumnHeaderText();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmViewReport frmView = new frmViewReport(detailVanDe);
            frmView.Show();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            loadSearchedGhiChu();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            loadAllThongKeGhiChu();
        }

        private void btnQuanLyLoaiSuCo_Click(object sender, EventArgs e)
        {
            frmQuanLyLoaiVanDe frmTKSC = new frmQuanLyLoaiVanDe();
            frmTKSC.ShowDialog();
        }
        private void modifyColumnHeaderText()
        {
            gridViewThongKeGhiChu.Columns[0].Caption = "Stt";
            gridViewThongKeGhiChu.Columns[1].Caption = "Ngày thiết lập";
            gridViewThongKeGhiChu.Columns[2].Caption = "Nhân viên thực hiện";
            gridViewThongKeGhiChu.Columns[3].Caption = "Tên vấn đề";
            gridViewThongKeGhiChu.Columns[4].Caption = "Tiền liên quan";
            gridViewThongKeGhiChu.Columns[5].Caption = "Ghi chú";
        }
    }
}