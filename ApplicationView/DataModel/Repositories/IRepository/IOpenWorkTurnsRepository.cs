using ApplicationView.DataModel.Entities;
using System;
using System.Collections.Generic;

namespace ApplicationView.DataModel.Repositories.IRepository
{
    public interface IOpenWorkTurnsRepository
    {
        List<OpenWorkTurn> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        OpenWorkTurn GetById(string id);
        bool GetFilterOpenWorkTurnById(string id);
        OpenWorkTurn IsTurnOpenForUser(string accountid, string busnissid);
        String Create(OpenWorkTurn openturns);
        String Update(string id, OpenWorkTurn openturns);
        String Delete(string id);
        String CloseCashier(string accountId, string TurnId);
        Boolean ChechCashierOpen(string accountId, string TurnId);
    }
}
