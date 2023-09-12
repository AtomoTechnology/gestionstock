using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class FrmRestaurarBD : Form
    {
        public FrmRestaurarBD()
        {
            InitializeComponent();
        }
        SqlConnection conexion = new SqlConnection(ConexionBD.Cn);
        private void FrmRestaurarBD_Load(object sender, EventArgs e)
        {
            this.Top = 40;
            this.Left = 40;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void FrmRestaurarBD_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog(); ofd.Filter = "SQL SERVER database backup files|*.bak"; ofd.Title = "Database Restore"; if (ofd.ShowDialog() == DialogResult.OK) { txtRuta.Text = ofd.FileName; btnRestaurar.Enabled = true; }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            string database = conexion.Database.ToString();
            if (conexion.State != ConnectionState.Open)
            {
                conexion.Open();
            }

            try
            {
                string sql1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(sql1, conexion);
                cmd1.ExecuteNonQuery();
                string sql2 = string.Format("USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + txtRuta.Text + "' WITH REPLACE;"); SqlCommand cmd2 = new SqlCommand(sql2, conexion);
                cmd2.ExecuteNonQuery(); string sql3 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                SqlCommand cmd3 = new SqlCommand(sql3, conexion);
                cmd3.ExecuteNonQuery(); // s.Speak("Database Restored successfully"); 
                MessageBox.Show("Base de datos restaurada correctamente", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRestaurar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }

        }
    }
}
