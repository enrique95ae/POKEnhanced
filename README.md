# POKEnhanced

POKEnhanced is a Mobile cross-platform app developed with Xamarin.forms. This app allows users to search for pokemons by name or pokedex index and visualizing relevant information. The users can add up to 6 pokemons to their team and remove them. Pokemons can be added to a favorites list by clicking a star button. Lastly, all the tweets by the official Pokemon Go twitter account are displayed in a third tab.

This app uses two API for retrieving data:

-PokeAPI

-Twitter's API

## Demo

[YouTube demo](https://www.youtube.com/watch?v=J47x2hurhxM&feature=youtu.be)

## Installation

Not available on the store. In order to test this app you need to run it in a emulator. 


```bash
Clone the project > open the .sln file in visual studio > run it.
```

If for some reason it doesnt work make sure to do:

-Delete bin and obj folders.

-Solution > clean solution.

-Dependencies > NuGets > Restore NuGets

-Rebuild solution.

## NuGets
Newtonsoft.Json -> Json deserializing
LinqToTwitter -> Using twitters API
Xamarin.Plugin.Settings -> for storing data between app usages


## Contributing and code usage
This is by no means a good code, but it is a functioning base. Major improvements can be done all over the app.

Feel free to clone it, work with it and ask questions. 

Give credit if using anything from this app. 

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## Credit to:
[PokeAPI](https://pokeapi.co) for the Pokemon calls.

[Twitter](https://twitter.com) for the tweet retrieving.

[LinqToTwitter](https://www.nuget.org/packages/linqtotwitter/)

[Newtosoft.Json](https://www.newtonsoft.com/json) for the json deserializing.

[Plugin.Twitter](https://www.nuget.org/packages/Plugin.Twitter/) for twitter integration

[Housem Dellai](https://www.nuget.org/profiles/HoussemDellai) for the twitter nuggets and YouTube explanations.

## Done By:
Enrique Alonso Esposito

Matthew Killoran



## License
[MIT](https://choosealicense.com/licenses/mit/)
