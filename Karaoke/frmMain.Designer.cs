namespace Karaoke
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnProduct = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmployee = new DevExpress.XtraBars.BarButtonItem();
            this.btnRoom = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogIn = new DevExpress.XtraBars.BarButtonItem();
            this.btnLogOut = new DevExpress.XtraBars.BarButtonItem();
            this.cboSkin = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.status = new DevExpress.XtraBars.BarStaticItem();
            this.btnReceipt = new DevExpress.XtraBars.BarButtonItem();
            this.btnInvoice = new DevExpress.XtraBars.BarCheckItem();
            this.btnAddInvoice = new DevExpress.XtraBars.BarButtonItem();
            this.btnTonKho = new DevExpress.XtraBars.BarButtonItem();
            this.btnReport = new DevExpress.XtraBars.BarButtonItem();
            this.btnChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnSetting = new DevExpress.XtraBars.BarButtonItem();
            this.btnItemDieuChinhTonKho = new DevExpress.XtraBars.BarButtonItem();
            this.btnReceiptProduct = new DevExpress.XtraBars.BarButtonItem();
            this.btnVanDe = new DevExpress.XtraBars.BarButtonItem();
            this.btnExit = new DevExpress.XtraBars.BarButtonItem();
            this.IconCollection = new DevExpress.Utils.ImageCollection(this.components);
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgQuanLyHoaDon = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgQuanLySanPham = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rpgQuanLyPhong = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.TabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.dfLookAndFeel = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabbedMdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonKeyTip = "";
            this.ribbonControl1.ApplicationIcon = global::Karaoke.Properties.Resources._1338350841_audacity;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnProduct,
            this.btnEmployee,
            this.btnRoom,
            this.btnLogIn,
            this.btnLogOut,
            this.cboSkin,
            this.status,
            this.btnReceipt,
            this.btnInvoice,
            this.btnAddInvoice,
            this.btnTonKho,
            this.btnReport,
            this.btnChart,
            this.btnSetting,
            this.btnItemDieuChinhTonKho,
            this.btnReceiptProduct,
            this.btnVanDe,
            this.btnExit});
            this.ribbonControl1.LargeImages = this.IconCollection;
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 22;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1});
            this.ribbonControl1.SelectedPage = this.ribbonPage2;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide;
            this.ribbonControl1.Size = new System.Drawing.Size(992, 143);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnProduct
            // 
            this.btnProduct.Caption = "Sản phẩm";
            this.btnProduct.Id = 0;
            this.btnProduct.LargeImageIndex = 55;
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnProduct_ItemClick);
            // 
            // btnEmployee
            // 
            this.btnEmployee.Caption = "Nhân viên";
            this.btnEmployee.Id = 1;
            this.btnEmployee.LargeImageIndex = 20;
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployee_ItemClick);
            // 
            // btnRoom
            // 
            this.btnRoom.Caption = "Phòng ";
            this.btnRoom.Id = 2;
            this.btnRoom.LargeImageIndex = 53;
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRoom_ItemClick);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Caption = "Đăng nhập";
            this.btnLogIn.Id = 3;
            this.btnLogIn.LargeImageIndex = 23;
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogIn_ItemClick);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Caption = "Đăng xuất";
            this.btnLogOut.Id = 4;
            this.btnLogOut.LargeImageIndex = 25;
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLogOut_ItemClick);
            // 
            // cboSkin
            // 
            this.cboSkin.Caption = "Skin";
            this.cboSkin.Edit = this.repositoryItemComboBox1;
            this.cboSkin.Id = 5;
            this.cboSkin.Name = "cboSkin";
            this.cboSkin.Width = 100;
            this.cboSkin.EditValueChanged += new System.EventHandler(this.cboSkin_EditValueChanged);
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Caramel",
            "Money Twins",
            "Lilian",
            "The Asphalt World",
            "iMaginary",
            "Black",
            "Blue"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // status
            // 
            this.status.Id = 6;
            this.status.Name = "status";
            this.status.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // btnReceipt
            // 
            this.btnReceipt.Caption = "Vận hành";
            this.btnReceipt.Id = 7;
            this.btnReceipt.LargeImageIndex = 0;
            this.btnReceipt.Name = "btnReceipt";
            this.btnReceipt.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReceipt_ItemClick);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Caption = "Danh sách Hóa đơn nhập";
            this.btnInvoice.Id = 8;
            this.btnInvoice.LargeImageIndex = 51;
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.CheckedChanged += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInvoice_CheckedChanged);
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Caption = "Thêm Hóa đơn nhập";
            this.btnAddInvoice.Id = 9;
            this.btnAddInvoice.LargeImageIndex = 56;
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAddInvoice_ItemClick);
            // 
            // btnTonKho
            // 
            this.btnTonKho.Caption = "Thống kê";
            this.btnTonKho.Id = 10;
            this.btnTonKho.LargeImageIndex = 4;
            this.btnTonKho.Name = "btnTonKho";
            this.btnTonKho.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTonKho_ItemClick);
            // 
            // btnReport
            // 
            this.btnReport.Caption = "Thống kê";
            this.btnReport.Id = 11;
            this.btnReport.LargeImageIndex = 7;
            this.btnReport.Name = "btnReport";
            this.btnReport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReport_ItemClick);
            // 
            // btnChart
            // 
            this.btnChart.Caption = "Biểu đồ";
            this.btnChart.Id = 15;
            this.btnChart.LargeGlyph = global::Karaoke.Properties.Resources._1331543845_bar_chart;
            this.btnChart.Name = "btnChart";
            this.btnChart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChart_ItemClick);
            // 
            // btnSetting
            // 
            this.btnSetting.Caption = "Cài đặt";
            this.btnSetting.Id = 16;
            this.btnSetting.LargeImageIndex = 16;
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSetting_ItemClick);
            // 
            // btnItemDieuChinhTonKho
            // 
            this.btnItemDieuChinhTonKho.Caption = "Điều chỉnh tồn kho";
            this.btnItemDieuChinhTonKho.Id = 18;
            this.btnItemDieuChinhTonKho.LargeGlyph = global::Karaoke.Properties.Resources._1338111760_Modify;
            this.btnItemDieuChinhTonKho.Name = "btnItemDieuChinhTonKho";
            this.btnItemDieuChinhTonKho.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnItemDieuChinhTonKho_ItemClick);
            // 
            // btnReceiptProduct
            // 
            this.btnReceiptProduct.Caption = "Bán lẻ";
            this.btnReceiptProduct.Id = 19;
            this.btnReceiptProduct.LargeGlyph = global::Karaoke.Properties.Resources._1338288369_report;
            this.btnReceiptProduct.Name = "btnReceiptProduct";
            this.btnReceiptProduct.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReceiptProduct_ItemClick);
            // 
            // btnVanDe
            // 
            this.btnVanDe.Caption = "Xử lý sự cố";
            this.btnVanDe.Id = 20;
            this.btnVanDe.LargeGlyph = global::Karaoke.Properties.Resources._1338360894_jamendo;
            this.btnVanDe.Name = "btnVanDe";
            this.btnVanDe.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVanDe_ItemClick);
            // 
            // btnExit
            // 
            this.btnExit.Caption = "Exit";
            this.btnExit.Glyph = global::Karaoke.Properties.Resources._1338361581_exit;
            this.btnExit.Id = 21;
            this.btnExit.LargeGlyph = global::Karaoke.Properties.Resources._1338361581_exit;
            this.btnExit.LargeGlyphDisabled = global::Karaoke.Properties.Resources._1338361581_exit;
            this.btnExit.Name = "btnExit";
            this.btnExit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExit_ItemClick);
            // 
            // IconCollection
            // 
            this.IconCollection.ImageSize = new System.Drawing.Size(70, 70);
            this.IconCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("IconCollection.ImageStream")));
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgQuanLyHoaDon,
            this.rpgQuanLySanPham,
            this.rpgQuanLyPhong,
            this.ribbonPageGroup7,
            this.ribbonPageGroup1});
            this.ribbonPage2.KeyTip = "";
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Hệ thống";
            // 
            // rpgQuanLyHoaDon
            // 
            this.rpgQuanLyHoaDon.ItemLinks.Add(this.btnInvoice);
            this.rpgQuanLyHoaDon.ItemLinks.Add(this.btnAddInvoice);
            this.rpgQuanLyHoaDon.KeyTip = "";
            this.rpgQuanLyHoaDon.Name = "rpgQuanLyHoaDon";
            this.rpgQuanLyHoaDon.ShowCaptionButton = false;
            this.rpgQuanLyHoaDon.Text = "Quản lý hóa đơn";
            // 
            // rpgQuanLySanPham
            // 
            this.rpgQuanLySanPham.ItemLinks.Add(this.btnProduct);
            this.rpgQuanLySanPham.ItemLinks.Add(this.btnTonKho);
            this.rpgQuanLySanPham.ItemLinks.Add(this.btnItemDieuChinhTonKho);
            this.rpgQuanLySanPham.KeyTip = "";
            this.rpgQuanLySanPham.Name = "rpgQuanLySanPham";
            this.rpgQuanLySanPham.Text = "Quản lý sản phẩm";
            // 
            // rpgQuanLyPhong
            // 
            this.rpgQuanLyPhong.ItemLinks.Add(this.btnRoom);
            this.rpgQuanLyPhong.ItemLinks.Add(this.btnEmployee);
            this.rpgQuanLyPhong.ItemLinks.Add(this.btnSetting);
            this.rpgQuanLyPhong.KeyTip = "";
            this.rpgQuanLyPhong.Name = "rpgQuanLyPhong";
            this.rpgQuanLyPhong.Text = "Quản lý chung";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btnReceipt);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnReport);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnChart);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnReceiptProduct);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnVanDe);
            this.ribbonPageGroup7.KeyTip = "";
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "Quản lý vận hành";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnExit);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLogIn);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLogOut);
            this.ribbonPageGroup1.ItemLinks.Add(this.cboSkin);
            this.ribbonPageGroup1.KeyTip = "";
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.status);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 383);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(992, 25);
            // 
            // TabbedMdiManager
            // 
            this.TabbedMdiManager.MdiParent = this;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.KeyTip = "";
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.KeyTip = "";
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnProduct);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnEmployee);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnRoom);
            this.ribbonPageGroup6.KeyTip = "";
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.ShowCaptionButton = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 408);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Phần mềm quản lý Karaoke";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IconCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabbedMdiManager)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager TabbedMdiManager;
        private DevExpress.Utils.ImageCollection IconCollection;
        private DevExpress.LookAndFeel.DefaultLookAndFeel dfLookAndFeel;
        private DevExpress.XtraBars.BarButtonItem btnProduct;
        private DevExpress.XtraBars.BarButtonItem btnEmployee;
        private DevExpress.XtraBars.BarButtonItem btnRoom;
        private DevExpress.XtraBars.BarButtonItem btnLogIn;
        private DevExpress.XtraBars.BarButtonItem btnLogOut;
        private DevExpress.XtraBars.BarEditItem cboSkin;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgQuanLyHoaDon;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarStaticItem status;
        private DevExpress.XtraBars.BarButtonItem btnReceipt;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarCheckItem btnInvoice;
        private DevExpress.XtraBars.BarButtonItem btnAddInvoice;
        private DevExpress.XtraBars.BarButtonItem btnTonKho;
        private DevExpress.XtraBars.BarButtonItem btnReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem btnChart;
        private DevExpress.XtraBars.BarButtonItem btnSetting;
        private DevExpress.XtraBars.BarButtonItem btnItemDieuChinhTonKho;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgQuanLySanPham;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgQuanLyPhong;
        private DevExpress.XtraBars.BarButtonItem btnReceiptProduct;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.BarButtonItem btnVanDe;
        private DevExpress.XtraBars.BarButtonItem btnExit;

    }
}

