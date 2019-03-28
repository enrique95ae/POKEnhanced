using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace POKEnhanced2
{
    public partial class FavoritesPage : ContentPage
    {
        public class favoriteItem
        {
            public string url { get; set; }
            public string name { get; set; }
        }

        public ObservableCollection<favoriteItem> favoritesListViewSource = new ObservableCollection<favoriteItem>();
        
        public FavoritesPage()
        {
            InitializeComponent();
            favoritesListView.ItemsSource = favoritesListViewSource;
            favoriteItem pokemonFavorited = new favoriteItem();

            //Capitalize the first letter of the pomemon's name
            string UppercaseFirst(string s)
            {
                // Check for empty string.
                if (string.IsNullOrEmpty(s))
                {
                    return string.Empty;
                }
                // Return char and concat substring.
                return char.ToUpper(s[0]) + s.Substring(1);
            }


            for (int i = 0; i < globals.GlobalVariables.favoritesList.Count; i++)
            {
                pokemonFavorited.name = UppercaseFirst(globals.GlobalVariables.favoritesList[i].Name);
                pokemonFavorited.url = globals.GlobalVariables.favoritesList[i].Sprites.FrontDefault.ToString();

                favoritesListViewSource.Insert(0, pokemonFavorited);
            }
        }
    }
}
