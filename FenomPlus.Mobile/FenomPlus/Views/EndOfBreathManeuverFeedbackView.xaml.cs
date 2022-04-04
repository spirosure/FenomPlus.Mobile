using System;
using System.Collections.Generic;
using FenomPlus.ViewModels;
using Xamarin.Forms;

namespace FenomPlus.Views
{
    public partial class EndOfBreathManeuverFeedbackView : BaseContentPage
    {
        private EndOfBreathManeuverFeedbackViewModel model;

        public EndOfBreathManeuverFeedbackView()
        {
            InitializeComponent();
            BindingContext = model = new EndOfBreathManeuverFeedbackViewModel();
        }
    }
}
