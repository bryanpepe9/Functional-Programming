module ConsoleApplication2.Occurence

    let rec occursInList n = function
    | [] -> false
    | x::xs -> if n = x then true
               else occursInList n xs
    ()
