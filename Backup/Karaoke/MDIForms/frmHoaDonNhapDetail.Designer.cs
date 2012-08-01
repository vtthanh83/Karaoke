namespace Karaoke.MDIForms
{
    partial class frmHoaDonNhapDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControlChiTietHoaDonNhap = new DevExpress.XtraGrid.GridControl();
            this.gridViewChiTietHoaDonNhap = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoLuong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiaNhap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTongTien = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlChiTietHoaDonNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChiTietHoaDonNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlChiTietHoaDonNhap
            // 
            this.gridControlChiTietHoaDonNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlChiTietHoaDonNhap.EmbeddedNavigator.Name = "";
            this.gridControlChiTietHoaDonNhap.FormsUseDefaultLookAndFeel = false;
            this.gridControlChiTietHoaDonNhap.Location = new System.Drawing.Point(0, 0);
            this.gridControlChiTietHoaDonNhap.MainView = this.gridViewChiTietHoaDonNhap;
            this.gridControlChiTietHoaDonNhap.Name = "gridControlChiTietHoaDonNhap";
            this.gridControlChiTietHoaDonNhap.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemCheckEdit1});
            this.gridControlChiTietHoaDonNhap.Size = new System.Drawing.Size(543, 328);
            this.gridControlChiTietHoaDonNhap.TabIndex = 9;
            this.gridControlChiTietHoaDonNhap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewChiTietHoaDonNhap});
            // 
            // gridViewChiTietHoaDonNhap
            // 
            this.gridViewChiTietHoaDonNhap.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridViewChiTietHoaDonNhap.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewChiTietHoaDonNhap.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.colSoLuong,
            this.colGiaNhap,
            this.gridColumn11,
            this.colTongTien});
            this.gridViewChiTietHoaDonNhap.FooterPanelHeight = 40;
            this.gridViewChiTietHoaDonNhap.GridControl = this.gridControlChiTietHoaDonNhap;
            this.gridViewChiTietHoaDonNhap.Name = "gridViewChiTietHoaDonNhap";
            this.gridViewChiTietHoaDonNhap.OptionsView.ShowFooter = true;
            this.gridViewChiTietHoaDonNhap.OptionsView.ShowGroupPanel = false;
            this.gridViewChiTietHoaDonNhap.RowHeight = 30;
            this.gridViewChiTietHoaDonNhap.CustomDrawFooterCell += new DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventHandler(this.gridViewChiTietHoaDonNhap_CustomDrawFooterCell);
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IDHoaDonNhap";
            this.gridColumn6.FieldName = "IDHoaDonNhap";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "IDChiTietHoaDonNhap";
            this.gridColumn7.FieldName = "IDChiTietHoaDonNhap";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IDSanPham";
            this.gridColumn8.FieldName = "IDSanPham";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // colSoLuong
            // 
            this.colSoLuong.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colSoLuong.AppearanceCell.Options.UseFont = true;
            this.colSoLuong.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colSoLuong.AppearanceHeader.Options.UseFont = true;
            this.colSoLuong.Caption = "Số lượng";
            this.colSoLuong.FieldName = "SoLuong";
            this.colSoLuong.Name = "colSoLuong";
            this.colSoLuong.OptionsColumn.AllowEdit = false;
            this.colSoLuong.OptionsColumn.AllowFocus = false;
            this.colSoLuong.OptionsColumn.ReadOnly = true;
            this.colSoLuong.Visible = true;
            this.colSoLuong.VisibleIndex = 1;
            this.colSoLuong.Width = 90;
            // 
            // colGiaNhap
            // 
            this.colGiaNhap.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colGiaNhap.AppearanceCell.Options.UseFont = true;
            this.colGiaNhap.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colGiaNhap.AppearanceHeader.Options.UseFont = true;
            this.colGiaNhap.Caption = "Giá nhập";
            this.colGiaNhap.ColumnEdit = this.repositoryItemTextEdit1;
            this.colGiaNhap.FieldName = "GiaNhap";
            this.colGiaNhap.Name = "colGiaNhap";
            this.colGiaNhap.OptionsColumn.AllowEdit = false;
            this.colGiaNhap.OptionsColumn.AllowFocus = false;
            this.colGiaNhap.OptionsColumn.ReadOnly = true;
            this.colGiaNhap.Visible = true;
            this.colGiaNhap.VisibleIndex = 2;
            this.colGiaNhap.Width = 138;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // gridColumn11
            // 
            this.gridColumn11.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridColumn11.AppearanceCell.Options.UseFont = true;
            this.gridColumn11.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridColumn11.AppearanceHeader.Options.UseFont = true;
            this.gridColumn11.Caption = "Sản phẩm";
            this.gridColumn11.FieldName = "TenSanPham";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.OptionsColumn.AllowEdit = false;
            this.gridColumn11.OptionsColumn.AllowFocus = false;
            this.gridColumn11.OptionsColumn.ReadOnly = true;
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 0;
            this.gridColumn11.Width = 122;
            // 
            // colTongTien
            // 
            this.colTongTien.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colTongTien.AppearanceCell.Options.UseFont = true;
            this.colTongTien.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 12F);
            this.colTongTien.AppearanceHeader.Options.UseFont = true;
            this.colTongTien.Caption = "Tổng tiền";
            this.colTongTien.ColumnEdit = this.repositoryItemTextEdit2;
            this.colTongTien.FieldName = "TongTien";
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.OptionsColumn.AllowEdit = false;
            this.colTongTien.OptionsColumn.AllowFocus = false;
            this.colTongTien.OptionsColumn.ReadOnly = true;
            this.colTongTien.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colTongTien.Visible = true;
            this.colTongTien.VisibleIndex = 3;
            this.colTongTien.Width = 136;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.DisplayFormat.FormatString = "n0";
            this.repositoryItemTextEdit2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.EditFormat.FormatString = "n0";
            this.repositoryItemTextEdit2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemGridLookUpEdit1
            // 
            this.repositoryItemGridLookUpEdit1.AutoHeight = false;
            this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
            this.repositoryItemGridLookUpEdit1.View = this.gridView1;
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.PictureChecked = global::Karaoke.Properties.Resources._1325149282_button_ok;
            this.repositoryItemCheckEdit1.PictureGrayed = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            this.repositoryItemCheckEdit1.PictureUnchecked = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            // 
            // frmHoaDonNhapDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 328);
            this.Controls.Add(this.gridControlChiTietHoaDonNhap);
            this.Name = "frmHoaDonNhapDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết hóa đơn nhập";
            this.Load += new System.EventHandler(this.frmHoaDonNhapDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlChiTietHoaDonNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChiTietHoaDonNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlChiTietHoaDonNhap;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewChiTietHoaDonNhap;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn colSoLuong;
        private DevExpress.XtraGrid.Columns.GridColumn colGiaNhap;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn colTongTien;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}