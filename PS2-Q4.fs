module Tutorials.PS2_Q4
type TERMINAL = ID|EOF|ADD|SUB|MUL|RPAREN|LPAREN|DI
    let accept = "Input is valid and completely consumed"
    let error = "Input is not valid and cant be completely consumed"
    let advance token = List.tail token
    let rec e xs 
        let newlist = token xs
        match List.head newlist with
            |ADD -> advance newlist |> e
            |SUB -> advance newlist |> e
            |_ -> newlist
    and b xs =
        if List.head xs = RPAREN then advance xs else failwith "No close parenthesis"
    and token xs =
        let newlist = f xs
        match List.head newlist with
            |MULT -> advance newlist |> token
            |DIV -> advance newlist |> token
             |_ -> newlist
    and f xs =
         match List.head xs with
             |ID -> advance xs
             |LPAREN -> advance xs |> e |> b
             |_ -> failwith (sprintf "Invalid token for f %A" xs)
    let test_program program =
        let result = program |> e
        match result with 
        | [] -> failwith "Missing EOF or early termination"
        | x::xs -> if x = EOF then accept else error

    printf "%A" (test_program [ID;SUB;ID;MUL;ID;EOF])
    printf "%A" (test_program [ID;ADD;ID;ADD;ID;ADD;ID;EOF])
    printf "%A" (test_program [LPAREN;ID;SUB;ID;RPAREN;MUL;ID;EOF])   
