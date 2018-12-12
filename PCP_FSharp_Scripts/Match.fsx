//(cond
// ((> temperatur 35) "heiss")
// ((> temperatur 25) "warm")
// ((> temperatur 15) "mittel")
// (else "kalt"))


let weather temperatur = 
    match temperatur with
    |_ when temperatur > 35 -> "heiss"
    |_ when temperatur > 25 -> "warm"
    |_ -> "kalt"


weather 26