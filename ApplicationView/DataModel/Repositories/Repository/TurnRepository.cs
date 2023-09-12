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

namespace ApplicationView.DataModel.Repositories.Repository
{
    public class TurnRepository : ITurnRepository
    {
        private readonly DbGestionStockContext _context;
        public TurnRepository(DbGestionStockContext context)
        {
            _context = context;
        }
        public string Create(Turns turns)
        {
            try
            {
                if (turns == null)
                    throw new ApiBusinessException("2000", "falta datos del turno", System.Net.HttpStatusCode.NotFound, "Http");
                if (String.IsNullOrEmpty(turns.TurnName))
                    throw new ApiBusinessException("2000", "Debe ingresar el nombre del turno", System.Net.HttpStatusCode.NotFound, "Http");
                if (turns.DateFrom == 0 || turns.DateFrom < 0)
                    throw new ApiBusinessException("2000", "Debe ingresar la fecha desde", System.Net.HttpStatusCode.NotFound, "Http");
                if (turns.DateTo == 0 || turns.DateTo < 0)
                    throw new ApiBusinessException("2000", "Debe ingresar la la fecha hasta", System.Net.HttpStatusCode.NotFound, "Http");

                turns.Id = Guid.NewGuid().ToString();                
                turns.CreatedDate = DateTime.Now;
                turns.state = (Int32)TurnEnum.Activeted;

                _context.Add(turns);
                _context.SaveChanges();
                return "El turno fue creado con exito";
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
                var entity = _context.Turns.Find(id);
                if (entity == null)
                    throw new ApiBusinessException("2000", "NO existe ese turno", System.Net.HttpStatusCode.NotFound, "Http");

                entity.FinalDate = DateTime.Now;
                entity.state = (Int32)TurnEnum.Deleted;

                _context.SaveChanges();
                return "El turno fue dado de baja";
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
        public List<Turns> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                var entities = _context.Turns.Where(u => u.state == state && (u.TurnName == name || string.IsNullOrEmpty(name)));
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
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }
        public Turns GetById(string id)
        {
            try
            {
                var result = _context.Turns.SingleOrDefault(u => u.Id == id && u.state == (Int32)TurnEnum.Activeted);
                return result;
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public string GetFilterByBusinessId(string businessid, string accountid)
        {
            try
            {
                var result = _context.Turns.Where(u => u.BusinessId == businessid && u.AccountId == accountid && u.state == (Int32)TurnEnum.Activeted);
                if (!result.Any())
                    return "";
                return result.FirstOrDefault().Id;
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public string Update(string id, Turns turns)
        {
            try
            {
                var entity = _context.Turns.Find(id);
                if (entity == null)
                    throw new ApiBusinessException("2000", "NO existe ese turno", System.Net.HttpStatusCode.NotFound, "Http");

                entity.TurnName = turns.TurnName;
                entity.DateTo = turns.DateTo;
                entity.DateFrom = turns.DateFrom;
                entity.Description = turns.Description;
                entity.ModifiedDate = DateTime.Now;

                _context.SaveChanges();
                return "El turno fue modificado con exitto";
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
