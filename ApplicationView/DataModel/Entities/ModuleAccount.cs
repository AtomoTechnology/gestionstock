using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Entities
{
    public class ModuleAccount: BaseEntity
    {
        public string ModuleId { get; set; }
        public string AccountId { get; set; }

        public Module Module { get; set; }  
        public Account Account { get; set; }

        public List<SubModuleAccount> SubModuleAccounts { get; set; }
    }
}
