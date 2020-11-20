module Tutorials.PS2_Q9

let rec lastH = function
    |[] -> None
    |[x] -> Some(x)
    |x::xs -> lastH xs

let last list =
    let last = lastAux list
    if last = None then printf " %A's last element is invalid " list
    else printf "%A's last element is %A " list last.Value|[]
last []
last ["cat"]
last [1..5]
