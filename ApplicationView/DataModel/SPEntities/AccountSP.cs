﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationView.DataModel.SPEntities
{
    public class AccountSP
    {
        public string Id { get; set; }
        public String RoleId { get; set; }
        public String UserId { get; set; }
        public String BusinessId { get; set; }
        public String UserName { get; set; }
        public String UserPass { get; set; }
        public String RoleName { get; set; }
        public Boolean Confirm { get; set; }
    }
}
