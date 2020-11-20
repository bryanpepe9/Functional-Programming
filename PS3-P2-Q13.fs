//General function for infinite stream of integers:
let rec upfrom n = Cons(n, fun() -> n+1)

//Function for infinite stream of floats, where the next number is 2.0/3.0 times the current number:
let rec upfromMult n = Cons(n, fun() -> n*(2.0/3.0) //Will multiply by 2.0/3.0 each time