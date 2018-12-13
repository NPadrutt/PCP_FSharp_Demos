//Angenommen, man hat die Liste
//(define a-list (list (list 1 2 3) (list 1 2) (list 1 2 3 4)))
//und möchte jede Liste mit 0 beginnen lassen. Wie kann man dies erreichen, ohne, dass extra eine
//Funktion (mit Namen) geschrieben werden muss?
//
// (map(lambda(list-to-extend) (cons 0 list-to-extend)) a-list)




let list = [ [1;4]; [2;3]; [4;5;7] ]
printfn "%A" list

let modifiedList = List.map(fun l-> 0::l) list
printfn "%A" modifiedList