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
namespace WinPresentacion.Maestras
{
    public partial class FrmProductos : Form
    {
        CtrlCategoria Categoria = new CtrlCategoria();
        CtrlMarca Marca = new CtrlMarca();
        CtrlUnidad Unidad = new CtrlUnidad();
        CtrlProductos Productos = new CtrlProductos();
        Validar val = new Validar();
        private bool IsNuevo = false;

        private bool IsEditar = false;
        public int IdAlmacen;

        private static FrmProductos _instancia;

        public static FrmProductos GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmProductos();
            }
            return _instancia;
        }
        public void setAlmacen(int IdProducto, string Codigo, string Nombre, string Desc, byte[] Imagen, int IdCategoria, int IdMarca, int IdUnidad, string CantUn, string Ubica)
        {
            this.txtIdProducto.Text = Convert.ToString(IdProducto);
            this.txtCodigo.Text = Codigo;
            this.txtNombre.Text = Nombre;
            this.txtDescripcion.Text = Desc;
            byte[] imagenBuffer = Imagen;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);
            pxImagen.Image = Image.FromStream(ms);
            pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            CboCategoria.SelectedValue = IdCategoria;
            cboMarca.SelectedValue = IdMarca;
            CboUnidad.SelectedValue = IdUnidad;
            this.txtCantidadMed.Text = CantUn;
            this.txtUbicacion.Text = Ubica;
        }
        public FrmProductos()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
       
        private void CargarMarca()
        {
            cboMarca.DataSource = Marca.Mostrar();
            cboMarca.DisplayMember = "NomMarca";
            cboMarca.ValueMember = "IdMarca";
        }
        private void CargarCategoria()
        {
            CboCategoria.DataSource = Categoria.Mostrar();
            CboCategoria.DisplayMember = "NomCategoria";
            CboCategoria.ValueMember = "Idcategoria";
        }
        //Mostrar Mensaje de Confirmación
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtCantidadMed.Text = string.Empty;
            //this.txtIdcategoria.Text = string.Empty;
            //this.txtCategoria.Text = string.Empty;
            this.txtUbicacion.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.pxImagen.Image = global::WinPresentacion.Properties.Resources.file;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtCantidadMed.ReadOnly = !valor;
            txtUbicacion.ReadOnly = !valor;
            this.CboCategoria.Enabled = valor;
            this.cboMarca.Enabled = valor;
            this.CboUnidad.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.txtDescripcion.ReadOnly = !valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
                btnAgregar.Enabled = true;
                btnQuitar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
                btnAgregar.Enabled = false;
                btnQuitar.Enabled = false;
            }

        }

        private void CargarUnidad()
        {
            CboUnidad.DataSource = Unidad.Mostrar();
            CboUnidad.DisplayMember = "NomUnidad";
            CboUnidad.ValueMember = "IdUnidad";
        }
        private void FrmProductos_Load(object sender, EventArgs e)
        {
            this.Top = 40;
            this.Left = 40;
            this.Habilitar(false);
            this.Botones();
            CargarCategoria();
            CargarMarca();
            CargarUnidad();
        }
        public void Nuevo()
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtCodigo.Focus();
        }
        public void Editar()
        {
            if (!this.txtCodigo.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Busque Producto a Editar");
            }
        }

        public void Guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtCodigo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Valor");
                    errorIcono.SetError(txtCodigo, "Ingrese un Valor");
                    //errorIcono.SetError(txtCategoria, "Ingrese un Valor");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pxImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();


                    if (this.IsNuevo)
                    {
                        rpta = CtrlProductos.Insertar(this.txtCodigo.Text, this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim().ToUpper(), imagen, Convert.ToInt32(CboCategoria.SelectedValue), Convert.ToInt32(cboMarca.SelectedValue), Convert.ToInt32(CboUnidad.SelectedValue), txtCantidadMed.Text, txtUbicacion.Text);

                    }
                    else
                    {
                        rpta = CtrlProductos.Editar(Convert.ToInt32(this.txtIdProducto.Text), this.txtCodigo.Text, this.txtNombre.Text.Trim().ToUpper(), this.txtDescripcion.Text.Trim().ToUpper(), imagen, Convert.ToInt32(CboCategoria.SelectedValue), Convert.ToInt32(cboMarca.SelectedValue), Convert.ToInt32(CboUnidad.SelectedValue), txtCantidadMed.Text, txtUbicacion.Text);
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                            rpta = CtrlProductos.InsertarProductoAlmacen(1, Convert.ToInt32(txtIdProducto.Text));
                            rpta = CtrlProductos.InsertarProductoAlmacen(2, Convert.ToInt32(txtIdProducto.Text));
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                            txtIdProducto.Text = string.Empty;
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void Cancelar()
        {

            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
        }
        public void CargarImagen()
        {
            //Cargar Imagen
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();

                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pxImagen.Image = System.Drawing.Image.FromFile(dialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        public void LimpiarImagen()
        {
            //Limpiar Imagen
            this.pxImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pxImagen.Image = global::WinPresentacion.Properties.Resources.file;
        }

        private void FrmProductos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CargarImagen();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            LimpiarImagen();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
            DataTable dt = new DataTable();
            dt = Productos.GenrarIdProducto();
            txtIdProducto.Text = dt.Rows[0][0].ToString();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Editar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {

            FrmListaProductos vistta = new FrmListaProductos();
            vistta.IdAlmacen = IdAlmacen;
            vistta.ShowDialog();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtNombre.Focus();
            }
        }
    }
}
