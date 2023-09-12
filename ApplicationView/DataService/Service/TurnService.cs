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
    public class TurnService : ITurnService
    {
        private readonly ITurnRepository _repo;
        private readonly IMapper _maapper;
        public TurnService(ITurnRepository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }
        public string Create(TurnsBE turns)
        {
            try
            {
                var result =_maapper.Map<Turns>(turns);
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
        public List<TurnsBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                var entities = _repo.GetAll(state, page, top, orderBy, ascending, name, ref count);
                return _maapper.Map<List<TurnsBE>>(entities);
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }
        public TurnsBE GetById(string id)
        {
            try
            {
                var entities = _repo.GetById(id);
                return _maapper.Map<TurnsBE>(entities);
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
                var entities = _repo.GetFilterByBusinessId(businessid, accountid);
                return entities;
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public string Update(string id, TurnsBE turns)
        {
            try
            {
                var result = _maapper.Map<Turns>(turns);
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
    }
}
