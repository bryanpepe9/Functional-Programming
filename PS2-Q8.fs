module Tutorials.PS2_Q8

    module number8 =
        let rec fold f a = function
            | [] -> a
            | x::xs -> fold f (f a x) xs
        let rec foldBack f xs a =
            match xs with
                | []    -> a
                | y::ys -> f y (foldBack f ys a)
        let flatten1 xs = fold (@) [] xs
        let flatten2 xs = foldBack (@) xs []
(*The foldback function given that does not use tail recursion, needs to execute the function
on each recursive calls, therefore, the foldback asymptotic time complexity is quadratic O(n^2).
For the function that does use tail recursion, the asymptotic time complexity will simply be linear O(n).*)
