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
namespace WinPresentacion.Reportes
{
    public partial class FrmListaProveedor : Form
    {
        CtrlProveedor CtrlProveedor = new CtrlProveedor();
        Maestras.Validar val = new Maestras.Validar();
        string url;
        public FrmListaProveedor()
        {
            InitializeComponent();
        }
        private void OcultarColumnas()
        {
            //    this.dataListado.Columns[0].Visible = false;
            //    this.dataListado.Columns[4].Visible = false;
            this.dataListado.Columns[5].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            //    this.dataListado.Columns[10].Visible = false;
            //    this.dataListado.Columns[11].Visible = false;
            //    this.dataListado.Columns[12].Visible = false;
        }
        public void anchogrid()
        {
            this.dataListado.Columns[0].Width = 100;
            this.dataListado.Columns[1].Width = 300;
            this.dataListado.Columns[2].Width = 110;
            this.dataListado.Columns[3].Width = 110;
            this.dataListado.Columns[4].Width = 150;
            this.dataListado.Columns[7].Width = 400;


        }

        private void CargarDatos()
        {
            dataListado.DataSource = CtrlProveedor.ListarTodos();
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void CargarDatosNom()
        {
            dataListado.DataSource = CtrlProveedor.ListarProveedorRazonSocial(txtApPaterno.Text);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void CargarDatosNro()
        {
            dataListado.DataSource = CtrlProveedor.ListarProveedorRUC(txtRuc.Text);

            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void FrmListaProveedor_Load(object sender, EventArgs e)
        {

            this.Top = 40;
            this.Left = 40;
            CargarDatos();


        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void FrmListaProveedor_MouseDown(object sender, MouseEventArgs e)
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

        private void txtRuc_KeyPress(object sender, KeyPressEventArgs e)
        {

            val.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                DataTable dt = new DataTable();
                dt = CtrlProveedor.ListarProveedorRUC(txtRuc.Text);
                if (dt.Rows.Count > 0)
                {
                    CargarDatosNro();
                }
                else
                {
                    MessageBox.Show("Provedor no se encuentra registrado", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtApPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            url = Convert.ToString(this.dataListado.CurrentRow.Cells["Web"].Value);

            txtRepresentante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["REPRESENTANTE"].Value);
            lblweb.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Web"].Value);
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataListado.Rows.Count > 0)
            {
                Exportar();
            }
            else
                MessageBox.Show("No hay Datos Para exportar");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmReporteProveedor re = new FrmReporteProveedor();
            re.ShowDialog();
        }
    }
}
