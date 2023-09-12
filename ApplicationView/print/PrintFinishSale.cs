using ApplicationView.Resolver.Security;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationView.print
{
    public static class PrintFinishSale
    {
        private static PictureBox imgbox = new PictureBox();
        public static void Finish(decimal total, string mode, int productquantity)
        {
            CrearTicket ticket = new CrearTicket();
            GenerateQR();
            ticket.lineasIgual();
            ticket.lineasIgual();
            ticket.TextoIzquierda("Cant producto :" + productquantity.ToString());
            ticket.TextoIzquierda("Mod pago :"+ mode);
            ticket.AgregarTotales("TOTAL : $ ", total);
            ticket.lineasIgual();
            ticket.lineasIgual();
            ticket.CortaTicket();
            ticket.CortaTicket();
            ticket.CortaTicket();
            //ticket.HeaderImage = Image.FromFile(@"C:\GestionStock\ApplicationView\bin\x86\Debug\net6.0-windows\imagen.png");
            //ticket.HeaderImage =imgbox.Image;
            ticket.ImprimirTicket(StringgConnection.GetPrint());
        }

        private static void GenerateQR()
        {
            QrEncoder qrEncoder = new QrEncoder();
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode("www.atomothecnology.com", out qrCode);

            GraphicsRenderer render = new GraphicsRenderer(new FixedCodeSize(400,QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();
            render.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);

            var imageTemporal = new Bitmap(ms);
            var imagen = new Bitmap(imageTemporal,new Size(200,200));
            imgbox.BackgroundImage = imagen;
            imagen.Save("imagen.png", ImageFormat.Png);;
        }
    }
}
