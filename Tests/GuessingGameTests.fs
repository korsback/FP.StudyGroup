module Tests.GuessingGameTests_cs

open Xunit

open Lib.GuessingGame

[<Fact>]
let rec ``Should return correct on 42``() =
    Assert.Equal(``Correct``, reply 42)

[<Fact>]
let rec ``Should return to low``() =
    Assert.Equal(``To low``, reply 40)

[<Fact>]
let rec ``Should return to high``() =
    Assert.Equal(``To high``, reply 44)

[<Fact>]
let rec ``Should return so close``() =
    Assert.Equal(``So close``, reply 41)