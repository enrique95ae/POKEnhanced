using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;


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
            //AppCenter.Start("android=56f19ac5-0cb0-410d-8ee7-d283d96a8976; ios=fa01de57-a1a0-4f6a-b57d-ca52e19f6fda",
            //typeof(Analytics), typeof(Crashes));  
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
