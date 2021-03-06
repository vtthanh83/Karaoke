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
    public partial class frmGhiChuXuLy : DevExpress.XtraEditors.XtraForm
    {
        public frmGhiChuXuLy()
        {
            InitializeComponent();
        }

        private void frmGhiChuXuLy_Load(object sender, EventArgs e)
        {
            loadDataRelatedToIssueProcessing();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenGoiNho.Text))
            {
                MessageBox.Show("Nhập tên gợi nhớ cho ghi chú xử lý.");
                txtTenGoiNho.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboLoaiXuLy.Text))
            {
                MessageBox.Show("Chọn loại tình huống cho ghi chú xử lý.");
                cboLoaiXuLy.Focus();
                return;
            }
            VanDe objVande = new VanDe();

            objVande.GhiChu = txtGhiChu.Text;
            objVande.NgayCapNhat = DateTime.Now.Date;
            objVande.Ten = txtTenGoiNho.Text;
            objVande.IDLoaiVD = new DataAccess().getIDLoaiVDByTenLoaiVD(cboLoaiXuLy.Text);
            objVande.UserID = Program.IDNhanvien;
            if (!string.IsNullOrEmpty(txtTien.Text))
            {
                objVande.Tien = Convert.ToInt32(txtTien.Text);
            }
            if (new DataAccess().insertVanDe(objVande) >= 0)
            {
                MessageBox.Show("Thêm ghi chú thành công");
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm ghi chú không thành công");
                this.Close();
            }
        }

        private void btnThemLoaiXuLy_Click(object sender, EventArgs e)
        {
            frmQuanLyLoaiVanDe objLoaiVanDe = new frmQuanLyLoaiVanDe();
            objLoaiVanDe.ShowDialog();
            loadDataRelatedToIssueProcessing();
        }
        // load cac thong tin lien quan
        private void loadDataRelatedToIssueProcessing()
        {
            // load Ten cac loai su co
            cboLoaiXuLy.Properties.Items.Clear();
            DataSet dsLoaiVD = new DataAccess().getAllLoaiVD();
            if (dsLoaiVD != null)
            {
                foreach (DataRow item in dsLoaiVD.Tables[0].Rows)
                {
                    cboLoaiXuLy.Properties.Items.Add(item["TenVD"]);
                }
            }
                       
        }
      
    }
}