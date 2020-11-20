//Part A
[<Measure>] type feet
[<Measure>] type inch
[<Measure>] type cent

//Part B
let inchInFeet = 12<inch/feet>
let inchInCent = 0.3937008<inch/centc>

//Part C
let covertInchToFeet = (x:float<inch>) = (x/inchInFeet)
let covertInchToCent = (x:float<inch>) = (x/inchInCent)

//Part D
let covertFeetToInch = (x:float<feet>) = (x/inchInFeet)
let covertCentToInch = (x:float<cent>) = (x/inchInCent)

//Part E
let x = covertFeetToInch 5.5<feet> |> covertCentToInch
printf "%A\n" x

//Part F 
let constant = 100<inch>
let v1 = covertInchToFeet constant
let v2 = covertInchToCent constant
printf "%A\n" v1
printf "%A\n" v2