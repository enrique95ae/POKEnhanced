using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace POKEnhanced2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()); ;
            globals.GlobalVariables.teamList = new ObservableCollection<PokemonData.PokemonJson>();
            globals.GlobalVariables.searchHistory = new ObservableCollection<PokemonData.PokemonJson>();
            globals.GlobalVariables.favoritesList = new ObservableCollection<PokemonData.PokemonJson>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts 
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps  
        }

        protected override void OnResume()
        {
            // Handle when your app resumes  
        }
    }
}
