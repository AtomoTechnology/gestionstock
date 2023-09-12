using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Datos;
using Negocio;
using System.Runtime.InteropServices;

namespace WinPresentacion.Maestras
{
    public partial class FrmClientes : Form
    {
        CtrlCliente ctCliente = new CtrlCliente();
        CtrlTipoDocumento CtrlTipoDocumento = new CtrlTipoDocumento();
        CtrlSexo CtrlSexo = new CtrlSexo();

        Validar Val = new Validar();

        private bool IsNuevo = false;
        private bool IsEditar = false;

        private static FrmClientes _instancia;

        public static FrmClientes GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmClientes();
            }
            return _instancia;
        }
        public void setCliente(int IdTipoDoc, string Numero, string ApPaterno, string ApMaterno, string pN, string SN, int sexo, int telefono, int movil, string email, string direccion, int iddistrito, int idprovincia, int idregion, int idpais)
        {
            this.cbTipo_Documento.SelectedValue = IdTipoDoc;
            this.txtNumDocumento.Text = Numero;
            this.txtApPaterno.Text = ApPaterno;
            this.txtApMaterno.Text = ApMaterno;
            this.txtPrimerNombre.Text = pN;
            this.txtOtrosNombres.Text = SN;
            txtTelefono.Text = Convert.ToString(telefono);
            txtMovil.Text = Convert.ToString(movil);
            txtEmail.Text = email;
            txtDireccion.Text = direccion;
            cbSexo.SelectedValue = sexo;
            cboDistrito.SelectedValue = iddistrito;
            cboProvincia.SelectedValue = idprovincia;
            this.cboRegion.SelectedValue = idregion;
            this.cboPais.SelectedValue = idpais;
        }
        public FrmClientes()
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
        private void CargarDocumento()
        {
            cbTipo_Documento.DataSource = CtrlTipoDocumento.CargarTipoDocReg();
            cbTipo_Documento.DisplayMember = "NomDocumento";
            cbTipo_Documento.ValueMember = "IdTipoDoc";
        }
        private void CargarSexo()
        {
            cbSexo.DataSource = CtrlSexo.Mostar();
            cbSexo.DisplayMember = "Sexo";
            cbSexo.ValueMember = "IdSexo";
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
            this.txtPrimerNombre.Text = string.Empty;
            this.txtOtrosNombres.Text = string.Empty;
            this.txtApMaterno.Text = string.Empty;
            this.txtApPaterno.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtEmail.Text = string.Empty;
            this.txtNumDocumento.Text = string.Empty;
            txtMovil.Text = string.Empty;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            //this.txtNumDocumento.ReadOnly = !valor;
            this.txtOtrosNombres.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtApMaterno.ReadOnly = !valor;
            this.txtApPaterno.ReadOnly = !valor;
            this.cbTipo_Documento.Enabled = valor;
            this.cboDistrito.Enabled = valor;
            this.cboPais.Enabled = valor;
            this.cboProvincia.Enabled = valor;
            this.cboRegion.Enabled = valor;
            this.cbSexo.Enabled = valor;
            this.txtPrimerNombre.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtEmail.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtMovil.ReadOnly = !valor;
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
        private void FrmClientes_Load(object sender, EventArgs e)
        {
            this.Top = 40;
            this.Left = 40;
            this.Habilitar(false);
            this.Botones();
            CargarPais();
            CargarDocumento();
            CargarSexo();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void FrmClientes_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void CargarDatos()
        {
            DataTable dt = new DataTable();
            dt = ctCliente.Verifica(txtNumDocumento.Text);
            if (dt.Rows.Count > 0)
            {
                txtNumDocumento.Text = dt.Rows[0][0].ToString();
                cbTipo_Documento.SelectedValue = dt.Rows[0][1].ToString();
                txtApPaterno.Text = dt.Rows[0][2].ToString();
                txtApMaterno.Text = dt.Rows[0][3].ToString();
                txtPrimerNombre.Text = dt.Rows[0][4].ToString();
                txtOtrosNombres.Text = dt.Rows[0][5].ToString();
                cbSexo.SelectedValue = dt.Rows[0][6].ToString();
                txtTelefono.Text = dt.Rows[0][7].ToString();
                txtMovil.Text = dt.Rows[0][8].ToString();
                txtEmail.Text = dt.Rows[0][9].ToString();
                txtDireccion.Text = dt.Rows[0][10].ToString();
                cboDistrito.SelectedValue = dt.Rows[0][11].ToString();
                cboProvincia.SelectedValue = dt.Rows[0][12].ToString();
                cboRegion.SelectedValue = dt.Rows[0][13].ToString();
                cboPais.SelectedValue = dt.Rows[0][14].ToString();
            }
            else
            {
                MessageBox.Show("Cliente no se encuentra registrado", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FrmClientes_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtNumDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            Val.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                CargarDatos();
                txtApPaterno.Focus();
            }
        }
        public void Nuevo()
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNumDocumento.Focus();
        }
        public void Editar()
        {
            if (!this.txtNumDocumento.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Ingrese N° de documento a Editar");
            }
        }
        public void Guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtNumDocumento.Text == string.Empty || this.txtApPaterno.Text == string.Empty || this.txtApMaterno.Text == string.Empty || this.txtPrimerNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNumDocumento, "Ingrese un Valor");
                    errorIcono.SetError(txtApMaterno, "Ingrese un Valor");
                    errorIcono.SetError(txtApPaterno, "Ingrese un Valor");
                    errorIcono.SetError(txtPrimerNombre, "Ingrese un Valor");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = CtrlCliente.Insertar(this.txtNumDocumento.Text, Convert.ToInt32(cbTipo_Documento.SelectedValue), this.txtApPaterno.Text.Trim().ToUpper(), this.txtApMaterno.Text.Trim().ToUpper(), this.txtPrimerNombre.Text.Trim().ToUpper(), this.txtOtrosNombres.Text.Trim().ToUpper(), Convert.ToInt32(cbSexo.SelectedValue), Convert.ToInt32(txtTelefono.Text), Convert.ToInt32(txtMovil.Text), this.txtEmail.Text, txtDireccion.Text, Convert.ToInt32(cboDistrito.SelectedValue), Convert.ToInt32(cboProvincia.SelectedValue), Convert.ToInt32(cboRegion.SelectedValue), Convert.ToInt32(cboPais.SelectedValue));

                    }
                    else
                    {
                        rpta = CtrlCliente.Editar(this.txtNumDocumento.Text, Convert.ToInt32(cbTipo_Documento.SelectedValue), this.txtApPaterno.Text.Trim().ToUpper(), this.txtApMaterno.Text.Trim().ToUpper(), this.txtPrimerNombre.Text.Trim().ToUpper(), this.txtOtrosNombres.Text.Trim().ToUpper(), Convert.ToInt32(cbSexo.SelectedValue), Convert.ToInt32(txtTelefono.Text), Convert.ToInt32(txtMovil.Text), this.txtEmail.Text, txtDireccion.Text, Convert.ToInt32(cboDistrito.SelectedValue), Convert.ToInt32(cboProvincia.SelectedValue), Convert.ToInt32(cboRegion.SelectedValue), Convert.ToInt32(cboPais.SelectedValue));
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
        //                    Codigo = Convert.ToString(row.Cells[3].Value);
        //                    Rpta = CtrlClientes.Eliminar(Codigo);

        //                    if (Rpta.Equals("OK"))
        //                    {
        //                        this.MensajeOk("Se Eliminó Correctamente el registro");
        //                        this.dataListado.Columns[0].Visible = false;
        //                        chkEliminar.Checked = false;

        //                    }
        //                    else
        //                    {
        //                        this.MensajeError(Rpta);
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
            FrmListarClientes lista = new FrmListarClientes();
            lista.ShowDialog();
        }
    }
}
