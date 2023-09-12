using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.BusnessEntities.BE
{
    public class AccountBE:BaseBE
    {
        public String RoleId { get; set; }
        public String UserId { get; set; }
        public String UserName { get; set; }
        public String UserPass { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public bool Confirm { get; set; }

        public RoleBE Role { get; set; }
        public UserBE User { get; set; }

        public List<ProviderBE> Providers { get; set; }
        public List<ModuleAccountBE> ModuleAccounts { get; set; }
    }
}
