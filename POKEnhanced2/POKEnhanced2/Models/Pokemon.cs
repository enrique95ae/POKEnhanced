namespace PokemonObject
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using PokemonData;

    public class PokemonItem
    {
        public long ID { get; set; }
        public string name { get; set; }
        public long baseExp { get; set; }
       //public List<long> gameIndexes { get; set; }
        //public List<string> moveset { get; set; }
        //public string image { get; set; }
        //public List<TypeElement> Types { get; set; }
    }
}