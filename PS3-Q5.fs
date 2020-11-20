// The fist interleave function from Question 18 of PS1:
let rec interleave = function
    |_,[] -> []
    |[],y::ys -> y::ys
    |x::xs, y::ys -> x::y::(interleave (xs, ys))
let list = interleave ([1;2;3], [4;5;6])

//Creating a helper function:
let rec helper some (xs,ys) =
    match some, (xs,ys) with
    |some, ([],[]) -> some
    |[y], ([],ys) -> y::ys
    |some,(x'::xs,y'::ys) -> helper (some@[x';y']) (xs,ys)
    |_,(_,_) -> failwith "No Values"

//Tail recursive version of interleave:
let interleaveTail xs ys =
     helper [List.head xs; List.head ys] (List.tail xs,List.tail ys)

//Comparing the timing of both functions with the given examples:

interleave([1..2..19999], [2..2..20000])
interleaveTail = [1..2..199999] [2..2..200000]
//The original function is faster for these two lists.