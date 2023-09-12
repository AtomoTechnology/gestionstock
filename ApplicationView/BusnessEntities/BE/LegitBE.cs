using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.BusnessEntities.BE
{
    public class LegitBE : BaseBE
    {
        public String AccountId { get; set; }
        public String SaleId { get; set; }
        public String FullName { get; set; }
        public String Address { get; set; }
        public decimal Total { get; set; }
        public AccountBE Account { get; set; }
        public SaleBE Sale { get; set; }
    }
}
