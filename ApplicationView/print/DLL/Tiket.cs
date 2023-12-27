using ApplicationView.Forms.MsgBox;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace ApplicationView.print.DLL
{
    public class TicketWithOutDLL
    {
        private ArrayList headerLines = new ArrayList();

        private ArrayList subHeaderLines = new ArrayList();

        private ArrayList items = new ArrayList();

        private ArrayList totales = new ArrayList();

        private ArrayList footerLines = new ArrayList();

        private Image headerImage = null;

        private int count = 0;

        private int maxChar = 35;

        private int maxCharDescription = 20;

        private int imageHeight = 0;

        private float leftMargin = 0f;

        private float topMargin = 3f;

        private string fontName = "Lucida Console";

        private int fontSize = 9;

        private Font printFont = null;

        private SolidBrush myBrush = new SolidBrush(Color.Black);

        private Graphics gfx = null;

        private string line = null;

        public Image HeaderImage
        {
            get
            {
                return headerImage;
            }
            set
            {
                if (headerImage != value)
                {
                    headerImage = value;
                }
            }
        }

        public int MaxChar
        {
            get
            {
                return maxChar;
            }
            set
            {
                if (value != maxChar)
                {
                    maxChar = value;
                }
            }
        }

        public int MaxCharDescription
        {
            get
            {
                return maxCharDescription;
            }
            set
            {
                if (value != maxCharDescription)
                {
                    maxCharDescription = value;
                }
            }
        }

        public int FontSize
        {
            get
            {
                return fontSize;
            }
            set
            {
                if (value != fontSize)
                {
                    fontSize = value;
                }
            }
        }

        public string FontName
        {
            get
            {
                return fontName;
            }
            set
            {
                if (value != fontName)
                {
                    fontName = value;
                }
            }
        }

        public void AddHeaderLine(string line)
        {
            headerLines.Add(line);
        }

        public void AddSubHeaderLine(string line)
        {
            subHeaderLines.Add(line);
        }

        public void AddItem(string cantidad, string item, string price)
        {
            OrderItem orderItem = new OrderItem('?');
            items.Add(orderItem.GenerateItem(cantidad, item, price));
        }

        public void AddTotal(string name, string price)
        {
            OrderTotal orderTotal = new OrderTotal('?');
            totales.Add(orderTotal.GenerateTotal(name, price));
        }

        public void AddFooterLine(string line)
        {
            footerLines.Add(line);
        }

        private string AlignRightText(int lenght)
        {
            string text = "";
            int num = maxChar - lenght;
            for (int i = 0; i < num; i++)
            {
                text += " ";
            }

            return text;
        }

        private string DottedLine()
        {
            string text = "";
            for (int i = 0; i < maxChar; i++)
            {
                text += "=";
            }

            return text;
        }

        public bool PrinterExists(string impresora)
        {
            foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
            {
                if (impresora == installedPrinter)
                {
                    return true;
                }
            }

            return false;
        }
        public void PrintTicket(string impresora)
        {
            printFont = new Font(fontName, fontSize, FontStyle.Regular);
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrinterSettings.PrinterName = impresora;            

            if (GetPrinterInfo(impresora))
            {
                printDocument.PrintPage += new PrintPageEventHandler(pr_PrintPage);
                printDocument.Print();
            }
            else
            {
                RJMessageBox.Show("No hay impresora disponible para imprimir", "Sistema de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pr_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics!.PageUnit = GraphicsUnit.Millimeter;
            gfx = e.Graphics;
            DrawImage();
            DrawHeader();
            DrawSubHeader();
            //DrawItems();
            DrawTotales();
            DrawFooter();
            if (headerImage != null)
            {
                HeaderImage.Dispose();
                headerImage.Dispose();
            }
        }

        private float YPosition()
        {
            return topMargin + ((float)count * printFont.GetHeight(gfx) + (float)imageHeight);
        }

        private void DrawImage()
        {
            if (headerImage != null)
            {
                try
                {
                    gfx.DrawImage(headerImage, new Point((int)leftMargin, (int)YPosition()));
                    double a = (double)headerImage.Height / 58.0 * 15.0;
                    imageHeight = (int)Math.Round(a) + 3;
                }
                catch (Exception)
                {
                }
            }
        }

        private void DrawHeader()
        {
            foreach (string headerLine in headerLines)
            {
                if (headerLine.Length > maxChar)
                {
                    int num = 0;
                    for (int num2 = headerLine.Length; num2 > maxChar; num2 -= maxChar)
                    {
                        line = headerLine.Substring(num, maxChar);
                        gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        num += maxChar;
                    }

                    line = headerLine;
                    gfx.DrawString(line.Substring(num, line.Length - num), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = headerLine;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
            }

            DrawEspacio();
        }

        private void DrawSubHeader()
        {
            foreach (string subHeaderLine in subHeaderLines)
            {
                if (subHeaderLine.Length > maxChar)
                {
                    int num = 0;
                    for (int num2 = subHeaderLine.Length; num2 > maxChar; num2 -= maxChar)
                    {
                        line = subHeaderLine;
                        gfx.DrawString(line.Substring(num, maxChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        num += maxChar;
                    }

                    line = subHeaderLine;
                    gfx.DrawString(line.Substring(num, line.Length - num), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = subHeaderLine;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                    line = DottedLine();
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
            }

            DrawEspacio();
        }

        private void DrawItems()
        {
            OrderItem orderItem = new OrderItem('?');
            gfx.DrawString("CANT DESCRIPCION  IMPORTE", printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            count++;
            DrawEspacio();
            foreach (string item in items)
            {
                line = orderItem.GetItemCantidad(item);
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                line = orderItem.GetItemPrice(item);
                line = AlignRightText(line.Length) + line;
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                string itemName = orderItem.GetItemName(item);
                leftMargin = 0f;
                if (itemName.Length > maxCharDescription)
                {
                    int num = 0;
                    for (int num2 = itemName.Length; num2 > maxCharDescription; num2 -= maxCharDescription)
                    {
                        line = orderItem.GetItemName(item);
                        gfx.DrawString("      " + line.Substring(num, maxCharDescription), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        num += maxCharDescription;
                    }

                    line = orderItem.GetItemName(item);
                    gfx.DrawString("      " + line.Substring(num, line.Length - num), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    gfx.DrawString("      " + orderItem.GetItemName(item), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
            }

            leftMargin = 0f;
            DrawEspacio();
            line = DottedLine();
            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            count++;
            DrawEspacio();
        }

        private void DrawTotales()
        {
            OrderTotal orderTotal = new OrderTotal('?');
            foreach (string totale in totales)
            {
                line = orderTotal.GetTotalCantidad(totale);
                line = AlignRightText(line.Length) + line;
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                leftMargin = 0f;
                line = "      " + orderTotal.GetTotalName(totale);
                gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                count++;
            }

            leftMargin = 0f;
            DrawEspacio();
            DrawEspacio();
        }

        private void DrawFooter()
        {
            foreach (string footerLine in footerLines)
            {
                if (footerLine.Length > maxChar)
                {
                    int num = 0;
                    for (int num2 = footerLine.Length; num2 > maxChar; num2 -= maxChar)
                    {
                        line = footerLine;
                        gfx.DrawString(line.Substring(num, maxChar), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                        count++;
                        num += maxChar;
                    }

                    line = footerLine;
                    gfx.DrawString(line.Substring(num, line.Length - num), printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
                else
                {
                    line = footerLine;
                    gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
                    count++;
                }
            }

            leftMargin = 0f;
            DrawEspacio();
        }

        private void DrawEspacio()
        {
            line = "";
            gfx.DrawString(line, printFont, myBrush, leftMargin, YPosition(), new StringFormat());
            count++;
        }

        public bool GetPrinterInfo(String printerNameconect)
        {
            var data = new ManagementObjectSearcher("select NumberOfCores from Win32_Processor").Get();
            int cores = 0;
            foreach (var processor in data)
            {
                cores += Convert.ToInt32(processor["NumberOfCores"]);
            }

            Boolean result = false;
            ManagementScope scope = new ManagementScope(@"\root\cimv2");
            scope.Connect();

            // Select Printers from WMI Object Collections
            ManagementObjectSearcher searcher = new
             ManagementObjectSearcher("SELECT * FROM Win32_Printer");

            string printerName = "";
            foreach (ManagementObject printer in searcher.Get())
            {
                printerName = printer["Name"].ToString().ToLower();
                if (printerName.ToLower().Equals(printerNameconect.ToLower()))
                {
                    if (printer["WorkOffline"].ToString().ToLower().Equals("true"))
                    {
                        // printer is offline by user
                        //Console.WriteLine("Your Plug-N-Play printer is not connected.");
                        result = false;
                    }
                    else
                    {
                        // printer is not offline
                        //Console.WriteLine("Your Plug-N-Play printer is connected.");
                        result = true;
                        break;
                    }
                }
                result = false;
            }
            return result;
        }      

    }
}
