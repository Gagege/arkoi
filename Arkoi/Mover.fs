namespace Arkoi

open Types

module Mover =

    let calculateAdjacentCoordinates currentCoordinates direction =
        let x, y = currentCoordinates
        match direction with
        | Up ->     (x, y - 1)
        | Down ->   (x, y + 1)
        | Right ->  (x + 1, y)
        | Left ->   (x - 1, y)

    let move mover direction tiles =
        let newCoordinates = calculateAdjacentCoordinates mover.position direction
        let tileAtCoordinate = List.find (Utils.findTile newCoordinates) tiles
        if mover.level = Air
        then 
            {mover with position = newCoordinates}
        else
            match tileAtCoordinate.image with
            | '#' -> mover // wall
            | '+' -> mover // door
            | _   -> {mover with position = newCoordinates}

    let face mover direction =
        {mover with facing = direction}