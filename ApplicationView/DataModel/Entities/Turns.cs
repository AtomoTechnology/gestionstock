using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Entities
{
    public class Turns : BaseEntity
    {
        public string BusinessId { get; set; }
        public string AccountId { get; set; }
        public string TurnName { get; set; }
        public int DateFrom { get; set; }
        public int DateTo { get; set; }  
        public string Description { get; set; }
        public Business Business { get; set; }
        public Account Account { get; set; }
        public List<OpenWorkTurn> OpenWorkShifts { get; set; }
    }
}
