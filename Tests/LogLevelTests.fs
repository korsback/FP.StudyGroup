module Tests.LogLevelTests

open Xunit
open Lib.LogLevels

[<Fact>]
let rec ``Should split log line correctly`` () =
    let logLine = "test : test"
    let expected = [| "test"; "test" |]
    
    Assert.True(Array.forall2 (=) expected (split logLine))

[<Theory>]
[<InlineData("[ERROR]", "error")>]
[<InlineData("[WARNING]", "warning")>]
[<InlineData("[INFO]", "info")>]
[<InlineData("test", "unknown")>]
let rec ``Should format log level correctly`` (logLevel : string, expected : string) =
    Assert.Equal(expected, formatLogLevel logLevel)    

[<Fact>]
let rec ``Should extract message from log line correctly`` () =
    let logLine = "test: message"
    let expected = "message"
    
    Assert.Equal(expected, message logLine)

[<Fact>]
let rec ``Should extract log level from log line correctly`` () =
    let logLine = "[ERROR]: message"
    let expected = "error"
    
    Assert.Equal(expected, logLevel logLine)

[<Fact>]
let rec ``Should reformat log line correctly`` () =
    let logLine = "[ERROR]: message"
    let expected = "message (error)"
    
    Assert.Equal(expected, reformat logLine)

