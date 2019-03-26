using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using PokemonData;

namespace POKEnhanced2
{
    public partial class PokemonPage : ContentPage
    {
        public PokemonPage(PokemonJson pokemonToUse)
        {
            InitializeComponent();


            //handle if the pokemon only has one type. (duplicating it so index is not null in type check below for setting background colors)
            if(pokemonToUse.Types.Count == 1)
            {
                pokemonToUse.Types.Add(pokemonToUse.Types[0]);
            }

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

            pokemonName_Label.Text = UppercaseFirst(pokemonToUse.Name);

            pokemon_pic.Source = pokemonToUse.Sprites.FrontDefault;
            baseExp_Label.Text = pokemonToUse.BaseExperience.ToString();

            //checking pokemon types to set background color.
            if (pokemonToUse.Types[0].Type.Name == "grass" || pokemonToUse.Types[1].Type.Name == "grass")
            {
                this.BackgroundColor = Color.FromHex("#ccffcc");
            }
            else if (pokemonToUse.Types[0].Type.Name == "fire" || pokemonToUse.Types[1].Type.Name == "fire")
            {
                this.BackgroundColor = Color.FromHex("#ffad99");
            }
            else if (pokemonToUse.Types[0].Type.Name == "water" || pokemonToUse.Types[1].Type.Name == "water")
            {
                this.BackgroundColor = Color.FromHex("#b3f0ff");
            }
            else if (pokemonToUse.Types[0].Type.Name == "electric" || pokemonToUse.Types[1].Type.Name == "electric")
            {
                this.BackgroundColor = Color.FromHex("#ffff99");
            }
            else if (pokemonToUse.Types[0].Type.Name == "fairy" || pokemonToUse.Types[1].Type.Name == "fairy")
            {
                this.BackgroundColor = Color.FromHex("#ffe6ff");
            }
            else if (pokemonToUse.Types[0].Type.Name == "fighting" || pokemonToUse.Types[1].Type.Name == "fighting")
            {
                this.BackgroundColor = Color.FromHex("#e6ccb3");
            }
            else
            {
                this.BackgroundColor = Color.Silver;
            }


        }
    }
}
