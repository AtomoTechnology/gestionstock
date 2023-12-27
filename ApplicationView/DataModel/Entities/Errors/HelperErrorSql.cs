using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Entities.Errors
{
    public class HelperErrorSql
    {
        public int ErrorNumber { get; set; }
        public int ErrorState { get; set; }
        public int ErrorSeverity { get; set; }
        public String ErrorProcedure { get; set; }
        public int ErrorLine { get; set; }
        public String ErrorMessage { get; set; }
    }
}
