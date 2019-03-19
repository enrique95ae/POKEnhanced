using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace POKEnhanced
{
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }











        //NAVIGATION BUTTONS: ===================================================================================================
        private async void byNameButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchByNamePage());
        }

        private async void byRegionButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchByNamePage());
        }

        private async void byNumberButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchByNamePage());
        }
        //=========================================================================================================================
    }
}
