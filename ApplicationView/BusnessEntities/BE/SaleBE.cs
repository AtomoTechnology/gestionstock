﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.BusnessEntities.BE
{
    public class SaleBE:BaseBE
    {
        public String AccountId { get; set; }
        public String PaymentTypeId { get; set; }
        public Decimal Total { get; set; }
        public Boolean finalizeSale { get; set; }
        public String SaleType { get; set; }
        public Int64 InvoiceCode { get; set; }
        public string CodeLotePayment { get; set; }
        public PaymentTypeBE PaymentType { get; set; }
        public List<SaleDetailBE> SaleDetail { get; set; }
    }
}
