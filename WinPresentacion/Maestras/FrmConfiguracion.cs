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
    public partial class FrmConfiguracion : Form
    {
        CtrlAlmacen CtrlAlmacen = new CtrlAlmacen();
        CtrlCajas CtrlCajas = new CtrlCajas();
        public FrmConfiguracion()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void FrmConfiguracion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            this.Top = 40;
            this.Left = 40;
            cboAlmacen.DataSource = CtrlAlmacen.CargarAlmacen();
            cboAlmacen.DisplayMember = "NomAlmacen";
            cboAlmacen.ValueMember = "IdAlmacen";

            if (cboAlmacen.SelectedValue != null)
            {
                string idalmacen = cboAlmacen.SelectedValue.ToString();
                cboCaja.DataSource = CtrlCajas.CargarCaja(idalmacen);
                cboCaja.DisplayMember = "NomCaja";
                cboCaja.ValueMember = "IdCaja";
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro de guardar los cambios?", "◄ Sistema de Ventas ►", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                if (cboCaja.SelectedValue!=null)
                {
                    string Almacen, idcaja;
                    MDIContenedor MDI = MDIContenedor.GetInstancia();
                    Almacen = cboAlmacen.SelectedValue.ToString();
                    idcaja = cboCaja.SelectedValue.ToString();
                    MDI.setAlmacen(Almacen);
                    MDI.setCja(idcaja);
                    MDI.btnConfiguracion.Enabled = false;

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Seleccione Caja", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                
            }

            //MessageBox.Show("almacen: " + cboAlmacen.Text);

        }

        private void cboAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboAlmacen.SelectedValue != null)
            {
                string idalmacen = cboAlmacen.SelectedValue.ToString();
                cboCaja.DataSource = CtrlCajas.CargarCaja(idalmacen);
                cboCaja.DisplayMember = "NomCaja";
                cboCaja.ValueMember = "IdCaja";
            }
           
        }
    }
}
