module ConsoleApplication2.Special_Sum

  let rec specialSum = function
    |1 -> 0
    |n -> divby(n) + specialSum(n-1)
    ()
    let max x y =
        if x > y then x
        else y
