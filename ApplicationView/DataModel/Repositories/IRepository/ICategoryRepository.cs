using ApplicationView.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataModel.Repositories.IRepository
{
    public interface ICategoryRepository
    {
        List<Category> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        Category GetById(string id);
        String Create(Category category);
        String Update(string id, Category category);
        String Delete(string id);
    }
}
