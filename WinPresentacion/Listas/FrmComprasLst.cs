using System;
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
    public partial class FrmComprasLst : Form
    {
        public int IdAlmacen;
        public FrmComprasLst()
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
            this.gvVenta.DataSource = CtrlCompras.Mostrar(IdAlmacen);
            this.OcultarColumnas();
            this.gvVenta.Columns[1].Width = 134;
            this.gvVenta.Columns[2].Width = 80;
            this.gvVenta.Columns[3].Width = 100;
            this.gvVenta.Columns[4].Width = 200;
            this.gvVenta.Columns[5].Width = 200;
            this.gvVenta.Columns[6].Width = 130;
            this.gvVenta.Columns[7].Width = 97;
            //this.gvVenta.Columns[8].Width = 100;
            //this.gvVenta.Columns[9].Width = 100;
            lblCantidad.Text = "Total de Registros " + gvVenta.Rows.Count;
            this.gvVenta.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());

        }

        private void BuscarFechas()
        {
            this.gvVenta.DataSource = CtrlCompras.BuscarFechas(dtfecha1.Value.ToString("dd/MM/yyyy"),
                this.dtFecha2.Value.ToString("dd/MM/yyyy"), IdAlmacen);
            lblCantidad.Text = "Total de Registros " + gvVenta.Rows.Count;
            this.OcultarColumnas();


        }
        private void FrmComprasLst_Load(object sender, EventArgs e)
        {
            this.Top = 40;
            this.Left = 40;
            MostrarGanaciasDiarias();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmComprasLst_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuscarFechas();
        }
        private void Exportar()
        {
            try
            {
                if (gvVenta.DataSource != null)
                {
                    SaveFileDialog fichero = new SaveFileDialog();
                    fichero.Filter = "Excel (*.xls)|*.xls";
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application aplicacion;
                        Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                        aplicacion = new Microsoft.Office.Interop.Excel.Application();
                        libros_trabajo = aplicacion.Workbooks.Add();
                        hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                        //exportar cabeceras dgvLog
                        for (int i = 1; i <= this.gvVenta.Columns.Count; i++)
                        {
                            hoja_trabajo.Cells[1, i] = this.gvVenta.Columns[i - 1].HeaderText;
                        }

                        //Recorremos el DataGridView rellenando la hoja de trabajo con los datos
                        for (int i = 0; i < this.gvVenta.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < this.gvVenta.Columns.Count; j++)
                            {
                                hoja_trabajo.Cells[i + 2, j + 1] = this.gvVenta.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);

                        libros_trabajo.Close(true);
                        aplicacion.Quit();
                        MessageBox.Show("Datos exportados correctamnete", "Decor Mayo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("NO hay regostros para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Exportar();
        }
    }
}
