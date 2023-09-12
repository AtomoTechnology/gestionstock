using ApplicationView.DataModel.Entities;
using System;
using System.Collections.Generic;

namespace ApplicationView.DataModel.Repositories.IRepository
{
    public interface ISettingBusinessRepository
    {
        List<SettingBusiness> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        SettingBusiness GetById(string id);
        SettingBusiness GetSettingBusinessByBusinessId(string BusinessId);
        String Create(SettingBusiness stb);
        String Update(string id, SettingBusiness stb);
        String Delete(string id);
    }
}
