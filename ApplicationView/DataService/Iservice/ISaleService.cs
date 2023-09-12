using ApplicationView.BusnessEntities.BE;
using ApplicationView.BusnessEntities.Dtos;
using ApplicationView.Resolver.Enums;
using System;
using System.Collections.Generic;

namespace ApplicationView.DataService.Iservice
{
    public interface ISaleService
    {
        List<SaleBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        List<PaymentTypeBE> GetAllPaymentType(int state);
        SaleBE GetById(string id);
        List<SaleDetailDto> Create(SaleBE sale, string lotId);
        List<SaleDetailDto> GetReprintTicket(string nroticket);
        List<SearchSaleSPDTO> GetAllSaleHistoric(DateTime datefrom, DateTime dateto, string turn, int page, int pageSize);
        List<SearchSaleSPDTO> GetAllSaleHistoricExport(DateTime datefrom, DateTime dateto, string turn);
        List<TurnsBE> GetAllTurn();
        String Update(string id, SaleBE sale);
        String Delete(string id);
        String RemoveNoneSale(SaleDetailDto saleDetailId, string LotId, string accountId, DeleteSaleEnum enumtype);
        String UpdateWithLegit(SaleWithLogitDto dto);

    }
}
