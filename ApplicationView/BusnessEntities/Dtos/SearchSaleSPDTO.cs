using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.BusnessEntities.Dtos
{
    public class SearchSaleSPDTO
    {
        public String Accountname { get; set; }
        public string ProductCode { get; set; }
        public String ProductName { get; set; }
        public int InvoiceCode { get; set; }
        public String PaymentName { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public Int64 count { get; set; }
        public decimal subtotal { get; set; }
        public decimal Total { get; set; }
    }
}
