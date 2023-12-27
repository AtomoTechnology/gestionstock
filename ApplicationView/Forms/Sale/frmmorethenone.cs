using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationView.Forms.Sale
{
    public partial class frmmorethenone : Form
    {
        public int Quantity = 0;
        public frmmorethenone()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    Quantity = Convert.ToInt32(textBox1.Text);
                    this.Close();
                }
                else
                {
                    Quantity = 0;
                    this.Close();
                }
            }
        }
    }
}
