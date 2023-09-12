using ApplicationView.DataModel.Context;
using ApplicationView.DataModel.Entities;
using ApplicationView.DataModel.Repositories.IRepository;
using ApplicationView.Resolver.Enums;
using ApplicationView.Resolver.HelperError.Handlers;
using ApplicationView.Resolver.HelperError.IExceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationView.DataModel.Repositories.Repository
{
    public class SettingBusinessRepository : ISettingBusinessRepository
    {
        private readonly DbGestionStockContext _context;
        public SettingBusinessRepository(DbGestionStockContext context)
        {
            _context = context;
        }
        public string Create(SettingBusiness stb)
        {
            try
            {
                if (stb == null)
                    throw new ApiBusinessException("3000", "falta datos de la configuracion en los campos obligatorios", System.Net.HttpStatusCode.NotFound, "Http");
                if (String.IsNullOrEmpty(stb.BusinessId))
                    throw new ApiBusinessException("3000", "Debe ingresar la empresa", System.Net.HttpStatusCode.NotFound, "Http");
                if (stb.DateTo == DateTime.Now)
                    throw new ApiBusinessException("3000", "La fecha de finalización no puede ser igual que hoy", System.Net.HttpStatusCode.NotFound, "Http");

                stb.Id = Guid.NewGuid().ToString();
                stb.CreatedDate = DateTime.Now;
                stb.FinalDate = null;
                stb.state = (Int32)StateEnum.Activeted;

                _context.Add(stb);
                _context.SaveChanges();
                return "La configuración fue guardada con exito";
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
        public string Delete(string id) => throw new NotImplementedException();
        public List<SettingBusiness> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count) => throw new NotImplementedException();
        public SettingBusiness GetById(string id) => throw new NotImplementedException();
        public SettingBusiness GetSettingBusinessByBusinessId(string BusinessId)
        {
            try
            {
                var result = _context.SettingBusiness.SingleOrDefault(u => u.BusinessId == BusinessId && u.state == (Int32)StateEnum.Activeted);
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
        public string Update(string id, SettingBusiness stb)
        {
            try
            {
                var ent = _context.SettingBusiness.Find(id);
                if (stb == null)
                    throw new ApiBusinessException("3000", "NO existe esa empresa", System.Net.HttpStatusCode.NotFound, "Http");
                if (String.IsNullOrEmpty(stb.BusinessId))
                    throw new ApiBusinessException("3000", "Debe ingresar la empresa", System.Net.HttpStatusCode.NotFound, "Http");
                if (stb.DateTo == DateTime.Now)
                    throw new ApiBusinessException("3000", "La fecha de finalización no puede ser igual que hoy", System.Net.HttpStatusCode.NotFound, "Http");

                ent.BusinessId = stb.BusinessId;
                ent.DateTo = stb.DateTo;
                ent.IsActive = stb.IsActive;
                ent.IsFree = stb.IsFree;
                ent.IsTryOn = stb.IsTryOn;

                _context.SaveChanges();

                return "La configuracion de la empresa fue modificada con exito!";
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
