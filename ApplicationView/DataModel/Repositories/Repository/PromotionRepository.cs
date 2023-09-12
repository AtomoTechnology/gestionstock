using ApplicationView.DataModel.Context;
using ApplicationView.DataModel.Entities;
using ApplicationView.DataModel.Repositories.IRepository;
using ApplicationView.Resolver.Enums;
using ApplicationView.Resolver.HelperError.Handlers;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Resolver.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Repositories.Repository
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly DbGestionStockContext _context;
        public PromotionRepository(DbGestionStockContext context)
        {
            _context = context;
        }
        public string Create(Promotion entity)
        {
            try
            {
                if (entity == null)
                    throw new ApiBusinessException("5000", "falta datos para la promocion en los campos obligatorios", System.Net.HttpStatusCode.NotFound, "Http");
                
                if (String.IsNullOrEmpty(entity.PromoName))
                    throw new ApiBusinessException("5000", "Debe ingresar el nombre de la promocion", System.Net.HttpStatusCode.NotFound, "Http");
                
                if (entity.FinalPromotion <= DateTime.Now)
                    throw new ApiBusinessException("5000", "La fecha final de la promocion no puede ser manor o igual que hoy", System.Net.HttpStatusCode.NotFound, "Http");
                
                if (!entity.PromotionDetails.Any())
                    throw new ApiBusinessException("5000", "Falta cargar producto para la promocion", System.Net.HttpStatusCode.NotFound, "Http");

                var ispromo = _context.Promotions.Where(u => u.PromoName == entity.PromoName);
                if (ispromo.Any())
                    throw new ApiBusinessException("5000", "Existe una promocion con ese nombre", System.Net.HttpStatusCode.NotFound, "Http");
                var promo = _context.Promotions;
                string finalcode;
                if (!promo.Any())
                    finalcode = "Pro-100";
                else
                {
                    string cod = promo.LastOrDefault().PromoCode.Replace("Pro-", "");
                    finalcode = "Pro-" + Convert.ToString((Convert.ToInt32(cod) + 1));
                }
                if (entity.untilstockexhausted)
                    entity.FinalPromotion = null;

                entity.Id = Guid.NewGuid().ToString();
                entity.CreatedDate = DateTime.Now;
                entity.FinalDate = null;
                entity.PromoCode = finalcode;
                entity.state = (Int32)StateEnum.Activeted;

                foreach (var item in entity.PromotionDetails)
                {
                    item.Id = Guid.NewGuid().ToString();
                    item.PromotionId = entity.Id;
                    item.CreatedDate = DateTime.Now;
                    item.FinalDate = null;
                    item.state = (Int32)StateEnum.Activeted;
                }

                _context.Add(entity);
                _context.SaveChanges();
                return "La Promocion fue guardada con exito - " + entity.PromoCode;
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
                var entity = _context.Categories.SingleOrDefault(u => u.Id == id && u.FinalDate == null);
                if (entity == null)
                    throw new ApiBusinessException("5000", "NO existe esa promocion", System.Net.HttpStatusCode.NotFound, "Http");

                entity.FinalDate = DateTime.Now;
                entity.state = (Int32)StateEnum.Deleted;

                _context.SaveChanges();
                return "La promocion fue dada de baja con exito!";
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
        public List<Promotion> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                var entities = _context.Promotions.Where(u => u.state == state && (u.PromoName == name || string.IsNullOrEmpty(name)));
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
        public Promotion GetById(string id)
        {
            try
            {
                var result = _context.Promotions.SingleOrDefault(u => u.Id == id && u.state == (Int32)StateEnum.Activeted);
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

        public List<PromotionDetail> GetDetailPromoById(string promoId)
        {
            try
            {
                var result = _context.PromotionDetails.Where(u => u.PromotionId == promoId && u.state == (Int32)StateEnum.Activeted).ToList();
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

        public string Update(string id, Promotion entity)
        {
            try
            {
                var promo = _context.Promotions.Find(id);
                if (entity == null)
                    throw new ApiBusinessException("3000", "NO existe esa promocion", System.Net.HttpStatusCode.NotFound, "Http");

                promo.Description = entity.Description;
                promo.PromoName = entity.PromoName;
                promo.FinalPromotion = entity.FinalPromotion;
                promo.Price = entity.Price; 

                if (entity.untilstockexhausted)
                    entity.FinalPromotion = null;

                if (promo.PromotionDetails.Any())
                {
                    var detail = _context.PromotionDetails.Where(u => u.Id == id);
                    //if (detail.Any())
                    //{
                        var diff = promo.PromotionDetails.Except(entity.PromotionDetails).ToList();
                        if (diff.Any())
                            _context.PromotionDetails.AddRange(diff);
                    //}
                }
                _context.SaveChanges();

                return "La Promocion fue modificada con exito!";
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
