namespace Arkoi

open System
open Types

module Graphics =

    let renderTile tile =
        Console.SetCursorPosition(tile.coordinate)
        Console.Write tile.image

    let renderTiles = 
        List.map renderTile

    let renderProtagonist protagonist =
        Console.SetCursorPosition(protagonist.mover.position)
        let image = match protagonist.mover.facing with
                    | Up -> protagonist.image.up
                    | Down -> protagonist.image.down
                    | Left -> protagonist.image.left
                    | Right -> protagonist.image.right
        Console.Write image

    let render state =
        Console.Clear()
        renderTiles state.tiles |> ignore
        renderProtagonist state.protagonist
        Console.CursorVisible <- false