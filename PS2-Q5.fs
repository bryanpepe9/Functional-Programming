module Tutorials.PS2_Q5

let rec inner1 addval xs ys =
    if List.length xs <> List.length ys then failwith "Lists of different length"
    else match xs,ys with
        |_,[] -> addval + 0I
        |xs, ys -> let newadd = addval + (List.head xs * List.head ys)
            inner newadd (List.tail xs) (List.tail ys)
let tailinner xs ys = inner1 0I xs ys


let rec inner2 xs ys =
    if List.length xs <> List.length ys then failwith "lists are not same length"
    else match xs,ys with
        |_,[] -> 0I
        |xs, ys -> let heads = (List.head xs * List.head ys)
            heads + (inner (List.tail xs) (List.tail ys))
let nontailinner xs ys = inner2 0I xs ys

printf "%A" (tailinner [1I..50000I] [50001I..100000I])
printf "%A" (nontailinner [1I..50000I] [50001I..100000I])