module CarsAssemblyTests

open Xunit
open Lib.CarsAssembly

[<Theory>]
[<InlineData(0, 0.0)>]
[<InlineData(1, 1.0)>]
[<InlineData(5, 0.9)>]
[<InlineData(9, 0.8)>]
[<InlineData(10, 0.77)>]
let ``Should calculate success rate correctly`` (speed: int, expected: float) =
    Assert.Equal(expected, successRate speed)
   
[<Theory>]
[<InlineData(0, 0)>]
[<InlineData(1, 1.0)>]
[<InlineData(5, 0.9)>]
[<InlineData(9, 0.8)>]
[<InlineData(10, 0.77)>]
let ``Should calculate production rate correctly`` (speed: int, success_rate: float) =
    let expected = speed |> float |> (*) 221.0 |> (*) success_rate
    Assert.Equal(expected, productionRatePerHour speed)
    
[<Theory>]
[<InlineData(0)>]
[<InlineData(1)>]
[<InlineData(5)>]
[<InlineData(9)>]
[<InlineData(10)>]
let ``Should calculate working items per minute correctly`` (speed: int) =
    let expected = productionRatePerHour speed / 60.0 |> int
    Assert.Equal(expected, workingItemsPerMinute speed)