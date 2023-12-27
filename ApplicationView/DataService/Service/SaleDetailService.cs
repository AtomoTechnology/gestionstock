using ApplicationView.BusnessEntities.BE;
using ApplicationView.BusnessEntities.Dtos;
using ApplicationView.DataModel.Entities;
using ApplicationView.DataModel.Repositories.IRepository;
using ApplicationView.DataService.Iservice;
using ApplicationView.Resolver.HelperError.Handlers;
using ApplicationView.Resolver.HelperError.IExceptions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationView.DataService.Service
{
    public class SaleDetailService : ISaleDetailService
    {
        private readonly ISaleDetailRepoository _repo;
        private readonly IMapper _maapper;
        public SaleDetailService(ISaleDetailRepoository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }
        public List<SaleDetailDto> Create(SaleDetailBE saleDetail, string lotId)
        {
            try
            {
                var entity = _repo.Create(_maapper.Map<SaleDetail>(saleDetail), lotId).ToList();
                List<SaleDetailDto> dto = new List<SaleDetailDto>();
                if (entity.Count > 0)
                {
                    foreach (var item in entity)
                    { 
                        var resultitem = dto.Where(u => u.ProductCode == item.ProductCode).ToList();
                        if (resultitem.Count > 0 )
                        {
                            resultitem[0].quantity = resultitem[0].quantity + 1;
                        }
                        else
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
                                Subtotal = item.SalePrice * item.quantity,
                                CreatedDate = item.CreatedDate,
                                PaymentName = item.PaymentName
                            });
                        }                        
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
        public List<SaleDetailBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count) => throw new NotImplementedException();
        public SaleDetailBE GetById(string id) => throw new NotImplementedException();
        public List<SaleDetailDto> SearchAllDetailByCode(string saleCode)
        {
            try
            {
                var entities = _repo.SearchAllDetailByCode(saleCode);
                List<SaleDetailDto> be = new List<SaleDetailDto>();

                if (entities.Count > 0)
                {
                    foreach (var item in entities)
                    {
                        be.Add(new SaleDetailDto()
                        {
                            SaleId = item.SaleId,
                            Id = item.Id,
                            SalePrice = item.price,
                            productId = item.productId,
                            ProductName = item.Product.ProductName,
                            quantity = item.quantity,
                            InvoiceCode = item.Sale.InvoiceCode,
                            ProductCode = item.Product.ProductCode,
                            Subtotal = item.price * item.quantity
                        });
                    }
                }
                return be;
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
        public string Update(string id, SaleDetailBE saleDetail) => throw new NotImplementedException();
    }
}
