using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

using PokemonData;


namespace POKEnhanced2
{
    public partial class SearchByNamePage : ContentPage
    {

        public SearchByNamePage()
        {
            InitializeComponent();
        }

        async void searchButton_Clicked(object sender, EventArgs e)
        {
            //getting input and constructing request url
            string userInput;
            userInput = nameEntry.Text.ToLower();

            //seting up URI and creatting HTTP client and response holder
            string nameApiEndpoint = globals.GlobalVariables.searchByNameString + userInput;
            Uri nameApiUri = new Uri(nameApiEndpoint);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(nameApiUri);

            //response stream into string
            string jsonContent = await response.Content.ReadAsStringAsync();

            if (jsonContent != globals.GlobalVariables.notFoundString)
            {
                //parse into an object of type PokemonJson
                var pokemon = PokemonJson.FromJson(jsonContent);

                //sending the object to the next page
                await Navigation.PushAsync(new PokemonPage(pokemon));
            }
            else //pop up message if the 
            {
                await DisplayAlert("NOT FOUND", "Please try again!", "OK");
            }
        }
    }
}
