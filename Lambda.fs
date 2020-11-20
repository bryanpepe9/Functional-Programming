module examples_23.Lambda

open System

let do_funcs() =
    
    let rand_list = [1;2;3]
    
    let rand_list2 = List.map (fun x -> x * 2) rand_list // fun is used to create lambda expressions
    
    printfn "Double List : %A" rand_list2

	[4;5;6;7;8]
	|> List.filter (fun v -> (v % 2) = 0) // filter is used to filter out elemnts of the list that dont meet the condition
	|> List.map (fun x -> x * 2) // map takes the items and performs and operation, it this case, multiply by 2. 
	|> printfn "Even Doubles : %A"

	let mult_num x = x * 3 // Multiplies a number by three
	let add_num y = y + 5 // Adds 5 to a number

	let mult_add = mult_num >> add_num // This function first multiplies and then adds
	let add_mult = mult_num << add_num // This function first adds then multiply, notice that the order can remain the same if we change direction of >>.
    
	printfn "mult_add : %i" (mult_add 5) // When 5 is given, function returns 20 
	printfn "add_mult : %i" (add_mult 5) // When 5 is given, function returns 30

do_funcs()

Console.ReadKey() |> ignore

