namespace Karaoke.MDIForms
{
    partial class frmTonKho
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
            this.gridControlSanPham = new DevExpress.XtraGrid.GridControl();
            this.gridViewSanPham = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkDeleteSanPham = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridControlNhomSP = new DevExpress.XtraGrid.GridControl();
            this.gridViewNhomSP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNhomSP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkDeleteNhomSP = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridControlTonKho = new DevExpress.XtraGrid.GridControl();
            this.gridViewTonKho = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoluong = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnUpdateTonKho = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeleteSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNhomSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhomSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeleteNhomSP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTonKho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControlSanPham
            // 
            this.gridControlSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlSanPham.EmbeddedNavigator.Name = "";
            this.gridControlSanPham.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridControlSanPham.FormsUseDefaultLookAndFeel = false;
            this.gridControlSanPham.Location = new System.Drawing.Point(2, 2);
            this.gridControlSanPham.MainView = this.gridViewSanPham;
            this.gridControlSanPham.Name = "gridControlSanPham";
            this.gridControlSanPham.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkDeleteSanPham});
            this.gridControlSanPham.Size = new System.Drawing.Size(277, 316);
            this.gridControlSanPham.TabIndex = 3;
            this.gridControlSanPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSanPham});
            // 
            // gridViewSanPham
            // 
            this.gridViewSanPham.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewSanPham.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewSanPham.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn10});
            this.gridViewSanPham.GridControl = this.gridControlSanPham;
            this.gridViewSanPham.Name = "gridViewSanPham";
            this.gridViewSanPham.NewItemRowText = "Chọn Nhóm sản phẩm, Click vào đây để thêm mới";
            this.gridViewSanPham.OptionsSelection.MultiSelect = true;
            this.gridViewSanPham.OptionsView.ShowGroupPanel = false;
            this.gridViewSanPham.RowHeight = 30;
            this.gridViewSanPham.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewSanPham_FocusedRowChanged);
            this.gridViewSanPham.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridViewSanPham_SelectionChanged);
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "IDSanPham";
            this.gridColumn4.FieldName = "IDSanPham";
            this.gridColumn4.Name = "gridColumn4";
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "Sản phẩm";
            this.gridColumn5.FieldName = "TenSanPham";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowFocus = false;
            this.gridColumn5.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 140;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "IDNhomSP";
            this.gridColumn10.FieldName = "IDNhomSP";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // chkDeleteSanPham
            // 
            this.chkDeleteSanPham.AutoHeight = false;
            this.chkDeleteSanPham.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.chkDeleteSanPham.Name = "chkDeleteSanPham";
            this.chkDeleteSanPham.PictureChecked = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            this.chkDeleteSanPham.PictureGrayed = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            this.chkDeleteSanPham.PictureUnchecked = global::Karaoke.Properties.Resources._1325149282_button_ok;
            // 
            // gridControlNhomSP
            // 
            this.gridControlNhomSP.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControlNhomSP.EmbeddedNavigator.Name = "";
            this.gridControlNhomSP.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridControlNhomSP.FormsUseDefaultLookAndFeel = false;
            this.gridControlNhomSP.Location = new System.Drawing.Point(2, 2);
            this.gridControlNhomSP.MainView = this.gridViewNhomSP;
            this.gridControlNhomSP.Name = "gridControlNhomSP";
            this.gridControlNhomSP.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkDeleteNhomSP});
            this.gridControlNhomSP.Size = new System.Drawing.Size(281, 238);
            this.gridControlNhomSP.TabIndex = 2;
            this.gridControlNhomSP.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewNhomSP});
            // 
            // gridViewNhomSP
            // 
            this.gridViewNhomSP.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewNhomSP.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewNhomSP.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.colNhomSP});
            this.gridViewNhomSP.GridControl = this.gridControlNhomSP;
            this.gridViewNhomSP.Name = "gridViewNhomSP";
            this.gridViewNhomSP.NewItemRowText = "Click vào đây để thêm mới";
            this.gridViewNhomSP.OptionsView.ShowGroupPanel = false;
            this.gridViewNhomSP.RowHeight = 30;
            this.gridViewNhomSP.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewNhomSP_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "IDNhomSP";
            this.gridColumn1.FieldName = "IDNhomSP";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // colNhomSP
            // 
            this.colNhomSP.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colNhomSP.AppearanceCell.Options.UseFont = true;
            this.colNhomSP.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.colNhomSP.AppearanceHeader.Options.UseFont = true;
            this.colNhomSP.Caption = "Nhóm Sản phẩm";
            this.colNhomSP.FieldName = "TenNhomSP";
            this.colNhomSP.Name = "colNhomSP";
            this.colNhomSP.OptionsColumn.AllowEdit = false;
            this.colNhomSP.OptionsColumn.AllowFocus = false;
            this.colNhomSP.OptionsColumn.AllowMove = false;
            this.colNhomSP.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colNhomSP.OptionsColumn.ReadOnly = true;
            this.colNhomSP.Visible = true;
            this.colNhomSP.VisibleIndex = 0;
            this.colNhomSP.Width = 177;
            // 
            // chkDeleteNhomSP
            // 
            this.chkDeleteNhomSP.AutoHeight = false;
            this.chkDeleteNhomSP.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.chkDeleteNhomSP.Name = "chkDeleteNhomSP";
            this.chkDeleteNhomSP.PictureChecked = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            this.chkDeleteNhomSP.PictureGrayed = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            this.chkDeleteNhomSP.PictureUnchecked = global::Karaoke.Properties.Resources._1325149282_button_ok;
            // 
            // gridControlTonKho
            // 
            this.gridControlTonKho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlTonKho.EmbeddedNavigator.Name = "";
            this.gridControlTonKho.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridControlTonKho.FormsUseDefaultLookAndFeel = false;
            this.gridControlTonKho.Location = new System.Drawing.Point(2, 20);
            this.gridControlTonKho.MainView = this.gridViewTonKho;
            this.gridControlTonKho.Name = "gridControlTonKho";
            this.gridControlTonKho.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControlTonKho.Size = new System.Drawing.Size(715, 495);
            this.gridControlTonKho.TabIndex = 4;
            this.gridControlTonKho.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTonKho});
            // 
            // gridViewTonKho
            // 
            this.gridViewTonKho.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewTonKho.Appearance.GroupFooter.Options.UseFont = true;
            this.gridViewTonKho.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewTonKho.Appearance.GroupRow.Options.UseFont = true;
            this.gridViewTonKho.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridViewTonKho.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewTonKho.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.colSoluong,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn3});
            this.gridViewTonKho.FooterPanelHeight = 40;
            this.gridViewTonKho.GridControl = this.gridControlTonKho;
            this.gridViewTonKho.GroupCount = 1;
            this.gridViewTonKho.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoLuong", this.colSoluong, "")});
            this.gridViewTonKho.Name = "gridViewTonKho";
            this.gridViewTonKho.NewItemRowText = "Chọn Nhóm sản phẩm, Click vào đây để thêm mới";
            this.gridViewTonKho.OptionsView.ShowGroupPanel = false;
            this.gridViewTonKho.RowHeight = 30;
            this.gridViewTonKho.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn3, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewTonKho.DoubleClick += new System.EventHandler(this.gridViewTonKho_DoubleClick);
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "Danh mục";
            this.gridColumn2.FieldName = "DanhMuc";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.AllowFocus = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 198;
            // 
            // colSoluong
            // 
            this.colSoluong.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSoluong.AppearanceCell.Options.UseFont = true;
            this.colSoluong.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSoluong.AppearanceHeader.Options.UseFont = true;
            this.colSoluong.Caption = "Số lượng";
            this.colSoluong.FieldName = "SoLuong";
            this.colSoluong.Name = "colSoluong";
            this.colSoluong.OptionsColumn.AllowEdit = false;
            this.colSoluong.OptionsColumn.AllowFocus = false;
            this.colSoluong.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSoluong.Visible = true;
            this.colSoluong.VisibleIndex = 2;
            this.colSoluong.Width = 97;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "IDSanPham";
            this.gridColumn6.FieldName = "IDSanPham";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "IDHoaDonNhap";
            this.gridColumn7.FieldName = "IDHoaDonNhap";
            this.gridColumn7.Name = "gridColumn7";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IDHoaDonXuat";
            this.gridColumn8.FieldName = "IDHoaDonXuat";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // gridColumn9
            // 
            this.gridColumn9.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn9.AppearanceCell.Options.UseFont = true;
            this.gridColumn9.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn9.AppearanceHeader.Options.UseFont = true;
            this.gridColumn9.Caption = "Ngày";
            this.gridColumn9.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.gridColumn9.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumn9.FieldName = "Ngay";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.AllowFocus = false;
            this.gridColumn9.OptionsColumn.AllowMove = false;
            this.gridColumn9.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 0;
            this.gridColumn9.Width = 122;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "Sản phẩm";
            this.gridColumn3.FieldName = "TenSanPham";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 139;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.PictureChecked = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            this.repositoryItemCheckEdit1.PictureGrayed = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            this.repositoryItemCheckEdit1.PictureUnchecked = global::Karaoke.Properties.Resources._1325149282_button_ok;
            // 
            // btnUpdateTonKho
            // 
            this.btnUpdateTonKho.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateTonKho.Appearance.Options.UseFont = true;
            this.btnUpdateTonKho.Location = new System.Drawing.Point(5, 5);
            this.btnUpdateTonKho.Name = "btnUpdateTonKho";
            this.btnUpdateTonKho.Size = new System.Drawing.Size(100, 30);
            this.btnUpdateTonKho.TabIndex = 5;
            this.btnUpdateTonKho.Text = "Cập nhật";
            this.btnUpdateTonKho.Click += new System.EventHandler(this.btnUpdateTonKho_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(120, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(100, 30);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Xuất Report";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelControl1.Controls.Add(this.panelControl2);
            this.panelControl1.Controls.Add(this.gridControlNhomSP);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(285, 562);
            this.panelControl1.TabIndex = 7;
            // 
            // panelControl2
            // 
            this.panelControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelControl2.Controls.Add(this.gridControlSanPham);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(2, 240);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(281, 320);
            this.panelControl2.TabIndex = 3;
            // 
            // panelControl3
            // 
            this.panelControl3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelControl3.Controls.Add(this.groupControl1);
            this.panelControl3.Controls.Add(this.panelControl4);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(285, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(723, 562);
            this.panelControl3.TabIndex = 8;
            // 
            // panelControl4
            // 
            this.panelControl4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.panelControl4.Controls.Add(this.btnUpdateTonKho);
            this.panelControl4.Controls.Add(this.simpleButton1);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl4.Location = new System.Drawing.Point(2, 2);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(719, 41);
            this.panelControl4.TabIndex = 0;
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl1.Controls.Add(this.gridControlTonKho);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(2, 43);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(719, 517);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Tồn kho sản phẩm";
            // 
            // frmTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmTonKho";
            this.Text = "Thống kê Tồn kho";
            this.Load += new System.EventHandler(this.frmTonKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeleteSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlNhomSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewNhomSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkDeleteNhomSP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTonKho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlSanPham;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkDeleteSanPham;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.GridControl gridControlNhomSP;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewNhomSP;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colNhomSP;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkDeleteNhomSP;
        private DevExpress.XtraGrid.GridControl gridControlTonKho;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTonKho;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colSoluong;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraEditors.SimpleButton btnUpdateTonKho;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.PanelControl panelControl4;
    }
}