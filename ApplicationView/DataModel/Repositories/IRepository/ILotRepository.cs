using ApplicationView.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataModel.Repositories.IRepository
{
    public interface ILotRepository
    {
        List<Lot> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        Lot GetById(string id); 
        String Create(Lot entity);
        String Update(string id, Lot entity);
        String Delete(string id);
    }
}
