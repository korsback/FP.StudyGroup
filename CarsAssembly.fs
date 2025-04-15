module Lib.CarsAssembly

let successRate (speed : int) : float =
    if speed = 0 then 0.0
    elif speed < 5 then 1.0
    elif speed < 9 then 0.9
    elif speed = 9 then 0.8
    else 0.77

let productionRatePerHour (speed : int) : float =
    speed |>
    successRate |> 
    fun y -> y * float(speed) * 221.0

let workingItemsPerMinute (speed : int) : int =
    speed |> 
    productionRatePerHour |> 
    fun y -> y / 60.0 |> int
