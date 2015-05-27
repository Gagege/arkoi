namespace Arkoi
   
open System
open Types

module Game =

    let rec getInput() = 
        let input = Console.ReadKey(true) 
        match input.Key with
            | ConsoleKey.W ->           Move(Up)
            | ConsoleKey.D ->           Move(Right)
            | ConsoleKey.S ->           Move(Down)
            | ConsoleKey.A ->           Move(Left)
            | ConsoleKey.UpArrow ->     Face(Up)
            | ConsoleKey.RightArrow ->  Face(Right)
            | ConsoleKey.DownArrow ->   Face(Down)
            | ConsoleKey.LeftArrow ->   Face(Left)
            | ConsoleKey.X ->           Attack
            | ConsoleKey.E ->           Interact
            | ConsoleKey.Escape ->      Exit
            | _ -> getInput() // If user pressed a key we don't want to handle, ask for input again

    let rec stepGame state =
        Graphics.render state
        match getInput() with
        | Move direction -> state |> stepGame
        | Face direction -> state |> stepGame
        | Attack -> state |> stepGame
        | Interact -> state |> stepGame
        | Exit -> ()
        