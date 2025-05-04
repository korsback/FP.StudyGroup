module Lib.PizzaPricing

type Pizza =
    | Margherita
    | Caprese 
    | Formaggio
    | ExtraToppings of Pizza
    | ExtraSauce of Pizza
    
type PizzaPrice = Pizza -> int
type CalculateFee = int list -> int list
type OrderPrice = Pizza list -> int

let rec pizzaPrice : PizzaPrice =
    fun pizza ->
        match pizza with
        | Margherita -> 7
        | Caprese -> 9
        | Formaggio -> 10
        | ExtraToppings pizza -> pizzaPrice pizza + 2
        | ExtraSauce pizza -> pizzaPrice pizza + 1
        
let calculateFee : CalculateFee =
    fun prices ->
        match List.length prices with
        | 1 -> 3::prices
        | 2 -> 2::prices
        | _ -> prices
    
let orderPrice : OrderPrice =
    fun pizzas ->
        pizzas |>
        List.map pizzaPrice |>
        calculateFee |>
        List.sum