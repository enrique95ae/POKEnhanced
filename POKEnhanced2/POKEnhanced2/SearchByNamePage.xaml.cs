using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

using PokemonObject;
using PokemonData;


namespace POKEnhanced2
{
    public partial class SearchByNamePage : ContentPage
    {
        public PokemonItem pokemonReady = new PokemonItem();

        public SearchByNamePage()
        {
            InitializeComponent();
        }

        async void searchButton_Clicked(object sender, EventArgs e)
        {
            //getting input and constructing request url
            string userInput;
            userInput = nameEntry.Text;

            //seting up URI and creatting HTTP client and response holder
            string nameApiEndpoint = globals.GlobalVariables.searchByNameString + userInput;
            Uri nameApiUri = new Uri(nameApiEndpoint);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(nameApiUri);

            //response stream into string
            string jsonContent = await response.Content.ReadAsStringAsync();

            //parse into an object of type PokemonJson


            if (jsonContent != globals.GlobalVariables.notFoundString)
            {
                var pokemon = PokemonJson.FromJson(jsonContent);

                pokemonReady.ID = pokemon.Id;
                pokemonReady.name = pokemon.Name.ToString();
                pokemonReady.baseExp = pokemon.BaseExperience;

                Console.WriteLine(pokemonReady.ID);
                Console.WriteLine(pokemonReady.name);
                Console.WriteLine(pokemonReady.baseExp);

                await Navigation.PushAsync(new PokemonPage(pokemonReady));
            }
            else
            {
                await DisplayAlert("NOT FOUND", "Please try again!", "OK");
            }

        }
    }
}
