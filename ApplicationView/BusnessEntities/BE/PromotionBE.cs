using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.BusnessEntities.BE
{
    public class PromotionBE:BaseBE
    {
        public string PromoCode { get; set; }
        public string PromoName { get; set; }
        public decimal Price { get; set; }
        public DateTime? FinalPromotion { get; set; }
        public int stock { get; set; }
        public Boolean untilstockexhausted { get; set; }
        public string Description { get; set; }

        public List<PromotionDetailBE> PromotionDetails { get; set; }
    }
}
