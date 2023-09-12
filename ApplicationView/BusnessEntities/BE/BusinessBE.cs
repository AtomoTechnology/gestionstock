using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.BusnessEntities.BE
{
    public class BusinessBE: BaseBE
    {
        public String BusinessName { get; set; }
        public String Cuit_Cuil { get; set; }
        public string Grossrevenue { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }

        public List<UserBE> Users { get; set; }
    }
}
