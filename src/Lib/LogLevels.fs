module Lib.LogLevels

let split (logLine : string) : string[] = 
    logLine.Split([|":"|], System.StringSplitOptions.TrimEntries)

let formatLogLevel (logLevel : string) : string = 
    logLevel 
    |> fun level ->
        match level with
        | "[ERROR]" -> "error"
        | "[WARNING]" -> "warning"
        | "[INFO]" -> "info"
        | _ -> "unknown"

let message (logLine: string): string = 
    logLine |> split |> fun parts -> parts.[1]

let logLevel(logLine: string): string =
    logLine |> split |> fun parts -> formatLogLevel parts.[0]

let reformat(logLine: string): string =
    logLine
    |> fun line -> $"{message line} ({logLevel line})"