let rec tail_helper acc = function //tail recursion always need a helper, so write an accumulator and what it is going to do. 
|0 -> acc //Base case returns the accumulator
|n -> let acc = if n % 2 = 0 //tail recursive doesnt require thought, just make the recursive call.
                then acc 
                else acc + n
      tail_helper acc (n-1) //Calling recursive function on smaller input.

let tail n = if n > 1
             then tail_helper 0 (n-1)
             else 0