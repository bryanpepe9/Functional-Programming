module examples_23.Prime_Calculator
      let firstThirtyPrimeNumbers =
              let isprime x =
                  let list = List.filter (fun n -> x % n = 0) [2..x-1]
                  if list = [] then true
                  else false
              let rec numbprint = function
                  |113 -> printfn "%d" 113
                  |x -> if isprime x = true then printf "%d " x
                                                 numbprint (x+1)
                        else numbprint (x+1)

              numbprint 1