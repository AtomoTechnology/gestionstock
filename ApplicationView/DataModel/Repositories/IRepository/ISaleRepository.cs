using ApplicationView.DataModel.Entities;
using ApplicationView.DataModel.SPEntities;
using ApplicationView.Resolver.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataModel.Repositories.IRepository
{
    public interface ISaleRepository
    {
        List<Sale> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        List<PaymentType> GetAllPaymentType(int state);
        IEnumerable<SearchSaleSP> GetAllSaleHistoric(DateTime datefrom, DateTime dateto,string user, int page, int pageSize);
        IEnumerable<SearchSaleSP> GetAllSaleHistoricExport(DateTime datefrom, DateTime dateto, string turn);
        Sale GetById(string id);
        List<Turns> GetAllTurn();
        IEnumerable<SaleDetailEntityDto> Create(Sale sale, string lotId);
        List<SaleDetailEntityDto> GetReprintTicket(string nroticket);
        String Update(string id, Sale sale);
        String Delete(string id);
        String RemoveNoneSale(SaleDetail saleDetailId, string LotId, string accountId, DeleteSaleEnum enumtype);
        String UpdateWithLegit(SaleWithLogit entity);
        ClossCashier GetCashier(string AccountId);
        ClossCashier GetAccountredemption(string AccountId, string OpenWorkTurnid);
    }
}
