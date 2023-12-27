namespace ApplicationView.Forms.Sale
{
    partial class frmclosecachier
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblstartturn = new System.Windows.Forms.Label();
            this.lblcash = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnnew = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.lblelectronic = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblcashCashier = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 66);
            this.panel1.TabIndex = 11;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btnclose
            // 
            this.btnclose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnclose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnclose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnclose.FlatAppearance.BorderSize = 0;
            this.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnclose.Font = new System.Drawing.Font("Century", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnclose.ForeColor = System.Drawing.Color.White;
            this.btnclose.Location = new System.Drawing.Point(843, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(50, 66);
            this.btnclose.TabIndex = 24;
            this.btnclose.Text = "X";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(31, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(354, 55);
            this.label8.TabIndex = 9;
            this.label8.Text = "Cierre de Caja";
            this.label8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label8_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 31);
            this.label1.TabIndex = 12;
            this.label1.Text = "$ Inicio turno";
            // 
            // lblstartturn
            // 
            this.lblstartturn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblstartturn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblstartturn.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblstartturn.ForeColor = System.Drawing.Color.Brown;
            this.lblstartturn.Location = new System.Drawing.Point(432, 73);
            this.lblstartturn.Name = "lblstartturn";
            this.lblstartturn.Size = new System.Drawing.Size(436, 63);
            this.lblstartturn.TabIndex = 13;
            this.lblstartturn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblcash
            // 
            this.lblcash.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcash.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblcash.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblcash.ForeColor = System.Drawing.Color.Brown;
            this.lblcash.Location = new System.Drawing.Point(336, 153);
            this.lblcash.Name = "lblcash";
            this.lblcash.Size = new System.Drawing.Size(532, 63);
            this.lblcash.TabIndex = 15;
            this.lblcash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(216, 31);
            this.label4.TabIndex = 14;
            this.label4.Text = "$ venta en efectivo";
            // 
            // lbltotal
            // 
            this.lbltotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbltotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbltotal.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbltotal.ForeColor = System.Drawing.Color.Brown;
            this.lbltotal.Location = new System.Drawing.Point(337, 383);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(532, 63);
            this.lbltotal.TabIndex = 17;
            this.lbltotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(13, 403);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 31);
            this.label6.TabIndex = 16;
            this.label6.Text = "$ Total recaudado";
            // 
            // btnnew
            // 
            this.btnnew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnnew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnnew.Image = global::ApplicationView.Properties.Resources.closecashier__3_;
            this.btnnew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnnew.Location = new System.Drawing.Point(527, 454);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(184, 48);
            this.btnnew.TabIndex = 18;
            this.btnnew.Text = "Cerrar caja";
            this.btnnew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnnew.UseVisualStyleBackColor = true;
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
            // 
            // btncancel
            // 
            this.btncancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btncancel.Image = global::ApplicationView.Properties.Resources.error;
            this.btncancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncancel.Location = new System.Drawing.Point(717, 454);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(151, 48);
            this.btncancel.TabIndex = 19;
            this.btncancel.Text = "Cancelar";
            this.btncancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // lblelectronic
            // 
            this.lblelectronic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblelectronic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblelectronic.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblelectronic.ForeColor = System.Drawing.Color.Brown;
            this.lblelectronic.Location = new System.Drawing.Point(337, 229);
            this.lblelectronic.Name = "lblelectronic";
            this.lblelectronic.Size = new System.Drawing.Size(532, 63);
            this.lblelectronic.TabIndex = 21;
            this.lblelectronic.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(13, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 31);
            this.label3.TabIndex = 20;
            this.label3.Text = "$ venta electronica";
            // 
            // lblcashCashier
            // 
            this.lblcashCashier.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblcashCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblcashCashier.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblcashCashier.ForeColor = System.Drawing.Color.Brown;
            this.lblcashCashier.Location = new System.Drawing.Point(338, 307);
            this.lblcashCashier.Name = "lblcashCashier";
            this.lblcashCashier.Size = new System.Drawing.Size(532, 63);
            this.lblcashCashier.TabIndex = 23;
            this.lblcashCashier.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Brown;
            this.label5.Location = new System.Drawing.Point(14, 327);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(247, 46);
            this.label5.TabIndex = 22;
            this.label5.Text = "$ Total en caja";
            // 
            // frmclosecachier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(893, 515);
            this.Controls.Add(this.lblcashCashier);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblelectronic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnnew);
            this.Controls.Add(this.lbltotal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblcash);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblstartturn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmclosecachier";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierre de caja";
            this.ResizeEnd += new System.EventHandler(this.frmclosecachier_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.frmclosecachier_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmclosecachier_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmclosecachier_MouseDown);
            this.Validated += new System.EventHandler(this.frmclosecachier_Validated);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblstartturn;
        private System.Windows.Forms.Label lblcash;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnnew;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label lblelectronic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblcashCashier;
        private System.Windows.Forms.Label label5;
    }
}