//General function for infinite stream of integers:
let rec upfrom n = Cons(n, fun() -> n+1)

//Function for infinite stream of integers, where the next number is 23 more than the current number:
let rec upfrom23 n = Cons(n, fun() -> n+23) //Will add 23 each time