//Question 3 from Problem Set 2:
    type TERMINAL = IF|THEN|ELSE|BEGIN|END|PRINT|SEMICOLON|ID|EOF
    let accept = "Input is valid and completely consumed"
    let error = "Input is not valid and cant be completely consumed"
    let eat terminal = function
        | [] -> failwith "Empty token on eat"
        | x::xs -> if x = terminal then xs else failwith "Invalid token for eat"
    let e = eat ID
    let rec s xs =
        match xs with
            | IF::xs -> xs |> e |> eat THEN |> s |> eat ELSE |> s
            | BEGIN::xs -> xs |> s |> l
            | PRINT::xs -> xs |> e
            | _ -> failwith "Not a valid token for s"
    and l xs =
        match xs with
            | [] -> failwith "premature end of data"
            | END::xs -> xs
            | SEMICOLON::xs -> xs |> s |> l
            | _ -> printf "%A" (List.head xs)
                failwith "Not a valid token for l %A"
    let tester program =
    let result = program |> s
        match result with 
        | [] -> failwith "Early termination or missing EOF"
        | x::xs -> if x = EOF then accept else error

    printf "%A" (tester [IF;ID;THEN;BEGIN;PRINT;ID;SEMICOLON;PRINT;ID;END;ELSE;PRINT;ID;EOF])
    printf "%A" (tester [IF;ID;THEN;IF;ID;THEN;PRINT;ID;ELSE;PRINT;ID;ELSE;BEGIN;PRINT;ID;END;EOF])
    printf "%A" (tester [IF;ID;THEN;BEGIN;PRINT;ID;SEMICOLON;PRINT;ID;SEMICOLON;END;ELSE;PRINT;ID;EOF])
    
    
    
//Question 4 from Problem Set 2:
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



//Question 13-A from Problem Set 2:
type TERMINAL = IF | THEN | ELSE | BEGIN | END | PRINT | SEMICOLON | ID | EOF

type 'a treeParse =
    | Branch_ID of ID: 'a 
    | Print of ID: 'a treeParse
    | Branch_If of E: 'a treeParse * THEN :'a treeParse * ELSE :'a treeParse
    | Branch_Begin of S: 'a treeParse * L: 'a treeParse
    | Branch_End
    | Branch_Semicolon of S: 'a treeParse * L: 'a treeParse
    | Branch_EOF 
    
let E = function
    | [] -> None
    | ID::xs -> Some(Branch_ID(ID), xs)
    | _ -> None
let eat terminal = function
    | x::xs when x = terminal -> Some(xs)
    | _ -> None 
let rec S = function
    | [EOF] -> None
    | IF::xs -> let temporaryVal = xs |> E
                let (e_tree,tail) = if temporaryVal <> None then temporaryVal.Value else (Branch_End,[EOF])
                let temporaryVal = (tail |> eat THEN).Value |> S
                let (then_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Branch_End,[EOF])
                let temporaryVal = (tail |> eat ELSE).Value |> S
                let (else_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Branch_End,[EOF])
                Some(Branch_If(e_tree,then_tree,else_tree),tail)
    | BEGIN::xs -> let temporaryVal = xs |> S
                   let (s_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Branch_End, [EOF])
                   let temporaryVal = tail |> L
                   let (l_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Branch_End, [EOF])
                   Some(Branch_Begin(s_tree, l_tree), tail)
    | PRINT::xs -> let temporaryVal = xs |> E
                   let (e_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Branch_End,[EOF])
                   Some(Print(e_tree), tail)
    | _ -> None 
and L = function
    | END::xs -> Some(Branch_End, xs)
    | SEMICOLON::xs -> let temporaryVal = xs |> S
                       let (s_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Branch_End, [EOF])
                       let temporaryVal = tail |> L
                       let (l_tree, tail) =  if temporaryVal <> None then temporaryVal.Value else (Branch_End, [EOF])
                       Some(Branch_Semicolon(s_tree,l_tree), tail)
    | _ -> None 
    
let exceptionHandler = function
     | None -> "Wrong Input"
     | Some x -> match x with
                 | (tree,remainder) -> sprintf "Tree Produced: %A" tree
let runner =
     let prog = [IF;ID;THEN;IF;ID;THEN;PRINT;ID;ELSE;PRINT;ID;ELSE;BEGIN;PRINT;ID;END;EOF]
     prog |> S |> exceptionHandler |> printf "%s \n"




//Question 13-B from Problem Set 2:
type tokens = ID | ADD | SUB | MUL | DIV | LPAREN | RPAREN | EOF

type 'a parseTree =
    | Br_Id 
    | Br_Add of E_branch: 'a parseTree * T_branch: 'a parseTree
    | Br_Sub of E_branch: 'a parseTree * T_branch: 'a parseTree
    | Br_Mul of T_branch: 'a parseTree * F_branch: 'a parseTree
    | Br_Div of T_branch: 'a parseTree * F_branch: 'a parseTree
    | F_branch of tree: 'a parseTree
    | T_branch of tree: 'a parseTree
    | E_branch of tree: 'a parseTree
    
let eat terminal = function
    | terminal::xs -> Some(xs)
    | _ -> None     
let rec E = function
    | [] -> None 
    | [EOF] -> None 
    | ADD::xs -> let temporaryVal = xs |> E
                 let (e_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Br_Id, [EOF])
                 let temporaryVal = tail |> T
                 let (t_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Br_Id, [EOF])
                 Some(Br_Add(e_tree,t_tree), tail)
    | SUB::xs -> let temporaryVal = xs |> E
                 let (e_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Br_Id, [EOF])
                 let temporaryVal = tail |> T
                 let (t_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Br_Id, [EOF])
                 Some(Br_Sub(e_tree,t_tree), tail)
    | x::xs -> let temporaryVal = (x::xs) |> T
               let (t_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Br_Id, [])
               Some(t_tree, tail)
and T = function
    | MUL::xs -> let temporaryVal = xs |> E
                 let (t_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Br_Id, [EOF])
                 let temporaryVal = tail |> T
                 let (f_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Br_Id, [EOF])
                 Some(Br_Mul(t_tree,f_tree), tail)
    | DIV::xs -> let temporaryVal = xs |> E
                 let (t_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Br_Id, [EOF])
                 let temporaryVal = tail |> T
                 let (f_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Br_Id, [EOF])
                 Some(Br_Div(t_tree,f_tree), tail)
    | x::xs -> let temporaryVal =  (x::xs) |> F
               let (f_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Br_Id, [])
               Some(f_tree, tail)
    | _ -> None 
and F = function
    | ID::xs -> let temporaryVal = xs |> E
                let (e_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Br_Id, [])
                Some(e_tree, tail)
    | LPAREN::xs -> let temporaryVal = xs |> E
                    let (e_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Br_Id, [EOF])
                    Some(e_tree, tail)
    | RPAREN::xs -> let temporaryVal = E xs
                    let (e_tree, tail) = if temporaryVal <> None then temporaryVal.Value else (Br_Id, [])
                    Some(e_tree, tail)
    | _ -> None 
let exceptionHandler = function
     | None -> "Wrong Input"
     | Some x -> match x with
                    (tree, tail) ->  sprintf "Tree Produced: %A" tree
    
let runner =
    let prog1 = [ID;ADD;ID;ADD;ID;ADD;ID;EOF]
    let prog2 = [ID;SUB;ID;MUL;ID;EOF]
    let prog3 = [LPAREN;ID;SUB;ID;RPAREN;MUL;ID;EOF]
    printf "Is program: %A valid? "prog1
    prog1 |> E |> exceptionHandler |> printf "%s \n"
    printf "Is program: %A valid?  prog2
    prog2 |> E |> exceptionHandler |> printf "%s \n"
    printf "Is program: %A valid?  prog3
    prog3 |> E |> exceptionHandler |> printf "%s \n"