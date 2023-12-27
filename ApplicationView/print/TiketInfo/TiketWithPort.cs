using ApplicationView.BusnessEntities.Dtos;
using ApplicationView.print.DLL;
using ApplicationView.Resolver.Security;
using BarControls;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationView.print.TiketInfo
{
    public class TiketWithPort
    {
        private static TiketWithPort _factory;

        public static TiketWithPort GetInstance()
        {
            if (_factory == null)
                _factory = new TiketWithPort();
            return _factory;
        }

       

        public void print(string busnessname, string address, string cuit, string bruto, string startactivity, string user, string nrofact, List<SaleDetailDto> sldto, string title = "TICKET DE COMPRA")
        {
            //ticket.HeaderImage = "homero.jpg"; //esta propiedad no es obligatoria
            TicketWithOutDLL ticket = new TicketWithOutDLL();
            ticket.AddHeaderLine(title);
            ticket.AddHeaderLine(busnessname);
            ticket.AddHeaderLine(address);
            ticket.AddHeaderLine("C.U.I.T : " + cuit);
            ticket.AddHeaderLine("Ing. B. : " + bruto);
            ticket.AddHeaderLine("Ini. activ.  : " + startactivity.ToString());
            ticket.AddHeaderLine("Nro. Tikect. :" + nrofact);
            SaleDetailDto resp;
            if (sldto.Count > 0)
            {
                resp = sldto[0];
            }
            else
            {
                resp = new SaleDetailDto()
                {
                    CreatedDate = DateTime.Now
                };
            }
            ticket.AddHeaderLine("Fecha Venta : " + resp.CreatedDate.ToShortDateString());
            ticket.AddHeaderLine("Hora Venta  : " + resp.CreatedDate.ToShortTimeString());
            ticket.AddHeaderLine("Cajero : " + user);
            ticket.AddHeaderLine("                                         ");

            //El metodo AddItem requeire 3 parametros, el primero es cantidad, el segundo es la descripcion
            //del producto y el tercero es el precio
            decimal total = 0;
            string mode = "";
            int productquantity = 0;
            if (sldto.Count > 0)
            {
                foreach (SaleDetailDto item in sldto)
                {
                    total += item.Subtotal;
                    productquantity += item.quantity;
                    mode = item.PaymentName;
                    string newline = string.Empty;
                    if (item.ProductName.Length > 14)
                    {
                        newline = item.ProductName.Substring(0, 12) + "..";
                    }                        
                    else
                    {
                        string caracter = AlignRightText(Math.Abs(item.ProductName.Length - 14));
                        newline = item.ProductName + caracter;
                    }
                    ticket.AddHeaderLine((item.SalePrice + " x " + item.quantity).ToString());
                    ticket.AddHeaderLine(newline + " : " + (item.SalePrice * item.quantity));
                    ticket.AddHeaderLine("                                         ");

                }
            }
            #region Total
            ticket.AddHeaderLine("                                         ");
            ticket.AddHeaderLine("Cant producto :"+ productquantity.ToString());
            ticket.AddHeaderLine("Mod pago :"+ mode);
            ticket.AddHeaderLine("TOTAL : $ "+ total.ToString());
            ticket.AddHeaderLine("                                         ");
            #endregion


            //El metodo AddFooterLine funciona igual que la cabecera
            ticket.AddHeaderLine("Servirte ES NUESTRA p.....");
            ticket.AddHeaderLine("VIVE LA EXPERIENCIA CON ");
            ticket.AddHeaderLine(busnessname);
            ticket.AddHeaderLine("GRACIAS POR TU COMPRA");
            ticket.AddHeaderLine("                                         ");
            ticket.AddSubHeaderLine("           ");
            ticket.AddSubHeaderLine("           ");
            //Y por ultimo llamamos al metodo PrintTicket para imprimir el ticket, este metodo necesita un
            //parametro de tipo string que debe de ser el no
            ticket.PrintTicket(StringgConnection.GetPrint());
        }

        private string AlignRightText(int lenght)
        {
            string text = "";
            for (int i = 0; i < lenght; i++)
            {
                text += " ";
            }

            return text;
        }
    }
}
