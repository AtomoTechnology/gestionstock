using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Negocio;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
namespace WinPresentacion.Maestras
{
    public partial class FrmProveedor : Form
    {
        CtrlProveedor Proveedor = new CtrlProveedor();
        private bool IsNuevo = false;
        private bool IsEditar = false;
        Validar val = new Validar();

        private static FrmProveedor _instancia;

        public static FrmProveedor GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmProveedor();
            }
            return _instancia;
        }
        public void setProveedor(string ruc, string razon, int tele, int cel, string email, string url, string repre, string direccion, int iddistrito, int idprovincia, int idregion, int idpais)
        {

            this.txtRUC.Text = ruc;
            this.txtRazonSocial.Text = razon;
            this.txtEmail.Text = email;
            this.txtURL.Text = url;
            this.txtRepresentante.Text = repre;
            txtTelefono.Text = Convert.ToString(tele);
            txtMovil.Text = Convert.ToString(cel);
            txtEmail.Text = email;
            txtDireccion.Text = direccion;
            cboDistrito.SelectedValue = iddistrito;
            cboProvincia.SelectedValue = idprovincia;
            this.cboRegion.SelectedValue = idregion;
            this.cboPais.SelectedValue = idpais;
        }
        public FrmProveedor()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(ConexionBD.Cn);
        //Cargar Combo Pais
        public void CargarPais()
        {
            SqlCommand cmd = new SqlCommand("SELECT IdPais, NomPais FROM dbo.Pais", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            DataRow fila = dt.NewRow();
            //fila["DescPais"] = "SELECCIONE PAIS";
            //dt.Rows.InsertAt(fila, 0);

            cboPais.DisplayMember = "NomPais";
            cboPais.ValueMember = "IdPais";
            cboPais.DataSource = dt;
        }
        //cargar Combo de Departamento
        public void CargarRegion(string Id_Pais)
        {
            SqlCommand cmd = new SqlCommand("SELECT dbo.Region.IdRegion, dbo.Region.NomRegion                 FROM dbo.Region INNER JOIN dbo.Pais ON dbo.Region.IdPais = dbo.Pais.IdPais                  where Region.IdPais=@IdPais", con);
            cmd.Parameters.AddWithValue("IdPais", Id_Pais);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            //DataRow fila = dt.NewRow();
            //fila["DescRegion"] = "SELECCIONE REGIÓN";
            //dt.Rows.InsertAt(fila, 0);

            cboRegion.DisplayMember = "NomRegion";
            cboRegion.ValueMember = "IdRegion";
            cboRegion.DataSource = dt;
        }
        //Cargar Combo de Provincia
        public void CargarProvincia(string Id_Region)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT IdProvincia, NomProvincia,IdRegion from Provincia where IdRegion=@IdRegion", con);
            cmd.Parameters.AddWithValue("IdRegion", Id_Region);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            //DataRow fila = dt.NewRow();
            //fila["DescProvincia"] = "SELECCIONE PROVINCIA";
            //dt.Rows.InsertAt(fila, 0);

            cboProvincia.DisplayMember = "NomProvincia";
            cboProvincia.ValueMember = "IdProvincia";
            cboProvincia.DataSource = dt;
        }
        //Cargar Combo de Distrito
        public void CargarDistrito(string Id_Provincia)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT IdDistrito, NomDistrito,IdProvincia from Distrito where IdProvincia=@IdProvincia", con);
            cmd.Parameters.AddWithValue("IdProvincia", Id_Provincia);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();

            //DataRow fila = dt.NewRow();
            //fila["DescDistrito"] = "SELECCIONE DISTRITO";
            //dt.Rows.InsertAt(fila, 0);

            cboDistrito.DisplayMember = "NomDistrito";
            cboDistrito.ValueMember = "IdDistrito";
            cboDistrito.DataSource = dt;
        }
        private void FrmProveedor_Load(object sender, EventArgs e)
        {

            this.Top = 40;
            this.Left = 40; this.Habilitar(false);
            this.Botones();
            CargarPais();
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
            this.txtRUC.Text = string.Empty;
            this.txtRazonSocial.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtMovil.Text = string.Empty;
            this.txtURL.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtRepresentante.Text = string.Empty;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            //this.txtRUC.ReadOnly = !valor;
            this.txtRazonSocial.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            txtRepresentante.ReadOnly = !valor;
            this.cboDistrito.Enabled = valor;
            this.cboPais.Enabled = valor;
            this.cboProvincia.Enabled = valor;
            this.cboRegion.Enabled = valor;

            this.txtMovil.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtURL.ReadOnly = !valor;
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
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }
        public void Nuevo()
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtRUC.Focus();
        }
        public void Editar()
        {
            if (!this.txtRUC.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Ingrese RUC Para Editar Proveedor");
            }
        }
        public void Guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtRUC.Text == string.Empty || this.txtRazonSocial.Text == string.Empty || this.txtMovil.Text == string.Empty || this.txtTelefono.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtRUC, "Ingrese un Valor");
                    errorIcono.SetError(txtRazonSocial, "Ingrese un Valor");
                    errorIcono.SetError(txtMovil, "Ingrese un Valor");
                    errorIcono.SetError(txtTelefono, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = CtrlProveedor.Insertar(this.txtRUC.Text, this.txtRazonSocial.Text.Trim().ToUpper(), Convert.ToInt32(txtTelefono.Text), Convert.ToInt32(txtMovil.Text), txtEmail.Text, txtURL.Text, txtRepresentante.Text, txtDireccion.Text, Convert.ToInt32(cboDistrito.SelectedValue), Convert.ToInt32(cboProvincia.SelectedValue), Convert.ToInt32(cboRegion.SelectedValue), Convert.ToInt32(cboPais.SelectedValue));

                    }
                    else
                    {
                        rpta = CtrlProveedor.Editar(this.txtRUC.Text, this.txtRazonSocial.Text.Trim().ToUpper(), Convert.ToInt32(txtTelefono.Text), Convert.ToInt32(txtMovil.Text), txtEmail.Text, txtURL.Text, txtRepresentante.Text, txtDireccion.Text, Convert.ToInt32(cboDistrito.SelectedValue), Convert.ToInt32(cboProvincia.SelectedValue), Convert.ToInt32(cboRegion.SelectedValue), Convert.ToInt32(cboPais.SelectedValue));
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
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
        //public void EliminarRegistros()
        //{
        //    try
        //    {
        //        DialogResult Opcion;
        //        Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

        //        if (Opcion == DialogResult.OK)
        //        {
        //            string Codigo;
        //            string Rpta = "";

        //            foreach (DataGridViewRow row in dataListado.Rows)
        //            {
        //                if (Convert.ToBoolean(row.Cells[0].Value))
        //                {
        //                    Codigo = Convert.ToString(row.Cells[1].Value);
        //                    Rpta = CtrlProveedor.Eliminar(Codigo);

        //                    if (Rpta.Equals("OK"))
        //                    {
        //                        this.MensajeOk("Se Eliminó Correctamente el registro");
        //                        this.dataListado.Columns[0].Visible = false;
        //                        chkEliminar.Checked = false;

        //                    }
        //                    else
        //                    {
        //                        this.MensajeError(Rpta);
        //                        chkEliminar.Checked = false;
        //                    }

        //                }
        //            }
        //            this.Mostrar();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + ex.StackTrace);
        //    }
        //}
        public void Cancelar()
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Habilitar(false);
            this.Limpiar();
            //this.txtIdcliente.Text = string.Empty;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void FrmProveedor_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPais.SelectedValue != null)
            {
                string Id_Pais = cboPais.SelectedValue.ToString();
                CargarRegion(Id_Pais);
            }
        }

        private void cboRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboRegion.SelectedValue != null)
            {
                string Id_Region = cboRegion.SelectedValue.ToString();
                CargarProvincia(Id_Region);
            }
        }

        private void cboProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvincia.SelectedValue != null)
            {
                string Id_Provincia = cboProvincia.SelectedValue.ToString();
                CargarDistrito(Id_Provincia);
            }
        }
        private void CargarDatos()
        {
            DataTable dt = new DataTable();
            dt = CtrlProveedor.VerificaProveedor(txtRUC.Text);
            if (dt.Rows.Count > 0)
            {
                txtRUC.Text = dt.Rows[0][0].ToString();
                txtRazonSocial.Text = dt.Rows[0][1].ToString();
                txtTelefono.Text = dt.Rows[0][2].ToString();
                txtMovil.Text = dt.Rows[0][3].ToString();
                txtEmail.Text = dt.Rows[0][4].ToString();
                txtURL.Text = dt.Rows[0][5].ToString();
                txtRepresentante.Text = dt.Rows[0][6].ToString();
                txtDireccion.Text = dt.Rows[0][7].ToString();
                cboDistrito.SelectedValue = dt.Rows[0][8].ToString();
                cboProvincia.SelectedValue = dt.Rows[0][9].ToString();
                cboRegion.SelectedValue = dt.Rows[0][10].ToString();
                cboPais.SelectedValue = dt.Rows[0][11].ToString();
            }
            else
            {
                MessageBox.Show("Proveedor no se encuentra registrado", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Nuevo();
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
            FrmListaProveedor lista = new FrmListaProveedor();
            lista.ShowDialog();
        }

        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CargarDatos();
                txtRazonSocial.Focus();
            }
        }

        private void txtRazonSocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                txtMovil.Focus();
            }
        }

        private void txtMovil_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                txtURL.Focus();
            }
        }

        private void txtURL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                txtRepresentante.Focus();
            }
        }

        private void txtRepresentante_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloLetras(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                cboDistrito.Focus();
            }
        }
    }
}
