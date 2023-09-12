using ApplicationView.DataModel.Context;
using ApplicationView.DataModel.Entities;
using ApplicationView.DataModel.Repositories.IRepository;
using ApplicationView.Resolver.Enums;
using ApplicationView.Resolver.HelperError.Handlers;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Resolver.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Repositories.Repository
{
    public class LegitRepository : ILegitRepository
    {
        private readonly DbGestionStockContext _context;
        public LegitRepository(DbGestionStockContext context)
        {
            _context = context;
        }
        public string Create(Legit entity)
        {
            try
            {
                if (entity == null)
                    throw new ApiBusinessException("5000", "falta datos de fiado en los campos obligatorios", System.Net.HttpStatusCode.NotFound, "Http");
                if (String.IsNullOrEmpty(entity.FullName))
                    throw new ApiBusinessException("5000", "Debe ingresar el nombre de la persona para la fiar", System.Net.HttpStatusCode.NotFound, "Http");

                entity.Id = Guid.NewGuid().ToString();
                entity.CreatedDate = DateTime.Now;
                entity.FinalDate = null;
                entity.state = (Int32)StateEnum.Activeted;

                _context.Add(entity);
                _context.SaveChanges();
                return "El fiado fue guardado con exito";
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
                var entity = _context.Legit.SingleOrDefault(u => u.Id == id && u.FinalDate == null);
                if (entity == null)
                    throw new ApiBusinessException("5000", "NO existe esa fiar", System.Net.HttpStatusCode.NotFound, "Http");

                entity.FinalDate = DateTime.Now;
                entity.state = (Int32)StateEnum.Deleted;

                _context.SaveChanges();
                return "El fiar fue dado de baja con exito!";
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
        public List<Legit> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                var entities = _context.Legit.Include(u => u.Account).Where(u => u.state == state && (u.FullName.Contains(name) || string.IsNullOrEmpty(name)));
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
        public Legit GetById(string id)
        {
            try
            {
                var result = _context.Legit.SingleOrDefault(u => u.Id == id && u.state == (Int32)StateEnum.Activeted && u.FinalDate != null);
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

        public string PayLegit(List<Legit> be)
        {
            try
            {
                List<Legit> ent = new List<Legit>();
                foreach (var item in be)
                {
                    var entity = _context.Legit.Find(item.Id);

                    if (entity.Total == item.Total)
                    {
                        var sale = _context.Sales.Find(entity.SaleId);
                        sale.state = (Int32)SaleEnum.PayFinished;
                        entity.state = (int)StateEnum.PayLegit;
                    }

                    entity.Total = item.Total;
                    entity.FinalDate = DateTime.Now;
                    entity.ModifiedDate = DateTime.Now;
                }

                _context.SaveChanges();
                return "El fiar fue modificada con exito!";
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

        public string Update(string id, Legit leg)
        {
            try
            {
                var entity = _context.Legit.Find(id);
                if (entity == null)
                    throw new ApiBusinessException("3000", "NO existe esa fiar", System.Net.HttpStatusCode.NotFound, "Http");

                entity.SaleId = leg.SaleId;
                entity.AccountId = leg.AccountId;
                entity.Total = leg.Total;
                entity.FullName = leg.FullName;
                entity.Address = leg.Address;

                _context.SaveChanges();

                return "El fiar fue modificada con exito!";
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
