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
    public partial class FrmCompras : Form
    {
        Validar val = new Validar();
        CtrlTipoDocumento tipo = new CtrlTipoDocumento();
        public string Idtrabajador;
        public int IdAlmacen;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;

        private decimal subtotal = 0;

        private static FrmCompras _instancia;

        public static FrmCompras GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmCompras();
            }
            return _instancia;
        }
        public void setProveedor(string RUC, string RazonSocial)
        {
            this.txtRUC.Text = RUC;
            this.txtProveedor.Text = RazonSocial;
            //this.lblNroRuc.Text = RUC;

        }

        public void setArticulo(int idarticulo, string nombre)
        {
            this.txtIdarticulo.Text = Convert.ToString(idarticulo);
            this.txtArticulo.Text = nombre;
            //this.lblAlmacen.Text = Id_Almacen;
        }
        public FrmCompras()
        {
            InitializeComponent();

            lblFecha.Text = DateTime.Now.ToShortDateString(); lblCantidadProduc.Text = Convert.ToString(dataListadoDetalle.Rows.Count.ToString());
            this.txtIdarticulo.Visible = false;
            this.txtProveedor.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
        }
        private void cargardocumento()
        {
            cbTipo_Comprobante.DataSource = tipo.CargarParaVentas();
            cbTipo_Comprobante.DisplayMember = "NomDocumento";
            cbTipo_Comprobante.ValueMember = "IdTipoDoc";
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
            //this.txtIdingreso.Text = string.Empty;
            this.txtRUC.Text = string.Empty;
            this.txtProveedor.Text = string.Empty;
            //this.lblSerie.Text = string.Empty;
            //this.lblNumero.Text = string.Empty;
            this.txtIgv.Text = string.Empty;
            this.lblValorVenta.Text = "0,0";
            this.txtIgv.Text = "18";
            this.crearTabla();
        }
        private void limpiarDetalle()
        {
            this.txtIdarticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtPrecio_Compra.Text = string.Empty;
            this.txtPrecio_Venta.Text = string.Empty;

        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            //this.txtIdingreso.ReadOnly = !valor;
            //this.lblSerie.Enabled = !valor;
            //this.lblNumero.Enabled = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.lblFecha.Enabled = valor;
            this.cbTipo_Comprobante.Enabled = valor;
            this.txtStock.ReadOnly = !valor;
            this.txtPrecio_Compra.ReadOnly = !valor;
            this.txtPrecio_Venta.ReadOnly = !valor;


            this.btnBuscarArticulo.Enabled = valor;
            this.btnBuscarProveedor.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevaCompra.Enabled = false;
                this.btnNuevaCompra.Enabled = false;
                this.btnGuardarCompra.Enabled = true;
                this.btnCancelarCompra.Enabled = true;
                btnAgregar.Enabled = true;
                btnQuitar.Enabled = true;
                btnBuscarProveedor.Enabled = true;
                btnBuscarArticulo.Enabled = true;
            }
            else
            {
                this.Habilitar(false);

                this.btnNuevaCompra.Enabled = true;
                this.btnGuardarCompra.Enabled = false;
                this.btnCancelarCompra.Enabled = false;
                this.btnAgregar.Enabled = false;
                btnQuitar.Enabled = false;
                btnBuscarProveedor.Enabled = false;
                btnBuscarArticulo.Enabled = false;
            }

        }
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("ID", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("ARTÍCULO", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("P. COMPRA", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("P. VENTA", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("CANTIDAD", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("SUBTOTAL", System.Type.GetType("System.Decimal"));
            //this.dtDetalle.Columns.Add("Impuesto", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;

        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {
            this.Top = 40;
            this.Left = 40;
            cargardocumento();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
            this.dataListadoDetalle.Columns[0].Width = 60;
            this.dataListadoDetalle.Columns[1].Width = 320;
            this.dataListadoDetalle.Columns[2].Width = 127;
            this.dataListadoDetalle.Columns[3].Width = 125;
            this.dataListadoDetalle.Columns[4].Width = 135;
            this.dataListadoDetalle.Columns[5].Width = 140;

            //this.dataListadoDetalle.Columns[8].Width = 98;
            this.dataListadoDetalle.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void FrmCompras_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void FrmCompras_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        public void GeneraCompra()
        {
            try
            {
                string rpta = "";
                if (this.lblNumero.Text == string.Empty || this.lblSerie.Text == string.Empty
                    || this.txtRUC.Text == string.Empty || this.txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtRUC, "Ingrese un Valor");
                    //errorIcono.SetError(txtSerie, "Ingrese un Valor");
                    //errorIcono.SetError(txtCorrelativo, "Ingrese un Valor");
                    errorIcono.SetError(txtIgv, "Ingrese un Valor");
                }
                else
                {

                    if (this.IsNuevo)
                    {
                        rpta = CtrlCompras.Insertar(lblNumero.Text, lblSerie.Text, Convert.ToInt32(cbTipo_Comprobante.SelectedValue), Convert.ToDateTime(lblFecha.Text), Convert.ToDecimal(txtIgv.Text), Idtrabajador, txtRUC.Text, Convert.ToDecimal(lblValorVenta.Text), "EMITIDO", dtDetalle, IdAlmacen);

                    }


                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Compra realiza con éxito");
                            lblSerie.Text = string.Empty;
                            lblNumero.Text = string.Empty;
                            lblsubtotal.Text = "0";
                            lblCantidadProduc.Text = "0";
                            lblIGV.Text = "0";
                            lblValorVenta.Text = "0.0";
                        }


                    }
                    else
                    {
                        this.MensajeError(rpta);
                        lblsubtotal.Text = "0";
                        lblCantidadProduc.Text = "0";
                        lblIGV.Text = "0";
                        lblValorVenta.Text = "0.0";
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiarDetalle();




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        public void CancelaCompra()
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.limpiarDetalle();
        }
        public void NuevaCompra()
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtProveedor.Focus();
            this.limpiarDetalle();
        }
        //public void AnularCompra()
        //{
        //    try
        //    {
        //        DialogResult Opcion;
        //        Opcion = MessageBox.Show("Realmente Desea Anular los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

        //        if (Opcion == DialogResult.OK)
        //        {
        //            string Codigo;
        //            string Rpta = "";

        //            foreach (DataGridViewRow row in dataListado.Rows)
        //            {
        //                if (Convert.ToBoolean(row.Cells[0].Value))
        //                {
        //                    Codigo = Convert.ToString(row.Cells[1].Value);
        //                    Rpta = CtrlCompra.Anular(Codigo);

        //                    if (Rpta.Equals("OK"))
        //                    {
        //                        this.MensajeOk("Se Anuló Correctamente el Ingreso");
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
        public void AgregaraGrila()
        {
            try
            {

                if (this.txtIdarticulo.Text == string.Empty || this.txtStock.Text == string.Empty
                    || this.txtPrecio_Compra.Text == string.Empty || this.txtPrecio_Venta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtIdarticulo, "Ingrese un Valor");
                    errorIcono.SetError(txtStock, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio_Compra, "Ingrese un Valor");
                    errorIcono.SetError(txtPrecio_Venta, "Ingrese un Valor");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["id"]) == Convert.ToInt32(this.txtIdarticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el artículo en el detalle");
                        }
                    }
                    if (registrar)
                    {
                        decimal subTotal = Convert.ToDecimal(this.txtStock.Text) * Convert.ToDecimal(this.txtPrecio_Compra.Text);
                        totalPagado = totalPagado + subTotal;


                        decimal IGV = totalPagado * 18 / 100;
                        subtotal = totalPagado - IGV;
                        this.lblsubtotal.Text = subtotal.ToString("N2");
                        this.lblIGV.Text = IGV.ToString("N2");

                        lblValorVenta.Text = totalPagado.ToString("N2");
                        //Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["ID"] = Convert.ToInt32(this.txtIdarticulo.Text);
                        row["ARTÍCULO"] = this.txtArticulo.Text;
                        row["CANTIDAD"] = Convert.ToInt32(this.txtStock.Text);
                        row["P. COMPRA"] = Convert.ToDecimal(this.txtPrecio_Compra.Text);
                        row["P. VENTA"] = Convert.ToDecimal(this.txtPrecio_Venta.Text);
                        row["SUBTOTAL"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        lblCantidadProduc.Text = Convert.ToString(dtDetalle.Rows.Count.ToString());
                        this.limpiarDetalle();

                    }




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        public void QuitardeGrilla()
        {

            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //Disminuir el total PAgado
                //decimal IGV = totalPagado * 18 / 100;
                this.totalPagado = this.totalPagado  - Convert.ToDecimal(row["subtotal"].ToString());

                decimal IGV = totalPagado * 18 / 100;
                this.lblsubtotal.Text = totalPagado.ToString("N2");

                this.lblIGV.Text = IGV.ToString("N2");
                lblValorVenta.Text = totalPagado.ToString("N2");

                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
                lblCantidadProduc.Text = Convert.ToString(dtDetalle.Rows.Count.ToString());
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            NuevaCompra();
        }

        private void btnGuardarCompra_Click(object sender, EventArgs e)
        {
            GeneraCompra();
        }

        private void btnCancelarCompra_Click(object sender, EventArgs e)
        {
            CancelaCompra();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregaraGrila();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            QuitardeGrilla();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FrmVistaProductoCompra vista = new FrmVistaProductoCompra();
            vista.IdAlmacen = IdAlmacen;
            vista.ShowDialog();
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                AgregaraGrila();
            }
        }

        private void txtPrecio_Venta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtStock.Focus();
            }
        }

        private void txtPrecio_Compra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                txtPrecio_Venta.Focus();
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            FrmVistaProveedorCompra lista = new FrmVistaProveedorCompra();
            lista.ShowDialog();
        }
    }
}
