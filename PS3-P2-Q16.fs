(* 
S → 1S | 0A0S | 2
A → 1A | epsilon
*)

//Part A
//The smallest strings that this CFG can recognize is 2.
//Other strings that it can recognize include: 12,112,1112,11112,10102,1011012,01111011112 and etc.
//This CFG recognizes strings that contain 0's, 1's, and 2's. If you observe the examples above there are a few things
//about this CFG that always hold. First, the CFG will always end in a 2 because 2 is the only value that will not
//lead to any more productions, and also, as seed in the S production, S is always the last character so 2 has to be
//the last value. Also, there will always a single 2, and there can be any amount of 1's and 0's, with a different 
//amount for each. If there is a 0 in the string than there will be at least two 0's by default.

//Here is a complex string to prove the points above:
//S -> 1S
//1S -> 10A0S
//10A0S -> 10101S
//10101S -> 101011S
//101011S -> 1010110A0S
//1010110A0S -> 1010110100A0S
//1010110100A0S-> 1010110100101S
//1010110100101S -> 10101101001012
//In the above we have an equal amount of 0 and ones. 

//Part B
//S            {return 1S;}
//S            {return 0A0S;}
//S            {return 2;}
//A            {return 1A}
//A            { }

type tokens = ZERO | ONE | TWO | EOF | ERRO

let rec parse = function 
|" " -> [EOF]
|s -> 
    match s.Char 0 with 
    |'0' -> ZERO :: parse (s.Substring 1)
    |'1' -> ONE  :: parse (s.Substring 1)
    |'2' -> TWO :: parse (s.Substring 1)
    | x -> failwith (sprintf "PARSE: wrong input %A" x)
|a ->
    match a.Char 0 with 
    |'1' -> ONE  :: parse (s.Substring 1)
    | y -> failwith (sprintf "PARSE: wrong input %A" y)

//Part C
//Tree that creates a separate node for each prduction in S:
type parse_tree_S = 
    |Lf of tokens 
    |Sub1 of parse_tree * parse_tree //1S
    |Sub2 of parse_tree * parse_tree * parse_tree * parse_tree  //0A0S
    |Two of parse_tree //2

//Tree that creates a separate node for each prduction in A:
type parse_tree_A = 
    |Lf of tokens 
    |Sub1 of parse_tree * parse_tree //1A
    |_ -> failwith "Epsilon returns without consuming tokens"

//Part D
//String of ten tokens that is recognized by the grammar: 1010110012
//First I will create a function for s and a which will help with building the tree
let rec s = function 
|[] -> failwith "Input terminated early"
|x::xs -> 
    match x with 
    |ZERO -> xs |> A |> eat ZERO |> S
    |ONE -> xs |> S
    |TWO -> x::xs
    |EOF -> x::xs
    |_ -> failwith "Wrong Input"

let rec a = function 
|[] -> failwith "Input terminated early"
|x::xs -> 
    match x with 
    |ONE -> xs |> A
    |EPSILON -> ""
    |EOF -> x::xs
    |_ -> failwith "Wrong Input"

let buildTree_S = function
|[] -> Lf(ERROR)
|xs -> let (S_tree, tokens) = xs |> S
       if tokens <> [EOF] || S_tree = None
       then printfn "Want [EOF], got %A" tokens
            LF (ERROR)
       else S_tree.Value

let buildTree_A = function
|[] -> Lf(ERROR)
|xs -> let (A_tree, tokens) = xs |> A
       if tokens <> [EOF] || A_tree = None
       then printfn "Want [EOF], got %A" tokens
            LF (ERROR)
       else A_tree.Value

//Tree for the the chosen string:
tree for "1010110012" = 
    Sub1(Lf ONE, Sub2(Lf ZERO, Sub1(Lf ONE, Sub2(Lf ZERO, Two(Lf ONE, Lf ONE), Lf ZERO), Lf ZERO), Lf ONE), Lf TWO)

//Part E
let parse_check_build s = 
    let tokens = catchFail (fun () -> parse s) [ERROR]
    printfn "tokens for %A = %A" s tokens
    let out = catchFail (fun () > checkSyntax tokens) false
    printfn "is valid for %A = %A" s out
    let out = catchfFail (fun () -> buildTree tokens) (Lf(Error))
    printfn "tree for %A = %A" s out