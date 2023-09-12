using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.BusnessEntities.BE
{
    public class TurnsBE:BaseBE
    {
        public string BusinessId { get; set; }
        public string AccountId { get; set; }
        public string TurnName { get; set; }
        public int DateFrom { get; set; }
        public int DateTo { get; set; }
        public string Description { get; set; }
        public BusinessBE Business { get; set; }
        public AccountBE Account { get; set; }
        public List<OpenWorkTurnBE> OpenWorkShifts { get; set; }
    }
}
