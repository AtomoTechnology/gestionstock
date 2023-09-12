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
    public partial class FrmListaProductos : Form
    {
        CtrlProductos Productos = new CtrlProductos();
        Validar val = new Validar();
        public int IdAlmacen;
        public FrmListaProductos()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
       
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[4].Visible = false;
            this.dataListado.Columns[8].Visible = false;
            this.dataListado.Columns[9].Visible = false;
            this.dataListado.Columns[10].Visible = false;
            this.dataListado.Columns[11].Visible = false;
            this.dataListado.Columns[12].Visible = false;
        }
        public void anchogrid()
        {
            //this.dataListado.Columns[0].Width = 80;
            this.dataListado.Columns[1].Width = 80;
            this.dataListado.Columns[2].Width = 150;
            this.dataListado.Columns[3].Width = 300;
            //this.dataListado.Columns[4].Width = 100;
            this.dataListado.Columns[5].Width = 120;
            this.dataListado.Columns[6].Width = 120;
            this.dataListado.Columns[7].Width = 120;

        }

        private void CargarDatos()
        {
            dataListado.DataSource = Productos.ListarProductos(IdAlmacen);
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void CargarDatosNom()
        {
            dataListado.DataSource = Productos.ListarProductosNomProductos(IdAlmacen, txtProducto.Text);
            anchogrid();
            OcultarColumnas();
            lblCantidad.Text = "Total de Registros " + dataListado.Rows.Count;

        }
        private void FrmListaProductos_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void FrmListaProductos_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void FrmListaProductos_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            CargarDatosNom();
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                FrmProductos p = FrmProductos.GetInstancia();
                int IdProducto, IdMarca, IdCategoria, IdUnidad;
                string Codigo, Nombre, Desc, Ubica, CantUn;
                byte[] Imagen;
                IdProducto = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdProducto"].Value);
                Codigo = Convert.ToString(this.dataListado.CurrentRow.Cells["CÓDIGO"].Value);
                Nombre = Convert.ToString(this.dataListado.CurrentRow.Cells["PRODUCTO"].Value);
                Desc = Convert.ToString(this.dataListado.CurrentRow.Cells["DESCRIPCIÓN"].Value);
                Ubica = Convert.ToString(this.dataListado.CurrentRow.Cells["Ubicacion"].Value);
                CantUn = Convert.ToString(this.dataListado.CurrentRow.Cells["CantidadMedida"].Value);

                IdCategoria = Convert.ToInt32(this.dataListado.CurrentRow.Cells["Idcategoria"].Value);
                IdMarca = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdMarca"].Value);

                IdUnidad = Convert.ToInt32(this.dataListado.CurrentRow.Cells["IdUnidad"].Value);
                Imagen = (byte[])this.dataListado.CurrentRow.Cells["Imagen"].Value;
                //System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
                p.setAlmacen(IdProducto, Codigo, Nombre, Desc, Imagen, IdCategoria, IdMarca, IdUnidad, CantUn, Ubica);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
