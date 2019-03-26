using System;
using System.Collections.Generic;

using Xamarin.Forms;
using PokemonObject;

namespace POKEnhanced2
{
    public partial class PokemonPage : ContentPage
    {
        public PokemonPage(PokemonItem pokemonToUse)
        {
            pokemonName_Label.Text = pokemonToUse.name;
            pokemonBaseExp_Label.Text = pokemonToUse.baseExp.ToString();
            InitializeComponent();
        }
    }
}
