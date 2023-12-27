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

namespace ApplicationView.DataModel.Repositories.Repository
{
    public class OpenWorkTurnsRepository : IOpenWorkTurnsRepository
    {
        private readonly DbGestionStockContext _context;
        public OpenWorkTurnsRepository (DbGestionStockContext context)
        {
            _context = context;
        }
        public string Create(OpenWorkTurn openturns)
        {
            try
            {
                if (openturns == null)
                    throw new ApiBusinessException("2000", "falta datos para iniciar el turno", System.Net.HttpStatusCode.NotFound, "Http");
                if (openturns.StartingQuantity < 0)
                    throw new ApiBusinessException("2000", "Debe ingresar a cantidad de dinero para iniciar el turno", System.Net.HttpStatusCode.NotFound, "Http");
                if (string.IsNullOrEmpty(openturns.TurnId))
                    throw new ApiBusinessException("2000", "Debe selecionar el turno", System.Net.HttpStatusCode.NotFound, "Http");
                if (string.IsNullOrEmpty(openturns.AccountId))
                    throw new ApiBusinessException("2000", "Debe selecionar el usuario", System.Net.HttpStatusCode.NotFound, "Http");
                var  entiity = _context.OpenWorkTurns.Where(u => u.AccountId == openturns.AccountId && u.state == (Int32)StateEnum.Activeted).ToList();
                if (entiity.Any()) 
                    throw new ApiBusinessException("2000", "Ya existe un turno abierto para ese usuario", System.Net.HttpStatusCode.NotFound, "Http");

                openturns.Turn = null;
                openturns.Id = Guid.NewGuid().ToString();
                openturns.CreatedDate = DateTime.Now;
                openturns.state = (Int32)TurnEnum.Activeted;

                _context.Add(openturns);
                _context.SaveChanges();
                return "El turno fue abierto con exito-"+ openturns.Id;
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
                var entity = _context.OpenWorkTurns.Find(id);
                if (entity == null)
                    throw new ApiBusinessException("2000", "NO existe turno abierto", System.Net.HttpStatusCode.NotFound, "Http");

                entity.FinalDate = DateTime.Now;
                entity.state = (Int32)TurnEnum.Deleted;

                _context.SaveChanges();
                return "El turno fue cerrado con existo";
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
        public string CloseCashier(string accountId, string TurnId)
        {
            try
            {
                var entity = _context.OpenWorkTurns.SingleOrDefault(u => u.AccountId == accountId && u.TurnId == TurnId && u.FinalDate == null && u.state == (Int32)StateEnum.Activeted);
                if (entity == null)
                    return "";

                entity.FinalDate = DateTime.Now;
                entity.state = (Int32)StateEnum.CloseCashier;

                _context.SaveChanges();
                return "ok";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public List<OpenWorkTurn> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                var entities = _context.OpenWorkTurns.Include(u => u.Turn).Include(p => p.Account.User).Where(u => u.state == state && (u.Turn.TurnName == name || string.IsNullOrEmpty(name)));
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
        public OpenWorkTurn GetById(string id)
        {
            try
            {
                var result = _context.OpenWorkTurns.SingleOrDefault(u => u.Id == id && u.state == (Int32)TurnEnum.Activeted);
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

        public bool GetFilterOpenWorkTurnById(string id)
        {
            try
            {
                var result = _context.OpenWorkTurns.Where(u => u.Account.User.Business.Id == id && u.state == (Int32)TurnEnum.Activeted).ToList();
                if (result.Any())
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public OpenWorkTurn IsTurnOpenForUser(string accountid, string busnissid)
        {
            try
            {
                var result = _context.OpenWorkTurns.Where(u => u.AccountId == accountid && u.Account.User.BusinessId == busnissid && u.state == (Int32)TurnEnum.Activeted);
                if (result.Any())
                    return result.FirstOrDefault();
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Update(string id, OpenWorkTurn openturns)
        {
            try
            {
                var entity = _context.OpenWorkTurns.Find(id);
                if (entity == null)
                    throw new ApiBusinessException("2000", "NO existe turno abierto", System.Net.HttpStatusCode.NotFound, "Http");
                if (entity.state == (Int32)TurnEnum.CloseTurn)
                    throw new ApiBusinessException("2000", "Ese turno ya fue cerrado", System.Net.HttpStatusCode.NotFound, "Http");
                if (string.IsNullOrEmpty(openturns.TurnId))
                    throw new ApiBusinessException("2000", "Debe selecionar el turno", System.Net.HttpStatusCode.NotFound, "Http");
                if (string.IsNullOrEmpty(openturns.AccountId))
                    throw new ApiBusinessException("2000", "Debe selecionar el usuario", System.Net.HttpStatusCode.NotFound, "Http");

                entity.TurnId = openturns.TurnId;
                entity.AccountId = openturns.AccountId;
                entity.StartingQuantity = openturns.StartingQuantity;
                entity.ModifiedDate = DateTime.Now;

                _context.SaveChanges();
                return "El turno abierto fue modificado con exitto";
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

        public bool ChechCashierOpen(string accountId, string TurnId)
        {
            try
            {
                var entity = _context.OpenWorkTurns.SingleOrDefault(u => u.AccountId == accountId && u.TurnId == TurnId && u.FinalDate == null && u.state == (Int32)StateEnum.Activeted);
                if (entity == null)
                    return false;
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

        public Boolean CloseWorkUser(string accountId)
        {
            try
            {
                var result = _context.OpenWorkTurns.SingleOrDefault(u => u.AccountId == accountId && u.state == (Int32)TurnEnum.Activeted);
                var sale = _context.Sales.Where(u => u.AccountId == accountId && u.SaleType == CashierState.GetStateCashier(1));
                if (result == null)
                    throw new ApiBusinessException("2000", "No hay caja abierta para cerrar", System.Net.HttpStatusCode.NotFound, "Http");
                result.state = (Int32)TurnEnum.CloseTurn;
                result.FinalDate = DateTime.Now;
                if (sale.Any())
                {
                    foreach (var item in sale)
                    {
                        item.SaleType = CashierState.GetStateCashier(2);
                    }
                }
                var p = _context.SaveChanges();
                if (result != null)
                    return true;
                return false;
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
        public List<OpenWorkTurn> GetAll(string AccountId, int page, int top, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                var entities = _context.OpenWorkTurns.Include(u => u.Turn).Include(p => p.Account.User).Where(u => u.AccountId == AccountId && (u.Turn.TurnName == name || string.IsNullOrEmpty(name)));
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

        public OpenWorkTurn GetOpenWorkTurnByAccountId(string AccountId)
        {
            try
            {
                var result = _context.OpenWorkTurns.SingleOrDefault(u => u.AccountId == AccountId && u.state == (Int32)TurnEnum.Activeted && u.FinalDate == null);
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
    }
}
