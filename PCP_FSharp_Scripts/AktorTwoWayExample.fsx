// Repräsentiert die verschiedenen Nachrichtentypen
// "Add" und "Sub" sind nur simple Bezeichner
type msg = 
    | Add of int
    | Sub of int
    | Fetch of AsyncReplyChannel<int>

let counter =
    MailboxProcessor.Start(fun inbox ->
        let rec loop n =
            async { let! msg = inbox.Receive()              // "Receive()" wartet hier auf eine neue Nachricht. Einstiegspunkt von aussen!
                    match msg with
                        | Add(x) -> return! loop(n + x)
                        | Sub(x) -> return! loop(n - x)
                        | Fetch(replyChannel) ->
                            replyChannel.Reply(n)           // Mit "Reply()" wird "n" zurückgegeben
                            return! loop(n)}
        loop 0)                                             // Hier erfolgt der erste Aufruf von "loop"

counter.Post(Add 7)
counter.Post(Add 7)
counter.Post(Sub 7)
counter.PostAndReply(Fetch)