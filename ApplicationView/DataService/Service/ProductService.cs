using ApplicationView.BusnessEntities.BE;
using ApplicationView.DataModel.Entities;
using ApplicationView.DataModel.Repositories.IRepository;
using ApplicationView.DataService.Iservice;
using ApplicationView.Resolver.Enums;
using ApplicationView.Resolver.HelperError.Handlers;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Resolver.log;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataService.Service
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _maapper;
        public ProductService(IProductRepository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }

        public string Create(LotBE lot)
        {
            try
            {
                var entity = _repo.Create(_maapper.Map<Lot>(lot));
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
        public string Delete(string id)
        {
            try
            {
                var entity = _repo.Delete(id);
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
        public List<ProductBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                LogsInfo.WriteLog("Ingresa en el producto servicio", null);
                var entities = _repo.GetAll(state, page, top, orderBy, ascending, name, ref count);
                LogsInfo.WriteLog("Ingresa en el producto servicio after entity ", null);
                return _maapper.Map<List<ProductBE>>(entities);
            }
            catch (ApiBusinessException ex)
            {
                LogsInfo.WriteLog("ApiBusinessException product service ", ex);
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
            catch (Exception ex)
            {
                LogsInfo.WriteLog("Exception product service ", ex);
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public List<ProductBE> GetAllExpiredProduct(int state, int page, int top, string orderBy, string ascending, DateTime datefrom, DateTime dateto, ref int count)
        {
            try
            {
                var entities = _repo.GetAllExpiredProduct(state, page, top, orderBy, ascending, datefrom, dateto, ref count);
                return _maapper.Map<List<ProductBE>>(entities);
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

        public List<ProductBE> GetAllSearch(int state, int page, int top, string orderBy, string ascending, string name, int option, ref int count)
        {
            try
            {
                var entities = _repo.GetAllSearch(state, page, top, orderBy, ascending, name,option, ref count);
                return _maapper.Map<List<ProductBE>>(entities);
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

        public ProductBE GetById(string id)
        {
            try
            {
                var entities = _repo.GetById(id);
                return _maapper.Map<ProductBE>(entities);
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

        public LotBE GetLotByIdProduct(string id)
        {
            try
            {
                var entities = _repo.GetLotByIdProduct(id);
                return _maapper.Map<LotBE>(entities);
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

        public Int64 LastFactNro()
        {
            try
            {
                return _repo.LastFactNro();
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

        public bool SearchExpiredProductByLotCode(string lotCode, string productId)
        {
            try
            {
                var entities = _repo.SearchExpiredProductByLotCode(lotCode, productId);
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

        public ProductWithStockBE SearchProducByCode(string codeRef, bool ischeckprice = false)
        {
            try
            {
                var entities = _repo.SearchProducByCode(codeRef, ischeckprice);
                return _maapper.Map<ProductWithStockBE>(entities);
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

        public string Update(string id, ProductBE product)
        {
            try
            {
                var entities = _repo.Update(id, _maapper.Map<Product>(product));
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

        public string UpdatePrices(string id, string accountId, decimal porcentsale, decimal porcentpurchase, UpdatePriceEnum priceenum, bool ispurchaseprice = false)
        {
            try
            {
                var entities = _repo.UpdatePrices(id, accountId, porcentsale, porcentpurchase, priceenum, ispurchaseprice);
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

        public string UpdateStock(string id, UpdateStockProductBe stock)
        {
            try
            {
                var entities = _repo.UpdateStock(id, _maapper.Map<UpdateStockProduct>(stock));
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
