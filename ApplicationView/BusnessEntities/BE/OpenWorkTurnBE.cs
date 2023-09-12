using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.BusnessEntities.BE
{
    public class OpenWorkTurnBE:BaseBE
    {
        public string AccountId { get; set; }
        public string TurnId { get; set; }
        public int DateFrom { get; set; }
        public int DateTo { get; set; }

        public string TurnName { get; set;}
        public decimal StartingQuantity { get; set; }

        public AccountBE Account { get; set; }
        public TurnsBE Turn { get; set; }
    }
}
