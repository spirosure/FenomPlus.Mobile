using System;

using Xamarin.Forms;

namespace FenomPlus.Models
{
    public class ViewPastResultsDataModel
    {
        public string ID { get; set; }
        public string SerialNumber { get; set; }
        public string TestType { get; set; }
        public string Date_Time { get; set; }
        public string QCStatus { get; set; }
        public string TestResult { get; set; }

        public ViewPastResultsDataModel()
        {
            ID = "1";
            SerialNumber = "F150-23de121ww";
            TestType = "Adult";
            Date_Time = "2001-08-01 18:55";
            QCStatus = "Qualified";
            TestResult = "299";
        }
    }
}

