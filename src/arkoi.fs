namespace Arkoi

open System
open Arkoi.Game
open Arkoi.Types

module Main =

    let map1 = [ 
            "##############";
            "#            #          ######";
            "#            ############    #";
            "#            -          +    #";
            "#    ~~      ############    #";
            "#     ~~     # ######## #    #";
            "#      ~~    # #      # #    #";
            "############## #      # ## ###";
            "               #      #  # #  ";
            "     ###########      #### #  ";
            "     #                     #  ";
            "     #                     #  ";
            "     #                     #  ";
            "     #######################  "; ]

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
        let state = {
            tiles = generateCoordinates; 
            protagonist = 
            { 
                mover = {position = (2,2); facing = Down; level = Ground};
                image = {up = '^'; down = 'v'; left = '<'; right = '>'};
            }
        }
        let newState = stepGame state
        Console.Clear()
        printf "%A" newState.protagonist
        Console.ReadKey(true) |> ignore
        0 // return an integer exit code