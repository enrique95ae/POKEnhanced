using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using PokemonData;

namespace POKEnhanced2
{
    public partial class PokemonPage : ContentPage
    {
        public ObservableCollection<string> movesList = new ObservableCollection<string>();
        public ObservableCollection<string> gamesList = new ObservableCollection<string>();
        public PokemonJson pokemonToTeam;
        public bool isFavorite = false;

        public PokemonPage(PokemonJson pokemonToUse)
        {
            InitializeComponent();

            //set the favorite button depending if the pokemon is already in the team or not.
            for(int i=0; i<globals.GlobalVariables.favoritesList.Count; i++)
            {
                if(pokemonToUse.Name == globals.GlobalVariables.favoritesList[i].Name)
                {
                    isFavorite = true;
                    break; //no need to keep looping through the list
                }
                else
                {
                    isFavorite = false;
                }
            }

            if(isFavorite == false)
            {
                isFavorite_Button.Source = "https://cdn2.iconfinder.com/data/icons/picons-basic-1/57/basic1-132_star_off-512.png";
            }
            else
            {
                isFavorite_Button.Source = "https://cdn3.iconfinder.com/data/icons/basicolor-votting-awards/24/198_star_favorite_vote_achievement-512.png";
            }

            isFavorite = false;

            //handle if the pokemon only has one type. (duplicating it so index is not null in type check below for setting background colors)
            if (pokemonToUse.Types.Count == 1)
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

            //setting pokemon's name
            pokemonName_Label.Text = UppercaseFirst(pokemonToUse.Name);

            //setting pokemon's pictures
            pokemon_pic.Source = pokemonToUse.Sprites.FrontDefault;

            //setting pokemon's base experience
            baseExp_Label.Text = pokemonToUse.BaseExperience.ToString();

            //setting pokemon's types
            type1_Label.Text = UppercaseFirst(pokemonToUse.Types[1].Type.Name);
            type2_Label.Text = UppercaseFirst(pokemonToUse.Types[0].Type.Name);

            //settings pokemon's weight and height
            weight_Label.Text = UppercaseFirst(pokemonToUse.Weight.ToString());
            height_Label.Text = UppercaseFirst(pokemonToUse.Height.ToString());

            //setting and populating the moves list: #############################################
            movesListView.ItemsSource = movesList;
            for (int i = 0; i<pokemonToUse.Moves.Count; i++)
            {
                movesList.Add(UppercaseFirst(pokemonToUse.Moves[i].MoveMove.Name));
            }
            //####################################################################################

            //setting the games list: ############################################################
            gamesListView.ItemsSource = gamesList;
            for(int i=0; i<pokemonToUse.GameIndices.Count; i++)
            {
                gamesList.Add(UppercaseFirst(pokemonToUse.GameIndices[i].Version.Name));
            }
            //####################################################################################

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

            pokemonToTeam = pokemonToUse;
        }

        //adding a pokemon to the team button event
        //checks for: duplicates and full team
        private void addToTeamButton_Clicked(object sender, EventArgs e)
        {
            bool isInTeam = false;
            if (globals.GlobalVariables.teamList.Count < 6) //while there is space in the team
            {
                if(globals.GlobalVariables.teamList.Count >= 0) 
                {
                    //interact through as many times as pokemons are in the team list
                    for (int i = 0; i < globals.GlobalVariables.teamList.Count; i++) 
                    {
                        //if the current pokemon is already in the team
                        if(globals.GlobalVariables.teamList[i].Name == pokemonToTeam.Name)
                        {
                            //we set the flag to true and jump to the deciding if adding logic
                            isInTeam = true;
                        }
                    }

                    //deciding if adding or not logic according to our flag: isInTeam 
                    if(isInTeam == false) //add it to team if this pokemon isn't already in the team
                    {
                        globals.GlobalVariables.teamList.Add(pokemonToTeam);
                        DisplayAlert("Success!", pokemonToTeam.Name + " was added to your team!" , "OK!");
                    }
                    else //if already in the team, show an error message and reset the flag for future additions.
                    {
                        DisplayAlert("Duplicate pokemon", "You already have this pokemon in your team.", "OK!");
                        isInTeam = false;
                    }
                }
            }
            else
            {
                DisplayAlert("Full Team", "Please remove a pokemon from your team and try again.", "OK!");
            }
        }

        //logic for adding a pokemon to the favorites list and updating the button's look
        private void favoriteButton_Clicked(object sender, EventArgs e)
        {
            //first we check if it already is in the team
            for (int i = 0; i < globals.GlobalVariables.favoritesList.Count; i++)
            {
                if (pokemonToTeam.Name == globals.GlobalVariables.favoritesList[i].Name)
                {
                    isFavorite = true;
                    break; //no need to keep looping through the list
                }
                else
                {
                    isFavorite = false;
                }
            }

            //if is not in the team we add it
            if(isFavorite == false)
            {
                globals.GlobalVariables.favoritesList.Insert(0, pokemonToTeam);
                isFavorite_Button.Source = "https://cdn3.iconfinder.com/data/icons/basicolor-votting-awards/24/198_star_favorite_vote_achievement-512.png";
            }
            //if it is in the team, update pic.
            else
            {
                isFavorite_Button.Source = "https://cdn3.iconfinder.com/data/icons/basicolor-votting-awards/24/198_star_favorite_vote_achievement-512.png";
            }

            isFavorite = false;
        }
    }
}
