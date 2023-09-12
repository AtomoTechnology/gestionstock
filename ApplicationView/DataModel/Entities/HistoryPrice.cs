using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataModel.Entities
{
    public class HistoryPrice:BaseEntity
    {
        public string ProductId { get; set; }
        public string AccountId { get; set; }
        [Precision(14, 2)]
        public decimal PriceSale { get; set; }
        [Precision(14, 2)]
        public decimal PricePurchase { get; set; }
        public Int32 typeUpdate { get; set; }

        public Product Product { get; set; }
        public Account Account { get; set; }
    }
}
