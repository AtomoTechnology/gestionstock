using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataModel.Entities
{
    public class Sale: BaseEntity
    {
        public String AccountId { get; set; }
        public String? PaymentTypeId { get; set; }
        public String? OpenWorkTurnId { get; set; }

        public Int64 InvoiceCode { get; set; }
        [Precision(14, 2)]
        public Decimal Total { get; set; }
        public Boolean finalizeSale { get; set; }
        public String SaleType { get; set; }
        public string CodeLotePayment { get; set; }
        public PaymentType PaymentType { get; set; }
        public List<SaleDetail> SaleDetail { get; set; }
        public List<Legit> Legit { get; set; }
    }
}
