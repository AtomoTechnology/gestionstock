using ApplicationView.DataModel.Entities;
using System;
using System.Collections.Generic;

namespace ApplicationView.DataModel.Repositories.IRepository
{
    public interface ITurnRepository
    {
        List<Turns> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        Turns GetById(string id);
        String Create(Turns turns);
        string GetFilterByBusinessId(string businessid, string accountid);
        String Update(string id, Turns turns);
        String Delete(string id);
    }
}
