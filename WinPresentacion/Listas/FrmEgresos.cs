﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using System.Runtime.InteropServices;
namespace WinPresentacion.Listas
{
    public partial class FrmEgresos : Form
    {
        CtrlCompras CtrlCompras = new CtrlCompras();
        public int IdAlmacen;
        public FrmEgresos()
        {
            InitializeComponent();
        }
        private void OcultarColumnas()
        {
            this.gvVenta.Columns[0].Visible = false;
            //this.gvVenta.Columns[1].Visible = false;

        }

        //Método Mostrar
        private void MostrarGanaciasDiarias()
        {
            this.gvVenta.DataSource = CtrlCompras.MostraregresosDiarias(IdAlmacen, dtfecha1.Value);
            this.OcultarColumnas();
            this.gvVenta.Columns[1].Width = 134;
            this.gvVenta.Columns[2].Width = 80;
            this.gvVenta.Columns[3].Width = 100;
            this.gvVenta.Columns[4].Width = 200;
            this.gvVenta.Columns[5].Width = 200;
            this.gvVenta.Columns[6].Width = 130;
            this.gvVenta.Columns[7].Width = 97;
            //this.gvVenta.Columns[9].Width = 100;
            this.gvVenta.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());

            int suma = 0;
            foreach (DataGridViewRow row in gvVenta.Rows)
            {
                suma += Convert.ToInt32(row.Cells[8].Value);    //aqui recorre las celdas y las va sumando
            }
            txtGanacia.Text = Convert.ToString(suma.ToString("N2"));
        }
        private void MostrarDetalle()
        {

            this.gvDetalle.DataSource = CtrlCompras.MostrarDetalle(Convert.ToInt32(this.txtIdventa.Text));

        }
        public void Pasarcampo(DataGridView midgv, TextBox txb, string columna)
        {
            // especifico que campo de la fila que este seleccionada vamos a pasar al textbox

            txb.Text = midgv.Rows[midgv.CurrentRow.Index].Cells[columna].Value.ToString();

        }
        private void BuscarFechas()
        {
            this.gvVenta.DataSource = CtrlCompras.BuscarFechas(dtfecha1.Value.ToString("dd/MM/yyyy"),
                this.dtFecha2.Value.ToString("dd/MM/yyyy"), IdAlmacen);
            this.OcultarColumnas();

            decimal suma = 0;
            foreach (DataGridViewRow row in gvVenta.Rows)
            {
                suma += Convert.ToInt32(row.Cells[8].Value);    //aqui recorre las celdas y las va sumando
            }
            txtGanacia.Text = Convert.ToString(suma.ToString("N2"));
        }
       
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void FrmEgresos_Load(object sender, EventArgs e)
        {
            this.Top = 40;
            this.Left = 40;
            MostrarGanaciasDiarias();
        }

        private void FrmEgresos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = CtrlVenta.BuscarFechas(dtfecha1.Value.ToString("dd/MM/yyyy"),
                this.dtFecha2.Value.ToString("dd/MM/yyyy"), IdAlmacen);
            if (dt.Rows.Count > 0)
            {
                BuscarFechas();
            }
            else
            {
                MessageBox.Show("No hay Registros para Mostrar", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void gvVenta_Click(object sender, EventArgs e)
        {
            int i = 0;

            if (gvVenta.Rows.Count <= 0)
            {
                txtIdventa.Text = "";

            }

            else

            {
                this.txtIdventa.Text = Convert.ToString(this.gvVenta.CurrentRow.Cells["IdCompra"].Value);

                MostrarDetalle();
                this.gvDetalle.Columns[0].Width = 80;
                this.gvDetalle.Columns[1].Width = 290;
                this.gvDetalle.Columns[2].Width = 150;
                this.gvDetalle.Columns[3].Width = 150;
                this.gvDetalle.Columns[4].Width = 120;
                this.gvDetalle.Columns[5].Width = 100;

                this.gvDetalle.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            }
        }
    }
}
