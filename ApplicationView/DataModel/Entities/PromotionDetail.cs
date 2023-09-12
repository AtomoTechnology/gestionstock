using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Entities
{
    public class PromotionDetail:BaseEntity
    {
        public string ProductId { get; set; }
        public string PromotionId { get; set; }
        //public int quantity { get; set; }

        public Promotion Promotion { get; set; }
        public Product Product { get; set; }
    }
}
