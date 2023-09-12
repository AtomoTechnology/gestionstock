using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.BusnessEntities.BE
{
    public class SubModuleAccountBE:BaseBE
    {
        public string ModuleAccountId { get; set; }
        public string SubModuleId { get; set; }

        public ModuleAccountBE ModuleAccount { get; set; }
        public SubModuleBE SubModule { get; set; }
    }
}
