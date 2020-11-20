module ClassLibrary2.Matrix_ProblemSet2

let rec mult xs ys =
match ys with
| (_::_)::_ as ys -> (inner xs (List.map List.head ys)) :: (mult xs (List.map List.tail ys))
| _ -> []

let rec multiply (xs, ys) =
match xs with
| (xs)::xss -> (mult xs ys) :: (multiply (xss, ys))
| _ -> []