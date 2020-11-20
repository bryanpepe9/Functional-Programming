//Part A
let rec interp = function
| NUM n -> NUM n       
|BOOL true -> BOOL true  
|BOOL false -> BOOL false 
|SUCC -> SUCC      
|PRED -> PRED      
|ISZERO -> ISZERO   
|ERROR s-> ERROR s  
| APP (e1, e2) ->
    match (interp e1, interp e2) with
    | (ERROR s, _)  -> ERROR s   
    | (_, ERROR s)  -> ERROR s
    | (SUCC, NUM n) -> NUM (n+1) 
    | (SUCC, v)     -> ERROR (sprintf "'SUCC' requires int as argument, not '%A'" v)
    | (PRED, NUM 0) -> NUM 0         
    | (PRED, NUM n) -> NUM (n-1)   
    | (PRED, v) ->  ERROR (sprintf "'PRED' requires int as arg, not %A" v)
    | (ISZERO, NUM 0) -> BOOL true    
    | (ISZERO, NUM n) -> BOOL false    
    | (ISZERO, v) ->  ERROR (sprintf "'ISZERO' requires int as arg, not %A" v) 
|IF (b, e1, e2) ->  
  match (interp b) with
  | (BOOL true) -> interp e1  
  | (BOOL false)-> interp e2   
  | (v) -> ERROR (sprintf "'IF' must be bool, not %A" v)
    
let interpfile filename = filename |> parsefile |> interp 
let interpstr sourcecode = sourcecode |> parsestr |> interp

printfn "%A" (interpstr "PRED 0")
printfn "%A" (interpfile "../../../if.txt" )

//Part B
let rec subst exp str term = 
    match exp with 
    |NUM n -> NUM n //Base cases
    |BOOL b -> BOOL b
    |SUCC -> SUCC
    |PRED -> PRED
    |ISZERO -> ISZERO
    |IF(c, e1,e2) -> IF(subst c str term, subst e1 str term, subst e2 str term)
    |APP(e1,e2) -> APP(subst e1 str term, subst e2 str term)
    |FUN(x,body) when x = str -> FUN (x,body)
    |FUN(x,body)-> FUN (x,subst body str term)
    |IDs when s = str -> term //Only place where something is changed
    |IDs -> IDs