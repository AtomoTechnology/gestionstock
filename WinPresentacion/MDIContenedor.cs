using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinPresentacion
{
    public partial class MDIContenedor : Form
    {

        public string DNI;
        public string Cargo;
        private static MDIContenedor _instancia;

        public static MDIContenedor GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new MDIContenedor();
            }
            return _instancia;
        }
        public void setAlmacen(string IdAlmacen)
        {
            this.lblAlmacen.Text = IdAlmacen;

        }
        public void setCja(string IdCaja)
        {
            this.txtIdCaja.Text = IdCaja;

        }
        public MDIContenedor()
        {
            InitializeComponent();
        }

        private void MDIContenedor_Load(object sender, EventArgs e)
        {

            Boolean FormularioActivo = false;
            //Verificamos si el Formulario esta Activo (CARGADO)
            foreach (Form F in this.MdiChildren)
            {
                if (F.Text == "FrmConfiguracion")
                {
                    F.Activate();
                    FormularioActivo = true;

                    //FrmBoleto.Enabled = false;
                    break;
                }
            }
            //Si el Formulario no esta Activo los Activamos (Cargamos)
            if (!FormularioActivo)
            {

                Maestras.FrmConfiguracion Ventas = new Maestras.FrmConfiguracion();
                Ventas.MdiParent = this;
                Ventas.Show();
            }






            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            WindowState = FormWindowState.Maximized;
            Locationes();

            //Permisos
            if (lblCargo.Text.Trim() == "VENDEDOR")
            {
                btnVender.Enabled = true;
                btnVentas.Enabled = true;
                btnLstVentas.Enabled = true;
                btnRClientes.Enabled = true;
                btnReClientes.Enabled = true;
                btnConfiguracion.Enabled = true;
                //acceso denegado
                btnComprar.Enabled = false;
                btnRCompras.Enabled = false;
                btnLstCompras.Enabled = false;
                btnRePersonal.Enabled = false;
                btnReProductos.Enabled = false;
                btnRProductos.Enabled = false;
                btnRPersonal.Enabled = false;
                btnRMarcas.Enabled = false;
                btnBackup.Enabled = false;
                btnResaurarBD.Enabled = false;
                btnReProveedores.Enabled = false;
                btnRProveedor.Enabled = false;
                btnReProductos.Enabled = false;
                btnRCompras.Enabled = false;
                btnAddUsuario.Enabled = false;

            }
            if (lblCargo.Text.Trim() == "ALMACENERO")
            {
                btnReProveedores.Enabled = true;
                btnRProveedor.Enabled = true;
                btnReProductos.Enabled = true;
                btnRCompras.Enabled = true;
                btnComprar.Enabled = true;
                btnRCompras.Enabled = true;
                btnLstCompras.Enabled = true;

                //acceso denegado
                btnVender.Enabled = false;
                btnRVentas.Enabled = false;
                btnRCompras.Enabled = false;
                //btnVentas.Enabled = false;
                btnLstVentas.Enabled = false;
                btnRClientes.Enabled = false;
                btnReClientes.Enabled = false;
                btnConfiguracion.Enabled = true;
                btnRePersonal.Enabled = false;
                btnReProductos.Enabled = true;
                btnRProductos.Enabled = true;
                btnRPersonal.Enabled = false;
                btnRMarcas.Enabled = true;
                btnBackup.Enabled = false;
                btnResaurarBD.Enabled = false;
                btnAddUsuario.Enabled = false;

            }
        }

        public void Locationes()
        {
            pictureBox1.Location = new Point(0, 3);
            btnMantenimiento.Location = new Point(3, 132);
            panel8.Location = new Point(0, 132);
            btnVentas.Location = new Point(3, 232);
            panel4.Location = new Point(0, 232);
            btnCompras.Location = new Point(3, 182);
            panel3.Location = new Point(0, 182);
            btnReportes.Location = new Point(3, 282);
            panel7.Location = new Point(0, 282);
            btnSisema.Location = new Point(3, 333);
            panel22.Location = new Point(0, 333);


            subMenuMantenimiento.Location = new Point(41, 176);
            subMenuCompras.Location = new Point(41, 227);
            subMenuVentas.Location = new Point(41, 277);
            SubmenuReportes.Location = new Point(41, 327);
            subMenuSistema.Location = new Point(41, 277);

        }
        public void ActivarSubMeniManteniminto()
        {
            if (subMenuCompras.Visible == false && SubmenuReportes.Visible == false && subMenuVentas.Visible == false && subMenuSistema.Visible == false)
            {


                if (subMenuMantenimiento.Visible == false)
                {
                    subMenuMantenimiento.Visible = true;
                    btnMantenimiento.Location = new Point(3, 132);
                    panel8.Location = new Point(0, 132);
                    subMenuMantenimiento.Location = new Point(41, 176);

                    //compras
                    btnCompras.Location = new Point(3, 343);
                    panel3.Location = new Point(0, 343);
                    subMenuCompras.Location = new Point(41, 357);

                    //ventas
                    btnVentas.Location = new Point(3, 393);
                    panel4.Location = new Point(0, 393);
                    subMenuVentas.Location = new Point(41, 408);

                    //Reportes
                    btnReportes.Location = new Point(3, 443);
                    panel7.Location = new Point(0, 443);
                    SubmenuReportes.Location = new Point(41, 458);

                    //Sistema
                    btnSisema.Location = new Point(3, 494);
                    panel22.Location = new Point(0, 494);
                    subMenuSistema.Location = new Point(41, 509);
                }
                else if (subMenuMantenimiento.Visible == true)
                {
                    subMenuMantenimiento.Visible = false;
                    Locationes();
                }
            }



        }

        public void ActivarSubCompras()
        {
            if (subMenuMantenimiento.Visible == false && SubmenuReportes.Visible == false && subMenuVentas.Visible == false && subMenuSistema.Visible == false)
            {
                if (subMenuCompras.Visible == false)
                {

                    subMenuCompras.Visible = true;
                    //compras
                    btnCompras.Location = new Point(3, 182);
                    panel3.Location = new Point(0, 182);
                    subMenuCompras.Location = new Point(41, 227);

                    //Mantenimiento
                    btnMantenimiento.Location = new Point(3, 132);
                    panel8.Location = new Point(0, 132);
                    subMenuMantenimiento.Location = new Point(41, 176);



                    //ventas
                    btnVentas.Location = new Point(3, 298);
                    panel4.Location = new Point(0, 298);
                    subMenuVentas.Location = new Point(41, 344);

                    //Reportes
                    btnReportes.Location = new Point(3, 348);
                    panel7.Location = new Point(0, 348);
                    SubmenuReportes.Location = new Point(41, 392);

                    //Sistema
                    btnSisema.Location = new Point(3, 399);
                    panel22.Location = new Point(0, 399);
                    subMenuSistema.Location = new Point(41, 443);
                }
                else if (subMenuCompras.Visible == true)
                {

                    subMenuCompras.Visible = false;
                    Locationes();
                }
            }

        }

        public void ActivarSubVentas()
        {
            if (subMenuMantenimiento.Visible == false && SubmenuReportes.Visible == false && subMenuCompras.Visible == false && subMenuSistema.Visible == false)
            {
                if (subMenuVentas.Visible == false)
                {
                    subMenuVentas.Visible = true;
                    //ventas
                    btnVentas.Location = new Point(3, 232);
                    panel4.Location = new Point(0, 232);
                    subMenuVentas.Location = new Point(41, 278);

                    //compras
                    btnCompras.Location = new Point(3, 182);
                    panel3.Location = new Point(0, 182);
                    subMenuCompras.Location = new Point(41, 227);

                    //Mantenimiento
                    btnMantenimiento.Location = new Point(3, 132);
                    panel8.Location = new Point(0, 132);
                    subMenuMantenimiento.Location = new Point(41, 176);

                    //Reportes
                    btnReportes.Location = new Point(3, 348);
                    panel7.Location = new Point(0, 348);
                    SubmenuReportes.Location = new Point(41, 392);

                    //Sistema
                    btnSisema.Location = new Point(3, 399);
                    panel22.Location = new Point(0, 399);
                    subMenuSistema.Location = new Point(41, 443);

                }
                else if (subMenuVentas.Visible == true)
                {

                    subMenuVentas.Visible = false;
                    Locationes();
                }
            }

        }

        public void ActivarSubReportes()
        {
            if (subMenuMantenimiento.Visible == false && subMenuCompras.Visible == false && subMenuVentas.Visible == false && subMenuSistema.Visible == false)
            {
                if (SubmenuReportes.Visible == false)
                {

                    SubmenuReportes.Visible = true;
                    //Reportes
                    btnReportes.Location = new Point(3, 282);
                    panel7.Location = new Point(0, 282);
                    SubmenuReportes.Location = new Point(41, 332);

                    //compras
                    btnCompras.Location = new Point(3, 182);
                    panel3.Location = new Point(0, 182);
                    subMenuCompras.Location = new Point(41, 227);

                    //Mantenimiento
                    btnMantenimiento.Location = new Point(3, 132);
                    panel8.Location = new Point(0, 132);
                    subMenuMantenimiento.Location = new Point(41, 176);

                    //ventas
                    btnVentas.Location = new Point(3, 232);
                    panel4.Location = new Point(0, 232);
                    subMenuVentas.Location = new Point(41, 279);


                    //Sistema
                    btnSisema.Location = new Point(3, 534);
                    panel22.Location = new Point(0, 534);
                    subMenuSistema.Location = new Point(41, 548);
                }
                else if (SubmenuReportes.Visible == true)
                {

                    SubmenuReportes.Visible = false;
                    Locationes();
                }
            }

        }

        public void ActivarSubSistema()
        {
            if (subMenuMantenimiento.Visible == false && subMenuCompras.Visible == false && subMenuVentas.Visible == false && SubmenuReportes.Visible == false)
            {
                if (subMenuSistema.Visible == false)
                {

                    subMenuSistema.Visible = true;
                    //Reportes
                    btnReportes.Location = new Point(3, 282);
                    panel7.Location = new Point(0, 282);
                    SubmenuReportes.Location = new Point(41, 332);

                    //compras
                    btnCompras.Location = new Point(3, 182);
                    panel3.Location = new Point(0, 182);
                    subMenuCompras.Location = new Point(41, 227);

                    //Mantenimiento
                    btnMantenimiento.Location = new Point(3, 132);
                    panel8.Location = new Point(0, 132);
                    subMenuMantenimiento.Location = new Point(41, 176);

                    //ventas
                    btnVentas.Location = new Point(3, 232);
                    panel4.Location = new Point(0, 232);
                    subMenuVentas.Location = new Point(41, 279);


                    //Sistema
                    btnSisema.Location = new Point(3, 333);
                    panel22.Location = new Point(0, 333);
                    subMenuSistema.Location = new Point(41, 382);
                }
                else if (subMenuSistema.Visible == true)
                {

                    subMenuSistema.Visible = false;
                    Locationes();
                }
            }

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desea Salir", "◄ Sistema de Ventas ►", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            ActivarSubMeniManteniminto();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            ActivarSubCompras();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            ActivarSubVentas();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ActivarSubReportes();
        }

        private void btnSisema_Click(object sender, EventArgs e)
        {
            ActivarSubSistema();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string hora = DateTime.Now.ToLongTimeString();
            lblfechaHora.Text = DateTime.Now.ToShortDateString() + "  " + hora;
        }

        private void btnRPersonal_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmPersonal")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Maestras.FrmPersonal Ventas = Maestras.FrmPersonal.GetInstancia();
                    Ventas.MdiParent = this;
                    Ventas.Show();
                }
            }
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            Boolean FormularioActivo = false;
            //Verificamos si el Formulario esta Activo (CARGADO)
            foreach (Form F in this.MdiChildren)
            {
                if (F.Text == "FrmConfiguracion")
                {
                    F.Activate();
                    FormularioActivo = true;

                    //FrmBoleto.Enabled = false;
                    break;
                }
            }
            //Si el Formulario no esta Activo los Activamos (Cargamos)
            if (!FormularioActivo)
            {

                Maestras.FrmConfiguracion Ventas = new Maestras.FrmConfiguracion();
                Ventas.MdiParent = this;
                Ventas.Show();
            }
        }

        private void btnRClientes_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmClientes")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Maestras.FrmClientes Ventas = Maestras.FrmClientes.GetInstancia();
                    Ventas.MdiParent = this;
                    Ventas.Show();
                }
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmCompras")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Maestras.FrmCompras Ventas = Maestras.FrmCompras.GetInstancia();
                    Ventas.MdiParent = this;
                    Ventas.Show();
                    Ventas.Idtrabajador = DNI;
                    Ventas.IdAlmacen = Convert.ToInt32(lblAlmacen.Text);
                }
            }
        }

        private void btnRProductos_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmProductos")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Maestras.FrmProductos Ventas = Maestras.FrmProductos.GetInstancia();
                    Ventas.MdiParent = this;
                    Ventas.Show();
                    Ventas.IdAlmacen = Convert.ToInt32(lblAlmacen.Text);
                }
            }

        }

        private void btnRProveedor_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmProveedor")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Maestras.FrmProveedor Ventas = Maestras.FrmProveedor.GetInstancia();
                    Ventas.MdiParent = this;
                    Ventas.Show();
                }
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmVentas")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Maestras.FrmVentas Ventas = Maestras.FrmVentas.GetInstancia();
                    Ventas.MdiParent = this;
                    Ventas.Show();
                    Ventas.IdAlmacen = Convert.ToInt32(lblAlmacen.Text);
                    Ventas.Idtrabajador = DNI;
                }
            }
        }

        private void btnRMarcas_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmMarcas")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Maestras.FrmMarcas Ventas = Maestras.FrmMarcas.GetInstancia();
                    Ventas.MdiParent = this;
                    Ventas.Show();
                }
            }
        }

        private void btnLstVentas_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmVentasLst")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Listas.FrmVentasLst Ventas = new Listas.FrmVentasLst();
                    Ventas.MdiParent = this;
                    Ventas.IdAlmacen = Convert.ToInt32(lblAlmacen.Text);
                    Ventas.Show();

                }
            }
        }

        private void btnLstCompras_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmComprasLst")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Listas.FrmComprasLst Ventas = new Listas.FrmComprasLst();
                    Ventas.MdiParent = this;
                    Ventas.IdAlmacen = Convert.ToInt32(lblAlmacen.Text);
                    Ventas.Show();

                }
            }
        }

        private void btnRVentas_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmIngresos")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Listas.FrmIngresos Ventas = new Listas.FrmIngresos();
                    Ventas.MdiParent = this;
                    Ventas.IdAlmacen = Convert.ToInt32(lblAlmacen.Text);
                    Ventas.Show();

                }
            }
        }

        private void btnRCompras_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmEgresos")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Listas.FrmEgresos Ventas = new Listas.FrmEgresos();
                    Ventas.MdiParent = this;
                    Ventas.IdAlmacen = Convert.ToInt32(lblAlmacen.Text);
                    Ventas.Show();

                }
            }
        }

        private void btnReProductos_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmStockProductos")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Reportes.FrmStockProductos Ventas = new Reportes.FrmStockProductos();
                    Ventas.MdiParent = this;
                    Ventas.IdAlmacen = Convert.ToInt32(lblAlmacen.Text);
                    Ventas.Show();

                }
            }
        }

        private void btnReProveedores_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmListaProveedor")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Reportes.FrmListaProveedor Ventas = new Reportes.FrmListaProveedor();
                    Ventas.MdiParent = this;

                    Ventas.Show();

                }
            }
       }

        private void btnReClientes_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmListaClientes")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Reportes.FrmListaClientes Ventas = new Reportes.FrmListaClientes();
                    Ventas.MdiParent = this;

                    Ventas.Show();

                }
            }
        }

        private void btnRePersonal_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmListaPersonal")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Reportes.FrmListaPersonal Ventas = new Reportes.FrmListaPersonal();
                    Ventas.MdiParent = this;

                    Ventas.Show();

                }
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmBackup")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Maestras.FrmBackup Ventas = new Maestras.FrmBackup();
                    Ventas.MdiParent = this;
                    Ventas.Show();

                }
            }
       }

        private void btnResaurarBD_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmRestaurarBD")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Maestras.FrmRestaurarBD Ventas = new Maestras.FrmRestaurarBD();
                    Ventas.MdiParent = this;
                    Ventas.Show();

                }
            }
       }

        private void btnAddUsuario_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmAddusuario")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Maestras.FrmAddusuario Ventas = new Maestras.FrmAddusuario();
                    Ventas.MdiParent = this;
                    Ventas.Show();

                }
            }
        }

        private void btnCierredeCaja_Click(object sender, EventArgs e)
        {
            if (lblAlmacen.Text.Length <= 0)
            {
                MessageBox.Show("Elija Numero de Tienda en Sistema/Configuración", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Boolean FormularioActivo = false;
                //Verificamos si el Formulario esta Activo (CARGADO)
                foreach (Form F in this.MdiChildren)
                {
                    if (F.Text == "FrmCierreCaja")
                    {
                        F.Activate();
                        FormularioActivo = true;

                        //FrmBoleto.Enabled = false;
                        break;
                    }
                }
                //Si el Formulario no esta Activo los Activamos (Cargamos)
                if (!FormularioActivo)
                {

                    Maestras.FrmCierreCaja Ventas = Maestras.FrmCierreCaja.GetInstancia();
                    Ventas.MdiParent = this;
                    Ventas.Show();
                    Ventas.IdAlmacen = Convert.ToInt32(lblAlmacen.Text);                    
                    Ventas.DNIPersona = DNI;
                    Ventas.IdCaja = Convert.ToInt32(txtIdCaja.Text);
                }
            }
        }
    }
}
