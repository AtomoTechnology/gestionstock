using ApplicationView.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Repositories.IRepository
{
    public interface IPromotionRepository
    {
        List<Promotion> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        Promotion GetById(string id);
        List<PromotionDetail>  GetDetailPromoById(string promoId);
        String Create(Promotion entity);
        String Update(string id, Promotion entity);
        String Delete(string id);
    }
}
