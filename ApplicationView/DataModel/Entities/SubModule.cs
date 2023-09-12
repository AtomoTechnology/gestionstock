using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Entities
{
    public class SubModule:BaseEntity
    {
        public string ModuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ActionName { get; set; }  

        public Module Module { get; set; }
        public List<SubModuleAccount> SubModuleAccounts { get; set; }
    }
}
