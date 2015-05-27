namespace Arkoi

module Types =

    type Coordinate = int * int

    type Direction =
        | Up 
        | Down
        | Left
        | Right

    type MoverLevel =
    | Air
    | Ground

    type Mover = {
        position : Coordinate;
        facing : Direction;
        level : MoverLevel
    }

    type Protagonist = {
        mover : Mover
    }

    type MapTile = {
        coordinate : Coordinate;
        image : char;
    }

    type State = {
        tiles : MapTile list
        protagonist : Protagonist
    }

    type Input = 
        | Move of Direction
        | Face of Direction
        | Attack
        | Interact
        | Exit