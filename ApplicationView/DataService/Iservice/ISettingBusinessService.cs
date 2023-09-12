using ApplicationView.BusnessEntities.BE;
using System;
using System.Collections.Generic;

namespace ApplicationView.DataService.Iservice
{
    public interface ISettingBusinessService
    {
        List<SettingBusinessBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        SettingBusinessBE GetById(string id);
        SettingBusinessBE GetSettingBusinessByBusinessId(string BusinessId);
        String Create(SettingBusinessBE stb);
        String Update(string id, SettingBusinessBE stb);
        String Delete(string id);
    }
}
