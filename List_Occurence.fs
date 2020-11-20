module examples_23.List_Occurence

  let rec occursIn n = function
  | [] -> false
  | x::xs -> if n = x then true
               else occursIn n xs
  ()