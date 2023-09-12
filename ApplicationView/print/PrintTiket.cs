using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationView.print
{
    public static class PrintTiket
    {
        public static async Task PrintAsync()
        {
            try
            {
                CrearTicket ticket = new CrearTicket();
                //ticket.HeaderImage = Image.FromFile(@"Resources\agregar.png");

                //ticket.TextoIzquierda(" ");
                ticket.TextoCentro("TICKET DE VENTA DE PRODUCTO");
                ticket.TextoIzquierda(" ");
                ticket.TextoExtremos("FECHA : " + DateTime.Now.ToString(), "HORA : " + DateTime.Now.Hour.ToString());
                ticket.TextoIzquierda(" ");
                ticket.EncabezadoVenta();
                ticket.lineasGuio();
                //foreach (DataGridViewRow fila in Rows)
                //{
                //    string val = fila.Cells[1].Value.ToString();
                //    int val1 = 14;
                //    decimal val2 = 12;

                    ticket.AgregaArticulo("val", 123);
                //}
                ticket.lineasIgual();
                ticket.AgregarTotales("          TOTAL COMPRADO : $ ", decimal.Parse("234"));
                ticket.AgregarTotales("          TOTAL VENDIDO  : $ ", decimal.Parse("34"));
                ticket.TextoIzquierda(" ");
                ticket.AgregarTotales("          GANANCIA       : $ ", decimal.Parse("452"));
                ticket.TextoIzquierda(" ");
                ticket.TextoIzquierda(" ");
                ticket.TextoIzquierda(" ");
                ticket.TextoIzquierda(" ");
                ticket.TextoIzquierda(" ");
                ticket.TextoIzquierda(" ");
                ticket.CortaTicket();
                ticket.ImprimirTicket("XP-58C");
            }
            catch (Exception eeee) { }
        }
    }
}
