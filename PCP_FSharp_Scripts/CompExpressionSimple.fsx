type MaybeBuilder() =
  member this.Return(x) = Some x
  member this.Bind(p, rest) = match p with
                              | None -> None
                              | Some a -> rest a
 
let maybe = new MaybeBuilder()

let tryDecr x n = 
  printfn "Conditionally decrementing %A by %A" x n
  if x > n then Some (x - n) else None
 
let maybeDecr x = maybe {
    let! y = tryDecr x 10
    let! z = tryDecr y 30
    let! t = tryDecr z 50
    return t
  }


maybeDecr 100;;