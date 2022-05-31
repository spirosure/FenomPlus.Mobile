using System;
using System.Collections.Generic;

namespace FenomPlus.Database.Tables
{
    public class QualityControlUsersTb : BaseTb<QualityControlUsersTb>
    {
        public DateTime DateAdded { get; set; }
        public string User { get; set; }
        public string QCStatus { get; set; }
    }
}