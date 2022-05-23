using System;
using Xamarin.Forms;

namespace FenomPlus.Models
{
    public class QualityControlDevicesDataModel
    {
        public string ID { get; set; }
        public string Date_Time { get; set; }
        public string SerialNumber { get; set; }

        public QualityControlDevicesDataModel()
        {
            ID = "1";
            SerialNumber = "F150-23de121ww";
            Date_Time = "Expired";
        }
    }
}

