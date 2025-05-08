module Tests.PizzaPricingTests

open Lib.PizzaPricing
open Swensen.Unquote
open Xunit

[<Fact>]
let ``Should calculate price for single pizza`` () =
    test <@ pizzaPrice Caprese = 9 @>
 
[<Fact>]
let ``Should calculate price for single pizza with extra sauce`` () =
    test <@ pizzaPrice (ExtraSauce (ExtraSauce Caprese)) = 11 @>
    
[<Fact>]
let ``Should calculate price for single pizza with extra sauce and extra toppings`` () =
    test <@ pizzaPrice (ExtraToppings (ExtraSauce Caprese)) = 12 @>
    
[<Fact>]
let ``Should calculate price for order with fee for two pizzas`` () =
    test <@ orderPrice [Caprese; ExtraSauce Caprese;] = 21 @>
    
[<Fact>]
let ``Should calculate price for order with fee for one pizza`` () =
    test <@ orderPrice [Caprese]= 12 @>
    
[<Fact>]
let ``Should calculate price for order without fee for three pizzas`` () =
    test <@ orderPrice [Caprese; Margherita; Formaggio]= 21 @>