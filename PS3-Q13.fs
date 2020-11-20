let stack x = 
    let stk ref x
    ((fun y -> stk := y :: (!stk)), //Push Function
    (fun () -> stk := List.tail (!stk)) //Pop Function
    (fun () -> List.head (!stk)), //Top Function
    (fun () -> List.isEmpty (!stk))) //isEmpty Function
