using ApplicationView.BusnessEntities.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataService.Iservice
{
    public interface IUserService
    {
        List<UserBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        UserBE GetById(string id);
        String Create(UserBE user, List<ModuleAccountBE> mabe);
        String Update(string id, UserBE user);
        Boolean Delete(string id);
        List<AccountBE> GetAllAccounts();
    }
}
