﻿using ApplicationView.BusnessEntities.BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataService.Iservice
{
    public interface IBusnessService
    {
        List<BusinessBE> GetAll(int state, int page, int top, string orderBy, string ascending, string name, ref int count);
        BusinessBE GetById(string id);
        BusinessBE GetBusinessByUserId(string UserId);
        String Create(BusinessBE busness);
        String Update(string id, BusinessBE busness);
        String Delete(string id);
    }
}
