namespace ApplicationView.Forms.Sale
{
    partial class frmsale
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
            this.dataList = new System.Windows.Forms.DataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnpay = new System.Windows.Forms.Button();
            this.txtreadcode = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.productqquantity = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.nrofact = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtcajeroname = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblinfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.Button();
            this.chckprinttiket = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataList
            // 
            this.dataList.AllowUserToAddRows = false;
            this.dataList.AllowUserToDeleteRows = false;
            this.dataList.AllowUserToOrderColumns = true;
            this.dataList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.quantity,
            this.SalePrice});
            this.dataList.Location = new System.Drawing.Point(9, 292);
            this.dataList.MultiSelect = false;
            this.dataList.Name = "dataList";
            this.dataList.ReadOnly = true;
            this.dataList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataList.RowHeadersWidth = 51;
            this.dataList.RowTemplate.Height = 29;
            this.dataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataList.Size = new System.Drawing.Size(962, 411);
            this.dataList.TabIndex = 1;
            this.dataList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataList_CellDoubleClick);
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Nombre";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "Cantidad";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // SalePrice
            // 
            this.SalePrice.DataPropertyName = "SalePrice";
            this.SalePrice.HeaderText = "Precio";
            this.SalePrice.MinimumWidth = 6;
            this.SalePrice.Name = "SalePrice";
            this.SalePrice.ReadOnly = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.btnpay);
            this.groupBox5.Controls.Add(this.txtreadcode);
            this.groupBox5.Location = new System.Drawing.Point(9, 693);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(965, 89);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 45);
            this.label2.TabIndex = 6;
            this.label2.Text = "Codigo de venta";
            // 
            // btnpay
            // 
            this.btnpay.BackColor = System.Drawing.SystemColors.Control;
            this.btnpay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnpay.ForeColor = System.Drawing.Color.Black;
            this.btnpay.ImageKey = "(none)";
            this.btnpay.Location = new System.Drawing.Point(757, 16);
            this.btnpay.Name = "btnpay";
            this.btnpay.Size = new System.Drawing.Size(198, 64);
            this.btnpay.TabIndex = 5;
            this.btnpay.Text = "Cobrar";
            this.btnpay.UseVisualStyleBackColor = false;
            this.btnpay.Click += new System.EventHandler(this.btnpay_Click);
            // 
            // txtreadcode
            // 
            this.txtreadcode.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtreadcode.Location = new System.Drawing.Point(304, 16);
            this.txtreadcode.Multiline = true;
            this.txtreadcode.Name = "txtreadcode";
            this.txtreadcode.Size = new System.Drawing.Size(450, 65);
            this.txtreadcode.TabIndex = 1;
            this.txtreadcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtreadcode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(239, 217);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(732, 72);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total a cobrar";
            // 
            // productqquantity
            // 
            this.productqquantity.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.productqquantity.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.productqquantity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.productqquantity.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.productqquantity.ForeColor = System.Drawing.Color.White;
            this.productqquantity.Location = new System.Drawing.Point(658, 112);
            this.productqquantity.Name = "productqquantity";
            this.productqquantity.Size = new System.Drawing.Size(306, 56);
            this.productqquantity.TabIndex = 9;
            this.productqquantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(658, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 38);
            this.label4.TabIndex = 8;
            this.label4.Text = "Cantidad de productos";
            // 
            // nrofact
            // 
            this.nrofact.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nrofact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.nrofact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nrofact.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nrofact.ForeColor = System.Drawing.Color.White;
            this.nrofact.Location = new System.Drawing.Point(7, 112);
            this.nrofact.Name = "nrofact";
            this.nrofact.Size = new System.Drawing.Size(306, 56);
            this.nrofact.TabIndex = 11;
            this.nrofact.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(5, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 38);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nro factura";
            // 
            // txtcajeroname
            // 
            this.txtcajeroname.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtcajeroname.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtcajeroname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtcajeroname.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtcajeroname.ForeColor = System.Drawing.Color.White;
            this.txtcajeroname.Location = new System.Drawing.Point(319, 112);
            this.txtcajeroname.Name = "txtcajeroname";
            this.txtcajeroname.Size = new System.Drawing.Size(333, 56);
            this.txtcajeroname.TabIndex = 13;
            this.txtcajeroname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(358, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(135, 38);
            this.label7.TabIndex = 12;
            this.label7.Text = "Cajero(a)";
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.Font = new System.Drawing.Font("Century", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblinfo.ForeColor = System.Drawing.Color.Black;
            this.lblinfo.Location = new System.Drawing.Point(189, 7);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(486, 55);
            this.lblinfo.TabIndex = 16;
            this.lblinfo.Text = "Ventas de productos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.lblinfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 66);
            this.panel1.TabIndex = 20;
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
            this.btnclose.Location = new System.Drawing.Point(930, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(50, 66);
            this.btnclose.TabIndex = 24;
            this.btnclose.Text = "X";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // chckprinttiket
            // 
            this.chckprinttiket.AutoSize = true;
            this.chckprinttiket.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chckprinttiket.Location = new System.Drawing.Point(535, 183);
            this.chckprinttiket.Name = "chckprinttiket";
            this.chckprinttiket.Size = new System.Drawing.Size(18, 17);
            this.chckprinttiket.TabIndex = 22;
            this.chckprinttiket.UseVisualStyleBackColor = true;
            this.chckprinttiket.CheckedChanged += new System.EventHandler(this.chckprinttiket_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(444, 38);
            this.label3.TabIndex = 23;
            this.label3.Text = "¿Deseas imprimir tiket de venta?";
            // 
            // frmsale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(980, 801);
            this.Controls.Add(this.chckprinttiket);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.txtcajeroname);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nrofact);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.productqquantity);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmsale";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venta de producto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmsale_FormClosing);
            this.Load += new System.EventHandler(this.frmsale_Load);
            this.ResizeEnd += new System.EventHandler(this.frmsale_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.frmsale_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmsale_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmsale_MouseDown);
            this.Validated += new System.EventHandler(this.frmsale_Validated);
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataList;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtreadcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnpay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label productqquantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label nrofact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtcajeroname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn productId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleId;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalePrice;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.CheckBox chckprinttiket;
        private System.Windows.Forms.Label label3;
    }
}