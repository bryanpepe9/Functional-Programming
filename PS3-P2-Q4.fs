let func1 = System.Diagnostics.Stopwatch.StartNew()

let rec reverse xs 
    match xs with 
    |[] -> []
    |x::xs -> reverse xs @ [x]

let list = [1;2;3;4;5]
let tester = reverse list 

printf "%A\n" tester 

func1.Stop()
printfn "%f" func1.Elapsed.TotalMilliseconds

let func2  = Syste.Diagnostics.Stopwatch.StartNew()

let rec tailRecursion list xs = 
    match xs with 
    |[] -> list
    |x::xs -> let nlist = x :: list 
              tailRecursion nLIst xs

let tailTester = tailRecursion [] list
printf "%A\n" tailTester

func2.Stop()
printfn "%f" func2.Elapsed.TotalMillisecond

(*
As we have seen before, the tail recursive function will genrally be faster than the non-tail recursive funtion, 
thus the function tailRecrusion will be O(n) while the function reverse will be O(n^2).

Non-tail recursion = 160.4426 milliseconds 
Tail recursion = 1.4792 milliseconds
*)