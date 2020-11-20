(*
Information on Palindromes
Starts with a then ends with a
Starts with b then ends with b
P -> APA
P -> BPB
P -> BAR
*)

(*
Part A 
aba|aba
Context Free Grammar: 
                                    P
                                  / | \
                                 a  P  a
                                  / | \
                                 b  P  b
                                  / | \
                                 a  P  a
                                    |
                                   BAR

type tokens = A | B | BAR
*)


//Part B
type tokens = A | B | BAR

let rec tokenizer =
|"" -> []
|let tok = match s.char 0 with 
           | "a" | "A" -> A
           | "b" | "B" -> B
           | "|" -> BAR
           | _ -> failwith "Invalid Input"
tok :: tokenizer (s.substring[1])


//Part C
let eat terminal = function
|[] -> failwith "Empty token on eat"
|x::xs -_ if x = terminal then xs else failwith "Not a valid token for eat"

let rec palindrome = function
|[] -> failwith "Empty tokens"
|A::xs -> xs |> palindrome |> eat A
|B::xs -> xs |> palindrome |> eat B
|BAR::xs -> xs



//Part D
type tree =
|BR_A of tree
|BR_B of tree
|BR_BAR
|A::xs -> let (tree,tail) = p
          let tail = tail |> eat A
          BR_A (tree)
|B::xs -> let (tree,tail) = p
          let tail = tail |> eat B
          BR_B (tree)
|BAR::xs -> let (tree,tail) = p
          BR_BAR (tree)
