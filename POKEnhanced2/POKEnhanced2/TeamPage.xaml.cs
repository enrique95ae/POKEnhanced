using System;
using System.Collections.Generic;
using System.Net.Http;
using PokemonData;


using Xamarin.Forms;

namespace POKEnhanced2
{
    public partial class TeamPage : ContentPage
    {
        public TeamPage()
        {
            InitializeComponent();

            edit_Button.Text = "Edit";
            delete1_button.IsEnabled = false;
            delete2_button.IsEnabled = false;
            delete3_button.IsEnabled = false;
            delete4_button.IsEnabled = false;
            delete5_button.IsEnabled = false;
            delete6_button.IsEnabled = false;

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

        async void openPokemonPage(string nameOrNum)
        {
            //seting up URI and creatting HTTP client and response holder
            string nameApiEndpoint = globals.GlobalVariables.searchByNameString + nameOrNum;
            Uri nameApiUri = new Uri(nameApiEndpoint);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(nameApiUri);

            //response stream into string
            string jsonContent = await response.Content.ReadAsStringAsync();

            if (jsonContent != globals.GlobalVariables.notFoundString)
            {
                //parse into an object of type PokemonJson
                var pokemon = PokemonJson.FromJson(jsonContent);

                globals.GlobalVariables.searchHistory.Add(pokemon);

                //sending the object to the next page
                await Navigation.PushAsync(new PokemonPage(pokemon));
            }
        }

        void pokemon1_Clicked(object sender, EventArgs e)
        {
            openPokemonPage(globals.GlobalVariables.teamList[0].Name);
        }

        void pokemon2_Clicked(object sender, EventArgs e)
        {
            openPokemonPage(globals.GlobalVariables.teamList[1].Name);
        }

        void pokemon3_Clicked(object sender, EventArgs e)
        {
            openPokemonPage(globals.GlobalVariables.teamList[2].Name);
        }

        void pokemon4_Clicked(object sender, EventArgs e)
        {
            openPokemonPage(globals.GlobalVariables.teamList[3].Name);
        }

        void pokemon5_Clicked(object sender, EventArgs e)
        {
            openPokemonPage(globals.GlobalVariables.teamList[4].Name);
        }

        void pokemon6_Clicked(object sender, EventArgs e)
        {
            openPokemonPage(globals.GlobalVariables.teamList[5].Name);
        }

        void editButton_Clicked(object sender, EventArgs e)
        {
            if(edit_Button.Text == "Edit")
            {
                pok1_button.IsEnabled = false;
                delete1_button.IsEnabled = true;
                pok1_button.Source = "";
                delete1_button.Source = "https://cdn4.iconfinder.com/data/icons/controls-add-on-flat/48/Contols_-_Add_On-35-512.png";

                pok2_button.IsEnabled = false;
                delete2_button.IsEnabled = true;
                pok2_button.Source = "";
                delete2_button.Source = "https://cdn4.iconfinder.com/data/icons/controls-add-on-flat/48/Contols_-_Add_On-35-512.png";

                pok3_button.IsEnabled = false;
                delete3_button.IsEnabled = true;
                pok3_button.Source = "";
                delete3_button.Source = "https://cdn4.iconfinder.com/data/icons/controls-add-on-flat/48/Contols_-_Add_On-35-512.png";

                pok4_button.IsEnabled = false;
                delete4_button.IsEnabled = true;
                pok4_button.Source = "";
                delete4_button.Source = "https://cdn4.iconfinder.com/data/icons/controls-add-on-flat/48/Contols_-_Add_On-35-512.png";

                pok5_button.IsEnabled = false;
                delete5_button.IsEnabled = true;
                pok5_button.Source = "";
                delete5_button.Source = "https://cdn4.iconfinder.com/data/icons/controls-add-on-flat/48/Contols_-_Add_On-35-512.png";

                pok6_button.IsEnabled = false;
                delete6_button.IsEnabled = true;
                pok6_button.Source = "";
                delete6_button.Source = "https://cdn4.iconfinder.com/data/icons/controls-add-on-flat/48/Contols_-_Add_On-35-512.png";

                edit_Button.Text = "Save changes";
                edit_Button.TextColor = Color.Blue;
            }
            else
            {
                if (globals.GlobalVariables.teamList.Count == 1)
                {
                    pok1_button.Source = globals.GlobalVariables.teamList[0].Sprites.FrontDefault;
                    pok1_button.IsEnabled = true;
                    delete1_button.IsEnabled = false;
                    delete1_button.Source = "";
                    pok2_button.IsEnabled = true;
                    delete2_button.IsEnabled = false;
                    delete2_button.Source = "";
                    pok3_button.IsEnabled = true;
                    delete3_button.IsEnabled = false;
                    delete3_button.Source = "";
                    pok4_button.IsEnabled = true;
                    delete4_button.IsEnabled = false;
                    delete4_button.Source = "";
                    pok5_button.IsEnabled = true;
                    delete5_button.IsEnabled = false;
                    delete5_button.Source = "";
                    pok6_button.IsEnabled = true;
                    delete6_button.IsEnabled = false;
                    delete6_button.Source = "";
                }
                else if (globals.GlobalVariables.teamList.Count == 2)
                {
                    pok1_button.Source = globals.GlobalVariables.teamList[0].Sprites.FrontDefault;
                    pok2_button.Source = globals.GlobalVariables.teamList[1].Sprites.FrontDefault;
                    pok1_button.IsEnabled = true;
                    delete1_button.IsEnabled = false;
                    delete1_button.Source = "";
                    pok2_button.IsEnabled = true;
                    delete2_button.IsEnabled = false;
                    delete2_button.Source = "";
                    pok3_button.IsEnabled = true;
                    delete3_button.IsEnabled = false;
                    delete3_button.Source = "";
                    pok4_button.IsEnabled = true;
                    delete4_button.IsEnabled = false;
                    delete4_button.Source = "";
                    pok5_button.IsEnabled = true;
                    delete5_button.IsEnabled = false;
                    delete5_button.Source = "";
                    pok6_button.IsEnabled = true;
                    delete6_button.IsEnabled = false;
                    delete6_button.Source = "";
                }
                else if (globals.GlobalVariables.teamList.Count == 3)
                {
                    pok1_button.Source = globals.GlobalVariables.teamList[0].Sprites.FrontDefault;
                    pok2_button.Source = globals.GlobalVariables.teamList[1].Sprites.FrontDefault;
                    pok3_button.Source = globals.GlobalVariables.teamList[2].Sprites.FrontDefault;
                    pok1_button.IsEnabled = true;
                    delete1_button.IsEnabled = false;
                    delete1_button.Source = "";
                    pok2_button.IsEnabled = true;
                    delete2_button.IsEnabled = false;
                    delete2_button.Source = "";
                    pok3_button.IsEnabled = true;
                    delete3_button.IsEnabled = false;
                    delete3_button.Source = "";
                    pok4_button.IsEnabled = true;
                    delete4_button.IsEnabled = false;
                    delete4_button.Source = "";
                    pok5_button.IsEnabled = true;
                    delete5_button.IsEnabled = false;
                    delete5_button.Source = "";
                    pok6_button.IsEnabled = true;
                    delete6_button.IsEnabled = false;
                    delete6_button.Source = "";
                }
                else if (globals.GlobalVariables.teamList.Count == 4)
                {
                    pok1_button.Source = globals.GlobalVariables.teamList[0].Sprites.FrontDefault;
                    pok2_button.Source = globals.GlobalVariables.teamList[1].Sprites.FrontDefault;
                    pok3_button.Source = globals.GlobalVariables.teamList[2].Sprites.FrontDefault;
                    pok4_button.Source = globals.GlobalVariables.teamList[3].Sprites.FrontDefault;
                    pok1_button.IsEnabled = true;
                    delete1_button.IsEnabled = false;
                    delete1_button.Source = "";
                    pok2_button.IsEnabled = true;
                    delete2_button.IsEnabled = false;
                    delete2_button.Source = "";
                    pok3_button.IsEnabled = true;
                    delete3_button.IsEnabled = false;
                    delete3_button.Source = "";
                    pok4_button.IsEnabled = true;
                    delete4_button.IsEnabled = false;
                    delete4_button.Source = "";
                    pok5_button.IsEnabled = true;
                    delete5_button.IsEnabled = false;
                    delete5_button.Source = "";
                    pok6_button.IsEnabled = true;
                    delete6_button.IsEnabled = false;
                    delete6_button.Source = "";
                }
                else if (globals.GlobalVariables.teamList.Count == 5)
                {
                    pok1_button.Source = globals.GlobalVariables.teamList[0].Sprites.FrontDefault;
                    pok2_button.Source = globals.GlobalVariables.teamList[1].Sprites.FrontDefault;
                    pok3_button.Source = globals.GlobalVariables.teamList[2].Sprites.FrontDefault;
                    pok4_button.Source = globals.GlobalVariables.teamList[3].Sprites.FrontDefault;
                    pok5_button.Source = globals.GlobalVariables.teamList[4].Sprites.FrontDefault;
                    pok1_button.IsEnabled = true;
                    delete1_button.IsEnabled = false;
                    delete1_button.Source = "";
                    pok2_button.IsEnabled = true;
                    delete2_button.IsEnabled = false;
                    delete2_button.Source = "";
                    pok3_button.IsEnabled = true;
                    delete3_button.IsEnabled = false;
                    delete3_button.Source = "";
                    pok4_button.IsEnabled = true;
                    delete4_button.IsEnabled = false;
                    delete4_button.Source = "";
                    pok5_button.IsEnabled = true;
                    delete5_button.IsEnabled = false;
                    delete5_button.Source = "";
                    pok6_button.IsEnabled = true;
                    delete6_button.IsEnabled = false;
                    delete6_button.Source = "";
                }
                else if (globals.GlobalVariables.teamList.Count == 6)
                {
                    pok1_button.Source = globals.GlobalVariables.teamList[0].Sprites.FrontDefault;
                    pok2_button.Source = globals.GlobalVariables.teamList[1].Sprites.FrontDefault;
                    pok3_button.Source = globals.GlobalVariables.teamList[2].Sprites.FrontDefault;
                    pok4_button.Source = globals.GlobalVariables.teamList[3].Sprites.FrontDefault;
                    pok5_button.Source = globals.GlobalVariables.teamList[4].Sprites.FrontDefault;
                    pok6_button.Source = globals.GlobalVariables.teamList[5].Sprites.FrontDefault;
                    pok1_button.IsEnabled = true;
                    delete1_button.IsEnabled = false;
                    delete1_button.Source = "";
                    pok2_button.IsEnabled = true;
                    delete2_button.IsEnabled = false;
                    delete2_button.Source = "";
                    pok3_button.IsEnabled = true;
                    delete3_button.IsEnabled = false;
                    delete3_button.Source = "";
                    pok4_button.IsEnabled = true;
                    delete4_button.IsEnabled = false;
                    delete4_button.Source = "";
                    pok5_button.IsEnabled = true;
                    delete5_button.IsEnabled = false;
                    delete5_button.Source = "";
                    pok6_button.IsEnabled = true;
                    delete6_button.IsEnabled = false;
                    delete6_button.Source = "";
                }
                edit_Button.Text = "Edit";
                edit_Button.TextColor = Color.Red;
            }
        }

        async void delete1_Clicked(object sender, EventArgs e)
        {
            globals.GlobalVariables.teamList.RemoveAt(0);
        }
        async void delete2_Clicked(object sender, EventArgs e)
        {
            globals.GlobalVariables.teamList.RemoveAt(1);
        }
        async void delete3_Clicked(object sender, EventArgs e)
        {
            globals.GlobalVariables.teamList.RemoveAt(2);
        }
        async void delete4_Clicked(object sender, EventArgs e)
        {
            globals.GlobalVariables.teamList.RemoveAt(3);
        }
        async void delete5_Clicked(object sender, EventArgs e)
        {
            globals.GlobalVariables.teamList.RemoveAt(4);
        }
        async void delete6_Clicked(object sender, EventArgs e)
        {
            globals.GlobalVariables.teamList.RemoveAt(5);
        }


    }
}
