using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataModel.Entities
{
    public class SaleDetail:BaseEntity
    {
        public String productId { get; set; }
        public String SaleId { get; set; }
        [Precision(14, 2)]
        public decimal price { get; set; }
        public Int32 quantity { get; set; }

        public Sale Sale { get; set; }
        public Product Product { get; set; }

    }
}
