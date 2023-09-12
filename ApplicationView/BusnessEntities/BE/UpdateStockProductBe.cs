using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.BusnessEntities.BE
{
    public class UpdateStockProductBe
    {
        public string AccountId { get; set; }
        public bool IsNewLote { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string NewLote { get; set; }
        public int stock { get; set; }  
    }
}
