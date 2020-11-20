//Curried function :
let curry a = (fun x -> fun y -> a(x,y))

let curry f x y = f (x,y)

val curry : a:('a * 'b -> 'c) -> x:'a -> y:'b -> 'c
(*In the above example the curry function takes in a function and users another function as input which is evaluated as curry function type.
Both functions return the same type.*)


//Uncurried function:
let uncurry a = (fun (x,y) -> a x y)

let uncurry f (x,y) = f x y

val uncurry : a:('a -> 'b -> 'c) -> x:'a * y:'b -> 'c
(*In the above example it is uncurry function where a single function is used as an input.*)
