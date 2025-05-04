module Lib.GuessingGame

type Answer =
    | ``Correct``
    | ``To high``
    | ``To low``
    | ``So close``
    | ``Invalid``

type Reply = int -> Answer

let reply : Reply = fun input ->
    match input with
        | 42 -> ``Correct``
        | x when x = 41 || x = 43 -> ``So close``
        | x when x < 41 -> ``To low``
        | x when x > 43 -> ``To high``
        | _ -> ``Invalid``
 
            