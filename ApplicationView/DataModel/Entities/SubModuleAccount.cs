using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Entities
{
    public class SubModuleAccount:BaseEntity
    {
        public string ModuleAccountId { get; set; }
        public string SubModuleId { get; set; }

        public ModuleAccount ModuleAccount { get; set; }

        [Required]
        [ForeignKey("SubModuleId")]
        public SubModule SubModule { get; set; }
    }
}
