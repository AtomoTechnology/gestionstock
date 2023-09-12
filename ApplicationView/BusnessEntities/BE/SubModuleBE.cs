using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.BusnessEntities.BE
{
    public class SubModuleBE:BaseBE
    {
        public string ModuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ActionName { get; set; }

        public ModuleBE Module { get; set; }
        public List<SubModuleAccountBE> SubModuleAccounts { get; set; }
    }
}
