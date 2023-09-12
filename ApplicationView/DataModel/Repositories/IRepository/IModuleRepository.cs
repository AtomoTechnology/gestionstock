using ApplicationView.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Repositories.IRepository
{
    public interface IModuleRepository
    {
        List<Module> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        Module GetById(string id);
        List<Module> GetPermissionByAccountId(string id);
        String Create(Module module);
        String Update(string id, Module module);
        String Delete(string id);
    }
}
