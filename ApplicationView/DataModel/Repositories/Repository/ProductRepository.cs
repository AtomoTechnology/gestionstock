using ApplicationView.DataModel.Context;
using ApplicationView.DataModel.Entities;
using ApplicationView.DataModel.Repositories.IRepository;
using ApplicationView.Resolver.Enums;
using ApplicationView.Resolver.HelperError.Handlers;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Resolver.log;
using ApplicationView.Resolver.QueryableExtensions;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ApplicationView.DataModel.Repositories.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DbGestionStockContext _context;
        public ProductRepository(DbGestionStockContext context)
        {
            _context = context;
        }
        public string Create(Lot lot)
        {
            try
            {
                if (lot == null)
                    throw new ApiBusinessException("6000", "falta datos del productoo  en los campos obligatorios", System.Net.HttpStatusCode.NotFound, "Http");
                if (String.IsNullOrEmpty(lot.Product.ProductName))
                    throw new ApiBusinessException("6000", "Debe ingresar el nombre del producto", System.Net.HttpStatusCode.NotFound, "Http");
                if (String.IsNullOrEmpty(lot.Product.ProductCode))
                    throw new ApiBusinessException("6000", "Debe ingresar el código del producto", System.Net.HttpStatusCode.NotFound, "Http");
                if (lot.Product.PurchasePrice <= 0)
                    throw new ApiBusinessException("6000", "Debe ingresar el precio de compra del producto", System.Net.HttpStatusCode.NotFound, "Http");
                if (lot.Product.SalePrice <= 0)
                    throw new ApiBusinessException("6000", "Debe ingresar el precio de venta", System.Net.HttpStatusCode.NotFound, "Http");

                IQueryable<Lot> lote = _context.Lots.Where(u => u.LotCode == lot.LotCode);
                IQueryable<Product> code = _context.Products.Where(u => u.ProductCode == lot.Product.ProductCode);
                IQueryable<Product> ProductName = _context.Products.Where(u => u.ProductName == lot.Product.ProductName);

                if (ProductName.Any())
                    throw new ApiBusinessException("3000", "Ya existe un producto con ese nombre", System.Net.HttpStatusCode.NotFound, "Http");
                if (code.Any())
                    throw new ApiBusinessException("3000", "Este codigo de producto ya pertenezca a otro producto.\n Le corresponde al producto: " + "'" + code.FirstOrDefault().ProductName + "'", System.Net.HttpStatusCode.NotFound, "Http");
                if (lote.Any())
                    throw new ApiBusinessException("3000", "Este número de lote ya pertenezca a otro producto.\n Le corresponde al producto: " + "'" + lote.FirstOrDefault().Product.ProductName + "'", System.Net.HttpStatusCode.NotFound, "Http");


                lot.Product.Id = Guid.NewGuid().ToString();
                lot.Product.CreatedDate = DateTime.Now;
                lot.Product.FinalDate = null;
                lot.Product.state = (Int32)StateEnum.Activeted;


                lot.Id = Guid.NewGuid().ToString();
                lot.ProductId = lot.Product.Id;
                lot.CreatedDate = DateTime.Now;
                lot.FinalDate = null;
                lot.state = (Int32)StateEnum.Activeted;

                _context.Add(lot);
                _context.SaveChanges();
                return "El producto fue guardado con exito";
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
                var entity = _context.Products.SingleOrDefault(u => u.Id == id && u.FinalDate == null);
                if (entity == null)
                    throw new ApiBusinessException("3000", "NO existe ee producto", System.Net.HttpStatusCode.NotFound, "Http");

                entity.FinalDate = DateTime.Now;
                entity.state = (Int32)StateEnum.Deleted;

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
        public List<Product> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                var entities = _context.Products.Where(u => (u.state == state && u.FinalDate == null) && (u.ProductName == name || string.IsNullOrEmpty(name)));
                count = entities.Count();
                int skipAmount = 0;
                if (page > 0)
                    skipAmount = top * (page - 1);

                entities = entities
               .OrderByPropertyOrField(orderBy, ascending)
               .Skip(skipAmount)
               .Take(top);

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
        public Product GetById(string id)
        {
            try
            {
                var result = _context.Products.SingleOrDefault(u => u.Id == id && u.state == (Int32)StateEnum.Activeted);
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

        public ProductWithStock SearchProducByCode(string codeRef, bool ischeckprice = false)
        {
            try
            {
                using (var db = new DbGestionStockContext())
                {
                    using (var ctx = db.Database.GetDbConnection())
                    {
                        try
                        {
                            ctx.Open();
                            List<ProductWithStock> entity;                            

                            if (codeRef.Contains("Pro"))
                            {
                                var values = new { codeRef = codeRef };
                                entity = ctx.Query<ProductWithStock>("[dbo].[Sp_Get_Product_CodRef_Pro]", values, commandType: CommandType.StoredProcedure).ToList();
                            }
                            else
                            {
                                var values = new{ codeRef = codeRef };
                                entity = ctx.Query<ProductWithStock>("[dbo].[Sp_Get_Product_CodRef]", values, commandType: CommandType.StoredProcedure).ToList();
                            }
                            if (entity.Any())
                            {
                                int sum = entity.Sum(u => u.Stock);
                                var result = entity.FirstOrDefault(); 
                                result.Stock = sum;
                                if (result.Stock == 0 && !ischeckprice)
                                    throw new ApiBusinessException("3000", "Productto sin stock", System.Net.HttpStatusCode.NotFound, "Http");
                                ctx.Close();
                                return result;
                            }
                            else
                                throw new ApiBusinessException("3000", "NO existe producto para ese codigo", System.Net.HttpStatusCode.NotFound, "Http"); ;
                        }
                        catch (ApiBusinessException ex)
                        {
                            ctx.Close();
                            throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
                        }
                        catch (Exception ex)
                        {
                            ctx.Close();
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

        public string Update(string id, Product product)
        {
            try
            {
                var entity = _context.Products.Find(id);
                if (entity == null)
                    throw new ApiBusinessException("3000", "NO existe ese producto", System.Net.HttpStatusCode.NotFound, "Http");    
                
                entity.Description = product.Description;
                entity.ProductName = product.ProductName;
                entity.CategoryId = product.CategoryId;
                entity.ProviderId = product.ProviderId;

                _context.SaveChanges();
                return "El producto fue modificado con exito!";
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

        public string UpdatePrices(string id, string accountId, decimal psale, decimal ppurchase, UpdatePriceEnum priceenum, bool ispurchaseprice = false)
        {
            string productName = string.Empty;
            List<HistoryPrice> historicprice = null;
            try
            {
                if (UpdatePriceEnum.All == priceenum)
                {
                    var entityall = _context.Products.Where(u => u.state == (Int32)StateEnum.Activeted && u.FinalDate == null).ToList();
                    if (!entityall.Any())
                        throw new ApiBusinessException("3000", "No hay producto para actualizar", System.Net.HttpStatusCode.NotFound, "Http");
                    historicprice = new List<HistoryPrice>();
                    foreach (var item in entityall)
                    {
                        historicprice.Add(new HistoryPrice()
                        {
                            Id = Guid.NewGuid().ToString(),
                            ProductId = item.Id,
                            AccountId = accountId,
                            CreatedDate = DateTime.Now,
                            PricePurchase = item.PurchasePrice,
                            PriceSale = item.SalePrice,
                            typeUpdate =(Int32)priceenum,
                            state = (Int32)StateEnum.Activeted,
                        });

                        if (ispurchaseprice == true)
                            item.PurchasePrice = item.PurchasePrice * (1 + (ppurchase / 100));
                        item.SalePrice = item.SalePrice * (1 + (psale / 100));
                    }
                }
                else
                {
                    var entity = _context.Products.Find(id);
                    if (entity == null)
                        throw new ApiBusinessException("3000", "NO existe ese producto", System.Net.HttpStatusCode.NotFound, "Http");
                    
                    historicprice = new List<HistoryPrice>();


                    historicprice.Add(new HistoryPrice()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProductId = entity.Id,
                        AccountId = accountId,
                        CreatedDate = DateTime.Now,
                        PricePurchase = entity.PurchasePrice,
                        PriceSale = entity.SalePrice,
                        typeUpdate = (Int32)priceenum,
                        state = (Int32)StateEnum.Activeted,
                    });
                   
                    productName = entity.ProductName;
                    if (ispurchaseprice == true)
                        entity.PurchasePrice = ppurchase;
                    entity.SalePrice = psale;
                }
                _context.AddRange(historicprice);
                _context.SaveChanges();
                var resp = (UpdatePriceEnum.All == priceenum || ispurchaseprice);
                var ms = "El precio para el producto " + "* " + productName + " *" + " se actualizó correctamente. \n Deseas seguir actualizando otro precio de producto?";
                return (resp ? "Los precios fueron actualizados con exitos!" : ms);
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
                var result = _context.Lots.SingleOrDefault(u => u.LotCode == lotCode);
                if (result == null)
                    return true;
                
                if (!result.ProductId.Equals(productId))
                    throw new ApiBusinessException("3000", "Este número de lote no pertenezca a ese producto.\n Le corresponde al producto: "+ "'" + result.Product.ProductName + "'" , System.Net.HttpStatusCode.NotFound, "Http");

                if (result.state == (Int32)StateEnum.Expired)
                    throw new ApiBusinessException("3000", "Esta vencido el producto para ese lote", System.Net.HttpStatusCode.NotFound, "Http");

                if (result.ExpiredDate < DateTime.Now)
                {
                    if (result.state == (Int32)StateEnum.Activeted)
                    {
                        result.state = (Int32)StateEnum.Expired;
                        result.FinalDate = DateTime.Now;
                        _context.SaveChanges();
                    }
                    throw new ApiBusinessException("3000", "Esta vencido el producto para ese lote", System.Net.HttpStatusCode.NotFound, "Http");
                }
                return true;
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

        public string UpdateStock(string id, UpdateStockProduct stock) {
            try
            {
                var entity = _context.Products.Find(id);
                if (entity == null)
                    throw new ApiBusinessException("3000", "NO existe ese producto", System.Net.HttpStatusCode.NotFound, "Http");
                if (stock.IsNewLote)
                {
                    var isnewlote = _context.Lots.Where(u => u.LotCode == stock.NewLote).ToList();
                    if (isnewlote.Any())
                        throw new ApiBusinessException("3000", "Ese lote pertenece a otro producto", System.Net.HttpStatusCode.NotFound, "Http");
                    var isexpired = _context.Lots.Where(u => u.ProductId == id && u.state == (Int32)StateEnum.Activeted && u.ExpiredDate < DateTime.Now);

                    if (isexpired.Any())
                    {
                        foreach (var item in isexpired)
                        {
                            item.state = (Int32)StateEnum.Expired;
                            item.ModifiedDate = DateTime.Now;
                            item.FinalDate = DateTime.Now;
                        }
                    }

                    var lot = new Lot()
                    {
                        ExpiredDate = stock.ExpiredDate,
                        CreatedDate = DateTime.Now,
                        Id = Guid.NewGuid().ToString(),
                        LotCode = stock.NewLote,
                        ProductId = id,
                        state = (Int32)StateEnum.Activeted,
                        Stock = stock.stock
                    };

                    var history = new History()
                    {
                        Id = Guid.NewGuid().ToString(),
                        OptionId = id,
                        AccountId = stock.AccountId,
                        ModuleAction = "Modulo de actualizar stock de producto",
                        Action = "Actualizacion de stock, el stock antes de actualizar es: " + 0,
                        CreatedDate = DateTime.Now,
                        TypeId = (Int32)HistoricEnum.Product,
                        state = (Int32)StateEnum.Activeted
                    };

                    _context.Histories.Add(history);
                    _context.Lots.Add(lot);

                }
                else
                {
                    var lote = _context.Lots.Include(p => p.Product).Where(u => u.LotCode == stock.NewLote);
                    if (lote == null)
                        throw new ApiBusinessException("3000", "No hay producto para ese lote", System.Net.HttpStatusCode.NotFound, "Http");

                    if (lote.Any())
                    {
                        foreach (var item in lote)
                        {
                            if (item.state == (Int32)StateEnum.Expired)
                                throw new ApiBusinessException("3000", "Esta vencido el producto para ese lote", System.Net.HttpStatusCode.NotFound, "Http");

                            if (item.ExpiredDate < DateTime.Now)
                            {
                                if (item.state == (Int32)StateEnum.Activeted)
                                {
                                    item.state = (Int32)StateEnum.Expired;
                                    item.FinalDate = DateTime.Now;
                                    _context.SaveChanges();
                                }
                                throw new ApiBusinessException("3000", "Esta vencido el producto para ese lote", System.Net.HttpStatusCode.NotFound, "Http");
                            }
                            if (!item.ProductId.Equals(id))
                                throw new ApiBusinessException("3000", "Este número de lote no pertenezca a ese producto.\n Le corresponde al producto: " + "'" + item.Product.ProductName + "'", System.Net.HttpStatusCode.NotFound, "Http");
                        }
                    }

                    var ent = _context.Lots.SingleOrDefault(u => u.LotCode == stock.NewLote);

                    var history = new History()
                    {
                        Id = Guid.NewGuid().ToString(),
                        OptionId = id,
                        AccountId = stock.AccountId,
                        ModuleAction = "Modulo de actualizar stock de producto",
                        Action = "Actualizacion de stock, el stock antes de actualizar es: " + ent.Stock,
                        CreatedDate = DateTime.Now,
                        TypeId = (Int32)HistoricEnum.Product,
                        state = (Int32)StateEnum.Activeted
                    };

                    ent.Stock += stock.stock;
                    ent.ModifiedDate = DateTime.Now;

                    _context.Histories.Add(history);
                }

                _context.SaveChanges();
                return "El el stock del producto "+ entity.ProductName +" fue actualizado con exito!";
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

        public List<Product> GetAllExpiredProduct(int state, int page, int top, string orderBy, string ascending, DateTime datefrom, DateTime dateto, ref int count) 
        {
            try
            {
                var entities = _context.Products.Include(u => u.Lots).Where(u => u.Lots.Any(p => p.ExpiredDate >= datefrom && p.ExpiredDate <= dateto));
                count = entities.Count();
                var skipAmount = 0;
                if (page > 0)
                    skipAmount = top * (page - 1);

                entities = entities
               .OrderByPropertyOrField(orderBy, ascending)
               .Skip(skipAmount)
               .Take(top);

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

        public List<Product> GetAllSearch(int state, int page, int top, string orderBy, string ascending, string name, int option, ref int count)
        {
            try
            {
                IQueryable<Product> entities;
                if (option == 1)
                    entities = _context.Products.Include(u => u.Lots).Where(u => (u.state == state && u.FinalDate == null) && u.ProductName == name);
                else
                    entities = _context.Products.Include(u => u.Lots).Where(u => (u.state == state && u.FinalDate == null) && u.ProductCode == name);

                count = entities.Count();
                var skipAmount = 0;
                if (page > 0)
                    skipAmount = top * (page - 1);

                entities = entities
               .OrderByPropertyOrField(orderBy, ascending)
               .Skip(skipAmount)
               .Take(top);

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

        public Lot GetLotByIdProduct(string id)
        {
            try
            {
                var result = _context.Lots.Where(u => u.ProductId == id && u.Stock > 0 && u.ExpiredDate > DateTime.Now && u.state == (Int32)StateEnum.Activeted);
                if (result.Any())
                    return result.FirstOrDefault();
                return null;
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
                var result = _context.Sales.ToList();
                if (result.Any())
                    return result.Max(u => u.InvoiceCode) + 1;
                return 1;
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
