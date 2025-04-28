module Tests.CounterTests

open Xunit
open FsCheck.Xunit
open Counter
open Swensen.Unquote

[<Fact>]
let ``Should not decrement when 0`` () : bool = 
    decide 0u Decrement = []

[<Property>] 
let ``Should decrement when above 0`` () : State -> unit = fun state ->
    test <@ decide (state + 1u) Decrement = [Decremented] @>
    
[<Property>] 
let ``Should increment when above 0`` () : State -> unit = fun state ->
    test <@ decide (state + 1u) Increment = [Incremented] @>