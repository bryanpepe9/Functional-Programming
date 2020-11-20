module examples_23.List_Reversing

    let rec reverseList = function
    | [] -> []
    | x::xs -> let revTail = reverseList(xs)
               revTail @ [x]
    ()
