using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Negocio;
namespace WinPresentacion.Reportes
{
    public partial class FrmListaClientes : Form
    {
        CtrlCliente CtrlCliente = new CtrlCliente();
        Maestras.Validar val = new Maestras.Validar();
        public FrmListaClientes()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
      
        private void OcultarColumnas()
        {
            //    this.dataListado.Columns[0].Visible = false;
            //    this.dataListado.Columns[4].Visible = false;
            //    this.dataListado.Columns[8].Visible = false;
            //    this.dataListado.Columns[9].Visible = false;
            //    this.dataListado.Columns[10].Visible = false;
            //    this.dataListado.Columns[11].Visible = false;
            //    this.dataListado.Columns[12].Visible = false;
        }
        public void anchogrid()
        {
            this.dataListado.Columns[0].Width = 110;
            this.dataListado.Columns[1].Width = 100;
            this.dataListado.Columns[2].Width = 300;
            this.dataListado.Columns[3].Width = 100;
            this.dataListado.Columns[4].Width = 110;
            this.dataListado.Columns[5].Width = 110;
            this.dataListado.Columns[6].Width = 150;
            this.dataListado.Columns[7].Width = 380;

        }

        private void CargarDatos()
        {
            dataListado.DataSource = CtrlCliente.ListarTodos();
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void CargarDatosNom()
        {
            dataListado.DataSource = CtrlCliente.ListarClienteApPaterno(txtApPaterno.Text);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void CargarDatosNro()
        {
            dataListado.DataSource = CtrlCliente.ListarClientesDNI(txtNumero.Text);

            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void FrmListaClientes_Load(object sender, EventArgs e)
        {
            this.Top = 40;
            this.Left = 40;
            CargarDatos();
        }

        private void FrmListaClientes_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtApPaterno_TextChanged(object sender, EventArgs e)
        {
            CargarDatosNom();
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CargarDatosNro();
            }
        }
        private void Exportar()
        {
            try
            {
                if (dataListado.DataSource != null)
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
                        for (int i = 1; i <= this.dataListado.Columns.Count; i++)
                        {
                            hoja_trabajo.Cells[1, i] = this.dataListado.Columns[i - 1].HeaderText;
                        }

                        //Recorremos el DataGridView rellenando la hoja de trabajo con los datos
                        for (int i = 0; i < this.dataListado.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < this.dataListado.Columns.Count; j++)
                            {
                                hoja_trabajo.Cells[i + 2, j + 1] = this.dataListado.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);

                        libros_trabajo.Close(true);
                        aplicacion.Quit();
                        MessageBox.Show("Datos exportados correctamnete", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void button1_Click(object sender, EventArgs e)
        {
            FrmReporteClientes re = new FrmReporteClientes();
            re.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataListado.Rows.Count > 0)
            {
                Exportar();
            }
            else
                MessageBox.Show("No hay Datos Para exportar");
        }

        private void txtApPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }
    }
}
