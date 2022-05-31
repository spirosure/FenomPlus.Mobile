using System;
namespace FenomPlus.Database.Tables
{
    public class QualityControlTb : BaseTb<QualityControlTb>
    {
        public string SerialNumber { get; set; }
        public string QCExpiration { get; set; }
        public DateTime DateTaken { get; set; }
        public string User { get; set; }
        public string QCStatus { get; set; }
        public double TestResult { get; set; }
    }
}
