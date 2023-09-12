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

namespace ApplicationView.DataModel.Repositories.Repository
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly DbGestionStockContext _context;
        public BusinessRepository(DbGestionStockContext context)
        {
            _context = context;
        }
        public string Create(Business business)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (business == null)
                        throw new ApiBusinessException("2000", "Falta datos del negocio en los campos obligatorios", System.Net.HttpStatusCode.NotFound, "Http");
                    if (String.IsNullOrEmpty(business.BusinessName))
                        throw new ApiBusinessException("2000", "Debe ingresar el nombre del negocio", System.Net.HttpStatusCode.NotFound, "Http");
                    var BusinessName = _context.Businesses.Where(u => u.BusinessName == business.BusinessName).ToList();
                    if (BusinessName.Any())
                        throw new ApiBusinessException("2000", "Ya existe un negocio con ese nombre", System.Net.HttpStatusCode.NotFound, "Http");
                    var Cuit_Cuil = _context.Businesses.Where(u => u.Cuit_Cuil == business.Cuit_Cuil).ToList();
                    if (Cuit_Cuil.Any())
                        throw new ApiBusinessException("2000", "Ya existe un negocio con ese Cuit/Cuil", System.Net.HttpStatusCode.NotFound, "Http");

                    var businessguid = Guid.NewGuid().ToString();
                    business.Id = businessguid;
                    if (business.Users != null)
                    {
                        foreach (var item in business.Users)
                        {
                            var userguid = Guid.NewGuid().ToString();

                            item.Id = userguid;
                            item.BusinessId = business.Id;
                            item.CreatedDate = DateTime.Now;
                            item.state = (Int32)StateEnum.Activeted;

                            if (item.Accounts != null)
                            {
                                foreach (var account in item.Accounts)
                                {
                                    var result = _context.Accounts.Where(u => u.UserName == account.UserName).ToList();
                                    if (result.Any())
                                    {
                                        throw new ApiBusinessException("2000", "Ya existe un usuario con ese nombre de usuario", System.Net.HttpStatusCode.NotFound, "Http");
                                    }
                                    else
                                    {
                                        var accountguid = Guid.NewGuid().ToString();
                                        account.UserId = item.Id;
                                        account.RoleId = "f298bdb2-4f4e-4fab-888c-438576651647";
                                        account.Id = accountguid;
                                        account.CreatedDate = DateTime.Now;
                                        account.state = (Int32)StateEnum.Activeted;
                                    }
                                }
                            }
                        }
                    }
                    business.CreatedDate = DateTime.Now;
                    business.state = (Int32)StateEnum.Activeted;

                    _context.Add(business);
                    _context.SaveChanges(); 
                    transaction.Commit();
                    return "El negocio fue creado con exito";
                }
                catch (ApiBusinessException ex)
                {
                    transaction.Rollback();
                    throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
                }
            }
        }

        public String Delete(string id)
        {
            try
            {
                var entity =  _context.Businesses.Include(u =>u.Users).SingleOrDefault(u => u.Id == id);
                if (entity == null)
                    throw new ApiBusinessException("2000", "NO existe ese negocio", System.Net.HttpStatusCode.NotFound, "Http");

                var users = _context.Users.Where(u => u.BusinessId == id).ToList();
                foreach (var item in users)
                {
                    item.FinalDate = DateTime.Now;
                    item.state = (Int32)StateEnum.Deleted;

                    var accounts = _context.Accounts.Where(u => u.UserId == item.Id).ToList();
                    foreach (var account in accounts)
                    {
                        account.FinalDate = DateTime.Now;
                        account.state = (Int32)StateEnum.Deleted;
                    }
                }

                entity.FinalDate = DateTime.Now;
                entity.state = (Int32)StateEnum.Deleted;

                _context.SaveChanges();
                return "El negocio fue dado de baja con sus empleados relacionado";
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

        public List<Business> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                var entities = _context.Businesses.Where(u => u.state == state && (u.BusinessName == name || string.IsNullOrEmpty(name)));
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

        public Business GetBusinessByUserId(string UserId)
        {
            try
            {
                var result = _context.Businesses.SingleOrDefault(u => u.Users.FirstOrDefault().Id == UserId && u.state == (Int32)StateEnum.Activeted);
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

        public Business GetById(string id)
        {
            try
            {
                var result = _context.Businesses.SingleOrDefault(u => u.Id == id && u.state == (Int32)StateEnum.Activeted);
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

        public String Update(string id, Business business)
        {
            try
            {
                var entity = _context.Businesses.Find(id);
                if (entity == null)
                    throw new ApiBusinessException("2000", "NO existe ese usuario", System.Net.HttpStatusCode.NotFound, "Http");

                entity.Address = business.Address;
                entity.Phone = business.Phone;
                entity.CreatedDate = business.CreatedDate;
                entity.BusinessName = business.BusinessName;
                entity.Cuit_Cuil = business.Cuit_Cuil;

                _context.SaveChanges();

                return "El negocio fue modificado con exitto";
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
