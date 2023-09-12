using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Entities
{
    //Fiar
    public class Legit : BaseEntity
    {
        public String AccountId { get; set; }
        public String SaleId { get; set; }
        public String FullName { get; set; }
        public String Address { get; set; }
        [Precision(14, 2)]
        public decimal Total { get; set; }
        public Account Account { get; set; }
        public Sale Sale { get; set; }
    }
}
