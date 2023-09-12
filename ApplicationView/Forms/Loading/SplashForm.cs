using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationView.Forms.Loading
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            this.myloading.Dock = DockStyle.Fill;
            this.myloading.Load("Resources/loading1.gif");

            this.myloading.SizeMode = PictureBoxSizeMode.StretchImage;
            this.myloading.Location = new System.Drawing.Point(0, (int)((0.05 * this.Height / 2 - this.myloading.Height / 2)));
            this.myloading.Size = new System.Drawing.Size(this.Width / 2 - this.myloading.Width / 2, (int)((0.13 * this.Height / 2 - this.myloading.Height / 2) - 2));
        }
    }
}
