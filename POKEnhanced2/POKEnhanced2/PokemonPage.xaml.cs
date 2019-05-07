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
        public string theEndpoint;

        public PokemonPage(PokemonJson pokemonToUse, string endpoint)
        {
            InitializeComponent();

            theEndpoint = endpoint;

            
            //sets the favorite button. Depending on whether the pokemon is on the team already or not. 
            for(int i=0; i<globals.GlobalVariables.favoritesList.Count; i++)
            {
                if(pokemonToUse.Name == globals.GlobalVariables.favoritesList[i].Name)
                {
                    isFavorite = true;
                    break; //loop is no longer needed at this point
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

            // handle if the pokemon only has a single type. ( duplicating it so index is not null in type check below for setting background colors )
            if (pokemonToUse.Types.Count == 1 )
            {
                pokemonToUse.Types.Add( pokemonToUse.Types[0] );
            }

            //Capitalize the first letter of the pokemon's name
            string UppercaseFirst(string s)
            {
                // Checking for an empty string.
                if (string.IsNullOrEmpty(s))
                {
                    return string.Empty;
                }
                //Return char and concatinate substring.
                return char.ToUpper(s[0]) + s.Substring( 1 );
            }

            //sets pokemon's name
            pokemonName_Label.Text = UppercaseFirst(pokemonToUse.Name);

            //sets pokemon's pictures
            pokemon_pic.Source = pokemonToUse.Sprites.FrontDefault;

            //sets pokemon's base experience
            baseExp_Label.Text = pokemonToUse.BaseExperience.ToString();

            //sets pokemon's types
            type1_Label.Text = UppercaseFirst(pokemonToUse.Types[1].Type.Name);

            type2_Label.Text = UppercaseFirst(pokemonToUse.Types[0].Type.Name);

            //sets pokemon's weight and height
            weight_Label.Text = UppercaseFirst(pokemonToUse.Weight.ToString());

            height_Label.Text = UppercaseFirst(pokemonToUse.Height.ToString());

            //sets and populating the moves list: #############################################
            movesListView.ItemsSource = movesList;
            for (int i = 0; i<pokemonToUse.Moves.Count; i++)
            {
                movesList.Add(UppercaseFirst(pokemonToUse.Moves[i].MoveMove.Name));
            }
            //####################################################################################

            //sets the games list: ############################################################
            gamesListView.ItemsSource = gamesList;
            for( int i=0; i<pokemonToUse.GameIndices.Count; i++)
            {
                gamesList.Add(UppercaseFirst(pokemonToUse.GameIndices[i].Version.Name));
            }
            //####################################################################################

            //checks pokemon types to set background color.
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

        //adds a pokemon to the team button event
        //checks for duplicates and full team
        private void addToTeamButton_Clicked(object sender, EventArgs e)
        {
            bool isInTeam = false;
            if (globals.GlobalVariables.teamList.Count < 6) //while there is space left in the team
            {
                if(globals.GlobalVariables.teamList.Count >= 0) 
                {
                    //interact through as many times as pokemon are in the team list
                    for (int i = 0; i < globals.GlobalVariables.teamList.Count; i++) 
                    {
                        //if the current pokemon is already in the teams  
                        if(globals.GlobalVariables.teamList[i].Name == pokemonToTeam.Name)
                        {
                            //sets the flag to true and jump to the deciding if adding logic
                            isInTeam = true;
                        }
                    }

                    //deciding if adding or not logic according to the flag:  isInTeam 
                    if(isInTeam == false) //add it to team if this pokemon is not already in the team
                    {
                        globals.GlobalVariables.teamList.Add(pokemonToTeam);
                        DisplayAlert("Success!", pokemonToTeam.Name + " was added to your team! " , "OK!");
                    }
                    else // if already in the team, show an error message and reset the flag for future additions
                    {
                        DisplayAlert("Duplicate pokemon", "You already have this pokemon in your team. ", "OK!");
                        isInTeam = false;
                    }
                }
            }
            else
            {
                DisplayAlert("Full Team", "Please remove a pokemon from your team and try again. ", "OK!");
            }
        }

        //logic for adding a pokemon to the favorites list and updating the button's look.
        private void favoriteButton_Clicked(object sender, EventArgs e)
        {
            // first we check if it already is in the team.   
            for (int i = 0; i < globals.GlobalVariables.favoritesList.Count; i++)
            {
                if (pokemonToTeam.Name == globals.GlobalVariables.favoritesList[i].Name)
                {
                    isFavorite = true;
                    break; // there is no need to keep looping through the list
                }
                else
                {
                    isFavorite = false;
                }
            }

            // if is not in the team we add it.
            if (isFavorite == false)
            {
                globals.GlobalVariables.favoritesList.Insert(0, pokemonToTeam);
                isFavorite_Button.Source = "https://cdn3.iconfinder.com/data/icons/basicolor-votting-awards/24/198_star_favorite_vote_achievement-512.png";
            }
            // if it is in the team, update pic
            else
            {
                isFavorite_Button.Source = "https://cdn3.iconfinder.com/data/icons/basicolor-votting-awards/24/198_star_favorite_vote_achievement-512.png";
            }

            isFavorite = false;
        }

        private async void QR_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new QRpage( theEndpoint));
        }
    }
}
