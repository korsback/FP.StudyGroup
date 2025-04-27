module Lib.Bandwagoner

type Coach = {
    Name: string
    FormerPlayer : bool
}

type Stats = {
    Wins: int
    Losses: int
}
type Team = {
    Name: string
    Coach: Coach
    Stats: Stats
}

type CreateCoach = string -> bool -> Coach
type CreateStats = int -> int -> Stats
type CreateTeam = string -> Coach -> Stats -> Team
type ReplaceCoach = Team -> Coach -> Team
type IsSameTeam = Team -> Team -> bool
type RootForTeam = Team -> bool

let createCoach : CreateCoach =
    fun name formerPlayer ->
        { Name = name; FormerPlayer = formerPlayer }
        
let createStats : CreateStats =
    fun wins losses ->
        { Wins = wins; Losses = losses }
        
let createTeam : CreateTeam =
    fun name coach stats ->
        { Name = name; Coach = coach; Stats = stats }
   
let replaceCoach : ReplaceCoach =
    fun team newCoach ->
        { team with Coach = newCoach }

let isSameTeam : IsSameTeam =
    fun team1 team2 ->
        team1 = team2

let rootForTeam : RootForTeam =
    fun team ->
        match team with
        | { Coach = { Name = "Gregg Popovich" } } -> true
        | { Name = "Chicago Bulls" } -> true
        | { Coach = { FormerPlayer = true } } -> true
        | { Stats = { Wins = wins } } when wins >= 60 -> true
        | { Stats = { Losses = losses; Wins = wins} } when losses > wins -> true
        | _ -> false