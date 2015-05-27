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
        Console.SetCursorPosition(protagonist.position)
        Console.Write '@'

    let render state =
        Console.Clear()
        renderTiles state.tiles |> ignore
        renderProtagonist state.protagonist
        Console.CursorVisible <- false