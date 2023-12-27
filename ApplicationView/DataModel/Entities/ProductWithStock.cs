using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Entities
{
    public class ProductWithStock: Product
    {
        public int Stock { get; set; }
        public string LotId { get; set; }
        public int Quantity { get; set; }
    }
}
