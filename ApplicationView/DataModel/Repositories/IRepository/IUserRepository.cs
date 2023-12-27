using ApplicationView.DataModel.Entities;
using System;
using System.Collections.Generic;

namespace ApplicationView.DataModel.Repositories.IRepository
{
    public interface IUserRepository
    {
        List<User> GetAll(int state, int page, int top, string orderBy, string ascending, ref int count);
        User GetById(string id);
        String Create(User user, List<ModuleAccount> mabe);
        String Update(string id, User user);
        Boolean Delete(string id);
        List<Account> GetAllAccounts();
    }
}
