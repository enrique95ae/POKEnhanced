using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace POKEnhanced2
{
    public partial class SearchByNamePage : ContentPage
    {
        public SearchByNamePage()
        {
            InitializeComponent();
        }

        private async void searchButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PokemonPage());
        }
    }
}
