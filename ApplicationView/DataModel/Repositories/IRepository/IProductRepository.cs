using ApplicationView.DataModel.Entities;
using ApplicationView.Resolver.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataModel.Repositories.IRepository
{
    public interface IProductRepository
    {
        List<Product> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        List<Product> GetAllSearch(int state, int page, int top, string orderBy, string ascending, string name, int option, ref int count);
        Product GetById(string id);
        Lot GetLotByIdProduct(string id);
        ProductWithStock SearchProducByCode(string codeRef, bool ischeckprice = false);
        String Create(Lot product);
        String Update(string id, Product product);
        string UpdateStock(string id, UpdateStockProduct stock);
        Boolean SearchExpiredProductByLotCode(string lotCode, string productId);
        Int64 LastFactNro();
        String UpdatePrices(string id, string accountId, decimal porcentsale, decimal porcentpurchase, UpdatePriceEnum priceenum, bool ispurchaseprice = false);
        String Delete(string id);
        List<Product> GetAllExpiredProduct(int state, int page, int top, string orderBy, string ascending, DateTime datefrom, DateTime dateto, ref int count);
    }
}
