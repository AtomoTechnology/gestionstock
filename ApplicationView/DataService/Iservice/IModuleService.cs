using ApplicationView.BusnessEntities.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataService.Iservice
{
    public interface IModuleService
    {
        List<ModuleBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        ModuleBE GetById(string id);
        List<ModuleBE> GetPermissionByAccountId(string id);
        String Create(ModuleBE be);
        String Update(string id, ModuleBE be);
        String Delete(string id);
    }
}
