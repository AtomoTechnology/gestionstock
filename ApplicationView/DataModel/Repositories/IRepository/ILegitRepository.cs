using ApplicationView.DataModel.Entities;
using System;
using System.Collections.Generic;

namespace ApplicationView.DataModel.Repositories.IRepository
{
    public interface ILegitRepository
    {
        List<Legit> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        Legit GetById(string id);
        String Create(Legit entity);
        String Update(string id, Legit entity);
        String PayLegit(List<Legit> be);
        String Delete(string id);
    }
}
