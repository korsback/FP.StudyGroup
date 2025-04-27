module Tests.BandwagonerTests

open Xunit

open Lib.Bandwagoner

let coachName: string = "John Doe"
let formerPlayer : bool = true
let wins : int = 10
let losses : int = 20
let teamName = "Team"
let newCoachName = "Jane Doe"

[<Fact>]
let rec ``Should return struct of Coach``() =
    
    let expected = { Name = coachName; FormerPlayer = formerPlayer }
    let actual = createCoach coachName formerPlayer
    
    Assert.Equal(expected, actual)

[<Fact>]
let rec ``Should return struct of Stats``() =
    
    let expected = { Wins = wins; Losses = losses }
    let actual = createStats wins losses
    
    Assert.Equal(expected, actual)
    
[<Fact>]
let rec ``Should return struct of Team``() =
    let coach = createCoach coachName formerPlayer
    let stats = createStats wins losses
    
    let expected = { Name = coachName; Coach = coach; Stats = stats;}
    let actual = createTeam coachName coach stats
    
    Assert.Equal(expected, actual)
    
[<Fact>]
let rec ``Should return struct of Team with replaced coach``() =
    let coach = createCoach coachName formerPlayer
    let stats = createStats wins losses
    let team = createTeam teamName coach stats
    let newCoach = createCoach newCoachName false
    
    let expected = { Name = teamName; Coach = newCoach; Stats = stats;}
    let actual = replaceCoach team newCoach
    
    Assert.Equal(expected, actual)

[<Fact>]
let rec ``Should return true for equal teams``() =
    let team1 = createTeam teamName (createCoach coachName formerPlayer) (createStats wins losses)
    let team2 = createTeam teamName (createCoach coachName formerPlayer) (createStats wins losses)
    
    let actual = isSameTeam team1 team2
    
    Assert.Equal(true, actual)

[<Theory>]
[<InlineData("Gregg Popovich", "Team1", false, 56, 26, true)>]
[<InlineData("Coach1", "Chicago Bulls", false, 56, 26, true)>]
[<InlineData("Coach1", "Team1", true, 56, 26, true)>]
[<InlineData("Coach1", "Team1", false, 30, 40, true)>]
[<InlineData("Coach1", "Team1", false, 60, 40, true)>]
[<InlineData("Coach1", "Team1", false, 30, 20, false)>]
let rec ``Should root for team with correct input``(coach: string, teamName: string, formerPlayer: bool,
                                 wins: int, losses: int, expected:bool) =
    let sutCoach = createCoach coach formerPlayer
    let sutStats = createStats wins losses
    let sutTeam = createTeam teamName sutCoach sutStats
    
    let actual = rootForTeam sutTeam
    
    Assert.Equal(expected, actual)