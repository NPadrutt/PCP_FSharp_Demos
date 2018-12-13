open System

printfn "F# Async Example!"
printfn "-----------------" 

let simulatedJob id time =
    let timestamp() = System.DateTime.Now.Ticks
        
    async {
        printfn "Job %d start" id
        let timestamp1 = timestamp()
        do! Async.Sleep(time * 1000)                        // Wartet hier bis Sleep durchgelaufen ist. Ignoriere Rückgabewert
        let timestamp2 = timestamp()
        let timespan = System.TimeSpan(timestamp2 - timestamp1)
        printfn "Job %d end %s" id (timespan.ToString("G"))
    }

// Stream Processing
[ 1 .. 10]                                                  // Liste mit Nummern 1 bis 10
|> List.mapi (fun index time -> simulatedJob index time)    // Lambda Expression -> Führe jeweils pro Element "simulatedJob" aus
|> Async.Parallel                                           // Parallele Abarbeitung
|> Async.RunSynchronously                                   // Starte alle miteinander
|> ignore                                                   // Ignoriere Rückgabewert