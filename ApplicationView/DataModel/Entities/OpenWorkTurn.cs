using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Entities
{
    public class OpenWorkTurn:BaseEntity
    {
        public string AccountId { get; set; }
        public string TurnId { get; set; }
        [Precision(14, 2)]
        public decimal StartingQuantity { get; set; }

        public Account Account { get; set; }
        public Turns Turn { get; set; }
    }
}
