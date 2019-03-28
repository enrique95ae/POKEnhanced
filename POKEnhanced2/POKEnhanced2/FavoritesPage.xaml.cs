using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using PokemonData;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace POKEnhanced2
{
    public partial class FavoritesPage : ContentPage
    {
        public ObservableCollection<PokemonJson> favoritesListViewSource = new ObservableCollection<PokemonJson>();
        
        public FavoritesPage()
        {
            InitializeComponent();

            favoritesListViewSource = globals.GlobalVariables.favoritesList;

            favoritesListView.ItemsSource = favoritesListViewSource;
        }

        void Handle_DeletePokemon(object sender, EventArgs e)
        {
            var menuItem = (MenuItem)sender;
            var pokemonDelete = (PokemonJson)menuItem.CommandParameter;
            favoritesListViewSource.Remove(pokemonDelete);
            globals.GlobalVariables.favoritesList.Remove(pokemonDelete);
        }
    }
}
