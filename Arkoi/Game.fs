namespace Arkoi
   
open System
open Types

module Game =

    let rec getInput() = 
        let input = Console.ReadKey(true) 
        match input.Key with
            | ConsoleKey.W ->           Move(Up)
            | ConsoleKey.S ->           Move(Down)
            | ConsoleKey.D ->           Move(Right)
            | ConsoleKey.A ->           Move(Left)
            | ConsoleKey.UpArrow ->     Face(Up)
            | ConsoleKey.DownArrow ->   Face(Down)
            | ConsoleKey.RightArrow ->  Face(Right)
            | ConsoleKey.LeftArrow ->   Face(Left)
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
        {mover with position = newCoordinates}

    let rec stepGame state =
        Graphics.render state
        let mutable quitting = false
        let newState = 
            match getInput() with
            | Move direction -> {state with protagonist = (move state.protagonist direction state.tiles)}
            | Face direction -> state
            | Attack -> state
            | Interact -> state
            | Exit -> quitting <- true; state

        if quitting 
        then newState 
        else stepGame newState
        