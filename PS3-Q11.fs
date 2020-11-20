let rec fib = function
|0 -> 0
|1 -> 1
|n -> fib(n-1) + fib(n-2)

Let rec helper (fib1, fib2) = function
|0 -> fib 1
|1 -> fib 2
|n -> helper (fib 2, fib1 + fib2)(n-1)

Let imperativeFib = function
|0 -> 0
|1 -> 1
|n ->  let fib1 = ref 0
        let fib2 = ref 1
        let fib3 = ref 1
        let count = ref n
        while !count > 2 do
                Fib := !fib1 + !fib2
                Fib1 := !fib2
                Fib2 := fib
!fib

//The imperative fibonacci function seems to be slower than the tail-recursive version.