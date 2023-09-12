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
namespace WinPresentacion.Reportes
{
    public partial class FrmReporteBoletaFac : Form
    {
        private int _Idventa;

        public int Idventa
        {
            get { return _Idventa; }
            set { _Idventa = value; }
        }
        public FrmReporteBoletaFac()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void FrmReporteBoletaFac_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'Principal.spImprimirReporteVenta' Puede moverla o quitarla según sea necesario.
            this.spImprimirReporteVentaTableAdapter.Fill(this.Principal.spImprimirReporteVenta, Idventa);

            this.reportViewer1.RefreshReport();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
