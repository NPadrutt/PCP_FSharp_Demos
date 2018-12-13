(*
  "rec":                Eine Funktion explizit als rekursiv Aufrufbar definieren, so dass deren Name auch innerhalb ihres Scopes sichtbar ist.
                        Ansonsten kann sie sich nicht selbts wieder aufrufen.
   "MailboxProcessor":  Dedizierte Message-Queue, welche auf einem eigenen Kontroll-Thread läuft. Jeder Thread kann dem Mailbox-Prozessor asynchron
                        oder synchron eine Message übergeben. Diese wird dann via Aktor ausgewertet.
*)

let mailbox =
    MailboxProcessor.Start(fun mb ->
        let rec loop x =                                                // Definiere "loop" explizit als rekursive Funktion (Scope!)
            async { let! msg = mb.Receive()                             // "Receive()" wartet hier auf eine neue Nachricht. Einstiegspunkt von aussen!
                    let x = x + msg
                    printfn "Running total: %i - new value %i" x msg
                    return! loop x }                                    // "return!" führt einen neuen async-Workflow aus und wartet auf das Resultat
        loop 0)                                                         // Hier erfolgt der erste Aufruf von "loop"

mailbox.Post(1)
mailbox.Post(2)
mailbox.Post(3)
mailbox.Post(4)
mailbox.Post(5)
mailbox.Post(6)