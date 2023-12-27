using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.BusnessEntities.Dtos
{
    public class OpenWorkTurnDTO
    {
        public string Id { get; set; }
        public string AccountId { get; set; }
        public string TurnName { get; set; }
        public string DateFrom { get; set; }

        public string AccountName { get; set; }
    }
}
