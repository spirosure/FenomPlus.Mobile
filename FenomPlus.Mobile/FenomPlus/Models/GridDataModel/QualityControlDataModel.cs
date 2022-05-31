using System;

using Xamarin.Forms;

namespace FenomPlus.Models
{
    public class QualityControlDataModel : QualityControlDBModel
    {
        public string ID { get; set; }
        public string SerialNumber { get; set; }
        public string QCExpiration { get; set; }
        public string Date_Time { get; set; }
        public string User { get; set; }
        public string QCStatus { get; set; }
        public string TestResults { get; set; }

        public QualityControlDataModel() : base()
        {
            ID = "1";
            SerialNumber = "F150-23de121ww";
            QCExpiration = "Expired";
            Date_Time = "2001-08-01 18:55";
            User = "VB";
            QCStatus = "Qualified";
            TestResults = "299";
        }
    }
}

