using ApplicationView.BusnessEntities.Dtos;
using ApplicationView.Resolver.Security;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationView.print
{
    public class Ticketprobar
    {
        private static Ticketprobar _factory;

        public static Ticketprobar GetInstance()
        {
            if (_factory == null)
                _factory = new Ticketprobar();
            return _factory;
        }

        //Variables globales
        PrintDocument pdoc;

        #region Propiedades
        private string _busnessname { get; set; }
        private string _address { get; set; }
        private string _cuit { get; set; }
        private string _bruto { get; set; }
        private string _startactivity { get; set; }
        private string _user { get; set; }
        private string _title { get; set; }
        private string _nrofact { get; set; }

        private string _productname { get; set; }
        private decimal _price { get; set; }
        DataGridViewRowCollection _sldto;
        #endregion

        //Metodos
        public void PrintHeadTiket(string busnessname, string address, string cuit, string bruto, string startactivity, string user, string nrofact, DataGridViewRowCollection sldto, string title = "VENTA DE PRODUCTO")
        {
            try
            {

                #region Setear
                this._busnessname = busnessname;
                this._address = address;
                this._cuit = cuit;
                this._bruto = bruto;    
                this._startactivity = startactivity;
                this._user = user;
                this._nrofact = nrofact;
                this._title = title;

                _sldto = sldto;
                #endregion

                //Crea las variables para la impresión del documento
                PrintDialog pd = new PrintDialog(); //Dialogo para abrir las impresoras
                pdoc = new PrintDocument(); //Documento a imprimir
                PrinterSettings ps = new PrinterSettings(); //Propiedades de la impresora
                Font font = new Font("Arial", 15); //Fuente a utilizar
                PaperSize psize = new PaperSize("Custom", 80, 200); //Tamaño de papel

                //Asigna el documento que se va a imprimir
                pd.Document = pdoc;
                //Asigna el tamaño de papel de la impresora
                pd.Document.DefaultPageSettings.PaperSize = psize;
                pd.PrinterSettings.PrinterName = StringgConnection.GetPrint();
                //Asigna el tamaño al documento
                pdoc.DefaultPageSettings.PaperSize.Height = 820;
                pdoc.DefaultPageSettings.PaperSize.Width = 520;
                pdoc.PrintPage += new PrintPageEventHandler(Header);
                pdoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Header(object sender, PrintPageEventArgs e)
        {
            //Lienzo del ticket
            Graphics graphics = e.Graphics;
            //Fuente del ticket
            Font fuente = new Font("Arial", 10);
            //Posiciones iniciales y espaciado en pixeles
            int inicialX = 5;
            int inicialY = 20;
            int espaciado = 40;

            graphics.DrawString(this._title, new Font("Arial", 11), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            espaciado += 20;
            graphics.DrawString(this._busnessname, new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            espaciado += 20;
            graphics.DrawString(this._address, new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            espaciado += 20;
            graphics.DrawString("C.U.I.T : " + this._cuit, new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            espaciado += 20;
            graphics.DrawString("Ing. Brutos : " + this._bruto, new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            espaciado += 20;
            graphics.DrawString("Ini. actividades : " + this._startactivity.ToString(), new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            espaciado += 20;
            graphics.DrawString("Nro. Factura :" + this._nrofact, new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            espaciado += 20;
            graphics.DrawString("Vendedor : " + this._user, new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            espaciado += 20;
            string lineaSeparacion = "========================================";
            graphics.DrawString(lineaSeparacion, new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado); 
            espaciado += 20;

            decimal total = 0;
            string mode = "";
            int productquantity = 0;
            foreach (DataGridViewRow row in _sldto)
            {
                var dto = (SaleDetailDto)row.DataBoundItem;
                total += dto.Subtotal;
                productquantity += dto.quantity;
                mode = dto.PaymentName;
                graphics.DrawString(dto.ProductName + " : " + dto.SalePrice, new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
                espaciado += 20;
            }

            graphics.DrawString(lineaSeparacion, new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado); 
            espaciado += 20;
            graphics.DrawString("Cant producto :" + productquantity.ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            espaciado += 20;
            graphics.DrawString("Mod pago :" + mode, new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            espaciado += 20;
            graphics.DrawString("TOTAL : $ "+ total.ToString(), new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
        }

        private void PrintBodyTiket(string productname, decimal price)
        {
            try
            {

                #region Setear
                this._productname = productname;
                this._price = price;
                #endregion

                //Crea las variables para la impresión del documento
                PrintDialog pd = new PrintDialog(); //Dialogo para abrir las impresoras
                pdoc = new PrintDocument(); //Documento a imprimir

                PrinterSettings ps = new PrinterSettings(); //Propiedades de la impresora
                Font font = new Font("Arial", 15); //Fuente a utilizar
                PaperSize psize = new PaperSize("Custom", 80, 250); //Tamaño de papel

                //Asigna el documento que se va a imprimir
                pd.Document = pdoc;
                //Asigna el tamaño de papel de la impresora
                pd.Document.DefaultPageSettings.PaperSize = psize;
                pd.PrinterSettings.PrinterName = StringgConnection.GetPrint();
                //Asigna el tamaño al documento
                pdoc.DefaultPageSettings.PaperSize.Height = 820;
                pdoc.DefaultPageSettings.PaperSize.Width = 520;
                
                pdoc.PrintPage += new PrintPageEventHandler(Body);
                pdoc.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Body(object sender, PrintPageEventArgs e)
        {
            //Lienzo del ticket
            Graphics graphics = e.Graphics;
            //Fuente del ticket
            Font fuente = new Font("Arial", 10);
            //Posiciones iniciales y espaciado en pixeles
            int inicialX = 5;
            int inicialY = 2;
            int espaciado = 40;

            //Comienza a dibujar
            //Encabezado
            graphics.DrawString(this._productname + " : " + this._price, new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            espaciado += 20;
            string lineaSeparacion = "========================================";
            graphics.DrawString(lineaSeparacion, new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            espaciado += 20;
            //string encabezados = "DESC  P.UNIT  CANT   TOTAL";
            //graphics.DrawString(encabezados, new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            //espaciado += 20;
            ////Separación y descripciónes de productos 
            //graphics.DrawString("Produc1 10  1   $10", new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            //espaciado += 20;
            //graphics.DrawString("Produc2  5  1  $10", new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            //espaciado += 20;
            //graphics.DrawString("Produc3  12  1  $10", new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            //espaciado += 20;
            //graphics.DrawString("Produc4  54  1  $10", new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            //espaciado += 20;
            //graphics.DrawString("Produc5 23.5  1  $10", new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            //espaciado += 20;
            //string total = "TOTAL    " + "$50";
            //espaciado += 20;
            //graphics.DrawString(lineaSeparacion, new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            //espaciado += 20;
            //graphics.DrawString(total, new Font("Arial", 12), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
            //espaciado += 20;
            //graphics.DrawString("¡Gracias por su preferencia!", new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
        }

        //private void ImprimirDetalles(object sender, PrintPageEventArgs e)
        //{
        //    //Lienzo del ticket
        //    Graphics graphics = e.Graphics;
        //    //Fuente del ticket
        //    Font fuente = new Font("Arial", 10);
        //    //Posiciones iniciales y espaciado en pixeles
        //    int inicialX = 5;
        //    int inicialY = 20;
        //    int espaciado = 40;

        //    //Comienza a dibujar
        //    var directorio = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
        //    var ultimoIndice = directorio.LastIndexOf("Tocumbo.UI");
        //    var relativePath = directorio.Substring(0, ultimoIndice);
        //    //Encabezado
        //    var urlImagen = Path.Combine(relativePath, "Tocumbo.UI\\Recursos\\Paleta_Menu.png");

        //    string pathImagen = new Uri(urlImagen).LocalPath;
        //    var imagen = Image.FromFile(pathImagen);
        //    var logotipo = RedimensionarImagen(imagen, 50, 50);
        //    graphics.DrawImage(logotipo, new PointF(40, 20));
        //    espaciado += 50;
        //    graphics.DrawString(this.Encabezado, new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
        //    espaciado += 40;
        //    graphics.DrawString("# Ticket: " + NoTicket, new Font("Arial", 12), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
        //    espaciado += 30;
        //    graphics.DrawString("Fecha:" + Fecha, new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
        //    espaciado += 20;
        //    string lineaSeparacion = "========================================";
        //    graphics.DrawString(lineaSeparacion, new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
        //    espaciado += 20;
        //    string encabezados = "DESC  CANT P.UNIT TOTAL";
        //    graphics.DrawString(encabezados, new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
        //    espaciado += 20;

        //    //Separación y descripciónes de productos 
        //    //foreach (DetalleVenta detalle in lstDetalles)
        //    //{
        //    //    var nombreProducto = detalle.NombreProducto;
        //    //    if (nombreProducto.Length > 16)
        //    //    {
        //    //        nombreProducto = detalle.NombreProducto.Substring(0, 16);
        //    //    }
        //    //    graphics.DrawString(string.Format("{0}  {1}  ${2}  ${3}", nombreProducto, detalle.Cantidad, detalle.PrecioUnitarioProducto, detalle.Total), new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
        //    //    espaciado += 20;

        //    //}

        //    string total = "TOTAL    " + "$" + Total;
        //    string pago = "Total pagado: $" + Pago;
        //    string cambio = "Cambio: $" + Cambio;
        //    espaciado += 20;
        //    graphics.DrawString(lineaSeparacion, new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
        //    espaciado += 20;
        //    graphics.DrawString(total, new Font("Arial", 12), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
        //    espaciado += 20;
        //    graphics.DrawString(pago, new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
        //    espaciado += 20;
        //    graphics.DrawString(cambio, new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
        //    espaciado += 50;
        //    graphics.DrawString(PiePagina, new Font("Arial", 10), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
        //}

        private Bitmap RedimensionarImagen(Image imagen, int ancho, int alto)
        {
            var rectanguloDestino = new Rectangle(0, 0, ancho, alto);
            var imagenDestino = new Bitmap(ancho, alto);

            imagenDestino.SetResolution(imagen.HorizontalResolution, imagen.VerticalResolution);

            using (var grafico = Graphics.FromImage(imagenDestino))
            {
                grafico.CompositingMode = CompositingMode.SourceCopy;
                grafico.CompositingQuality = CompositingQuality.HighQuality;
                grafico.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grafico.SmoothingMode = SmoothingMode.HighQuality;
                grafico.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var compresion = new ImageAttributes())
                {
                    compresion.SetWrapMode(WrapMode.TileFlipXY);
                    grafico.DrawImage(imagen, rectanguloDestino, 0, 0, imagen.Width, imagen.Height, GraphicsUnit.Pixel, compresion);
                }
            }

            return imagenDestino;
        }
    }
}
