using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Entities
{
    public class ClossCashier
    {
        public int Started { get; set; }
        public decimal Cash { get; set; }
        public decimal ElectronicPay { get; set; }
    }
}
