using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace POKEnhanced
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void teamButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TeamPage());
        }

        private async void historyButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }

        private async void newsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewsPage());
        }


    }
}
