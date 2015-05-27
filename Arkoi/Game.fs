namespace Arkoi
    
open Types

module Game =

    let rec getInput() = 
        let input = System.Console.ReadKey(true) 
        match input.Key with
            | System.ConsoleKey.W ->            Move(Up)
            | System.ConsoleKey.D ->            Move(Right)
            | System.ConsoleKey.S ->            Move(Down)
            | System.ConsoleKey.A ->            Move(Left)
            | System.ConsoleKey.UpArrow ->      Face(Up)
            | System.ConsoleKey.RightArrow ->   Face(Right)
            | System.ConsoleKey.DownArrow ->    Face(Down)
            | System.ConsoleKey.LeftArrow ->    Face(Left)
            | System.ConsoleKey.X ->            Attack
            | System.ConsoleKey.E ->            Interact
            | System.ConsoleKey.Escape ->       Exit
            | _ -> getInput()