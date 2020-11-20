module examples_23.Largest_Calc

    let rec largestInList = function
    | [] -> failwith "empty list doesn't contain largest value"
    | [x]  -> x
    | x::xs -> let largetail = largestInList(xs)
               if x > largetail then x
               else largetail
    ()
