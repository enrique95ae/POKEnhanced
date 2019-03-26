namespace globals
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using PokemonData;

    public static class GlobalVariables
    {
        public static string notFoundString = "Not Found";
        public static string searchByNameString = "https://pokeapi.co/api/v2/pokemon/";



        //public static PokemonJson pokemonFromJSON;
        public static ObservableCollection<PokemonJson> teamList;




        public static string grass = "grass";
    }
}