using ApplicationView.BusnessEntities.BE;
using ApplicationView.DataModel.Entities;
using ApplicationView.DataModel.Repositories.IRepository;
using ApplicationView.DataService.Iservice;
using ApplicationView.Resolver.HelperError.Handlers;
using ApplicationView.Resolver.HelperError.IExceptions;
using ApplicationView.Resolver.Security;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationView.DataService.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo;
        private readonly IMapper _maapper;
        public AccountService(IAccountRepository repo, IMapper maapper)
        {
            _repo = repo;
            _maapper = maapper;
        }
        public string ChangePassword(AccountBE be) 
        {
            try
            {
                var result = _repo.ChangePassword(_maapper.Map<Account>(be));
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

        public List<AccountBE> FilterAccountByBusinessId(int state, int page, int top, string businessId, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                var entities = _repo.FilterAccountByBusinessId(state, page, top, businessId, orderBy, ascending,name, ref count);
               
                return _maapper.Map<List<AccountBE>>(entities);
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

        public AccountBE GetPermisoAfterLogin(string AccountId)
        {
            try
            {
                var entity =  _repo.GetPermisoAfterLogin(AccountId);
                return _maapper.Map<AccountBE>(entity);
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

        public async Task<AccountBE> Login(string username, string userpass) {
            try
            {
                var entity = await _repo.Login(username, PassValidation.GetInstance().Encypt(userpass));
                return _maapper.Map<AccountBE>(entity);
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
        public string UpdatePassword(string oldpass, AccountBE business) => throw new NotImplementedException();
    }
}
