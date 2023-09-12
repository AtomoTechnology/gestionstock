using ApplicationView.BusnessEntities.BE;
using System;
using System.Collections.Generic;

namespace ApplicationView.DataService.Iservice
{
    public interface ITurnService
    {
        List<TurnsBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        TurnsBE GetById(string id);
        string GetFilterByBusinessId(string businessid, string accountid);
        String Create(TurnsBE turns);
        String Update(string id, TurnsBE turns);
        String Delete(string id);
    }
}
