using ApplicationView.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Repositories.IRepository
{
    public interface IAccountRepository
    {
        Task<Account> Login(string username, string userpass);
        String ChangePassword(Account entity);
        String UpdatePassword(string oldpass, Business business);
        List<Account> FilterAccountByBusinessId(int state, int page, int top, string businessId, string orderBy, string ascending, string name, ref int count);
    }
}
