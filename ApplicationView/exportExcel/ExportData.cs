using ApplicationView.BusnessEntities.Dtos;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.exportExcel
{
    public class ExportData
    {
        public String ExportExcel(string urlsave, List<SearchSaleSPDTO> listbe, String usuario)
        {
            try
            {
                ReportAllExcel v = new ReportAllExcel("Hoistorial de ventas", usuario, listbe);
                IExport export = new ExportExcelData(v);
                using (ExcelPackage pck = (ExcelPackage)export.Export())
                {
                    pck.SaveAs(new FileInfo(urlsave));
                    return "OK";
                }
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }      
    }
}
