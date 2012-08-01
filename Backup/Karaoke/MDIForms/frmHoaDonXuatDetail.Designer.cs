namespace Karaoke.MDIForms
{
    partial class frmHoaDonXuatDetail
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
            this.gridBillProduct = new DevExpress.XtraGrid.GridControl();
            this.gridViewBillProduct = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.deleteChitietHD = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.txtRoomPrice = new System.Windows.Forms.TextBox();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.txtHourMoney = new System.Windows.Forms.TextBox();
            this.txtBilltotal = new System.Windows.Forms.TextBox();
            this.txtProductMoney = new System.Windows.Forms.TextBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPrintBill = new DevExpress.XtraEditors.SimpleButton();
            this.txtExtra = new System.Windows.Forms.TextBox();
            this.txtReduce = new System.Windows.Forms.TextBox();
            this.txtTax = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboEmployee = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridBillProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBillProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteChitietHD)).BeginInit();
            this.SuspendLayout();
            // 
            // gridBillProduct
            // 
            this.gridBillProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gridBillProduct.EmbeddedNavigator.Name = "";
            this.gridBillProduct.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridBillProduct.FormsUseDefaultLookAndFeel = false;
            this.gridBillProduct.Location = new System.Drawing.Point(20, 105);
            this.gridBillProduct.MainView = this.gridViewBillProduct;
            this.gridBillProduct.Name = "gridBillProduct";
            this.gridBillProduct.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit4,
            this.deleteChitietHD});
            this.gridBillProduct.Size = new System.Drawing.Size(499, 155);
            this.gridBillProduct.TabIndex = 65;
            this.gridBillProduct.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBillProduct});
            // 
            // gridViewBillProduct
            // 
            this.gridViewBillProduct.Appearance.FocusedCell.BackColor = System.Drawing.Color.Blue;
            this.gridViewBillProduct.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.Blue;
            this.gridViewBillProduct.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridViewBillProduct.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridViewBillProduct.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewBillProduct.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewBillProduct.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewBillProduct.Appearance.FocusedRow.BackColor = System.Drawing.Color.Blue;
            this.gridViewBillProduct.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.Blue;
            this.gridViewBillProduct.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridViewBillProduct.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridViewBillProduct.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewBillProduct.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewBillProduct.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewBillProduct.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridViewBillProduct.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewBillProduct.Appearance.SelectedRow.BackColor = System.Drawing.Color.Blue;
            this.gridViewBillProduct.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.Blue;
            this.gridViewBillProduct.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridViewBillProduct.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridViewBillProduct.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridViewBillProduct.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn21,
            this.gridColumn1,
            this.gridColumn20,
            this.gridColumn2,
            this.gridColumn16,
            this.gridColumn12,
            this.gridColumn19,
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn15});
            this.gridViewBillProduct.GridControl = this.gridBillProduct;
            this.gridViewBillProduct.Name = "gridViewBillProduct";
            this.gridViewBillProduct.NewItemRowText = "Click vào đây để thêm mới";
            this.gridViewBillProduct.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "gridColumn21";
            this.gridColumn21.FieldName = "IDChitietHDxuat";
            this.gridColumn21.Name = "gridColumn21";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.Caption = "IDSanPham";
            this.gridColumn1.FieldName = "IDSanPham";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "IDHoadonXuat";
            this.gridColumn20.FieldName = "IDHoadonXuat";
            this.gridColumn20.Name = "gridColumn20";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.Caption = "Sản phẩm";
            this.gridColumn2.FieldName = "TenSanPham";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 103;
            // 
            // gridColumn16
            // 
            this.gridColumn16.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridColumn16.AppearanceCell.Options.UseFont = true;
            this.gridColumn16.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridColumn16.AppearanceHeader.Options.UseFont = true;
            this.gridColumn16.Caption = "Số lượng";
            this.gridColumn16.FieldName = "Soluong";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.OptionsColumn.ReadOnly = true;
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 1;
            // 
            // gridColumn12
            // 
            this.gridColumn12.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn12.AppearanceCell.Options.UseFont = true;
            this.gridColumn12.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridColumn12.AppearanceHeader.Options.UseFont = true;
            this.gridColumn12.Caption = "ĐVT";
            this.gridColumn12.FieldName = "DVT";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.OptionsColumn.ReadOnly = true;
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 2;
            this.gridColumn12.Width = 54;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "IDGiaxuat";
            this.gridColumn19.FieldName = "IDGiaxuat";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.OptionsColumn.ReadOnly = true;
            // 
            // gridColumn17
            // 
            this.gridColumn17.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.gridColumn17.AppearanceCell.Options.UseFont = true;
            this.gridColumn17.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridColumn17.AppearanceHeader.Options.UseFont = true;
            this.gridColumn17.Caption = "Đơn giá";
            this.gridColumn17.FieldName = "Gia";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.OptionsColumn.ReadOnly = true;
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 3;
            // 
            // gridColumn18
            // 
            this.gridColumn18.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn18.AppearanceCell.Options.UseFont = true;
            this.gridColumn18.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridColumn18.AppearanceHeader.Options.UseFont = true;
            this.gridColumn18.Caption = "Thành tiền";
            this.gridColumn18.FieldName = "Thanhtien";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.OptionsColumn.ReadOnly = true;
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 4;
            // 
            // gridColumn15
            // 
            this.gridColumn15.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 10F);
            this.gridColumn15.AppearanceCell.Options.UseFont = true;
            this.gridColumn15.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 11F);
            this.gridColumn15.AppearanceHeader.Options.UseFont = true;
            this.gridColumn15.Caption = "Tồn kho";
            this.gridColumn15.FieldName = "TonKho";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.OptionsColumn.ReadOnly = true;
            this.gridColumn15.Width = 100;
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
            // txtRoomPrice
            // 
            this.txtRoomPrice.BackColor = System.Drawing.Color.White;
            this.txtRoomPrice.Enabled = false;
            this.txtRoomPrice.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtRoomPrice.Location = new System.Drawing.Point(174, 67);
            this.txtRoomPrice.Name = "txtRoomPrice";
            this.txtRoomPrice.ReadOnly = true;
            this.txtRoomPrice.Size = new System.Drawing.Size(91, 24);
            this.txtRoomPrice.TabIndex = 64;
            this.txtRoomPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRoom
            // 
            this.txtRoom.BackColor = System.Drawing.Color.White;
            this.txtRoom.Enabled = false;
            this.txtRoom.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtRoom.Location = new System.Drawing.Point(117, 67);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.ReadOnly = true;
            this.txtRoom.Size = new System.Drawing.Size(51, 24);
            this.txtRoom.TabIndex = 63;
            this.txtRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtHourMoney
            // 
            this.txtHourMoney.BackColor = System.Drawing.Color.White;
            this.txtHourMoney.Enabled = false;
            this.txtHourMoney.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtHourMoney.Location = new System.Drawing.Point(347, 301);
            this.txtHourMoney.Name = "txtHourMoney";
            this.txtHourMoney.ReadOnly = true;
            this.txtHourMoney.Size = new System.Drawing.Size(122, 24);
            this.txtHourMoney.TabIndex = 62;
            this.txtHourMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBilltotal
            // 
            this.txtBilltotal.BackColor = System.Drawing.Color.White;
            this.txtBilltotal.Enabled = false;
            this.txtBilltotal.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtBilltotal.Location = new System.Drawing.Point(347, 425);
            this.txtBilltotal.Name = "txtBilltotal";
            this.txtBilltotal.ReadOnly = true;
            this.txtBilltotal.Size = new System.Drawing.Size(122, 24);
            this.txtBilltotal.TabIndex = 61;
            this.txtBilltotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtProductMoney
            // 
            this.txtProductMoney.BackColor = System.Drawing.Color.White;
            this.txtProductMoney.Enabled = false;
            this.txtProductMoney.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtProductMoney.Location = new System.Drawing.Point(347, 269);
            this.txtProductMoney.Name = "txtProductMoney";
            this.txtProductMoney.ReadOnly = true;
            this.txtProductMoney.Size = new System.Drawing.Size(122, 24);
            this.txtProductMoney.TabIndex = 60;
            this.txtProductMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTime
            // 
            this.txtTime.AcceptsTab = true;
            this.txtTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtTime.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTime.ForeColor = System.Drawing.Color.Red;
            this.txtTime.Location = new System.Drawing.Point(21, 8);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(499, 24);
            this.txtTime.TabIndex = 59;
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label12.Location = new System.Drawing.Point(16, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 17);
            this.label12.TabIndex = 54;
            this.label12.Text = "Phòng";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label11.Location = new System.Drawing.Point(232, 428);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 17);
            this.label11.TabIndex = 53;
            this.label11.Text = "Cộng";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(270, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 17);
            this.label10.TabIndex = 52;
            this.label10.Text = "Nhân viên";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label9.Location = new System.Drawing.Point(232, 304);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 17);
            this.label9.TabIndex = 51;
            this.label9.Text = "Tiền giờ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.Location = new System.Drawing.Point(232, 335);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 17);
            this.label8.TabIndex = 50;
            this.label8.Text = "Phụ thu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.Location = new System.Drawing.Point(232, 366);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 17);
            this.label7.TabIndex = 49;
            this.label7.Text = "Tiền giảm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.Location = new System.Drawing.Point(232, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 17);
            this.label6.TabIndex = 48;
            this.label6.Text = "Thuế";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(232, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 47;
            this.label5.Text = "Tiền hàng";
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.Image = global::Karaoke.Properties.Resources._2_Hot_Printer1;
            this.btnPrintBill.Location = new System.Drawing.Point(83, 320);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(70, 69);
            this.btnPrintBill.TabIndex = 66;
            this.btnPrintBill.Click += new System.EventHandler(this.btnPrintBill_Click);
            // 
            // txtExtra
            // 
            this.txtExtra.BackColor = System.Drawing.Color.White;
            this.txtExtra.Enabled = false;
            this.txtExtra.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtExtra.Location = new System.Drawing.Point(347, 332);
            this.txtExtra.Name = "txtExtra";
            this.txtExtra.ReadOnly = true;
            this.txtExtra.Size = new System.Drawing.Size(122, 24);
            this.txtExtra.TabIndex = 67;
            this.txtExtra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtReduce
            // 
            this.txtReduce.BackColor = System.Drawing.Color.White;
            this.txtReduce.Enabled = false;
            this.txtReduce.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtReduce.Location = new System.Drawing.Point(347, 363);
            this.txtReduce.Name = "txtReduce";
            this.txtReduce.ReadOnly = true;
            this.txtReduce.Size = new System.Drawing.Size(122, 24);
            this.txtReduce.TabIndex = 68;
            this.txtReduce.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTax
            // 
            this.txtTax.BackColor = System.Drawing.Color.White;
            this.txtTax.Enabled = false;
            this.txtTax.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtTax.Location = new System.Drawing.Point(347, 393);
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Size = new System.Drawing.Size(122, 24);
            this.txtTax.TabIndex = 69;
            this.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDate
            // 
            this.txtDate.BackColor = System.Drawing.Color.White;
            this.txtDate.Enabled = false;
            this.txtDate.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.txtDate.Location = new System.Drawing.Point(117, 35);
            this.txtDate.Name = "txtDate";
            this.txtDate.ReadOnly = true;
            this.txtDate.Size = new System.Drawing.Size(148, 24);
            this.txtDate.TabIndex = 71;
            this.txtDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(17, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 72;
            this.label1.Text = "Ngày";
            // 
            // cboEmployee
            // 
            this.cboEmployee.Enabled = false;
            this.cboEmployee.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cboEmployee.FormattingEnabled = true;
            this.cboEmployee.Location = new System.Drawing.Point(371, 67);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(148, 24);
            this.cboEmployee.TabIndex = 73;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(475, 272);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 74;
            this.label2.Text = "VND";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(475, 304);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 75;
            this.label3.Text = "VND";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.Location = new System.Drawing.Point(475, 338);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 17);
            this.label4.TabIndex = 76;
            this.label4.Text = "VND";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label13.Location = new System.Drawing.Point(475, 366);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 17);
            this.label13.TabIndex = 77;
            this.label13.Text = "VND";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label14.Location = new System.Drawing.Point(477, 396);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 17);
            this.label14.TabIndex = 78;
            this.label14.Text = "%";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label15.Location = new System.Drawing.Point(475, 428);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 17);
            this.label15.TabIndex = 79;
            this.label15.Text = "VND";
            // 
            // frmHoaDonXuatDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 457);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboEmployee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.txtReduce);
            this.Controls.Add(this.txtExtra);
            this.Controls.Add(this.btnPrintBill);
            this.Controls.Add(this.gridBillProduct);
            this.Controls.Add(this.txtRoomPrice);
            this.Controls.Add(this.txtRoom);
            this.Controls.Add(this.txtHourMoney);
            this.Controls.Add(this.txtBilltotal);
            this.Controls.Add(this.txtProductMoney);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Name = "frmHoaDonXuatDetail";
            this.Text = "Chi tiết Hóa đơn xuất";
            ((System.ComponentModel.ISupportInitialize)(this.gridBillProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBillProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deleteChitietHD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnPrintBill;
        private DevExpress.XtraGrid.GridControl gridBillProduct;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBillProduct;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit deleteChitietHD;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private System.Windows.Forms.TextBox txtRoomPrice;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.TextBox txtHourMoney;
        private System.Windows.Forms.TextBox txtBilltotal;
        private System.Windows.Forms.TextBox txtProductMoney;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExtra;
        private System.Windows.Forms.TextBox txtReduce;
        private System.Windows.Forms.TextBox txtTax;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}