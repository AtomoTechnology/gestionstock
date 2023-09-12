using ApplicationView.DataModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataModel.Repositories.IRepository
{
    public interface ISaleDetailRepoository
    {
        List<SaleDetail> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        List<SaleDetail> SearchAllDetailByCode(string saleCode);
        SaleDetail GetById(string id);
        IEnumerable<SaleDetailEntityDto> Create(SaleDetail saleDetail, string lotId);
        String Update(string id, SaleDetail saleDetail);
        String Delete(string id);
    }
}
