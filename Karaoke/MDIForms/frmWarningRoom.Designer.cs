namespace Karaoke.MDIForms
{
    partial class frmWarningRoom
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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnReturn = new DevExpress.XtraEditors.SimpleButton();
            this.gridWarning = new DevExpress.XtraGrid.GridControl();
            this.gridViewWarning = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRoomName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBillNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCloseRoom = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colReceiptName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContinue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colCB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.deleteChitietHD = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemSpinEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit9 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemSpinEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWarning)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteChitietHD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit5)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(291, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Danh sách phòng sắp hết tiền đặt cọc";
            // 
            // btnReturn
            // 
            this.btnReturn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnReturn.Appearance.Options.UseFont = true;
            this.btnReturn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnReturn.Location = new System.Drawing.Point(0, 315);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(541, 30);
            this.btnReturn.TabIndex = 67;
            this.btnReturn.Text = "Thoát";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // gridWarning
            // 
            this.gridWarning.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridWarning.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridWarning.EmbeddedNavigator.Name = "";
            this.gridWarning.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridWarning.FormsUseDefaultLookAndFeel = false;
            this.gridWarning.Location = new System.Drawing.Point(0, 21);
            this.gridWarning.MainView = this.gridViewWarning;
            this.gridWarning.Margin = new System.Windows.Forms.Padding(4);
            this.gridWarning.Name = "gridWarning";
            this.gridWarning.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit4,
            this.deleteChitietHD,
            this.repositoryItemSpinEdit1,
            this.repositoryItemSpinEdit2,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit9,
            this.repositoryItemSpinEdit5,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit5});
            this.gridWarning.Size = new System.Drawing.Size(541, 294);
            this.gridWarning.TabIndex = 68;
            this.gridWarning.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewWarning});
            // 
            // gridViewWarning
            // 
            this.gridViewWarning.Appearance.FocusedCell.BackColor = System.Drawing.Color.Blue;
            this.gridViewWarning.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Blue;
            this.gridViewWarning.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridViewWarning.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridViewWarning.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewWarning.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewWarning.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewWarning.Appearance.FocusedRow.BackColor = System.Drawing.Color.Blue;
            this.gridViewWarning.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Blue;
            this.gridViewWarning.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.gridViewWarning.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridViewWarning.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewWarning.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewWarning.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewWarning.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridViewWarning.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewWarning.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridViewWarning.Appearance.Row.Options.UseFont = true;
            this.gridViewWarning.Appearance.SelectedRow.BackColor = System.Drawing.Color.Blue;
            this.gridViewWarning.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Blue;
            this.gridViewWarning.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridViewWarning.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridViewWarning.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewWarning.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewWarning.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewWarning.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStatus,
            this.gridColumn1,
            this.colRoomName,
            this.colBillNum,
            this.gridColumn12,
            this.gridColumn19,
            this.colCloseRoom,
            this.colReceiptName,
            this.colContinue,
            this.colCB});
            this.gridViewWarning.GridControl = this.gridWarning;
            this.gridViewWarning.Name = "gridViewWarning";
            this.gridViewWarning.NewItemRowText = "Click vào đây để thêm mới";
            this.gridViewWarning.OptionsView.ShowGroupPanel = false;
            this.gridViewWarning.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewWarning_CellValueChanging);
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Trangthai";
            this.colStatus.FieldName = "Trangthai";
            this.colStatus.Name = "colStatus";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "IDPhong";
            this.gridColumn1.FieldName = "IDPhong";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            // 
            // colRoomName
            // 
            this.colRoomName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colRoomName.AppearanceCell.Options.UseFont = true;
            this.colRoomName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.colRoomName.AppearanceHeader.Options.UseFont = true;
            this.colRoomName.Caption = "Tên Phòng";
            this.colRoomName.FieldName = "TenPhong";
            this.colRoomName.GroupInterval = DevExpress.XtraGrid.ColumnGroupInterval.Value;
            this.colRoomName.Name = "colRoomName";
            this.colRoomName.OptionsColumn.AllowEdit = false;
            this.colRoomName.OptionsColumn.ReadOnly = true;
            this.colRoomName.Visible = true;
            this.colRoomName.VisibleIndex = 0;
            this.colRoomName.Width = 90;
            // 
            // colBillNum
            // 
            this.colBillNum.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colBillNum.AppearanceCell.Options.UseFont = true;
            this.colBillNum.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.colBillNum.AppearanceHeader.Options.UseFont = true;
            this.colBillNum.Caption = "Tình trạng";
            this.colBillNum.FieldName = "Tinhtrang";
            this.colBillNum.Name = "colBillNum";
            this.colBillNum.OptionsColumn.AllowEdit = false;
            this.colBillNum.OptionsColumn.ReadOnly = true;
            this.colBillNum.Visible = true;
            this.colBillNum.VisibleIndex = 1;
            this.colBillNum.Width = 82;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Tg. còn lại";
            this.gridColumn12.FieldName = "TgConlai";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.AllowEdit = false;
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "IDHoadonXuat";
            this.gridColumn19.FieldName = "IDHoadonXuat";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            // 
            // colCloseRoom
            // 
            this.colCloseRoom.Caption = "Đóng phòng";
            this.colCloseRoom.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colCloseRoom.FieldName = "Dongphong";
            this.colCloseRoom.Name = "colCloseRoom";
            this.colCloseRoom.Visible = true;
            this.colCloseRoom.VisibleIndex = 3;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.PictureChecked = global::Karaoke.Properties.Resources.Status_user_busy_icon1;
            this.repositoryItemCheckEdit1.PictureGrayed = global::Karaoke.Properties.Resources.Status_user_busy_icon1;
            this.repositoryItemCheckEdit1.PictureUnchecked = global::Karaoke.Properties.Resources.Status_user_busy_icon1;
            // 
            // colReceiptName
            // 
            this.colReceiptName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.colReceiptName.AppearanceCell.Options.UseFont = true;
            this.colReceiptName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.colReceiptName.AppearanceHeader.Options.UseFont = true;
            this.colReceiptName.Caption = "Hóa đơn";
            this.colReceiptName.FieldName = "TenHoadon";
            this.colReceiptName.Name = "colReceiptName";
            this.colReceiptName.OptionsColumn.ReadOnly = true;
            this.colReceiptName.Width = 63;
            // 
            // colContinue
            // 
            this.colContinue.Caption = "Tạo mới";
            this.colContinue.ColumnEdit = this.repositoryItemCheckEdit5;
            this.colContinue.FieldName = "Taomoi";
            this.colContinue.Name = "colContinue";
            this.colContinue.Visible = true;
            this.colContinue.VisibleIndex = 4;
            // 
            // repositoryItemCheckEdit5
            // 
            this.repositoryItemCheckEdit5.AutoWidth = true;
            this.repositoryItemCheckEdit5.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit5.Name = "repositoryItemCheckEdit5";
            this.repositoryItemCheckEdit5.PictureChecked = global::Karaoke.Properties.Resources.user1;
            this.repositoryItemCheckEdit5.PictureGrayed = global::Karaoke.Properties.Resources.user1;
            this.repositoryItemCheckEdit5.PictureUnchecked = global::Karaoke.Properties.Resources.user1;
            // 
            // colCB
            // 
            this.colCB.Caption = "CB";
            this.colCB.FieldName = "Congtac";
            this.colCB.Name = "colCB";
            this.colCB.OptionsColumn.ReadOnly = true;
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            this.repositoryItemCheckEdit4.PictureChecked = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            this.repositoryItemCheckEdit4.PictureGrayed = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            this.repositoryItemCheckEdit4.PictureUnchecked = global::Karaoke.Properties.Resources._1325149282_button_ok;
            // 
            // deleteChitietHD
            // 
            this.deleteChitietHD.AutoHeight = false;
            this.deleteChitietHD.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.deleteChitietHD.Name = "deleteChitietHD";
            this.deleteChitietHD.PictureChecked = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            this.deleteChitietHD.PictureGrayed = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            this.deleteChitietHD.PictureUnchecked = global::Karaoke.Properties.Resources._1325149327_recycle_bin;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // repositoryItemSpinEdit2
            // 
            this.repositoryItemSpinEdit2.AutoHeight = false;
            this.repositoryItemSpinEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit2.DisplayFormat.FormatString = "###,###";
            this.repositoryItemSpinEdit2.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.repositoryItemSpinEdit2.IsFloatValue = false;
            this.repositoryItemSpinEdit2.Mask.EditMask = "N00";
            this.repositoryItemSpinEdit2.MaxValue = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.repositoryItemSpinEdit2.Name = "repositoryItemSpinEdit2";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            this.repositoryItemCheckEdit3.PictureChecked = global::Karaoke.Properties.Resources.Actions_go_next_icon;
            this.repositoryItemCheckEdit3.PictureGrayed = global::Karaoke.Properties.Resources.Actions_go_next_icon;
            this.repositoryItemCheckEdit3.PictureUnchecked = global::Karaoke.Properties.Resources.Actions_go_next_icon;
            // 
            // repositoryItemCheckEdit9
            // 
            this.repositoryItemCheckEdit9.AutoHeight = false;
            this.repositoryItemCheckEdit9.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined;
            this.repositoryItemCheckEdit9.Name = "repositoryItemCheckEdit9";
            this.repositoryItemCheckEdit9.PictureChecked = global::Karaoke.Properties.Resources.Actions_arrow_down_double_icon_small;
            this.repositoryItemCheckEdit9.PictureGrayed = global::Karaoke.Properties.Resources.Actions_arrow_down_double_icon_small;
            this.repositoryItemCheckEdit9.PictureUnchecked = global::Karaoke.Properties.Resources.Actions_arrow_down_double_icon_small;
            // 
            // repositoryItemSpinEdit5
            // 
            this.repositoryItemSpinEdit5.AutoHeight = false;
            this.repositoryItemSpinEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit5.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.repositoryItemSpinEdit5.Name = "repositoryItemSpinEdit5";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmWarningRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 345);
            this.ControlBox = false;
            this.Controls.Add(this.gridWarning);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmWarningRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cảnh báo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReturnProduct_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewWarning)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteChitietHD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnReturn;
        private DevExpress.XtraGrid.GridControl gridWarning;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewWarning;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colRoomName;
        private DevExpress.XtraGrid.Columns.GridColumn colBillNum;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn colCloseRoom;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit5;
        private DevExpress.XtraGrid.Columns.GridColumn colReceiptName;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colContinue;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit9;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit deleteChitietHD;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit5;
        private DevExpress.XtraGrid.Columns.GridColumn colCB;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private System.Windows.Forms.Timer timer1;
    }
}