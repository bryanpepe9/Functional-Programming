//Binary Tree
let rec element n = function
    |Lf -> Br(n,Lf,LF)
    |Br(m,t1,t2) -> 
                    if n < m then elemetn n t1
                    else element n t2

let rec insert n = function
    |Lf -> Br(n,Lf,Lf)
    |Br(m,t1,t2) -> if n < m then Br(m, insert n t1, t2)
                             else Br(m, t1 ,insert n t2)

let rec buildtree = function
    |[] -> Lf
    |x::xs -> insert x (buildtree xs)

let rec sum = function
    |Lf -> 0
    |Br(m, t1, t2) -> m + sum t1 + sum t2
    
//Sample Calls:
let t = buildtree [3;1;4] //Returns: int tree = Br (4,Br (1,Lf,Br (3,Lf,Lf)),Lf)
element 1 t //Returns: bool = true
element 2 t ////Returns: bool = false
sum t //Returns: int = 8
