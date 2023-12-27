using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.Resolver.Enums
{
    public static class CashierState
    {
        public static String GetStateCashier(int state)
        {
            switch (state)
            {
                case (int)SaleStateEnum.OpenCashier:
                    return "OpenCashier";
                default:
                    return "CloseCashier";
            }
        }
    }
}
