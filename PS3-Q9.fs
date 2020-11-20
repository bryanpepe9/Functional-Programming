(*The first expression will give 2^k and the second will give 2^n where n is the result of the previous call*)

let twice f = (fun x -> f (f x))
let successor n = n + 1 
(*Will give 2^5*)
//Twice called; 1: 2 (2^1) 2: 4 (2^2) 3: 8 (2^3) 4: 16 (2^4)
let smallK = twice twice twice twice successor 0 

(*Will give 2^17*)
//Twice called; 1: 2 (2^1) 2: 4 (2^2) 3: 16 (2^4) 4: 65536 (2^16)
let bigK = (twice (twice (twice (twice successor)))) 0

printf "%A\n" smallK
printf "%A\n" bigK