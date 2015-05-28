﻿namespace Arkoi
   
open System
open Types
open Mover

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

    let rec stepGame state =
        Graphics.render state
        let mutable quitting = false
        let newState = 
            match getInput() with
            | Move direction -> {state with protagonist = {state.protagonist with mover = (move state.protagonist.mover direction state.tiles)}}
            | Face direction -> {state with protagonist = {state.protagonist with mover = (face state.protagonist.mover direction)}}
            | Attack -> state
            | Interact -> state
            | Exit -> quitting <- true; state

        if quitting 
        then newState 
        else stepGame newState
        