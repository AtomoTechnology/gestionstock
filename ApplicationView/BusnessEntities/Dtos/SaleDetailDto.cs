using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.BusnessEntities.Dtos
{
    public class SaleDetailDto
    {
        public String Id { get; set; }
        public String productId { get; set; }
        public string PaymentName { get; set; }
        public String SaleId { get; set; }       
        public String ProductCode { get; set; }
        public Int64 InvoiceCode { get; set; }
        public String ProductName { get; set; }
        public Decimal SalePrice { get; set; }
        public Int32 quantity { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
