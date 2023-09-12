using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.BusnessEntities.BE
{
    public class PromotionDetailBE:BaseBE
    {
        public string ProductId { get; set; }
        public string PromotionId { get; set; }
        public int quantity { get; set; }

        public PromotionBE Promotion { get; set; }
        public ProductBE Product { get; set; }
    }
}
