namespace ApplicationView.Forms.Sale
{
    partial class frmsalehistoric
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btndetailturn = new System.Windows.Forms.Button();
            this.cbuser = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnexport = new System.Windows.Forms.Button();
            this.btnprint = new System.Windows.Forms.Button();
            this.lblprice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpto = new System.Windows.Forms.DateTimePicker();
            this.dtpfrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnsearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataList = new System.Windows.Forms.DataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chartTorta = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnclose = new System.Windows.Forms.Button();
            this.lblinfo = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTorta)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(16, 78);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(858, 763);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btndetailturn);
            this.tabPage1.Controls.Add(this.cbuser);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.btnexport);
            this.tabPage1.Controls.Add(this.btnprint);
            this.tabPage1.Controls.Add(this.lblprice);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.dtpto);
            this.tabPage1.Controls.Add(this.dtpfrom);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.btnsearch);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dataList);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(850, 730);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Lista";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // btndetailturn
            // 
            this.btndetailturn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btndetailturn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndetailturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btndetailturn.Image = global::ApplicationView.Properties.Resources.closecashier__3_;
            this.btndetailturn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndetailturn.Location = new System.Drawing.Point(133, 61);
            this.btndetailturn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btndetailturn.Name = "btndetailturn";
            this.btndetailturn.Size = new System.Drawing.Size(193, 53);
            this.btndetailturn.TabIndex = 48;
            this.btndetailturn.Text = "Detalle x turno";
            this.btndetailturn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btndetailturn.UseVisualStyleBackColor = true;
            this.btndetailturn.Click += new System.EventHandler(this.btndetailturn_Click);
            // 
            // cbuser
            // 
            this.cbuser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbuser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cbuser.FormattingEnabled = true;
            this.cbuser.Items.AddRange(new object[] {
            "Seleccione el usuario"});
            this.cbuser.Location = new System.Drawing.Point(79, 12);
            this.cbuser.Name = "cbuser";
            this.cbuser.Size = new System.Drawing.Size(246, 36);
            this.cbuser.TabIndex = 47;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 23);
            this.label5.TabIndex = 46;
            this.label5.Text = "Usuario";
            // 
            // btnexport
            // 
            this.btnexport.Enabled = false;
            this.btnexport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnexport.Image = global::ApplicationView.Properties.Resources.excel;
            this.btnexport.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnexport.Location = new System.Drawing.Point(669, 61);
            this.btnexport.Name = "btnexport";
            this.btnexport.Size = new System.Drawing.Size(161, 53);
            this.btnexport.TabIndex = 45;
            this.btnexport.Text = "Exportar";
            this.btnexport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexport.UseVisualStyleBackColor = true;
            this.btnexport.Visible = false;
            this.btnexport.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnprint
            // 
            this.btnprint.Enabled = false;
            this.btnprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnprint.Image = global::ApplicationView.Properties.Resources.printer;
            this.btnprint.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnprint.Location = new System.Drawing.Point(499, 61);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(161, 53);
            this.btnprint.TabIndex = 44;
            this.btnprint.Text = "Imprimir";
            this.btnprint.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnprint.UseVisualStyleBackColor = true;
            // 
            // lblprice
            // 
            this.lblprice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblprice.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblprice.ForeColor = System.Drawing.Color.Red;
            this.lblprice.Location = new System.Drawing.Point(374, 128);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(469, 50);
            this.lblprice.TabIndex = 41;
            this.lblprice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(34, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(334, 50);
            this.label3.TabIndex = 40;
            this.label3.Text = "Recaudacion total";
            // 
            // dtpto
            // 
            this.dtpto.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpto.Location = new System.Drawing.Point(591, 17);
            this.dtpto.Name = "dtpto";
            this.dtpto.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpto.RightToLeftLayout = true;
            this.dtpto.Size = new System.Drawing.Size(106, 27);
            this.dtpto.TabIndex = 39;
            // 
            // dtpfrom
            // 
            this.dtpfrom.CalendarFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpfrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtpfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfrom.Location = new System.Drawing.Point(407, 16);
            this.dtpfrom.Name = "dtpfrom";
            this.dtpfrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpfrom.RightToLeftLayout = true;
            this.dtpfrom.Size = new System.Drawing.Size(101, 27);
            this.dtpfrom.TabIndex = 38;
            this.dtpfrom.Value = new System.DateTime(2023, 1, 19, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(521, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Hasta";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.lblTotal);
            this.groupBox5.Controls.Add(this.lblStatus);
            this.groupBox5.Controls.Add(this.btnNext);
            this.groupBox5.Controls.Add(this.btnLast);
            this.groupBox5.Controls.Add(this.btnPrevious);
            this.groupBox5.Controls.Add(this.btnFirst);
            this.groupBox5.Location = new System.Drawing.Point(68, 659);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(690, 63);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(341, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(171, 28);
            this.label12.TabIndex = 8;
            this.label12.Text = " Cantidad de registros";
            // 
            // lblTotal
            // 
            this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotal.Location = new System.Drawing.Point(507, 20);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(137, 25);
            this.lblTotal.TabIndex = 7;
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatus.Location = new System.Drawing.Point(75, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(139, 27);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "0 / 0";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(221, 19);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(32, 28);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(253, 19);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(32, 28);
            this.btnLast.TabIndex = 2;
            this.btnLast.Text = ">|";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(43, 19);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(32, 28);
            this.btnPrevious.TabIndex = 1;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(11, 19);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(32, 28);
            this.btnFirst.TabIndex = 0;
            this.btnFirst.Text = "|<";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnsearch
            // 
            this.btnsearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnsearch.Image = global::ApplicationView.Properties.Resources.Detective_icon_icons_com_54187;
            this.btnsearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsearch.Location = new System.Drawing.Point(332, 63);
            this.btnsearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(161, 53);
            this.btnsearch.TabIndex = 3;
            this.btnsearch.Text = "Visualizar";
            this.btnsearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(339, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desde";
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
            this.subtotal});
            this.dataList.Location = new System.Drawing.Point(13, 191);
            this.dataList.MultiSelect = false;
            this.dataList.Name = "dataList";
            this.dataList.ReadOnly = true;
            this.dataList.RowHeadersWidth = 51;
            this.dataList.RowTemplate.Height = 29;
            this.dataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataList.Size = new System.Drawing.Size(830, 467);
            this.dataList.TabIndex = 0;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Producto";
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
            // subtotal
            // 
            this.subtotal.DataPropertyName = "subtotal";
            this.subtotal.HeaderText = "Sub total";
            this.subtotal.MinimumWidth = 6;
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            // 
            // chartTorta
            // 
            chartArea1.AxisX.MaximumAutoSize = 100F;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            chartArea1.AxisX2.MaximumAutoSize = 100F;
            chartArea1.AxisX2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            chartArea1.AxisY.MaximumAutoSize = 100F;
            chartArea1.AxisY.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            chartArea1.AxisY2.MaximumAutoSize = 100F;
            chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 71.65134F;
            chartArea1.Position.X = 3F;
            this.chartTorta.ChartAreas.Add(chartArea1);
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            legend1.IsTextAutoFit = false;
            legend1.ItemColumnSpacing = 150;
            legend1.Name = "Legend1";
            legend1.TextWrapThreshold = 125;
            legend1.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.chartTorta.Legends.Add(legend1);
            this.chartTorta.Location = new System.Drawing.Point(887, 60);
            this.chartTorta.Name = "chartTorta";
            this.chartTorta.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            series1.Legend = "Legend1";
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;
            series1.Name = "Series1";
            this.chartTorta.Series.Add(series1);
            this.chartTorta.Size = new System.Drawing.Size(430, 788);
            this.chartTorta.TabIndex = 4;
            this.chartTorta.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.chartTorta);
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Location = new System.Drawing.Point(0, -2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1320, 848);
            this.panel2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.btnclose);
            this.panel1.Controls.Add(this.lblinfo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1320, 61);
            this.panel1.TabIndex = 5;
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
            this.btnclose.Location = new System.Drawing.Point(1270, 0);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(50, 61);
            this.btnclose.TabIndex = 23;
            this.btnclose.Text = "X";
            this.btnclose.UseVisualStyleBackColor = false;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.Font = new System.Drawing.Font("Century", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblinfo.ForeColor = System.Drawing.Color.Black;
            this.lblinfo.Location = new System.Drawing.Point(165, 3);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(459, 55);
            this.lblinfo.TabIndex = 22;
            this.lblinfo.Text = "Historial de ventas";
            // 
            // frmsalehistoric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1312, 852);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmsalehistoric";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de ventas";
            this.Load += new System.EventHandler(this.frmsalehistoric_Load);
            this.ResizeEnd += new System.EventHandler(this.frmsalehistoric_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.frmsalehistoric_SizeChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.frmsalehistoric_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmsalehistoric_MouseDown);
            this.Validated += new System.EventHandler(this.frmsalehistoric_Validated);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTorta)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataList;
        private System.Windows.Forms.DateTimePicker dtpto;
        private System.Windows.Forms.DateTimePicker dtpfrom;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTorta;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnexport;
        private System.Windows.Forms.Button btnprint;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btndetailturn;
        private System.Windows.Forms.ComboBox cbuser;
    }
}