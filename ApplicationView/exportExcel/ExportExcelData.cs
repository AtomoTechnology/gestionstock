using ApplicationView.BusnessEntities.Dtos;
using ApplicationView.exportExcel.Color;
using ApplicationView.exportExcel.EnumColor;
using ApplicationView.Patern.singleton;
using ApplicationView.VariableSeesion;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.exportExcel
{
    public class ExportExcelData : AbsExcelExport
    {
        #region Variable and Object
        DataTable tbl;
        ExcelPackage pck;
        ExcelWorksheet ws;
        int rows;
        int columns;
        int footer = 1;
        #endregion

        #region Single
        ReportAllExcel _excel;
        public ExportExcelData(ReportAllExcel excel)
        {
            _excel = excel;
        }

        public override void CreateBody()
        {
            #region Style Table Head
            ws.Cells["A11:AA11"].Merge = true;
            ws.Cells["A11:AA11"].Value = "LISTA DETALLADA";

            using (ExcelRange rng = ws.Cells["A11:AA11"])
            {
                rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rng.AutoFitColumns();
                rng.Style.Font.Bold = true;
                rng.Style.Font.SetFromFont(new Font("Calibri", 14, FontStyle.Regular));
                rng.Style.Font.Color.SetColor(Colors.GetInstance().GetColor(ColorEnum.Blue));
            }

            using (ExcelRange rng = ws.Cells["A12:AA12"])
            {
                rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rng.AutoFitColumns();
                rng.Style.Font.Bold = true;
                rng.Style.Font.SetFromFont(new Font("Calibri", 11, FontStyle.Regular));
                rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                rng.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                rng.Style.Fill.BackgroundColor.SetColor(Colors.GetInstance().GetColor(ColorEnum.Blue));
                rng.Style.Border.BorderAround(ExcelBorderStyle.Thin, Colors.GetInstance().GetColor(ColorEnum.DarkGrey));
            }
            #endregion

            #region Create Head Table

            tbl.Clear();
            tbl.Columns.Add("Codigo");
            tbl.Columns.Add("Producto");
            tbl.Columns.Add("Cantidad");
            tbl.Columns.Add("Precio");
            tbl.Columns.Add("SubTotal");
            #endregion

            #region Fill Table
            DataRow _user = tbl.NewRow();
            rows = 11;
            columns = 1;
            footer = 13;


            if (_excel.vm.Count > 0)
            {
                foreach (SearchSaleSPDTO user in _excel.vm)
                {
                    _user = tbl.NewRow();
                    _user["Codigo"] = 1;
                    _user["Producto"] = user.ProductName;
                    _user["Cantidad"] = user.quantity;
                    _user["Precio"] = (user.subtotal/ user.quantity);
                    _user["SubTotal"] = user.subtotal;
                    tbl.Rows.Add(_user);
                    rows++;

                    //using (ExcelRange rng = ws.Cells["A" + rows + ":H" + rows])
                    //{
                    //    rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    //    rng.AutoFitColumns();
                    //    rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                    //    rng.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    //    rng.Style.Border.BorderAround(ExcelBorderStyle.Thin, Colors.GetInstance().GetColor(ColorEnum.Blue));
                    //}
                }
            }
            else
            {
                ws.Cells["A" + (rows)].Value = "Codigo";
                ws.Cells["A" + (rows)].Value = "Producto";
                ws.Cells["B" + (rows)].Value = "Cantidad";
                ws.Cells["C" + (rows)].Value = "Precio";
                ws.Cells["D" + (rows)].Value = "SubTotal";
                rows++;
                tbl.Rows.Clear();

                ws.Cells["A" + rows + ":H" + rows].Style.Fill.BackgroundColor.SetColor(Colors.GetInstance().GetColor(ColorEnum.LightGrey));
                ws.Cells["A" + rows + ":H" + rows].Style.Font.SetFromFont(new Font("Calibri", 11, FontStyle.Regular));

                ws.Cells["A" + (rows) + ":H" + (rows)].Merge = true;
                ws.Cells["A" + (rows) + ":H" + (rows)].Value = "No hay detalle para mostrar.";
            }
            ws.Cells["A12"].LoadFromDataTable(tbl, true);
            #endregion
        }
        public override void CreateFooter()
        {
            using (ExcelRange rng = ws.Cells["A1:AB" + footer + ""])
            {
                rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rng.AutoFitColumns();
            }
        }
        #endregion

        public override void CreateHeader()
        {
            #region Create header
            var business = RepoPathern.BusnessService.GetById(LoginInfo.IdBusiness);
            ws.Cells["A5:W5"].Value = "EXPORTACION DE DATOS ";
            ws.Cells["E6:S6"].Value = "Empresa: " + business?.BusinessName; ;
            ws.Cells["E7:S7"].Value = "Direccion: " + business?.Address;

            ws.Cells["F8:H8"].Value = "Usuario logueado :";
            ws.Cells["I8:K8"].Value = LoginInfo.UserName;

            ws.Cells["M8:P8"].Value = "Fecha exportación :";
            ws.Cells["Q8:R8"].Value = DateTime.Today.ToShortDateString();
            #endregion

            #region WHITE
            using (ExcelRange rng = ws.Cells["A1:AA10"])
            {
                rng.AutoFitColumns();
                rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rng.AutoFitColumns();
                rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                rng.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.White);

            }
            #endregion

            #region MERGE
            ws.Cells["A5:W5"].Merge = true;
            ws.Cells["E6:S6"].Merge = true;
            ws.Cells["E7:S7"].Merge = true;
            ws.Cells["F8:H8"].Merge = true;

            ws.Cells["I8:K8"].Merge = true;
            ws.Cells["M8:P8"].Merge = true;
            ws.Cells["Q8:R8"].Merge = true;
            #endregion

            #region STYLE
            using (ExcelRange rng = ws.Cells["A1:AA7"])
            {
                rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rng.AutoFitColumns();
                rng.Style.Font.Bold = true;
                rng.Style.Font.SetFromFont(new Font("Calibri", 16, FontStyle.Italic));
                rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                rng.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                rng.Style.Font.Color.SetColor(Colors.GetInstance().GetColor(ColorEnum.Blue));

            }

            using (ExcelRange rng = ws.Cells["A8:AA8"])
            {
                rng.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                rng.AutoFitColumns();
                rng.Style.Font.Bold = true;
                rng.Style.Font.SetFromFont(new Font("Calibri", 15, FontStyle.Italic));
                rng.Style.Font.Color.SetColor(System.Drawing.Color.White);
                rng.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.CenterContinuous;
                rng.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                rng.Style.Font.Color.SetColor(Colors.GetInstance().GetColor(ColorEnum.Blue));
            }

            #endregion
        }
        
        public override object Export()
        {
            tbl = new DataTable();
            pck = new ExcelPackage();

            ws = pck.Workbook.Worksheets.Add(_excel.title);
            this.CreateHeader();
            this.CreateBody();
            this.CreateFooter();
            return pck;
        }
    }
}
