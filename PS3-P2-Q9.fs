let rec tail_helper acc = function 
|0 -> acc //Base case returns the accumulator
|n -> let acc = if n % i = 0 
                then acc 
                else acc + n
      tail_helper acc (n-1) //Calling recursive function on smaller input.

let tail n = if n > 1
             then tail_helper 0 (n)
             else 0