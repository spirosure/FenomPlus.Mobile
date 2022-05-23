using System;

using Xamarin.Forms;

namespace FenomPlus.Models
{
    public class ViewRecentErrorsDataModel
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public string Humidity { get; set; }
        public string Date_Time { get; set; }
        public string SerialNumber { get; set; }
        public string Firmware { get; set; }
        public string Software  { get; set; }

        public ViewRecentErrorsDataModel()
        {
            ID = "1";
            Description = "Some Error here";
            Humidity = "20%";
            Date_Time = "2001-08-01 18:55";
            SerialNumber = "F150-23de121ww";
            Firmware = "0.21";
            Software = "1.12";
        }
    }
}

