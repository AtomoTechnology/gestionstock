﻿using ApplicationView.DataModel.Context;
using ApplicationView.DataModel.Entities;
using ApplicationView.DataModel.Repositories.IRepository;
using ApplicationView.Resolver.Enums;
using ApplicationView.Resolver.HelperError.Handlers;
using ApplicationView.Resolver.HelperError.IExceptions;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ApplicationView.DataModel.Repositories.Repository
{
    public class IncreasePriceAfterTwelveRepository : IIncreasePriceAfterTwelveRepository
    {
        private readonly DbGestionStockContext _context;
        public IncreasePriceAfterTwelveRepository(DbGestionStockContext context)
        {
            _context = context;
        }

        public string Create(IncreasePriceAfterTwelve incr)
        {
            try
            {
                if (incr == null)
                    throw new ApiBusinessException("3000", "falta datos para el incremento de precio despues de las 12 de la noche", System.Net.HttpStatusCode.NotFound, "Http");
                if (incr.HourFrom == null)
                    throw new ApiBusinessException("3000", "Debe ingresar la hora desde para sumar el incremento del precio despues de las 12 de la noche", System.Net.HttpStatusCode.NotFound, "Http");
                if (incr.HourTo == null)
                    throw new ApiBusinessException("3000", "Debe ingresar la hora hasta para finalizar el incremento del precio despues de las 12 de la noche", System.Net.HttpStatusCode.NotFound, "Http");

                incr.Id = Guid.NewGuid().ToString();
                incr.CreatedDate = DateTime.Now;
                incr.FinalDate = null;
                incr.state = (Int32)StateEnum.Activeted;
                incr.IsActive = true;

                _context.Add(incr);
                _context.SaveChanges();
                return "El incremento de precio despues de las 12, fue guardado con exito";
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
                var entity = _context.IncreasePriceAfterTwelves.SingleOrDefault(u => u.Id == id && u.FinalDate == null && u.state == (Int32)StateEnum.Activeted);
                if (entity == null)
                    throw new ApiBusinessException("3000", "NO existe ese incremento de precio", System.Net.HttpStatusCode.NotFound, "Http");

                entity.FinalDate = DateTime.Now;
                entity.state = (Int32)StateEnum.Deleted;
                entity.IsActive = false;

                _context.SaveChanges();
                return "El incremento de precio despues de las 12,fue dado de baja con exito!";
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
        public List<IncreasePriceAfterTwelve> GetAll(int state, int page, int top, string orderBy, string ascending, DateTime hourFrom, DateTime hourTo, string BusinessId, ref int count)
        {
            try
            {
                // var entities = _context.IncreasePriceAfterTwelves.Where(u => u.state == state && u.Account.User.BusinessId == BusinessId);
                // count = entities.Count();
                // var skipAmount = 0;
                // if (page > 0)
                //     skipAmount = top * (page - 1);

                // entities = entities
                //.OrderByPropertyOrField(orderBy, ascending)
                //.Skip(skipAmount)
                //.Take(top);
                using (var db = new DbGestionStockContext())
                {
                    using (var ctx = db.Database.GetDbConnection())
                    {
                        try
                        {
                            ctx.Open();
                            var values = new
                            {
                                BusinessId = BusinessId
                            };
                            List<IncreasePriceAfterTwelve> entity = ctx.Query<IncreasePriceAfterTwelve>("[dbo].[Sp_IncreasePriceAfterTwelves]", values, commandType: CommandType.StoredProcedure).ToList();
                            ctx.Close();
                            return entity;
                        }
                        catch (ApiBusinessException ex)
                        {
                            ctx.Close();
                            throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
                        }
                        catch (Exception ex)
                        {
                            ctx.Close();
                            throw HandlerExceptions.GetInstance().RunCustomExceptions(ex);
                        }
                    }
                }               
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
        public IncreasePriceAfterTwelve GetById(string id)
        {
            try
            {
                var result = _context.IncreasePriceAfterTwelves.SingleOrDefault(u => u.Id == id && u.state == (Int32)StateEnum.Activeted);
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
        public string Update(string id, IncreasePriceAfterTwelve incr)
        {
            try
            {
                var entity = _context.IncreasePriceAfterTwelves.Find(id);
                if (entity == null)
                    throw new ApiBusinessException("3000", "NO existe ese usuario", System.Net.HttpStatusCode.NotFound, "Http");

                entity.HourFrom = incr.HourFrom;
                entity.HourTo = incr.HourTo;
                entity.Porcent = incr.Porcent;
                entity.ModifiedDate = DateTime.Now;

                _context.SaveChanges();

                return "El incremento de precio despues de las 12, fue modificado con exito!";
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
