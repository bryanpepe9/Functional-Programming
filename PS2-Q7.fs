module Tutorials.PS2_Q7

let rec oddeven = function
| [] -> []
| x::xs -> if x % 2 = 0 
    then oddeven xs @ [x]
    else x :: oddeven xs

(* The function above has an asymptotic time complexity of O(n^2) since it uses the then statement
which converts the linear complexity O(n) to a quadratic complexity O(n^2). This complexity would be
different if tail recursion was used instead.*)