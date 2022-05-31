using System;

using Xamarin.Forms;

namespace FenomPlus.Models
{
    public class QualityControlUsersDataModel : QualityControlUsersDBModel
    {
        public string Delete { get; set; }
        public string Renew { get; set; }

        public QualityControlUsersDataModel() : base()
        {
        }
    }
}

