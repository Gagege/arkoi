namespace Arkoi

module Types =

    type Coordinate = int * int

    type Direction =
        | Up 
        | Down
        | Left
        | Right

    type Protagonist = {
        position : Coordinate;
        facing : Direction;
    }

    type MapTile = {
        coordinate : Coordinate;
        image : char;
    }

    type World = {
        tiles : MapTile list
        protagonist : Protagonist
    }

    type Input = 
        | Move of Direction
        | Face of Direction
        | Attack
        | Interact
        | Exit