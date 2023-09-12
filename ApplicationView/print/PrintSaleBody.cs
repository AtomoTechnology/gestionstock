using ApplicationView.Resolver.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.print
{
    public static class PrintSaleBody
    {
        public static void Body(string productname, decimal price)
        {
            CrearTicket ticket = new CrearTicket();
            ticket.AgregaArticulo(productname, price);
            ticket.ImprimirTicket(StringgConnection.GetPrint());
        }
    }
}
