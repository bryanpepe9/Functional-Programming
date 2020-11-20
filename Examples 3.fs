module Examples2.Examples_3

open System

let do_funcs() =
    let rand_list = [1;2;3]
    
    let rand_list2 = List.map (fun x -> x * 2) rand_list
    
    printfn "Double List : %A" rand_list2
    
    [5;6;7;8]
    |> List.filter (fun v -> (v % 2) = 0)
    |> List.map (fun x -> x * 2)
    |> printfn "Even Doubles : %A"
    
    let mult_num x = x * 3
    let add_num y = y + 5
    
    let mult_add = mult_num >> add_num
    let add_mult = mult_num << add_num
    
    printfn "mult_add : %i" (mult_add 10)
    printfn "add_mult : %i" (add_mult 10)
    
do_funcs()

Console.ReadKey() |> ignore
