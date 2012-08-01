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
    public partial class frmReturnProduct : Form
    {
        private int maxNum;
        private string name;
        private int returnNum;
        public frmReturnProduct(bool add, int max, string title)
        {
            InitializeComponent();
            if (add)
            {
                maxNum = 1000;
                numReturn.Value = 1;
                returnNum = 1;
                Text = "Thêm sản phẩm";
                btnReturn.Text = "Thêm";
                textBox1.Text = "Bán sản phẩm";
            }
            else
            {
                maxNum = max;
                Text = "Trả sản phẩm";
                returnNum = max;
                numReturn.Value = max;
                btnReturn.Text = "Trả";
                textBox1.Text = "Còn dư";
            }
            name = title;
            numReturn.Focus();
            numReturn.Select(0, 6);
            
        }

        private void numReturn_ValueChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(numReturn.Value) <= maxNum)
                returnNum = Convert.ToInt32(numReturn.Value);
            else
                numReturn.Value = maxNum;
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            returnNum = 0;
            this.Hide();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        public int getReturnNum()
        {
            return returnNum;
        }

        public string getText()
        {
            return textBox1.Text;
        }
        private void frmReturnProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Hide();
            else if (e.KeyCode == Keys.Escape)
            {
                returnNum = 0;
                this.Hide();
            }

        }

        private void numReturn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.Hide();
            else if (e.KeyCode == Keys.Escape)
            {
                returnNum = 0;
                this.Hide();
            }

        }
    }
}
