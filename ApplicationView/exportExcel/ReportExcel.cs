using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.exportExcel
{
    public class ReportExcel
    {
        public String title;
        public String usuario;

        public ReportExcel(string Title, String Usuario)
        {
            this.title = Title;
            this.usuario = Usuario;
        }
    }
}
