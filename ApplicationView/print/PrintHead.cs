using ApplicationView.Resolver.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.print
{
    public static class PrintHead
    {
        public static void Head(string busnessname, string address, string cuit, string bruto, string startactivity, string user, string nrofact,string title = "TICKET DE VENTA DE PRODUCTO")
        {
            CrearTicket ticket = new CrearTicket();
            ticket.TextoCentro(title);
            ticket.TextoIzquierda(" ");
            ticket.TextoIzquierda(busnessname);
            ticket.TextoIzquierda(address);
            ticket.TextoIzquierda("C.U.I.T : " + cuit);
            ticket.TextoIzquierda("Ing. Brutos : " + bruto);
            ticket.TextoIzquierda("Ini. actividades : " + startactivity.ToString());
            ticket.TextoIzquierda("Nro. Factura :" + nrofact);
            ticket.TextoIzquierda("Vendedor : " + user);
            ticket.lineasIgual();
            ticket.ImprimirTicket(StringgConnection.GetPrint());
        }
    }
}
