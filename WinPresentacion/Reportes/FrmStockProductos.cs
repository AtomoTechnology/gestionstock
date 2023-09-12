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

namespace WinPresentacion.Reportes
{
    public partial class FrmStockProductos : Form
    {
        CtrlProductos CtrlProductos = new CtrlProductos();
        CtrlMarca CtrlMarca = new CtrlMarca();
        public int IdAlmacen;
        public FrmStockProductos()
        {
            InitializeComponent();
        }
        private void cargarMarca()
        {
            cboMarca.DataSource = CtrlMarca.Mostrar();
            cboMarca.DisplayMember = "NomMarca";
            cboMarca.ValueMember = "IdMarca";
        }
        public static AutoCompleteStringCollection Autocomplete()
        {
            CtrlMarca cy = new CtrlMarca();
            DataTable dt = cy.Mostrar();

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //recorrer y cargar los items para el autocompletado
            foreach (DataRow row in dt.Rows)
            {
                coleccion.Add(Convert.ToString(row["NomMarca"]));
            }

            return coleccion;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void OcultarColumnas()
        {
            //this.dataListado.Columns[0].Visible = false;
            //this.dataListado.Columns[1].Visible = false;
            //this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[3].Visible = false;
        }


        //Método BuscarNombre
        private void MostrarStockCompleto()
        {
            this.dataListado.DataSource = CtrlProductos.StockCompleto(IdAlmacen);
            this.OcultarColumnas();
            lblCantidad.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            //StockMax = Convert.ToInt32(dataListado.Rows[0].Cells[""].Value);
        }

        private void MostrarStockPornNombre()
        {
            this.dataListado.DataSource = CtrlProductos.StockNombreProducto(IdAlmacen, txtProducto.Text);
            this.OcultarColumnas();
            lblCantidad.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            //StockMax = Convert.ToInt32(dataListado.Rows[0].Cells[""].Value);
        }
        private void MostrarStockPorMarca()
        {


            this.dataListado.DataSource = CtrlProductos.StockMarcaProducto(IdAlmacen, Convert.ToInt32(cboMarca.SelectedValue));
            this.OcultarColumnas();
            lblCantidad.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            //StockMax = Convert.ToInt32(dataListado.Rows[0].Cells[""].Value);
        }
        private void MostrarStockPorCodigo()
        {
            this.dataListado.DataSource = CtrlProductos.StockCodigo(IdAlmacen, txtCodigo.Text);
            this.OcultarColumnas();
            lblCantidad.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
            this.dataListado.Columns.Cast<DataGridViewColumn>().ToList().ForEach(c => c.HeaderText = c.HeaderText.ToUpper());
            anchogrid();
            //StockMax = Convert.ToInt32(dataListado.Rows[0].Cells[""].Value);
        }
        public void anchogrid()
        {
            this.dataListado.Columns[0].Width = 80;
            this.dataListado.Columns[1].Width = 200;
            this.dataListado.Columns[2].Width = 120;
            //this.dataListado.Columns[3].Width = 150;
            this.dataListado.Columns[4].Width = 180;
            this.dataListado.Columns[5].Width = 140;
            this.dataListado.Columns[6].Width = 150;
            //this.dataListado.Columns[7].Width = 140;
        }
        private void FrmStockProductos_Load(object sender, EventArgs e)
        {
            this.Top = 40;
            this.Left = 40;
            cargarMarca();
            cboMarca.AutoCompleteCustomSource = Autocomplete();
            cboMarca.AutoCompleteMode = AutoCompleteMode.Suggest;
            cboMarca.AutoCompleteSource = AutoCompleteSource.CustomSource;
            MostrarStockCompleto();
        }

        private void FrmStockProductos_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            MostrarStockPornNombre();
        }

        private void dataListado_Click(object sender, EventArgs e)
        {
            int stock;
            stock = Convert.ToInt32(this.dataListado.CurrentRow.Cells["stock"].Value);
            if (stock <= 10 && stock > 0)
            {
                lblSituacion.Visible = true;
                lblSituacion.Text = "Su producto está por agotarse";
            }
            else if (stock == 0)
            {
                lblSituacion.Visible = true;
                lblSituacion.Text = "Su producto está agotado";
            }
            else
            {
                lblSituacion.Visible = false;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                MostrarStockPorCodigo();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MostrarStockPorMarca();
        }

        private void dataListado_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex].Name == "stock")  //Si es la columna a evaluar
            {
                int estado = Convert.ToInt32(e.Value);

                if (estado <= 10)

                {
                    e.CellStyle.ForeColor = Color.Red;
                    e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
                }
                else if (estado >= 10 && estado <= 20)

                {
                    e.CellStyle.ForeColor = Color.Orange;
                    e.CellStyle.Font = new System.Drawing.Font(e.CellStyle.Font, FontStyle.Bold);
                }
            }
        }
        private void Exportar()
        {
            try
            {
                if (dataListado.DataSource != null)
                {
                    SaveFileDialog fichero = new SaveFileDialog();
                    fichero.Filter = "Excel (*.xls)|*.xls";
                    if (fichero.ShowDialog() == DialogResult.OK)
                    {
                        Microsoft.Office.Interop.Excel.Application aplicacion;
                        Microsoft.Office.Interop.Excel.Workbook libros_trabajo;
                        Microsoft.Office.Interop.Excel.Worksheet hoja_trabajo;
                        aplicacion = new Microsoft.Office.Interop.Excel.Application();
                        libros_trabajo = aplicacion.Workbooks.Add();
                        hoja_trabajo = (Microsoft.Office.Interop.Excel.Worksheet)libros_trabajo.Worksheets.get_Item(1);

                        //exportar cabeceras dgvLog
                        for (int i = 1; i <= this.dataListado.Columns.Count; i++)
                        {
                            hoja_trabajo.Cells[1, i] = this.dataListado.Columns[i - 1].HeaderText;
                        }

                        //Recorremos el DataGridView rellenando la hoja de trabajo con los datos
                        for (int i = 0; i < this.dataListado.Rows.Count - 1; i++)
                        {
                            for (int j = 0; j < this.dataListado.Columns.Count; j++)
                            {
                                hoja_trabajo.Cells[i + 2, j + 1] = this.dataListado.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        libros_trabajo.SaveAs(fichero.FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal);

                        libros_trabajo.Close(true);
                        aplicacion.Quit();
                        MessageBox.Show("Datos exportados correctamnete", "Sistemas de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("NO hay regostros para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataListado.Rows.Count > 0)
            {
                Exportar();
            }
            else
                MessageBox.Show("No hay Datos Para exportar");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmReporteProductos re = new FrmReporteProductos();
            re.ShowDialog();
        }
    }
}
