//Part A 
fun f -> match f with
        |[] -> 5
        |x::xs -> 5 + x

(* Answer:
In part A we have a lambda function that uses match to make a comparison of the variable f with an empty list and 
list of strings, thus the return type of the match with function will be list and the the general type of the 
the function will be int list -> list. The input becomes int list because we have a return values which contain the
int value of '5'. x is just the head of the list and for it to be added to 5, x has to be an int itself, so the whole
input must be a int list. Return type: int list -> list.
*)


//Part B
fun x -> (@) x
(* Answer:
Here we have a lambda function the input is initially 'a, however, on the right hand side we have a unit type which
concatenates with x. As we know, the append symbol '@' can only be used to append two lists and since we have no
indication of what data type these lists are we maintain the polymorphic types. Additionally, we have the same variable
x on the right hand side, so the polymorphic type is represented by the same value of 'a. Finally, our type for the 
function above is: 'a list -> ('a list -> 'a list).
*)


//Part C
fun x -> x::5::[]
(* Answer:
We first pass an anonymous value 'a into the lambda function, then we see that teh parameter gets consed to an int
and an empty list therefore, the input x must be an int, and the output must be a list of ints. Therefore, the 
type of the function above must be: int -> int list
*)


//Part D
fun f -> String.length (f "cat")
(* Answer:
Again, we have a lambda function which passes in a parameter f, since the parameter is undefined up until this point, 
the initial type for the input is 'a. Then we apply String.length to f and another string "cat", this means that f must 
be a string and then another string "cat" passed in and a int is returned. Function type: (string -> string) -> int
*)


//Part E
fun x y -> x + " " + y
(* Answer:
Here we have a function that takes as input 2 parameters. Because the two parameters get added to a string, this 
means that they must also be of type string, and since we can only pass a parameter at a time the type of the 
function will be: string -> string -> string.
*)


//Part F
fun f -> f (f "cat")
(* Answer:
This question is similar to the one from part D, however we are ont taking the length of the string so the output 
will also be a string. Function type: (string -> string) -> string
*)