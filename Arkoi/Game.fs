namespace Arkoi
   
open System
open Types
open Mover

module Game =

    let rec getInput() = 
        let input = Console.ReadKey(true) 
        match input.Key with
            | ConsoleKey.W ->           FaceOrInteract(Up)
            | ConsoleKey.S ->           FaceOrInteract(Down)
            | ConsoleKey.D ->           FaceOrInteract(Right)
            | ConsoleKey.A ->           FaceOrInteract(Left)
            | ConsoleKey.UpArrow ->     Move(Up)   
            | ConsoleKey.DownArrow ->   Move(Down) 
            | ConsoleKey.RightArrow ->  Move(Right)
            | ConsoleKey.LeftArrow ->   Move(Left) 
            | ConsoleKey.X ->           Attack
            | ConsoleKey.Escape ->      Exit
            | _ -> getInput() // If user pressed a key we don't want to handle, ask for input again

    let handleMove state direction =
        {state with protagonist = {state.protagonist with mover = (move state.protagonist.mover direction state.tiles)}}

    let handleFace state direction =
        {state with protagonist = {state.protagonist with mover = (face state.protagonist.mover direction)}}

    let handleInteract state direction =
        // TODO: handle interacting with environment
        state

    let rec stepGame state =
        Graphics.render state
        let mutable quitting = false
        let newState = 
            match getInput() with
            | Move direction -> handleMove state direction
            | FaceOrInteract direction -> 
                // if the protagonist is already facing in the input direction, run the interact code. else face the direction
                if direction = state.protagonist.mover.facing
                then handleInteract state direction
                else handleFace state direction
            | Attack -> state
            | Exit -> quitting <- true; state

        if quitting 
        then newState 
        else stepGame newState
        