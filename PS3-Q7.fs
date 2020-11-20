let rec upfrom n = Cons(n, fun () -> upfrom(n+1))

let rec filter p (Cons(x, xsf)) =
  if p x then Cons(x, fun () -> filter p (xsf()))
         else filter p (xsf())

let rec helper stream = function
| [ ] -> stream
| x::xs -> let mults = filter( fun z -> z % x = 0 )
                       helper stream xs
let multiples xs = helper (upfrom 1) xs