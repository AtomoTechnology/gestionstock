using ApplicationView.BusnessEntities.Dtos;
using ApplicationView.Dtos.Prints;
using ApplicationView.Resolver.Security;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BarControls
{
    public class PrintNew
    {

        private static PrintNew _factory;

        public static PrintNew GetInstance()
        {
            if (_factory == null)
                _factory = new PrintNew();
            return _factory;
        }
        ArrayList headerLines = new ArrayList();
        ArrayList subHeaderLines = new ArrayList();
        ArrayList items = new ArrayList();
        ArrayList totales = new ArrayList();
        ArrayList footerLines = new ArrayList();
        private Image headerImage = null;

        #region Propiedades

        private string _productname { get; set; }
        private decimal _price { get; set; }
        DataGridViewRowCollection _sldto;
        #endregion

        int count = 0;

        int maxChar = 35;
        int maxCharDescription = 20;

        int imageHeight = 0;

        float leftMargin = 0;
        float topMargin = 3;

        string fontName = "Lucida Console";
        int fontSize = 9;

        Font printFont = null;
        SolidBrush myBrush = new SolidBrush(Color.Black);

        Graphics gfx = null;

        string line = null;

        public PrintNew()
        {

        }

        public Image HeaderImage
        {
            get { return headerImage; }
            set { if (headerImage != value) headerImage = value; }
        }

        public int MaxChar
        {
            get { return maxChar; }
            set { if (value != maxChar) maxChar = value; }
        }

        public int MaxCharDescription
        {
            get { return maxCharDescription; }
            set
            {
                if (value != maxCharDescription) maxCharDescription
          = value;
            }
        }

        public int FontSize
        {
            get { return fontSize; }
            set { if (value != fontSize) fontSize = value; }
        }

        public string FontName
        {
            get { return fontName; }
            set { if (value != fontName) fontName = value; }
        }

        public void AddHeaderLine(string line)
        {
            headerLines.Add(line);
        }

        public void AddSubHeaderLine(string line)
        {
            subHeaderLines.Add(line);
        }

        public void AddItem(/*string cantidad,*/ string item/*, string price*/)
        {
            OrderItem newItem = new OrderItem('?');
            items.Add(newItem.GenerateItem(/*cantidad,*/ item/*, price*/));
        }

        public void AddTotal(string name, string price)
        {
            OrderTotal newTotal = new OrderTotal('?');
            totales.Add(newTotal.GenerateTotal(name, price));
        }

        public void AddFooterLine(string line)
        {
            footerLines.Add(line);
        }

        private string AlignRightText(int lenght)
        {
            string espacios = "";
            int spaces = maxChar - lenght;
            for (int x = 0; x < spaces; x++)
                espacios += " ";
            return espacios;
        }

        private string DottedLine()
        {
            string dotted = "";
            for (int x = 0; x < maxChar; x++)
                dotted += "=";
            return dotted;
        }

        public bool PrinterExists(string impresora)
        {
            foreach (String strPrinter in
            PrinterSettings.InstalledPrinters)
            {
                if (impresora == strPrinter)
                    return true;
            }
            return false;
        }

        public void PrintTicketHeader(string busnessname, string address, string cuit, string bruto, string startactivity, string user, string nrofact, DataGridViewRowCollection sldto, string title = "VENTA DE PRODUCTO")
        {
            #region Setear
            _sldto = sldto;
            #endregion

            #region Load header
            AddHeaderLine(title);
            AddHeaderLine(busnessname);
            AddHeaderLine(address);
            AddHeaderLine("C.U.I.T : " + cuit);
            AddHeaderLine("Ing. Brutos : " + bruto);
            AddHeaderLine("Ini. actividades : " + startactivity.ToString());
            AddHeaderLine("Nro. Factura :" + nrofact);
            AddHeaderLine("Vendedor : " + user);
            #endregion

            #region Load body
            decimal total = 0;
            string mode = "";
            int productquantity = 0;
            foreach (DataGridViewRow row in _sldto)
            {
                var dto = (SaleDetailDto)row.DataBoundItem;
                total += dto.Subtotal;
                productquantity += dto.quantity;
                mode = dto.PaymentName;

                AddItem(dto.ProductName + " : " + dto.SalePrice);
                //graphics.DrawString(dto.ProductName + " : " + dto.SalePrice, new Font("Arial", 8), new SolidBrush(Color.Black), inicialX, inicialY + espaciado);
                //espaciado += 20;
            }
            #endregion

            #region Total
            AddTotal("Cant producto :" , productquantity.ToString());
            AddTotal("Mod pago :" , mode);
            AddTotal("TOTAL : $ ", total.ToString());
            #endregion

            #region Footer
            AddFooterLine("Para consultas, sugerecias o reglamos se puede consulta al :");
            #endregion
            printFont = new Font(fontName, fontSize,FontStyle.Regular);
            PrintDocument pr = new PrintDocument();
            pr.PrinterSettings.PrinterName = StringgConnection.GetPrint();
            pr.PrintPage += new PrintPageEventHandler(pr_PrintPage);
            pr.Print();
        }

        private void pr_PrintPage(object sender,
        System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;

            //DrawImage();
            DrawHeader();
            //DrawSubHeader();
            DrawItems();
            DrawTotales();
            //DrawFooter();

            if (headerImage != null)
            {
                HeaderImage.Dispose();
                headerImage.Dispose();
            }
            gfx.Clear(Color.Transparent);
        }

        private float YPosition()
        {
            return topMargin + (count * printFont.GetHeight(gfx) +
            imageHeight);
        }

        private void DrawImage()
        {
            if (headerImage != null)
            {
                try
                {
                    gfx.DrawImage(headerImage, new Point((int)
                    leftMargin, (int)YPosition()));
                    double height = ((double)headerImage.Height / 58)
                    * 15;
                    imageHeight = (int)Math.Round(height) + 3;
                }
                catch (Exception)
                {
                }
            }
        }

        private void DrawHeader()
        {
           // gfx.DrawString("Cabecera de prueba",
           //printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            foreach (string header in headerLines)
            {
                if (header.Length > maxChar)
                {
                    int currentChar = 0;
                    int headerLenght = header.Length;

                    while (headerLenght > maxChar)
                    {
                        line = header.Substring(currentChar, maxChar);
                        gfx.DrawString(line, new Font(fontName, fontSize, FontStyle.Bold), myBrush,
                        leftMargin, YPosition(), new StringFormat());

                        count++;
                        currentChar += maxChar;
                        headerLenght -= maxChar;
                    }
                    line = header;
                    gfx.DrawString(line.Substring(currentChar,
                    line.Length - currentChar), printFont, myBrush, leftMargin, YPosition
                    (), new StringFormat());
                    count++;
                }
                else
                {
                    line = header;
                    gfx.DrawString(line, printFont, myBrush,
                    leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            DrawEspacio();
        }

        private void DrawSubHeader()
        {
            foreach (string subHeader in subHeaderLines)
            {
                if (subHeader.Length > maxChar)
                {
                    int currentChar = 0;
                    int subHeaderLenght = subHeader.Length;

                    while (subHeaderLenght > maxChar)
                    {
                        line = subHeader;
                        gfx.DrawString(line.Substring(currentChar,
                        maxChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat
                        ());

                        count++;
                        currentChar += maxChar;
                        subHeaderLenght -= maxChar;
                    }
                    line = subHeader;
                    gfx.DrawString(line.Substring(currentChar,
                    line.Length - currentChar), printFont, myBrush, leftMargin, YPosition
                    (), new StringFormat());
                    count++;
                }
                else
                {
                    line = subHeader;

                    gfx.DrawString(line, printFont, myBrush,
                    leftMargin, YPosition(), new StringFormat());

                    count++;

                    line = DottedLine();

                    gfx.DrawString(line, printFont, myBrush,
                    leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            DrawEspacio();
        }

        private void DrawItems()
        {
            OrderItem ordIt = new OrderItem('?');

            //gfx.DrawString("CANT DESCRIPCION IMPORTE",
            //printFont, myBrush, leftMargin, YPosition(), new StringFormat());

            count++;
            DrawEspacio();

            foreach (string item in items)
            {
                //line = ordIt.GetItemCantidad(item);

                //gfx.DrawString(line, printFont, myBrush, leftMargin,
                //YPosition(), new StringFormat());

                //line = ordIt.GetItemPrice(item);
                //line = AlignRightText(line.Length) + line;

                //gfx.DrawString(line, printFont, myBrush, leftMargin,
                //YPosition(), new StringFormat());

                string name = ordIt.GetItemName(item);

                leftMargin = 0;
                if (name.Length > maxCharDescription)
                {
                    int currentChar = 0;
                    int itemLenght = name.Length;

                    //while (itemLenght > maxCharDescription)
                    //{
                    line = ordIt.GetItemName(item);
                    //if (line.Length > 24)
                    //{
                    var split = line.Split(':');
                    string substring = split[0].Substring(0, (12));
                    string final = substring + "..: " + split[1];
                    gfx.DrawString(" " + final, printFont, myBrush, leftMargin,YPosition(), new StringFormat());
                    //}
                    //else
                    //{
                    //    gfx.DrawString(" " + line, printFont, myBrush, leftMargin,
                    //    YPosition(), new StringFormat());
                    //}
                        

                        //count++;
                        //currentChar += maxCharDescription;
                        //itemLenght -= maxCharDescription;
                    //}

                    //line = ordIt.GetItemName(item);
                    //var split1 = line.Split(':');
                    //string substring1 = split1[0].Substring(currentChar, line.Length - currentChar);
                    //string final1 = substring1 + ": " + split1[1];


                    //line = ordIt.GetItemName(item);
                    //gfx.DrawString(" " + final1, printFont, myBrush,
                    //leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    gfx.DrawString(" " + ordIt.GetItemName(item),
                    printFont, myBrush, leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }

            leftMargin = 0;
            DrawEspacio();
            line = DottedLine();

            gfx.DrawString(line, printFont, myBrush, leftMargin,
            YPosition(), new StringFormat());

            count++;
            DrawEspacio();
        }

        private void DrawTotales()
        {
            OrderTotal ordTot = new OrderTotal('?');

            foreach (string total in totales)
            {
               
                line = ordTot.GetTotalCantidad(total);
                //line = AlignRightText(line.Length) + line;

                gfx.DrawString(line, printFont, myBrush, leftMargin,
                YPosition(), new StringFormat());
                leftMargin = 0;

                //line = " " + ordTot.GetTotalName(total);
                //gfx.DrawString(line, printFont, myBrush, leftMargin,
                //YPosition(), new StringFormat());
                count++;
            }
            leftMargin = 0;
            DrawEspacio();
            DrawEspacio();
        }

        private void DrawFooter()
        {
            foreach (string footer in footerLines)
            {
                if (footer.Length > maxChar)
                {
                    int currentChar = 0;
                    int footerLenght = footer.Length;

                    while (footerLenght > maxChar)
                    {
                        line = footer;
                        gfx.DrawString(line.Substring(currentChar,
                        maxChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat
                        ());

                        count++;
                        currentChar += maxChar;
                        footerLenght -= maxChar;
                    }
                    line = footer;
                    gfx.DrawString(line.Substring(currentChar,
                    line.Length - currentChar), printFont, myBrush, leftMargin, YPosition
                    (), new StringFormat());
                    count++;
                }
                else
                {
                    line = footer;
                    gfx.DrawString(line, printFont, myBrush,
                    leftMargin, YPosition(), new StringFormat());

                    count++;
                }
            }
            leftMargin = 0;
            DrawEspacio();
        }

        private void DrawEspacio()
        {
            line = "";

            gfx.DrawString(line, printFont, myBrush, leftMargin,
            YPosition(), new StringFormat());

            count++;
        }

        #region Header
        public void HeaderCustom(string busnessname, string address, string cuit, string bruto, string startactivity, string user, string nrofact, string title = "TICKET DE VENTA DE PRODUCTO")
        {
            gfx.DrawString(title, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            DrawEspacio();
            gfx.DrawString(busnessname, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            DrawEspacio();
            gfx.DrawString("C.U.I.T : " + cuit, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            DrawEspacio();
            gfx.DrawString("Ing. Brutos : " + bruto, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            DrawEspacio();
            gfx.DrawString("Ini. actividades : " + startactivity.ToString(), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            DrawEspacio();
            gfx.DrawString("Ini. actividades : " + startactivity.ToString(), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            DrawEspacio();
            gfx.DrawString("Vendedor : " + user, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            DrawEspacio();
        }
        #endregion
    }

    public class OrderItem
    {
        char[] delimitador = new char[] { '?' };

        public OrderItem(char delimit)
        {
            delimitador = new char[] { delimit };
        }

        public string GetItemCantidad(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[0];
        }

        public string GetItemName(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[1];
        }

        public string GetItemPrice(string orderItem)
        {
            string[] delimitado = orderItem.Split(delimitador);
            return delimitado[1];
        }

        public string GenerateItem(/*string cantidad, */string itemName/*,string price*/)
        {
            return /*cantidad +*/ delimitador[0] + itemName /*+ delimitador[0] + price*/;
        }


    }

    public class OrderTotal
    {
        char[] delimitador = new char[] { '?' };

        public OrderTotal(char delimit)
        {
            delimitador = new char[] { delimit };
        }

        public string GetTotalName(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[0];
        }

        public string GetTotalCantidad(string totalItem)
        {
            string[] delimitado = totalItem.Split(delimitador);
            return delimitado[0] + delimitado[1];
        }

        public string GenerateTotal(string totalName, string price)
        {
            return totalName + delimitador[0] + price;
        }
    }
}
