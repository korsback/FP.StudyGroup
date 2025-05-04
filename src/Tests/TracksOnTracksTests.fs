module Tests.TracksOnTracksTests

open FsCheck.Xunit
open Lib.TracksOnTracksOnTracks
open Swensen.Unquote
open Xunit

[<Property>]
let ``Should add to start of list`` (value: string) (list: string list) =
    let sut = addLanguage
    let result = sut value list
    test <@ result = value::list @>

[<Fact>]
let ``Should count languages`` () =
    let sut = countLanguages
    let result = sut ["1"; "2"; "3"] 
    test <@ result = 3 @>

[<Fact>]
let ``Should reverse list`` () =
    let sut = reverseList 
    let result = sut ["1"; "2"; "3"] 
    test <@ result = ["3"; "2"; "1"]@>

[<Fact>]
let ``Should return true if F# is first`` () =
    let sut = excitingList
    let result = sut ["F#"; "Clojure"; "Haskell"]
    test <@ result = true @>
    
[<Fact>]
let ``Should return true if F# is second`` () =
    let sut = excitingList
    let result = sut ["Clojure";"F#";"Haskel";]
    test <@ result = true @>

[<Fact>]
let ``Should return false if F# is non existing`` () =
    let sut = excitingList
    let result = sut ["C#";]
    test <@ result = false @>

[<Fact>]
let ``Should return false if F# is third`` () =
    let sut = excitingList
    let result = sut ["C#"; "Clojure"; "F#"; "Haskell"]
    test <@ result = false @>