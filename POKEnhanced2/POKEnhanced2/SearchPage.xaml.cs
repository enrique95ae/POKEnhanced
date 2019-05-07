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
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
        }

        async void searchButton_Clicked(object sender, EventArgs e)
        {
            if (nameEntry.Text != null)
            {
                //gets input and constructs request url
                string userInput;
                userInput = nameEntry.Text.ToLower();

                //setting up URI and creatting HTTP client and response holder.    
                string nameApiEndpoint = globals.GlobalVariables.searchByNameString + userInput;
                globals.GlobalVariables.endpoint = nameApiEndpoint;
                Uri nameApiUri = new Uri(nameApiEndpoint);
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(nameApiUri);

                // response stream into string.
                string jsonContent = await response.Content.ReadAsStringAsync();

                if (jsonContent != globals.GlobalVariables.notFoundString)
                {
                    //parses into an object of type PokemonJson.  
                    var pokemon = PokemonJson.FromJson(jsonContent);

                    globals.GlobalVariables.searchHistory.Add(pokemon);

                    //sends the object to the next page.        
                    await Navigation.PushAsync(new PokemonPage( pokemon, nameApiEndpoint));
                }
                else //pop up message if the pokemon does not exist.  
                {
                    await DisplayAlert("NOT FOUND", "Please try again! ", "OK");
                }
            }
            else
            {
                await DisplayAlert("EMPTY FIELD", "Please enter a pokemon! ", "OK");
            }

        }
    }
}