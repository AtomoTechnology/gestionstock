using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Datos;
namespace WinPresentacion.Maestras
{
    public partial class FrmBackup : Form
    {
        public FrmBackup()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection(ConexionBD.Cn);

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que realizar backup", "◄ Sistema de Ventas ►", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                string nombre_copia = (System.DateTime.Today.Day.ToString() + "-" + System.DateTime.Today.Month.ToString() + "-" + System.DateTime.Today.Year.ToString() + "-" + System.DateTime.Now.Hour.ToString() + "-" + System.DateTime.Now.Minute.ToString() + "-" + System.DateTime.Now.Second.ToString() + " BD-BDSistemaventas" + ".bak");

                string comando_consulta = "BACKUP DATABASE [BDSistemaVentas] TO  DISK = N'G:\\Bakup\\" + nombre_copia + "' WITH NOFORMAT, NOINIT,  NAME = N'BDSistemaVentas-Completa Base de datos Copia de seguridad', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

                SqlCommand cmd = new SqlCommand(comando_consulta, conexion);

                try
                {
                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("La Copia se ha creado Satisfactoriamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Si desea realizar otra copia de seguridad, porfavor cierre el formulario e intentalo de nuevo");
                }
                finally
                {
                    conexion.Close();
                    conexion.Dispose();
                }
            }
        }

        private void FrmBackup_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBackup_Load(object sender, EventArgs e)
        {
            this.Top = 40;
            this.Left = 40;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
    }
}
