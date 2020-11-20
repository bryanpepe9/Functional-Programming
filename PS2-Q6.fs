module Tutorials.PS2_Q6

let rec inner1 addval xs ys =
    if List.length xs <> List.length ys then failwith "Lists of different length"
    else match xs,ys with
        |_,[] -> addval + 0I
        |xs, ys -> let newadd = addval + (List.head xs * List.head ys)
            inner newadd (List.tail xs) (List.tail ys)
let tailinner xs ys = inner1 0I xs ys

let rec transpose = function        
    | []::_ -> []
    | xs -> List.map List.head xs :: transpose (List.map List.tail xs)

let multmatrix (xs, zs) =
	let rec loop = function
    	| [],_ -> []
    	|x::xs, ys -> let partial = List.map (tailinner x) ys
        	let tail = loop (xs, ys)
        	partial::tail
    let ys = transpose zs
    loop(xs, ys)

matrixmult ([[1;2;3];[4;5;6]], [[0;1];[3;2];[1;2]])