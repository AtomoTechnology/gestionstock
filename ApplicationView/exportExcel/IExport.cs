using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.exportExcel
{
    public interface IExport
    {
        object Export();
        void CreateHeader();
        void CreateBody();
        void CreateFooter();
    }
}
