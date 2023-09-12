
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Entities
{
    public class SettingBusiness:BaseEntity
    {
        public string BusinessId { set; get; }
        public DateTime DateFrom { set; get; }
        public DateTime DateTo { set; get; }    
        public bool IsActive { set; get; }
        public bool IsTryOn { set; get; } 
        public bool IsFree { set; get; }
        public Business Business { set; get; }
    }
}
