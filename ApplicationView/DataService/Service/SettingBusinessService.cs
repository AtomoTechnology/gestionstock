using ApplicationView.BusnessEntities.BE;
using ApplicationView.DataModel.Repositories.IRepository;
using ApplicationView.DataService.Iservice;
using ApplicationView.Resolver.HelperError.Handlers;
using ApplicationView.Resolver.HelperError.IExceptions;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace ApplicationView.DataService.Service
{
    public class SettingBusinessService : ISettingBusinessService
    {
        private readonly ISettingBusinessRepository _repo;
        private readonly IMapper _maapper;
        public SettingBusinessService(ISettingBusinessRepository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }
        public string Create(SettingBusinessBE stb) => throw new NotImplementedException();
        public string Delete(string id) => throw new NotImplementedException();
        public List<SettingBusinessBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count) => throw new NotImplementedException();
        public SettingBusinessBE GetById(string id) => throw new NotImplementedException();
        public SettingBusinessBE GetSettingBusinessByBusinessId(string BusinessId)
        {
            try
            {
                var entities = _repo.GetSettingBusinessByBusinessId(BusinessId);
                return _maapper.Map<SettingBusinessBE>(entities);
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
        public string Update(string id, SettingBusinessBE stb) => throw new NotImplementedException();
    }
}
