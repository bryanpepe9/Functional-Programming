open System


    let rec reverseList = function
    | [] -> []
    | x::xs -> let tailRev = reverseList(xs)
               tailRev @ [x]

()

