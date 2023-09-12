using ApplicationView.BusnessEntities.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataService.Iservice
{
    public interface ILegitService
    {
        List<LegitBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        LegitBE GetById(string id);
        String Create(LegitBE be);
        String Update(string id, LegitBE be);
        String PayLegit(List<LegitBE> be);
        String Delete(string id);
    }
}
