using ApplicationView.BusnessEntities.BE;
using ApplicationView.BusnessEntities.Dtos;
using ApplicationView.DataModel.Entities;
using ApplicationView.DataModel.Repositories.IRepository;
using ApplicationView.DataModel.SPEntities;
using ApplicationView.DataService.Iservice;
using ApplicationView.Resolver.Enums;
using ApplicationView.Resolver.HelperError.Handlers;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Resolver.log;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationView.DataService.Service
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repo;
        private readonly IMapper _maapper;
        public SaleService(ISaleRepository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }
        public List<SaleDetailDto> Create(SaleBE sale, string lotId)
        {
            try
            {
                var entity = _repo.Create(_maapper.Map<Sale>(sale), lotId).ToList();
                List<SaleDetailDto> dto = new List<SaleDetailDto>();
                if (entity.Count > 0)
                {
                    foreach (var item in entity)
                    {
                        dto.Add(new SaleDetailDto()
                        {
                            SaleId = item.SaleId,
                            Id = item.Id,
                            SalePrice = item.SalePrice,
                            productId = item.productId,
                            ProductName = item.ProductName,
                            quantity = item.quantity,
                            InvoiceCode = item.InvoiceCode,
                            ProductCode = item.ProductCode,
                            Subtotal = item.SalePrice * item.quantity
                        });
                    }
                }
                return dto;
            }
            catch (ApiBusinessException ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }
        public string Delete(string id) => throw new NotImplementedException();
        public List<SaleBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count) => throw new NotImplementedException();
        public List<PaymentTypeBE> GetAllPaymentType(int state)
        {
            try
            {
                var entities = _repo.GetAllPaymentType(state);
                return _maapper.Map<List<PaymentTypeBE>>(entities);
            }
            catch (ApiBusinessException ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public List<SearchSaleSPDTO> GetAllSaleHistoric(DateTime datefrom, DateTime dateto, string user, int page, int pageSize)
        {
            try
            {
                var entity = _repo.GetAllSaleHistoric(datefrom, dateto,user, page, pageSize).ToList();                
                return _maapper.Map<List<SearchSaleSPDTO>>(entity);
            }
            catch (ApiBusinessException ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public List<SearchSaleSPDTO> GetAllSaleHistoricExport(DateTime datefrom, DateTime dateto, string turn)
        {
            try
            {
                var entity = _repo.GetAllSaleHistoricExport(datefrom, dateto, turn).ToList();
                return _maapper.Map<List<SearchSaleSPDTO>>(entity);
            }
            catch (ApiBusinessException ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public ClossCashierBE GetCashier(string AccountId)
        {
            try
            {
                var entities = _repo.GetCashier(AccountId);
                return _maapper.Map<ClossCashierBE>(entities);
            }
            catch (ApiBusinessException ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public ClossCashierBE GetAccountredemption(string AccountId, string OpenWorkTurnid)
        {
            try
            {
                var entities = _repo.GetAccountredemption(AccountId, OpenWorkTurnid);
                return _maapper.Map<ClossCashierBE>(entities);
            }
            catch (ApiBusinessException ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }
        public List<TurnsBE> GetAllTurn()
        {
            try
            {
                var entities = _repo.GetAllTurn();
                if (entities.Count > 0)
                {
                    entities.Add(new Turns()
                    {
                        TurnName = "All",
                        Id = "All"
                    });
                }
                return _maapper.Map<List<TurnsBE>>(entities);
            }
            catch (ApiBusinessException ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public SaleBE GetById(string id)
        {
            try
            {
                var entities = _repo.GetById(id);
                return _maapper.Map<SaleBE>(entities);
            }
            catch (ApiBusinessException ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public List<SaleDetailDto> GetReprintTicket(string nroticket)
        {
            try
            {
                var entity = _repo.GetReprintTicket(nroticket).ToList();
                List<SaleDetailDto> dto = new List<SaleDetailDto>();
                if (entity.Count > 0)
                {
                    foreach (var item in entity)
                    {
                        dto.Add(new SaleDetailDto()
                        {
                            SaleId = item.SaleId,
                            Id = item.Id,
                            SalePrice = item.SalePrice,
                            productId = item.productId,
                            ProductName = item.ProductName,
                            quantity = item.quantity,
                            InvoiceCode = item.InvoiceCode,
                            ProductCode = item.ProductCode,
                            PaymentName = item.PaymentName,
                            Subtotal = item.SalePrice * item.quantity,
                            CreatedDate = item.CreatedDate
                        });
                    }
                }
                return dto;
            }
            catch (ApiBusinessException ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public string RemoveNoneSale(SaleDetailDto saleDetailId, string LotId, string accountId, DeleteSaleEnum enumtype)
        {
            try
            {
                var entities = _repo.RemoveNoneSale(_maapper.Map<SaleDetail>(saleDetailId),LotId, accountId, enumtype);
                return entities;
            }
            catch (ApiBusinessException ex)
            {
                LogsInfo.WriteLog("Error ApiBusinessException;", ex);
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                LogsInfo.WriteLog("Error Exception;", ex);
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public string Update(string id, SaleBE sale)
        {
            try
            {
                var entities = _repo.Update(id, _maapper.Map<Sale>(sale));
                return entities;
            }
            catch (ApiBusinessException ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public string UpdateWithLegit(SaleWithLogitDto dto)
        {
            try
            {
                var entities = _repo.UpdateWithLegit(_maapper.Map<SaleWithLogit>(dto));
                return entities;
            }
            catch (ApiBusinessException ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }
    }
}
