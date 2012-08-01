using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Karaoke.MDIForms
{
    public partial class frmWarningRoom : Form
    {
        
        private string mess;
        public frmWarningRoom(string title)
        {
            InitializeComponent();
            
            mess = title;
            lblMess.Text = mess;
        }

       
        private void frmReturnProduct_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
