using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Entities
{
    public class Module:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ActionName { get; set; }

        public List<ModuleAccount> ModuleAccounts { get; set; }
        public List<SubModule> SubModules { get; set; }
    }
}
