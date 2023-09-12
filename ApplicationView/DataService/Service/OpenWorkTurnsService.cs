using ApplicationView.BusnessEntities.BE;
using ApplicationView.DataModel.Entities;
using ApplicationView.DataModel.Repositories.IRepository;
using ApplicationView.DataService.Iservice;
using ApplicationView.Resolver.HelperError.Handlers;
using ApplicationView.Resolver.HelperError.IExceptions;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace ApplicationView.DataService.Service
{
    public class OpenWorkTurnsService : IOpenWorkTurnsService
    {
        private readonly IOpenWorkTurnsRepository _repo;
        private readonly IMapper _maapper;
        public OpenWorkTurnsService(IOpenWorkTurnsRepository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }
        public string Create(OpenWorkTurnBE openturns)
        {
            try
            {
                var result = _maapper.Map<OpenWorkTurn>(openturns);
                var entity = _repo.Create(result);
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
        public string CloseCashier(string accountId, string TurnId) => _repo.CloseCashier(accountId, TurnId);

        public List<OpenWorkTurnBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                var entities = _repo.GetAll(state, page, top, orderBy, ascending, name, ref count);
                return _maapper.Map<List<OpenWorkTurnBE>>(entities);
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
        public OpenWorkTurnBE GetById(string id)
        {
            try
            {
                var entities = _repo.GetById(id);
                return _maapper.Map<OpenWorkTurnBE>(entities);
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
                var entities = _repo.GetFilterOpenWorkTurnById(id);
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

        public OpenWorkTurnBE IsTurnOpenForUser(string accountid, string busnissid)
        {
            try
            {
                var entities = _repo.IsTurnOpenForUser(accountid, busnissid);
                var result = _maapper.Map<OpenWorkTurnBE>(entities);
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

        public string Update(string id, OpenWorkTurnBE openturns)
        {
            try
            {
                var result = _maapper.Map<OpenWorkTurn>(openturns);
                var entities = _repo.Update(id, result);
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

        public bool ChechCashierOpen(string accountId, string TurnId) => _repo.ChechCashierOpen(accountId, TurnId);
    }
}
