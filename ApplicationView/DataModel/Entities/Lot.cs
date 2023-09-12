using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataModel.Entities
{
    public class Lot:BaseEntity
    {
        public String ProductId { get; set; }
        public String LotCode { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int Stock { get; set; }

        public Product Product { get; set; }
    }
}
