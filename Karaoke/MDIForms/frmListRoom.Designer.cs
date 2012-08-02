namespace Karaoke.MDIForms
{
    partial class frmListRoom
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListRoom));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridBusyRoom = new DevExpress.XtraGrid.GridControl();
            this.gridViewBusyRoom = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemImageEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemPictureEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gridRoom = new DevExpress.XtraGrid.GridControl();
            this.gridViewRoom = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoomStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkRoomStatus = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBusyRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBusyRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkRoomStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl1.Controls.Add(this.gridBusyRoom);
            this.groupControl1.Location = new System.Drawing.Point(275, 2);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(270, 593);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "Phòng đang hoạt động";
            // 
            // gridBusyRoom
            // 
            this.gridBusyRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBusyRoom.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridBusyRoom.EmbeddedNavigator.Name = "";
            this.gridBusyRoom.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridBusyRoom.FormsUseDefaultLookAndFeel = false;
            this.gridBusyRoom.Location = new System.Drawing.Point(2, 20);
            this.gridBusyRoom.MainView = this.gridViewBusyRoom;
            this.gridBusyRoom.Margin = new System.Windows.Forms.Padding(4);
            this.gridBusyRoom.Name = "gridBusyRoom";
            this.gridBusyRoom.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit3,
            this.repositoryItemImageEdit3,
            this.repositoryItemCheckEdit2,
            this.repositoryItemImageEdit4,
            this.repositoryItemPictureEdit2});
            this.gridBusyRoom.Size = new System.Drawing.Size(266, 571);
            this.gridBusyRoom.TabIndex = 4;
            this.gridBusyRoom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBusyRoom});
            // 
            // gridViewBusyRoom
            // 
            this.gridViewBusyRoom.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridViewBusyRoom.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewBusyRoom.Appearance.FocusedRow.BackColor = System.Drawing.Color.Blue;
            this.gridViewBusyRoom.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Blue;
            this.gridViewBusyRoom.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridViewBusyRoom.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridViewBusyRoom.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewBusyRoom.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewBusyRoom.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewBusyRoom.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridViewBusyRoom.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Green;
            this.gridViewBusyRoom.Appearance.GroupFooter.Image = ((System.Drawing.Image)(resources.GetObject("gridViewBusyRoom.Appearance.GroupFooter.Image")));
            this.gridViewBusyRoom.Appearance.GroupFooter.Options.UseFont = true;
            this.gridViewBusyRoom.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridViewBusyRoom.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridViewBusyRoom.Appearance.GroupRow.ForeColor = System.Drawing.Color.Red;
            this.gridViewBusyRoom.Appearance.GroupRow.Options.UseFont = true;
            this.gridViewBusyRoom.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridViewBusyRoom.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridViewBusyRoom.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewBusyRoom.Appearance.SelectedRow.BackColor = System.Drawing.Color.Blue;
            this.gridViewBusyRoom.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Blue;
            this.gridViewBusyRoom.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridViewBusyRoom.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewBusyRoom.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewBusyRoom.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn7,
            this.gridColumn8});
            this.gridViewBusyRoom.GridControl = this.gridBusyRoom;
            this.gridViewBusyRoom.GroupCount = 1;
            this.gridViewBusyRoom.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridViewBusyRoom.GroupFormat = "{0} [#image]{1} {2} ";
            this.gridViewBusyRoom.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TT", this.gridColumn5, "")});
            this.gridViewBusyRoom.Name = "gridViewBusyRoom";
            this.gridViewBusyRoom.NewItemRowText = "Click vào đây để thêm mới";
            this.gridViewBusyRoom.OptionsMenu.EnableFooterMenu = false;
            this.gridViewBusyRoom.OptionsView.ShowGroupPanel = false;
            this.gridViewBusyRoom.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn2, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewBusyRoom.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewBusyRoom_FocusedRowChanged);
            this.gridViewBusyRoom.DoubleClick += new System.EventHandler(this.gridViewBusyRoom_DoubleClick_1);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "TT";
            this.gridColumn1.FieldName = "TT";
            this.gridColumn1.Name = "gridColumn1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "TenLoaiPhong";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.Caption = "IDPhong";
            this.gridColumn4.FieldName = "IDPhong";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.Caption = "Trạng Thái";
            this.gridColumn5.ColumnEdit = this.repositoryItemCheckEdit2;
            this.gridColumn5.FieldName = "Trangthai";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.OptionsColumn.AllowMove = false;
            this.gridColumn5.OptionsColumn.AllowSize = false;
            this.gridColumn5.OptionsColumn.FixedWidth = true;
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            this.gridColumn5.Width = 86;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AllowFocused = false;
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit2.FullFocusRect = true;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            this.repositoryItemCheckEdit2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Inactive;
            this.repositoryItemCheckEdit2.PictureChecked = global::Karaoke.Properties.Resources.Status_user_busy_icon1;
            this.repositoryItemCheckEdit2.PictureGrayed = global::Karaoke.Properties.Resources.user1;
            this.repositoryItemCheckEdit2.PictureUnchecked = global::Karaoke.Properties.Resources.blank;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.Caption = "Phòng";
            this.gridColumn7.FieldName = "TenPhong";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.FixedWidth = true;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 0;
            this.gridColumn7.Width = 89;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "IDLoaiPhong";
            this.gridColumn8.FieldName = "IDLoaiPhong";
            this.gridColumn8.Name = "gridColumn8";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            this.repositoryItemCheckEdit3.PictureChecked = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            this.repositoryItemCheckEdit3.PictureGrayed = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            this.repositoryItemCheckEdit3.PictureUnchecked = global::Karaoke.Properties.Resources._1325149282_button_ok;
            // 
            // repositoryItemImageEdit3
            // 
            this.repositoryItemImageEdit3.AutoHeight = false;
            this.repositoryItemImageEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit3.Name = "repositoryItemImageEdit3";
            // 
            // repositoryItemImageEdit4
            // 
            this.repositoryItemImageEdit4.AutoHeight = false;
            this.repositoryItemImageEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit4.Name = "repositoryItemImageEdit4";
            this.repositoryItemImageEdit4.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // repositoryItemPictureEdit2
            // 
            this.repositoryItemPictureEdit2.Appearance.Image = global::Karaoke.Properties.Resources.user;
            this.repositoryItemPictureEdit2.Appearance.Options.UseImage = true;
            this.repositoryItemPictureEdit2.Name = "repositoryItemPictureEdit2";
            // 
            // gridRoom
            // 
            this.gridRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridRoom.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridRoom.EmbeddedNavigator.Name = "";
            this.gridRoom.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridRoom.FormsUseDefaultLookAndFeel = false;
            this.gridRoom.Location = new System.Drawing.Point(2, 20);
            this.gridRoom.MainView = this.gridViewRoom;
            this.gridRoom.Margin = new System.Windows.Forms.Padding(4);
            this.gridRoom.Name = "gridRoom";
            this.gridRoom.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemImageEdit1,
            this.checkRoomStatus,
            this.repositoryItemImageEdit2,
            this.repositoryItemPictureEdit1});
            this.gridRoom.Size = new System.Drawing.Size(266, 571);
            this.gridRoom.TabIndex = 4;
            this.gridRoom.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewRoom,
            this.gridView1});
            // 
            // gridViewRoom
            // 
            this.gridViewRoom.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridViewRoom.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewRoom.Appearance.FocusedRow.BackColor = System.Drawing.Color.Blue;
            this.gridViewRoom.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Blue;
            this.gridViewRoom.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridViewRoom.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridViewRoom.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewRoom.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewRoom.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewRoom.Appearance.GroupFooter.Font = new System.Drawing.Font("Tahoma", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridViewRoom.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Green;
            this.gridViewRoom.Appearance.GroupFooter.Image = ((System.Drawing.Image)(resources.GetObject("gridViewRoom.Appearance.GroupFooter.Image")));
            this.gridViewRoom.Appearance.GroupFooter.Options.UseFont = true;
            this.gridViewRoom.Appearance.GroupFooter.Options.UseForeColor = true;
            this.gridViewRoom.Appearance.GroupFooter.Options.UseImage = true;
            this.gridViewRoom.Appearance.GroupRow.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridViewRoom.Appearance.GroupRow.ForeColor = System.Drawing.Color.Red;
            this.gridViewRoom.Appearance.GroupRow.Options.UseFont = true;
            this.gridViewRoom.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridViewRoom.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridViewRoom.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewRoom.Appearance.SelectedRow.BackColor = System.Drawing.Color.Blue;
            this.gridViewRoom.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Blue;
            this.gridViewRoom.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridViewRoom.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewRoom.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewRoom.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTT,
            this.gridColumn22,
            this.gridColumn3,
            this.colRoomStatus,
            this.gridColumn6,
            this.gridColumn23});
            this.gridViewRoom.GridControl = this.gridRoom;
            this.gridViewRoom.GroupCount = 1;
            this.gridViewRoom.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridViewRoom.GroupFormat = "{0} [#image]{1} {2} ";
            this.gridViewRoom.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TT", this.colRoomStatus, "")});
            this.gridViewRoom.Name = "gridViewRoom";
            this.gridViewRoom.NewItemRowText = "Click vào đây để thêm mới";
            this.gridViewRoom.OptionsMenu.EnableFooterMenu = false;
            this.gridViewRoom.OptionsView.ShowGroupPanel = false;
            this.gridViewRoom.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn22, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridViewRoom.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewRoom_FocusedRowChanged);
            this.gridViewRoom.DoubleClick += new System.EventHandler(this.gridViewRoom_DoubleClick);
            // 
            // colTT
            // 
            this.colTT.Caption = "TT";
            this.colTT.FieldName = "TT";
            this.colTT.Name = "colTT";
            // 
            // gridColumn22
            // 
            this.gridColumn22.FieldName = "TenLoaiPhong";
            this.gridColumn22.Name = "gridColumn22";
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.Caption = "IDPhong";
            this.gridColumn3.FieldName = "IDPhong";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            // 
            // colRoomStatus
            // 
            this.colRoomStatus.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.colRoomStatus.AppearanceCell.Options.UseFont = true;
            this.colRoomStatus.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.colRoomStatus.AppearanceHeader.Options.UseFont = true;
            this.colRoomStatus.Caption = "Trạng Thái";
            this.colRoomStatus.ColumnEdit = this.checkRoomStatus;
            this.colRoomStatus.FieldName = "Trangthai";
            this.colRoomStatus.Name = "colRoomStatus";
            this.colRoomStatus.OptionsColumn.AllowEdit = false;
            this.colRoomStatus.OptionsColumn.AllowMove = false;
            this.colRoomStatus.OptionsColumn.AllowSize = false;
            this.colRoomStatus.OptionsColumn.FixedWidth = true;
            this.colRoomStatus.OptionsColumn.ReadOnly = true;
            this.colRoomStatus.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.colRoomStatus.Visible = true;
            this.colRoomStatus.VisibleIndex = 1;
            this.colRoomStatus.Width = 86;
            // 
            // checkRoomStatus
            // 
            this.checkRoomStatus.AllowFocused = false;
            this.checkRoomStatus.AutoHeight = false;
            this.checkRoomStatus.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.checkRoomStatus.FullFocusRect = true;
            this.checkRoomStatus.Name = "checkRoomStatus";
            this.checkRoomStatus.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Inactive;
            this.checkRoomStatus.PictureChecked = global::Karaoke.Properties.Resources.Status_user_busy_icon1;
            this.checkRoomStatus.PictureGrayed = global::Karaoke.Properties.Resources.user1;
            this.checkRoomStatus.PictureUnchecked = global::Karaoke.Properties.Resources.blank;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.Caption = "Phòng";
            this.gridColumn6.FieldName = "TenPhong";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.OptionsColumn.ReadOnly = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            this.gridColumn6.Width = 89;
            // 
            // gridColumn23
            // 
            this.gridColumn23.Caption = "IDLoaiPhong";
            this.gridColumn23.FieldName = "IDLoaiPhong";
            this.gridColumn23.Name = "gridColumn23";
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
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // repositoryItemImageEdit2
            // 
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            this.repositoryItemImageEdit2.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Appearance.Image = global::Karaoke.Properties.Resources.user;
            this.repositoryItemPictureEdit1.Appearance.Options.UseImage = true;
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridRoom;
            this.gridView1.Name = "gridView1";
            // 
            // groupControl2
            // 
            this.groupControl2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.groupControl2.Controls.Add(this.gridRoom);
            this.groupControl2.Location = new System.Drawing.Point(0, 2);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(270, 593);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Phòng rảnh";
            // 
            // frmListRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 598);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.groupControl2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListRoom";
            this.Text = "frmListRoom";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBusyRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBusyRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewRoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkRoomStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridBusyRoom;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBusyRoom;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit2;
        private DevExpress.XtraGrid.GridControl gridRoom;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewRoom;
        private DevExpress.XtraGrid.Columns.GridColumn colTT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn colRoomStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkRoomStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl2;

    }
}