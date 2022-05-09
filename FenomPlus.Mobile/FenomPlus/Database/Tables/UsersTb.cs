using System;
using System.Collections.Generic;

namespace FenomPlus.Database.Tables
{
    public class UsersTb : BaseTb<UsersTb>
    {
        public DateTime DateAdded { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
    }
}