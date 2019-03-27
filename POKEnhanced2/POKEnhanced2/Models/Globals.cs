namespace globals
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using PokemonData;

    public static class GlobalVariables
    {
        public static string notFoundString = "Not Found";
        public static string searchByNameString = "https://pokeapi.co/api/v2/pokemon/";

        public static ObservableCollection<PokemonJson> teamList { get; set; }
        public static ObservableCollection<PokemonJson> searchHistory { get; set; }
        public static ObservableCollection<PokemonJson> favoritesList { get; set; }
    }
}