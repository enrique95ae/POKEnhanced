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


        private async void byNameButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchByNamePage());
        }

    }
}
