using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.exportExcel
{
    public abstract class AbsExcelExport : IExport
    {
        public abstract void CreateHeader();

        public abstract void CreateBody();

        public abstract void CreateFooter();


        public abstract object Export();
    }
}
