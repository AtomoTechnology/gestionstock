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
    public partial class FrmVentas : Form
    {
        MDIContenedor mdi = new MDIContenedor();
        ClsSeries Series = new ClsSeries();
        CtrlTipoDocumento tipo = new CtrlTipoDocumento();
        CtrlVenta ventas = new CtrlVenta();
        Validar val = new Validar();
        public int IdVenta;
        public int IdAlmacen;

        public string Idtrabajador;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;
        private decimal subtotal = 0;

        private static FrmVentas _instancia;

        public static FrmVentas GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmVentas();
            }
            return _instancia;
        }
        public void setCliente(string DNI, string Cliente)
        {
            this.txtDNI.Text = DNI;
            this.txtCliente.Text = Cliente;

        }

        public void setArticulo(int IdProducto, string nombre,
            decimal precio_compra, decimal precio_venta, int stock, int Id_DetalleCompra)
        {
            this.txtIdarticulo.Text = Convert.ToString(IdProducto);
            this.txtArticulo.Text = nombre;
            this.txtPrecio_Compra.Text = Convert.ToString(precio_compra);
            this.txtPrecio_Venta.Text = Convert.ToString(precio_venta);
            this.txtStock.Text = Convert.ToString(stock);
            this.txtId_DetalleCompra.Text = Convert.ToString(Id_DetalleCompra);

        }
        public FrmVentas()
        {
            InitializeComponent();
            lblCantidadProduc.Text = Convert.ToString(dataListadoDetalle.Rows.Count.ToString());
            this.txtIdarticulo.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.txtArticulo.ReadOnly = true;
            this.txtDNI.ReadOnly = true;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
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
            this.txtDNI.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            //this.lblSerie.Text = string.Empty;
            //this.lblNumero.Text = string.Empty;
            this.txtIgv.Text = string.Empty;
            this.lblValorVenta.Text = "0,0";
            this.txtIgv.Text = "18";
            //lblsubtotal.Text = string.Empty;
            //lblIGV.Text = string.Empty;
            //lblCantidadProduc.Text = string.Empty;
            this.crearTabla();
        }
        private void limpiarDetalle()
        {
            this.txtIdarticulo.Text = string.Empty;
            this.txtArticulo.Text = string.Empty;
            this.txtStock.Text = string.Empty;
            this.txtCantidad.Text = string.Empty;
            this.txtPrecio_Compra.Text = string.Empty;
            this.txtPrecio_Venta.Text = string.Empty;
            this.txtDescuento.Text = "0";


        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            //this.txtIdingreso.ReadOnly = !valor;
            //this.lblSerie.Enabled = !valor;
            //this.lblNumero.Enabled = !valor;
            this.txtIgv.ReadOnly = !valor;
            this.lblHora.Enabled = valor;
            this.cbTipo_Comprobante.Enabled = valor;
            this.txtStock.ReadOnly = !valor;
            this.txtPrecio_Compra.ReadOnly = !valor;
            this.txtPrecio_Venta.ReadOnly = !valor;


            this.btnBuscarArticulo.Enabled = valor;
            this.btnBuscarCliente.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
        }

        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevaVenta.Enabled = false;
                this.btnAgregar.Enabled = true;
                this.btnQuitar.Enabled = true;
                this.btnGuardarVenta.Enabled = true;
                this.btnCancelarVenta.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevaVenta.Enabled = true;
                this.btnGuardarVenta.Enabled = false;
                this.btnCancelarVenta.Enabled = false;
                this.btnAgregar.Enabled = false;
                this.btnQuitar.Enabled = false;
            }

        }
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("ID", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("ARTÍCULO", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("CANTIDAD", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("P. UNITARIO", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("DESCUENTO", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("IMPORTE", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Id_DetalleCompra", System.Type.GetType("System.Int32"));
            //this.dtDetalle.Columns.Add("Impuesto", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;

        }
        private void FrmVentas_Load(object sender, EventArgs e)
        {
            this.Top = 40;
            this.Left = 40;
            this.Habilitar(false);
            this.Botones();

            lblHora.Text = DateTime.Now.ToShortDateString();
            this.crearTabla();
            this.dataListadoDetalle.Columns[0].Width = 60;
            this.dataListadoDetalle.Columns[1].Width = 305;
            this.dataListadoDetalle.Columns[2].Width = 130;
            this.dataListadoDetalle.Columns[3].Width = 140;
            this.dataListadoDetalle.Columns[4].Width = 135;
            this.dataListadoDetalle.Columns[5].Width = 140;
            this.dataListadoDetalle.Columns[6].Visible = false;
            cargardocumento();
        }
        private void cargardocumento()
        {
            cbTipo_Comprobante.DataSource = tipo.CargarParaVentas();
            cbTipo_Comprobante.DisplayMember = "NomDocumento";
            cbTipo_Comprobante.ValueMember = "IdTipoDoc";
        }
        private void GenerarSeriedeDocumento()
        {
            lblSerie.Text = Series.GenerarSerieDocumentoVenta(IdAlmacen);
        }
        private void GenerarNumeroComprobante()
        {
            if (Convert.ToBoolean(cbTipo_Comprobante.SelectedValue.ToString() == "3"))
            {
                lblNumero.Text = Series.NumeroComprobanteVenta("Boleta");
            }
            else if (Convert.ToBoolean(cbTipo_Comprobante.SelectedValue.ToString() == "4"))
            {
                lblNumero.Text = Series.NumeroComprobanteVenta("Factura");
            }
        }
        private void GenerarNumeroComprobanteAl2()
        {
            if (Convert.ToBoolean(cbTipo_Comprobante.SelectedValue.ToString() == "3"))
            {
                lblNumero.Text = Series.NumeroComprobanteVentaAl2("Boleta");
            }
            else if (Convert.ToBoolean(cbTipo_Comprobante.SelectedValue.ToString() == "4"))
            {
                lblNumero.Text = Series.NumeroComprobanteVentaAl2("Factura");
            }
        }
        private void FrmVentas_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbTipo_Comprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipo_Comprobante.SelectedValue.ToString() == "4" && IdAlmacen == 1)
            {
                GenerarNumeroComprobante();
                lbldocumento.Text = "FACTURA DE VENTA";
            }
            else if (cbTipo_Comprobante.SelectedValue.ToString() == "4" && IdAlmacen == 2)
            {
                GenerarNumeroComprobanteAl2();
                lbldocumento.Text = "FACTURA DE VENTA";
            }
            if (cbTipo_Comprobante.SelectedValue.ToString() == "3" && IdAlmacen == 1)
            {
                GenerarNumeroComprobante();
                lbldocumento.Text = "BOLETA DE VENTA";
            }
            else if (cbTipo_Comprobante.SelectedValue.ToString() == "3" && IdAlmacen == 2)
            {
                GenerarNumeroComprobanteAl2();
                lbldocumento.Text = "BOLETA DE VENTA";
            }
        }
        public void GeneraVenta()
        {
            try
            {
                string rpta = "";
                if (this.lblNumero.Text == string.Empty || this.lblSerie.Text == string.Empty
                    || this.txtDNI.Text == string.Empty || this.txtIgv.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtDNI, "Ingrese un Valor");
                    //errorIcono.SetError(txtSerie, "Ingrese un Valor");
                    //errorIcono.SetError(txtCorrelativo, "Ingrese un Valor");
                    errorIcono.SetError(txtIgv, "Ingrese un Valor");
                }
                else
                {

                    if (this.IsNuevo)
                    {
                        rpta = CtrlVenta.Insertar(lblSerie.Text, lblNumero.Text, Convert.ToInt32(cbTipo_Comprobante.SelectedValue), Idtrabajador, txtDNI.Text, Convert.ToDateTime(lblHora.Text), Convert.ToDecimal(txtIgv.Text), Convert.ToDecimal(lblValorVenta.Text), "EMITIDO", dtDetalle, IdAlmacen);

                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                            if (MessageBox.Show("Desea imprimir Boleta", "◄ AVISO | DecorMayo ►", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                            {
                                Imprimir();
                            }
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
        public void CancelaVenta()
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.limpiarDetalle();
        }
        public void NuevaVenta()
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtCliente.Focus();
            this.limpiarDetalle();
            if (IdAlmacen == 1)
            {
                GenerarNumeroComprobante();

                lblSerie.Text = "0001";
            }
            else if (IdAlmacen == 2)
            {
                GenerarNumeroComprobanteAl2();
                lblSerie.Text = "0002";
            }



        }
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
                        this.dataListadoDetalle.Columns[6].Visible = false;
                        decimal subTotal = Convert.ToDecimal(this.txtCantidad.Text) * Convert.ToDecimal(this.txtPrecio_Venta.Text);
                        totalPagado = totalPagado + subTotal;


                        decimal IGV = totalPagado * 18 / 100;
                        subtotal = totalPagado - IGV;
                        this.lblsubtotal.Text = subtotal.ToString("N2");
                        this.lblIGV.Text = IGV.ToString("N2");
                        lblCantidadProduc.Text = Convert.ToString(dtDetalle.Rows.Count.ToString());
                        lblValorVenta.Text = totalPagado.ToString("N2");
                        //Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["ID"] = Convert.ToInt32(this.txtIdarticulo.Text);
                        row["ARTÍCULO"] = this.txtArticulo.Text;
                        row["CANTIDAD"] = Convert.ToInt32(this.txtCantidad.Text);
                        row["P. UNITARIO"] = Convert.ToDecimal(this.txtPrecio_Venta.Text);
                        row["DESCUENTO"] = Convert.ToDecimal(txtDescuento.Text);
                        row["IMPORTE"] = subTotal;
                        row["Id_DetalleCompra"] = Convert.ToInt32(txtId_DetalleCompra.Text);

                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();

                        lblCantidadProduc.Text = Convert.ToString(dtDetalle.Rows.Count.ToString());

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
                //Disminuir el totalPAgado


                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["IMPORTE"].ToString());
                this.lblValorVenta.Text = totalPagado.ToString("N2");

                decimal IGV = totalPagado * 18 / 100;
                subtotal = totalPagado - IGV;
                this.lblsubtotal.Text = subtotal.ToString("N2");
                this.lblIGV.Text = IGV.ToString("N2");

                //Removemos la fila
                this.dtDetalle.Rows.Remove(row);
                //Bajamos la cantiad
                lblCantidadProduc.Text = Convert.ToString(dtDetalle.Rows.Count.ToString());
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int stock = Convert.ToInt32(txtStock.Text);
            int cantidad = Convert.ToInt32(txtCantidad.Text);
            if (stock >= cantidad)
                AgregaraGrila();
            else
                MessageBox.Show("No hay suficiente estock", "Decor Mayo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            NuevaVenta();
        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            GeneraVenta();
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            CancelaVenta();
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            QuitardeGrilla();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmVistaClienteVenta vista = new FrmVistaClienteVenta();
            vista.ShowDialog();
        }

        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            FrmVistaProductoVenta vista = new FrmVistaProductoVenta();
            vista.IdAlmacen = IdAlmacen;
            vista.ShowDialog();
        }
        public void GenerarIdParaImprmir()
        {
            DataTable dt = new DataTable();
            dt = CtrlVenta.GenrarIdVenta(IdAlmacen);
            IdVenta = Convert.ToInt32(dt.Rows[0][0].ToString());
        }
        private void Imprimir()
        {
            Reportes.FrmReporteBoletaFac repor = new Reportes.FrmReporteBoletaFac();
            DataTable dt = new DataTable();
            dt = CtrlVenta.GenrarIdVenta(IdAlmacen);
            IdVenta = Convert.ToInt32(dt.Rows[0][0].ToString());
            repor.Idventa = IdVenta;
            repor.ShowDialog();
        }

        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                txtCantidad.Focus();
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.SoloNumeros(e);
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {

                AgregaraGrila();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Imprimir();
        }
    }
}
