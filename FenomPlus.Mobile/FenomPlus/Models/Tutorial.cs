using System;

using Xamarin.Forms;

namespace FenomPlus.Models
{
    public class Tutorial
    {
        public string Title { get; set; }
        public string Info { get; set; }
        public string Illustration { get; set; }
        public bool ShowImage { get { return (!ShowStep5 && !ShowStep6 && !ShowStep7); } }
        public bool ShowGuage { get { return (ShowStep5 || ShowStep6 || ShowStep7); } }
        public bool ShowStep5 { get; set; }
        public bool ShowStep6 { get; set; }
        public bool ShowStep7 { get; set; }
    }
}

