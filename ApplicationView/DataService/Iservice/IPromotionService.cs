using ApplicationView.BusnessEntities.BE;
using System;
using System.Collections.Generic;

namespace ApplicationView.DataService.Iservice
{
    public interface IPromotionService
    {
        List<PromotionBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        PromotionBE GetById(string id);
        String Create(PromotionBE be);
        String Update(string id, PromotionBE be);
        List<PromotionDetailBE> GetDetailPromoById(string promoId);
        String Delete(string id);
    }
}
