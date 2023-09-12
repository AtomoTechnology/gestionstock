using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ApplicationView.DataModel.Entities
{
    public class Promotion: BaseEntity
    {
        public string PromoCode { get; set; }
        public string PromoName { get; set; }

        [Precision(14, 2)]
        public decimal Price { get; set; }
        public DateTime? FinalPromotion { get; set; }
        public int stock { get; set; }
        public Boolean untilstockexhausted { get; set; }
        public string Description { get; set; }

        public List<PromotionDetail> PromotionDetails { get; set; }
    }
}