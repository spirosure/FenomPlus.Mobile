using System;

using Xamarin.Forms;

namespace FenomPlus.Models
{
    public class QualityControlUsersDataModel
    {
        public string ID { get; set; }
        public string DateAdded { get; set; }
        public string User { get; set; }
        public string QCStatus { get; set; }
        public string Select { get; set; }

        public QualityControlUsersDataModel()
        {
            ID = "1";
            DateAdded = "2001-08-01 18:55";
            User = "VB";
            QCStatus = "Qualified";
            Select = "Select";
        }
    }
}

