using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace POKEnhanced2
{
    public partial class TeamPage : ContentPage
    {
        public TeamPage()
        {
            InitializeComponent();


            //adding the pokemons in the slots in the page. CHANGE THIS WITH A SWITCH STATEMENT OR MAKE IT CLEANER
            if (globals.GlobalVariables.teamList.Count == 0)
            {
                DisplayAlert("Empty Team", "You haven't added any pokemons to your team yet. Please add a pokemon and come back after.", "OK!");
            }
            else
            {
                if(globals.GlobalVariables.teamList.Count == 1)
                {
                    pok1_button.Source = globals.GlobalVariables.teamList[0].Sprites.FrontDefault;
                }
                else if (globals.GlobalVariables.teamList.Count == 2)
                {
                    pok1_button.Source = globals.GlobalVariables.teamList[0].Sprites.FrontDefault;
                    pok2_button.Source = globals.GlobalVariables.teamList[1].Sprites.FrontDefault;
                }
                else if (globals.GlobalVariables.teamList.Count == 3)
                {
                    pok1_button.Source = globals.GlobalVariables.teamList[0].Sprites.FrontDefault;
                    pok2_button.Source = globals.GlobalVariables.teamList[1].Sprites.FrontDefault;
                    pok3_button.Source = globals.GlobalVariables.teamList[2].Sprites.FrontDefault;
                }
                else if (globals.GlobalVariables.teamList.Count == 4)
                {
                    pok1_button.Source = globals.GlobalVariables.teamList[0].Sprites.FrontDefault;
                    pok2_button.Source = globals.GlobalVariables.teamList[1].Sprites.FrontDefault;
                    pok3_button.Source = globals.GlobalVariables.teamList[2].Sprites.FrontDefault;
                    pok4_button.Source = globals.GlobalVariables.teamList[3].Sprites.FrontDefault;
                }
                else if (globals.GlobalVariables.teamList.Count == 5)
                {
                    pok1_button.Source = globals.GlobalVariables.teamList[0].Sprites.FrontDefault;
                    pok2_button.Source = globals.GlobalVariables.teamList[1].Sprites.FrontDefault;
                    pok3_button.Source = globals.GlobalVariables.teamList[2].Sprites.FrontDefault;
                    pok4_button.Source = globals.GlobalVariables.teamList[3].Sprites.FrontDefault;
                    pok5_button.Source = globals.GlobalVariables.teamList[4].Sprites.FrontDefault;
                }
                else if (globals.GlobalVariables.teamList.Count == 6)
                {
                    pok1_button.Source = globals.GlobalVariables.teamList[0].Sprites.FrontDefault;
                    pok2_button.Source = globals.GlobalVariables.teamList[1].Sprites.FrontDefault;
                    pok3_button.Source = globals.GlobalVariables.teamList[2].Sprites.FrontDefault;
                    pok4_button.Source = globals.GlobalVariables.teamList[3].Sprites.FrontDefault;
                    pok5_button.Source = globals.GlobalVariables.teamList[4].Sprites.FrontDefault;
                    pok6_button.Source = globals.GlobalVariables.teamList[5].Sprites.FrontDefault;
                }
            }

        }
    }
}
