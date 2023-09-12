using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.BusnessEntities.BE
{
    public class ModuleBE: BaseBE
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ModuleAccountBE> ModuleAccounts { get; set; }
        public List<SubModuleBE> SubModules { get; set; }
    }
}
