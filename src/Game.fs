namespace Arkoi
   
open System
open Types

module Game =

    let rec getInput() = 
        let input = Console.ReadKey(true) 
        match input.Key with
            | ConsoleKey.UpArrow ->     Move(Up)
            | ConsoleKey.DownArrow ->   Move(Down)
            | ConsoleKey.RightArrow ->  Move(Right)
            | ConsoleKey.LeftArrow ->   Move(Left)
            | ConsoleKey.X ->           Attack
            | ConsoleKey.E ->           Interact
            | ConsoleKey.Escape ->      Exit
            | _ -> getInput() // If user pressed a key we don't want to handle, ask for input again

    let calculateNewCoordinates currentCoordinates direction =
        let x, y = currentCoordinates
        match direction with
        | Up ->     (x, y - 1)
        | Down ->   (x, y + 1)
        | Right ->  (x + 1, y)
        | Left ->   (x - 1, y)

    let move mover direction tiles =
        let newCoordinates = calculateNewCoordinates mover.position direction
        let tileAtCoordinate = List.find (Utils.findTile newCoordinates) tiles
        if mover.level = Air
        then 
            {mover with position = newCoordinates}
        else
            match tileAtCoordinate.image with
            | '#' -> mover // wall
            | '+' -> mover // door
            | _   -> {mover with position = newCoordinates}

    let rec stepGame state =
        Graphics.render state
        let mutable quitting = false
        let newState = 
            match getInput() with
            | Move direction -> {state with protagonist = {state.protagonist with mover = (move state.protagonist.mover direction state.tiles)}}
            | Attack -> state
            | Interact -> state
            | Exit -> quitting <- true; state

        if quitting 
        then newState 
        else stepGame newState