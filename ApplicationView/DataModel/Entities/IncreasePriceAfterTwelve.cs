using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataModel.Entities
{
    public class IncreasePriceAfterTwelve:BaseEntity
    {
        public String AccountId { get; set; }
        public DateTime HourFrom { get; set; }
        public DateTime HourTo { get; set; }
        [Precision(14, 2)]
        public Decimal Porcent { get; set; }
        public Boolean IsActive { get; set; }   

        public Account Account { get; set; }

    }
}
