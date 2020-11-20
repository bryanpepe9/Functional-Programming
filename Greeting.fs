module examples_23.Greeting

    let greeting =
       printfn "Enter your name: "
       let name = System.Console.ReadLine()
       if name = "Bryan" || name = "Steve" then printfn "Hello %A!" (name)
       else printfn ""
    ()