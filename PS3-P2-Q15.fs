let thrice f = f << f << f 
let twice f = f << f
let successor n = n + 1
let tester = thrice twice successor 0 
let other = twice thrice successor 0
printf "%A\n" tester
printf "%A\n" other

//For thrice twice successor 0 = 8
//For twice thrice successor 0 = 9