module Examples2.formatting

let hello() = 
        
        printfn "%*s" 15 "Hello"

hello()

Console.ReadKey()|> ignore