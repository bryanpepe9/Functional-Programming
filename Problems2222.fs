module ClassLibrary2.Problems2222

let inner u v =
    ist.sum(List.map2)
        (fun u1 v1 -> u1 * v1) u v)

let k = inner [1; 2; 3] [4; 5; 6];;

printfn "val it: int %i" k