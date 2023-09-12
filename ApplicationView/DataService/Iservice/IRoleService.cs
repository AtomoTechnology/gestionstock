using ApplicationView.BusnessEntities.BE;
using System;
using System.Collections.Generic;

namespace ApplicationView.DataService.Iservice
{
    public  interface IRoleService
    {
        List<RoleBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        RoleBE GetById(string id);
        String Create(RoleBE role);
        String Update(string id, RoleBE role);
        String Delete(string id);
    }
}
