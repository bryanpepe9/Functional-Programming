open System

let bind_stuff() = 
    let mutable weight = 155
    weight <- 140

    printfn "Weight : %i" weight
    
    
    let change_me = ref 10
    change_me := 60
    
    printfn "Change : %i" ! change_me

bind_stuff()

Console.ReadKey() |> ignore