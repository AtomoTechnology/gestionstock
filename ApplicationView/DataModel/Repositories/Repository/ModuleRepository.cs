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
    public class ModuleRepository : IModuleRepository
    {
        private readonly DbGestionStockContext _context;
        public ModuleRepository(DbGestionStockContext context)
        {
            _context = context;
        }
        public string Create(Module module)
        {
            try
            {
                if (module == null)
                    throw new ApiBusinessException("5000", "falta datos del modulo en los campos obligatorios", System.Net.HttpStatusCode.NotFound, "Http");
                if (String.IsNullOrEmpty(module.Name))
                    throw new ApiBusinessException("5000", "Debe ingresar el nombre del modulo", System.Net.HttpStatusCode.NotFound, "Http");

                module.Id = Guid.NewGuid().ToString();
                module.CreatedDate = DateTime.Now;
                module.FinalDate = null;
                module.state = (Int32)StateEnum.Activeted;

                _context.Add(module);
                _context.SaveChanges();
                return "El modulo fue guardado con exito";
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
                    throw new ApiBusinessException("5000", "NO existe ese modulo", System.Net.HttpStatusCode.NotFound, "Http");

                entity.FinalDate = DateTime.Now;
                entity.state = (Int32)StateEnum.Deleted;

                _context.SaveChanges();
                return "La forma de pago fue dado de baja con exito!";
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
        public List<Module> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count)
        {
            try
            {
                var entities = _context.Modules.Include(u => u.SubModules).Where(u => u.state == state && (u.Name == name || string.IsNullOrEmpty(name)));
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
        public Module GetById(string id)
        {
            try
            {
                var result = _context.Modules.SingleOrDefault(u => u.Id == id && u.state == (Int32)StateEnum.Activeted);
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

        public List<Module> GetPermissionByAccountId(string id) {
            try
            {
                var result = _context.Modules.Include(u => u.SubModules).Include(u => u.ModuleAccounts).ThenInclude(u => u.SubModuleAccounts)
               .Where(u => u.ModuleAccounts.Any(Z => Z.AccountId == id) && u.state == (Int32)StateEnum.Activeted).ToList(); ;
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

        public string Update(string id, Module module)
        {
            try
            {
                var entity = _context.Modules.Find(id);
                if (entity == null)
                    throw new ApiBusinessException("3000", "NO existe ese module", System.Net.HttpStatusCode.NotFound, "Http");

                entity.Description = module.Description;
                entity.Name = module.Name;

                _context.SaveChanges();

                return "El modulo fue modificada con exito!";
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
