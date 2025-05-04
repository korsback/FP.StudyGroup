module Lib.TracksOnTracksOnTracks

let newList : string list = []
let existingList = ["F#"; "Clojure"; "Haskell"]

type AddLanguage = string -> string list -> string list
type CountLanguages = string list -> int
type ReverseList = string list -> string list
type ExcitingList = string list -> bool

let addLanguage : AddLanguage =
    fun value list -> value::list

let countLanguages : CountLanguages =
    fun list -> List.length list
    
let reverseList : ReverseList =
    fun list -> List.rev list
    
let excitingList : ExcitingList =
    function
    | "F#"::_ -> true
    | _::"F#"::[] -> true
    | _::"F#"::_::[] -> true
    | _ -> false