//Tail-recursive function that has a big integer as input and calculates 2I raised to that power.
let rec calc i number =
    match number with
    | _ when number = 0I -> 1I
    | _ when number = 1I -> 2I * i
    | x -> calc (2I*i) (x-1I)
let myfunc x = calc 2I x
let solution = myfunc 5I
