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
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationView.DataModel.Repositories.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DbGestionStockContext _context;
        public AccountRepository(DbGestionStockContext context)
        {
            _context = context;
        }
        public string ChangePassword(Account account) 
        {
            try
            {
                var entity = _context.Accounts.Find(account.Id);
                if (entity == null)
                    throw new ApiBusinessException("3000", "NO existe cuenta para ese usuario con esa contraseña", System.Net.HttpStatusCode.NotFound, "Http");

                entity.UserPass = account.UserPass;
                entity.Confirm = account.Confirm;

                _context.SaveChanges();

                return "La contraseña fue modificada con exito!";
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

        public List<Account> FilterAccountByBusinessId(int state, int page, int top, string businessId, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                var entities = _context.Accounts.Include(u => u.User).Include(u => u.Role).
                                        Include(u => u.ModuleAccounts).ThenInclude(u => u.SubModuleAccounts).Include(p => p.ModuleAccounts).
                                        ThenInclude(u => u.Module).ThenInclude(u => u.SubModules).Where(u => u.state == state && u.User.BusinessId == businessId && (u.User.FirstName == name || string.IsNullOrEmpty(name)));
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

        public async Task<Account> Login(string username, string userpass) 
        {
            try
            {
                //var values = new
                //{
                //    username = username,
                //    userpass = userpass
                //};
                //IEnumerable<AccountSP> entity = await _context.Database.GetDbConnection().QueryAsync<AccountSP>("[dbo].[Sp_login]", values, commandType: CommandType.StoredProcedure);

                Account entity = await _context.Accounts.Include(u => u.User).Include(u => u.Role).
                                        Include(u => u.ModuleAccounts).ThenInclude(u => u.SubModuleAccounts).Include(p => p.ModuleAccounts).
                                        ThenInclude(u => u.Module).ThenInclude(u => u.SubModules).SingleOrDefaultAsync(u => u.state == (Int32)StateEnum.Activeted && u.UserName == username &&  u.UserPass == userpass);

                if (entity != null)
                    return entity;
                return null;
            }
            catch (Exception ex)
            {
                throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
            }
        }

        public string UpdatePassword(string oldpass, Business business) => throw new NotImplementedException();
    }
}
