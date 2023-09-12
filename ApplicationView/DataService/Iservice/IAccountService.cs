using ApplicationView.BusnessEntities.BE;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataService.Iservice
{
    public interface IAccountService
    {
        Task<AccountBE> Login(string username, string userpass);
        String ChangePassword(AccountBE be);
        String UpdatePassword(string oldpass, AccountBE business);
        List<AccountBE> FilterAccountByBusinessId(int state, int page, int top, string businessId, string orderBy, string ascending, string name, ref int count);
         
    }
}
