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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnReturn = new DevExpress.XtraEditors.SimpleButton();
            this.lblMess = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.Location = new System.Drawing.Point(17, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(291, 21);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Danh sách phòng sắp hết tiền đặt cọc";
            // 
            // btnReturn
            // 
            this.btnReturn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnReturn.Appearance.Options.UseFont = true;
            this.btnReturn.Location = new System.Drawing.Point(112, 298);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(100, 30);
            this.btnReturn.TabIndex = 67;
            this.btnReturn.Text = "Thoát";
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // lblMess
            // 
            this.lblMess.AutoSize = true;
            this.lblMess.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.lblMess.ForeColor = System.Drawing.Color.Red;
            this.lblMess.Location = new System.Drawing.Point(131, 52);
            this.lblMess.Name = "lblMess";
            this.lblMess.Size = new System.Drawing.Size(55, 18);
            this.lblMess.TabIndex = 68;
            this.lblMess.Text = "label1";
            this.lblMess.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // frmWarningRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 345);
            this.ControlBox = false;
            this.Controls.Add(this.lblMess);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmWarningRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cảnh báo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReturnProduct_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.SimpleButton btnReturn;
        private System.Windows.Forms.Label lblMess;
    }
}