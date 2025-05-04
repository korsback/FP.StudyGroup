module Counter

// Part 1: counter 
type Operation = 
    | Increment
    | Decrement

type Counter = Operation -> int -> int

let counter : Counter =
    fun operation count ->
        match operation with
        | Increment -> count + 1
        | Decrement -> count - 1
    

let counter' (operation: Operation) (count: int) : int =
    match operation with
    | Increment -> count + 1
    | Decrement -> count - 1
   
   
// Part 2:

type State = uint
type Event = Incremented | Decremented
type Command = Increment | Decrement

type Evolve = State -> Event -> State
type Decide = State -> Command -> Event list
type Update = State -> Command -> State

let decide : Decide = fun state command ->
    match command with
    | Decrement when state > 0u -> [Decremented]
    | Decrement when state <= 0u -> []
    | Increment -> [Incremented]
    | _ -> failwith "Invalid command"
        
let evolve : Evolve = fun state event ->
    match event with
    | Incremented -> state + 1u
    | Decremented -> state - 1u
    
let update : Update = fun state command ->
    decide state command |>
    List.fold evolve state

let update' : Update = fun state command ->
    let events : Event list = decide state command
    List.fold evolve state events