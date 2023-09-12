namespace ApplicationView.Forms.Loading
{
    partial class SplashForm
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
            this.myloading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.myloading)).BeginInit();
            this.SuspendLayout();
            // 
            // myloading
            // 
            this.myloading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.myloading.Image = global::ApplicationView.Properties.Resources.loading1;
            this.myloading.InitialImage = null;
            this.myloading.Location = new System.Drawing.Point(0, 0);
            this.myloading.Name = "myloading";
            this.myloading.Size = new System.Drawing.Size(810, 636);
            this.myloading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.myloading.TabIndex = 0;
            this.myloading.TabStop = false;
            // 
            // SplashForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 636);
            this.Controls.Add(this.myloading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashForm";
            this.Opacity = 0.7D;
            this.Text = "SplashForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SplashForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myloading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox myloading;
    }
}