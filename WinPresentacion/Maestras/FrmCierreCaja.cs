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
    public partial class FrmCierreCaja : Form
    {
        public int IdAlmacen;
        public string DNIPersona;
        public int IdCaja;
        CtrlCajas CtrlCajas = new CtrlCajas();
        private static FrmCierreCaja _instancia;

        public static FrmCierreCaja GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new FrmCierreCaja();
            }
            return _instancia;
        }
        public FrmCierreCaja()
        {
            InitializeComponent();
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void FrmCierreCaja_Load(object sender, EventArgs e)
        {
            Top = 40;
            Left = 40;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            txthora.Text = DateTime.Now.ToLongTimeString();
            txtfecha.Text = DateTime.Now.ToShortDateString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            DataTable datos = new DataTable();
            datos = CtrlCajas.CalcularMonto(IdAlmacen,Convert.ToDateTime(txtfecha.Text), DNIPersona);
            if(datos.Rows.Count> 0)
            {
                txtMonto.Text = datos.Rows[0][1].ToString();
            }
            else
            {
                MessageBox.Show("No a realizado ventas hoy", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCierreCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void FrmCierreCaja_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        public void Guardar()
        {
            try
            {
                string rpta = "";
                if (this.txtMonto.Text == string.Empty || this.txtfecha.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtMonto, "Ingrese un Valor");
                    errorIcono.SetError(txtfecha, "Ingrese un Valor");
                    errorIcono.SetError(txthora, "Ingrese un Valor");

                }
                else
                {
                    

                       
                        rpta = CtrlCajas.Insertar(DNIPersona,IdCaja,IdAlmacen,Convert.ToDateTime(txtfecha.Text),Convert.ToDateTime(txthora.Text),Convert.ToDecimal(txtMonto.Text));

                        if (rpta.Equals("OK"))
                        {

                            this.MensajeOk("Informacón guardada correctamente");
                           
                            txtMonto.Text = string.Empty;
                            
                           

                        }
                        else
                        {
                            this.MensajeError(rpta);

                            txtMonto.Text = string.Empty;
                            
                        }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Esta seguro de Guardar la información","Sistema de Ventas",MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)==DialogResult.Yes)
            {
                Guardar();
            }
        }
    }
}
