//Part A
type Node =
    |Full of value: int * next: Node
    |Empty 

//Part B
let rec convert list =
    match list with
    |[] -> Empty
    |x::xs -> Full(x, covert xs)

//Part C
let tailTransform covertTail list =
    let listRev = List.rev list
    let rec tail acc list =
        match list with
        |[] -> acc
        |x::xs -> til (Full(x, acc)) xs
        match listRev with
        |[] -> Empty
        |x::xs -> tail (Full(x, Empty))x 