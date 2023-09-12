using ApplicationView.BusnessEntities.BE;
using ApplicationView.Resolver.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataService.Iservice
{
    public interface IProductService
    {
        List<ProductBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        List<ProductBE> GetAllSearch(int state, int page, int top, string orderBy, string ascending, string name, int option, ref int count);
        ProductBE GetById(string id);
        LotBE GetLotByIdProduct(string id);
        ProductWithStockBE SearchProducByCode(string codeRef, bool ischeckprice = false);
        Int64 LastFactNro();
        String Create(LotBE lot);
        String Update(string id, ProductBE product);
        String UpdateStock(string id, UpdateStockProductBe stock);
        Boolean SearchExpiredProductByLotCode(string lotCode, string productId);
        String UpdatePrices(string id, string accountId, decimal porcentsale, decimal porcentpurchase, UpdatePriceEnum priceenum, bool ispurchaseprice = false);
        String Delete(string id);
        List<ProductBE> GetAllExpiredProduct(int state, int page, int top, string orderBy, string ascending, DateTime datefrom, DateTime dateto, ref int count);
    }
}
