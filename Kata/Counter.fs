module Counter

type Operation = 
    | Increment
    | Decrement

let counter (operation: Operation) (count: int) : int =
    match operation with
    | Increment -> count + 1
    | Decrement -> count - 1
