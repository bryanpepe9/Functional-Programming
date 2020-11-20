//General function for infinite stream of integers:
let rec upfrom n = Cons(n, fun() -> n+1)

//Function for infinite stream of (integer,float) tuples, where the next tuple has the first element fo the current 
//tuple increased by 2 and the second decreased by 0.01:
let rec upfromMult (n,m) = Cons((n,m) fun() -> fst(n,m)+2,snd(n,m)-0.01) //Will add the 2 to the first tuple value and 
//subtract 0.01 from the second one

fst(3,4.1)+2,snd(3,4.1)-0.01 //(5,0.09)