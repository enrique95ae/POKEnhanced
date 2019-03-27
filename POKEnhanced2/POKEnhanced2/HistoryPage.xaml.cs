using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

namespace POKEnhanced2
{
    public partial class HistoryPage : ContentPage
    {

        public class historyItem
        {
            public string url { get; set; }
            public string name { get; set; }
        }

        public ObservableCollection<historyItem> historyListViewSource = new ObservableCollection<historyItem>();

        public HistoryPage()
        {
            InitializeComponent();
            historyListView.ItemsSource = historyListViewSource;
            historyItem pokemonVisited = new historyItem();

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


            for (int i=0; i<globals.GlobalVariables.searchHistory.Count; i++)
            {
                pokemonVisited.name = UppercaseFirst(globals.GlobalVariables.searchHistory[i].Name);
                pokemonVisited.url = globals.GlobalVariables.searchHistory[i].Sprites.FrontDefault.ToString();

                historyListViewSource.Insert(0, pokemonVisited);
            }
        }
    }
}
