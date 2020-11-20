//Non-tail recursive function of map
let rec map f = function
    | []    -> []
    | x::xs -> f x :: map f xs;;
//Time complexity is linear O(n)

//Creating a helper function to write tail recursion 
let rec map_help acc f = function
|[] -> acc
|x::xs -> map_help (fx::acc) f xs // or (acc @ [fx]) for quadratic, extremely slow 

//Tail recursive version of map 
let map_tail xs = List.rev (map_help [] xs)
//Time complexity is quadratic O(n^2)

//List.map is twice as fast
