using ApplicationView.BusnessEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.exportExcel
{
    public class ReportAllExcel : ReportExcel
    {
        public List<SearchSaleSPDTO> vm;
        public ReportAllExcel(String Title, String usuario, List<SearchSaleSPDTO> Vm) : base(Title, usuario)
        {
            vm = Vm;
        }
    }
}
