﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using PokemonData;

namespace POKEnhanced2
{
    public partial class PokemonPage : ContentPage
    {



        public PokemonPage(PokemonJson pokemonToUse)
        {
            InitializeComponent();

            //handle if the pokemon only has one type.
            //if(pokemonToUse.Types.Count == 1)
            //{
            //    pokemonToUse.Types.
            //}
            Console.WriteLine(pokemonToUse.Types.Count);

            pokemon_pic.Source = pokemonToUse.Sprites.FrontDefault;
            pokemonDescription_Label.Text = pokemonToUse.Moves.ToString();
            pokemonName_Label.Text = pokemonToUse.Name;
            pokemonBaseExp_Label.Text = pokemonToUse.BaseExperience.ToString();

            Console.WriteLine(pokemonToUse.Types[0].Type.Name);
            Console.WriteLine(pokemonToUse.Types[1].Type.Name);

            if (pokemonToUse.Types[0].Type.Name == "grass" || pokemonToUse.Types[1].Type.Name == "grass")
            {
                this.BackgroundColor = Color.FromHex("#ccffcc");
            }
            else if (pokemonToUse.Types[0].Type.Name == "fire" || pokemonToUse.Types[1].Type.Name == "fire")
            {
                this.BackgroundColor = Color.FromHex("#ffad99");
            }


        }
    }
}
