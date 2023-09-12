using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.BusnessEntities.BE
{
    public class ModuleAccountBE:BaseBE
    {
        public ModuleAccountBE()
        {
            SubModuleAccounts = new List<SubModuleAccountBE>();
        }
        public string ModuleId { get; set; }
        public string AccountId { get; set; }

        public ModuleBE Module { get; set; }
        public AccountBE Account { get; set; }
        public List<SubModuleAccountBE> SubModuleAccounts { get; set; }
    }
}
