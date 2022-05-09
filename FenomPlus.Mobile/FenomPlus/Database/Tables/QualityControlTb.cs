using System;
namespace FenomPlus.Database.Tables
{
    public class QualityControlTb : BaseTb<QualityControlTb>
    {
        public DateTime Date { get; set; }
        public string SerialNumber { get; set; }
        public string User { get; set; }
        public string Status { get; set; }
        public double TestResult { get; set; }
    }
}
