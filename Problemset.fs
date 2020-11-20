
let rec inner v1 v2 adder = 
	match v1 with 
	|[] -> adder
	|x::xs -> match v2 with 
				|y::ys -> inner xs ys (adder + (y * x))
				|[] -> failwith "Mismatch list length"

let rec inner' v1 v2 =
	match v1 with 
	|[] -> 0
	|x::xs -> match v2 with 
				|y::ys -> x * y + inner' xs ys
				|[] -> faliwith "Mismatch list length"

//Sample Calls:
let t = buildtree [3;1;4] //Returns: int tree = Br (4,Br (1,Lf,Br (3,Lf,Lf)),Lf)
element 1 t //Returns: bool = true
element 2 t ////Returns: bool = false
sum t //Returns: int = 8