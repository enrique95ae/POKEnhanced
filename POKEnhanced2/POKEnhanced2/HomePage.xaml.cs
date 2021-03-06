﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace POKEnhanced2
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        //NAVIGATION BUTTONS: ===================================================================================================
        private async void teamButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TeamPage());
        }

        private async void historyButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }

        private async void favoritesButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FavoritesPage());
        }
        //=======================================================================================================================

    }
}