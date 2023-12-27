using ApplicationView.DataModel.Context;
using ApplicationView.DataModel.Entities;
using ApplicationView.DataModel.Repositories.IRepository;
using ApplicationView.DataModel.SPEntities;
using ApplicationView.Resolver.Enums;
using ApplicationView.Resolver.HelperError.Handlers;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Resolver.log;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ApplicationView.DataModel.Repositories.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly DbGestionStockContext _context;
        public SaleRepository(DbGestionStockContext context)
        {
            _context = context;
        }
        public IEnumerable<SaleDetailEntityDto> Create(Sale sale, string lotId)
        {
            try
            {
                if (sale == null)
                    throw new ApiBusinessException("3000", "No se pudo realizar la venta", System.Net.HttpStatusCode.NotFound, "Http");
                using (var db = new DbGestionStockContext())
                {
                    using (var ctx = db.Database.GetDbConnection())
                    {
                        try
                        {
                            ctx.Open();
                            sale.Id = Guid.NewGuid().ToString();
                            sale.SaleDetail[0].Id = Guid.NewGuid().ToString();
                            var values = new
                            {
                                isfirst = 0,
                                saleId = sale.Id,
                                lotId = lotId,
                                SaleType = CashierState.GetStateCashier(1),
                                saledetailId = sale.SaleDetail[0].Id,
                                openWorkTurnId = sale.OpenWorkTurnId,
                                AccountId = sale.AccountId,
                                PaymentTypeId = sale.PaymentTypeId,
                                Total = 0.0,
                                price = sale.SaleDetail.FirstOrDefault().price,
                                productId = sale.SaleDetail.FirstOrDefault().productId,
                                quantity = sale.SaleDetail.FirstOrDefault().quantity
                            };
                            IEnumerable<SaleDetailEntityDto> entity = ctx.Query<SaleDetailEntityDto>("[dbo].[Sp_Insert_Sale]", values, commandType: CommandType.StoredProcedure);
                            if (entity.Any())
                            {
                                var resulterror = entity.Where(u => u.ErrorMessage == "No tiene stock para ese producto.").ToList();
                                if (resulterror.Any())
                                {
                                    ctx.Close();
                                    throw new ApiBusinessException("3000", entity.FirstOrDefault().ErrorMessage, System.Net.HttpStatusCode.NotFound, "Http");
                                }
                            }
                            ctx.Close();
                            return entity;
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
        public List<Sale> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count) => throw new NotImplementedException();
        public List<PaymentType> GetAllPaymentType(int state)
        {
            try
            {
                var entities = _context.PaymentTypes.Where(u => u.state == state && u.FinalDate == null);  
                return entities.ToList();
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

        public IEnumerable<SearchSaleSP> GetAllSaleHistoric(DateTime datefrom, DateTime dateto, string user, int page, int pageSize)        
        {
            try
            {                             
                var values = new
                {
                    user= user,
                    datefrom = datefrom,
                    dateto = dateto,
                    page = page,
                    pageSize = pageSize
                };
                IEnumerable<SearchSaleSP> entity = _context.Database.GetDbConnection().Query<SearchSaleSP>("[dbo].[Sp_Search_Pay_By_Day]", values, commandType: CommandType.StoredProcedure);
                return entity;
            }
            catch (ApiBusinessException ex)
            {
                //LogsInfo.WriteLog("ApiBusinessException repo ", ex);
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                //LogsInfo.WriteLog("Exception repo ", ex);
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public ClossCashier GetCashier(string AccountId)
        {
            try
            {
                var values = new
                {
                    AccountId = AccountId
                };
                ClossCashier resp = null;
                IEnumerable<ClossCashierSP> entity = _context.Database.GetDbConnection().Query<ClossCashierSP>("[dbo].[Sp_Sale_By_Day]", values, commandType: CommandType.StoredProcedure);
                if (entity.Any())
                {
                    resp = new ClossCashier();
                    resp.Cash = entity.Where(u => u.TypePay == "Efectivo").Sum(u => u.AmountSold);
                    resp.ElectronicPay = entity.Where(u => u.TypePay == "Pago Electronico").Sum(u => u.AmountSold);
                    resp.Started = entity.FirstOrDefault().Started;
                }
                return resp;
            }
            catch (ApiBusinessException ex)
            {
                //LogsInfo.WriteLog("GetCashier repo ", ex);
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                //LogsInfo.WriteLog("Exception repo ", ex);
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public ClossCashier GetAccountredemption(string AccountId, string OpenWorkTurnid)
        {
            try
            {
                var values = new
                {
                    AccountId = AccountId,
                    OpenWorkTurnid = OpenWorkTurnid
                };
                ClossCashier resp = null;
                IEnumerable<ClossCashierSP> entity = _context.Database.GetDbConnection().Query<ClossCashierSP>("[dbo].[Sp_Sale_By_Turn]", values, commandType: CommandType.StoredProcedure);
                if (entity.Any())
                {
                    resp = new ClossCashier();
                    resp.Cash = entity.Where(u => u.TypePay == "Efectivo").Sum(u => u.AmountSold);
                    resp.ElectronicPay = entity.Where(u => u.TypePay == "Pago Electronico").Sum(u => u.AmountSold);
                    resp.Started = entity.FirstOrDefault().Started;
                }
                return resp;
            }
            catch (ApiBusinessException ex)
            {
                //LogsInfo.WriteLog("GetCashier repo ", ex);
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                //LogsInfo.WriteLog("Exception repo ", ex);
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }
        public IEnumerable<SearchSaleSP> GetAllSaleHistoricExport(DateTime datefrom, DateTime dateto, string turn)
        {
            try
            {
                var values = new
                {
                    turnId = turn,
                    datefrom = datefrom,
                    dateto = dateto
                };

                IEnumerable<SearchSaleSP> entity = _context.Database.GetDbConnection().Query<SearchSaleSP>("[dbo].[Sp_Export_sale]", values, commandType: CommandType.StoredProcedure);

                return entity;
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

        public List<Turns> GetAllTurn()
        {
            try
            {
                var result = _context.Turns.Where(u => u.state == (Int32)StateEnum.Activeted && u.FinalDate == null).ToList();
                return result;
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

        public Sale GetById(string id)
        {
            try
            {
                var result = _context.Sales.Include(u => u.SaleDetail).SingleOrDefault(u => u.Id == id && u.state == (Int32)StateEnum.Activeted && u.FinalDate == null);
                return result;
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

        public List<SaleDetailEntityDto> GetReprintTicket(string nroticket)
        {
            try
            {
                if (nroticket == null)
                    throw new ApiBusinessException("3000", "Debe ingresa el numero de tiket", System.Net.HttpStatusCode.NotFound, "Http");
                using (var db = new DbGestionStockContext())
                {
                    using (var ctx = db.Database.GetDbConnection())
                    {
                        try
                        {
                            ctx.Open();
                            var values = new
                            {
                                InvoiceCode = Convert.ToInt32(nroticket)
                            };
                            IEnumerable<SaleDetailEntityDto> entity = ctx.Query<SaleDetailEntityDto>("[dbo].[Sp_Reprint_Ticket]", values, commandType: CommandType.StoredProcedure);
                            ctx.Close();
                            return entity.ToList();
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
            catch (ApiBusinessException ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public string RemoveNoneSale(SaleDetail saleDetailId, string LotId, string accountId, DeleteSaleEnum enumtype)
        {
            try
            {
                var entity = _context.Sales.SingleOrDefault(u => u.Id == saleDetailId.SaleId && u.FinalDate == null && u.state == (Int32)StateEnum.Activeted);
                
                if (entity == null)
                    throw new ApiBusinessException("3000", "NO hay venta para eliminar", System.Net.HttpStatusCode.NotFound, "Http");
                if (DeleteSaleEnum.Admin == enumtype)
                {
                    var SaleDetail = _context.SaleDetails.SingleOrDefault(u => u.SaleId == entity.Id && u.Id == saleDetailId.Id && u.FinalDate == null && u.state == (Int32)StateEnum.Activeted);
                    if (SaleDetail!= null)
                    {
                        var lot = _context.Lots.SingleOrDefault(u => u.Id == LotId && u.state == 1);
                        lot.Stock++;

                        var history = new History()
                        {
                            Id = Guid.NewGuid().ToString(),
                            OptionId = "Id de venta: " + SaleDetail.SaleId + " Id de detalle de venta: " + SaleDetail.Id,
                            AccountId = accountId,
                            ModuleAction = "Modulo de venta de producto",
                            Action = "Eliminacion de venta por el admin",
                            CreatedDate = DateTime.Now,
                            TypeId = (Int32)HistoricEnum.Sale,
                            state = (Int32)StateEnum.Activeted
                        };
                        if (SaleDetail.quantity > 1)
                            SaleDetail.quantity = SaleDetail.quantity - 1;
                        else
                        {
                            var resp = _context.SaleDetails.Where(u => u.SaleId == saleDetailId.SaleId).ToList();
                            if (resp.Count > 1)
                            {
                                _context.SaleDetails.Remove(SaleDetail);
                            }
                            else
                            {
                                _context.SaleDetails.Remove(SaleDetail);
                                _context.Sales.Remove(entity);
                            }
                        }
                            
                        _context.SaveChanges();
                        return "El producto fue dado de baja con exito!";
                    }
                }
                else
                {
                    var SaleDetail = _context.SaleDetails.Where(u => u.SaleId == entity.Id && u.FinalDate == null && u.state == (Int32)StateEnum.Activeted);
                    if (!SaleDetail.Any())
                        throw new ApiBusinessException("3000", "NO hay venta para eliminar", System.Net.HttpStatusCode.NotFound, "Http");

                    foreach (var item in SaleDetail)
                    {
                        var entitycontext = _context.Lots.FirstOrDefault(u => u.ProductId == item.productId && u.Stock >= 0 && u.ExpiredDate >= DateTime.Now && u.state == 1);
                       
                        if (entitycontext != null)
                            entitycontext.Stock += item.quantity;
                    }
                    var history = new History()
                    {
                        Id = Guid.NewGuid().ToString(),
                        OptionId = entity.Id,
                        AccountId = accountId,
                        ModuleAction = "Modulo de venta de producto",
                        Action = "Eliminacion de ventas por cerrar la pantalla de ventas",
                        CreatedDate = DateTime.Now,
                        TypeId = (Int32)HistoricEnum.Sale,
                        state = (Int32)StateEnum.Activeted
                    };
                    _context.Add(history);
                    var entitysaledetail = _context.SaleDetails.Where(u => u.SaleId == entity.Id);
                    var entitysale = _context.Sales.SingleOrDefault(u => u.Id == entity.Id);
                    if (entitysaledetail.Any())
                        _context.SaleDetails.RemoveRange(entitysaledetail);
                    if (entitysale != null)
                        _context.Sales.Remove(entitysale);
                }
                _context.SaveChanges();
                return "El producto fue dado de baja con exito!";
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

        public string Update(string id, Sale sale)
        {
            try
            {
                var entity = _context.Sales.Find(id);
                if (entity == null)
                    throw new ApiBusinessException("3000", "No se pudo cerrar la venta", System.Net.HttpStatusCode.NotFound, "Http");
               
                entity.PaymentTypeId = sale.PaymentTypeId;
                entity.Total = sale.Total;
                entity.finalizeSale = sale.finalizeSale;
                entity.CodeLotePayment = sale.CodeLotePayment;
                entity.ModifiedDate = DateTime.Now;
                entity.state = (Int32)SaleEnum.PayFinished;

                _context.SaveChanges();

                return "La venta fue realizado con exito!";
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

        public string UpdateWithLegit(SaleWithLogit entity)
        {
            try
            {
                var values = new
                {
                    SaleId = entity.Sale.Id,
                    LegitId = Guid.NewGuid().ToString(),
                    AccountId = entity.Sale.AccountId,
                    PaymentTypeId = entity.Sale.PaymentTypeId,
                    Total = entity.Sale.Total,
                    TotalLegit = entity.Legit.Total,
                    FullName = entity.Legit.FullName,
                    Address = entity.Legit.Address
                };

                _context.Database.GetDbConnection().Query("[dbo].[Sp_Sale_WithLegit]", values, commandType: CommandType.StoredProcedure);

                return "";
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
