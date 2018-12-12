open System.Web.Services.Description
open System

//(define rect-calc-list
//  (list (lambda (a b) (* a b)) (lambda (a b) (* 2 (+ a b))))
// )

//(define (calc-a-list funcList param1 param2)
//  (cond
//    ((empty? funcList)
//         (
//          (write "Finished")
//          (newline)
//          )
//         )
//    (else
//     (
//      (write ((first funcList) param1 param2 ))
//      (newline)
//      (calc-a-list (rest funcList) param1 param2)
//      )
//     )
//  )
//)

let calcOperations =  [ fun a b -> a * b
                        fun a b -> 2 * ( a + b)]


let rec calc2 (operations:(int-> int-> int)list) a b = 
    match operations with
    | [] -> ()
    | _-> printfn "Result: %i" (operations.Head a b); calc2 operations.Tail a b

calc2 calcOperations 5 6
calc2 [] 1 4
