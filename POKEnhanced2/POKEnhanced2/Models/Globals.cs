namespace globals
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using PokemonObject;

    public static class GlobalVariables
    {
        public static string notFoundString = "Not Found";
        public static string searchByNameString = "https://pokeapi.co/api/v2/pokemon/";




        public static ObservableCollection<Pokemon> teamList;
    }
}