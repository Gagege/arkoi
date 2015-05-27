open Arkoi.Game
open Arkoi.Types

let map1 = [ 
        "##############";
        "#>           #          ######";
        "#            ############    #";
        "#            -          +    #";
        "#    ~~      ############    #";
        "#     ~~     #          #    #";
        "#      ~~    #          # <  #";
        "##############          ######" ]

let tokenizeMap map = [for row in map -> [for column in row -> column]]

let generateCoordinates =
    let mutable y' = 0
    let mutable coord = List.empty
    for row in tokenizeMap map1 do
        let mutable x' = 0
        for col in row do
            coord <- List.append coord [{ coordinate = (x', y'); image = col; }]
            x' <- x' + 1
        y' <- y' + 1
    coord

[<EntryPoint>]
let main argv = 
    let state = {tiles = generateCoordinates; protagonist = { position = (2,2); facing = Right }}
    stepGame state
    0 // return an integer exit code
