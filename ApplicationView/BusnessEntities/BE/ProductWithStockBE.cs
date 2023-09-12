using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.BusnessEntities.BE
{
    public class ProductWithStockBE:ProductBE
    {
        public int Stock { get; set; }
        public string LotId { get; set; }
    }
}
