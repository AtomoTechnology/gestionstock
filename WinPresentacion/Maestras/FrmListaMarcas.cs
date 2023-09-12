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
namespace WinPresentacion.Maestras
{
    public partial class FrmListaMarcas : Form
    {
        CtrlMarca Marca = new CtrlMarca();
        Validar val = new Validar();
        public FrmListaMarcas()
        {
            InitializeComponent();
        }
        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Decor Mayo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]


        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void OcultarColumnas()
        {
            //this.dataListado.Columns[0].Visible = false;
            //this.dataListado.Columns[4].Visible = false;
            //this.dataListado.Columns[8].Visible = false;
            //this.dataListado.Columns[9].Visible = false;
            //this.dataListado.Columns[10].Visible = false;
            //this.dataListado.Columns[11].Visible = false;
            //this.dataListado.Columns[12].Visible = false;
        }
        public void anchogrid()
        {
            this.dataListado.Columns[0].Width = 100;
            this.dataListado.Columns[1].Width = 350;


        }

        private void CargarDatos()
        {
            dataListado.DataSource = Marca.ListarTodo();
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void CargarDatosNom()
        {
            dataListado.DataSource = Marca.ListarMarca(txtProducto.Text);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void FrmListaMarcas_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void FrmListaMarcas_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FrmMarcas frm = FrmMarcas.GetInstancia();
                int id;
                string marca;
                id = Convert.ToInt32(this.dataListado.CurrentRow.Cells["código"].Value);
                marca = Convert.ToString(dataListado.CurrentRow.Cells["marca"].Value);
                frm.setMarca(id, marca);
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            CargarDatosNom();
        }
        public void EliminarRegistros()
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    int Codigo = Convert.ToInt32(dataListado.CurrentRow.Cells["código"].Value);
                    string Rpta = "";

                    Rpta = CtrlMarca.Eliminar(Codigo);
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeOk("Se Eliminó Correctamente el registro");
                        CargarDatos();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void btnListar_Click(object sender, EventArgs e)
        {
            EliminarRegistros();
        }
    }
}
