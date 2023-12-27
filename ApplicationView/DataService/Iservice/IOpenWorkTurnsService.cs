using ApplicationView.BusnessEntities.BE;
using ApplicationView.BusnessEntities.Dtos;
using System;
using System.Collections.Generic;

namespace ApplicationView.DataService.Iservice
{
    public interface IOpenWorkTurnsService
    {
        List<OpenWorkTurnBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        List<OpenWorkTurnDTO> GetAlll(string AccountId, int page, int top, string orderBy, string ascending, string name, ref int count);
        OpenWorkTurnBE GetById(string id);
        OpenWorkTurnBE GetOpenWorkTurnByAccountId(string AccountId);
        bool CloseWorkUser(string accountId);
        bool GetFilterOpenWorkTurnById(string id);
        OpenWorkTurnBE IsTurnOpenForUser(string accountid, string busnissid);
        String Create(OpenWorkTurnBE openturns);
        String Update(string id, OpenWorkTurnBE openturns);
        String Delete(string id);
        String CloseCashier(string accountId, string TurnId);
        Boolean ChechCashierOpen(string accountId, string TurnId);
    }
}
