//Part A
[<Measure>] type sec
[<Measure>] type microsec
[<Measure>] type millsec
[<Measure>] type nanosec

//Part B
let secInMicrosec = 0.001<sec/microsec>
let secInMillsec = 0.000001<sec/millsec>
let secInNanosec = 0.000000001<sec/nanosec>

//Part C
let covertSecToMicrosec = (x:float<sec>) = (x/secInMicrosec)
let covertSecToMillsec = (x:float<sec>) = (x/secInMillsec)
let covertSecToNanosec = (x:float<sec>) = (x/secInNanosec)

//Part D
let covertMicrosecToSec = (x:float<microsec>) = (x * secInMicrosec)
let covertMillsecToSec = (x:float<millsec>) = (x * secInMillsec)
let covertNanosecToSec = (x:float<nanosec>) = (x * secInNanosec)

//Part E
let x = covertMicrosecToSec 5000.0<microsec> |> covertMillsecToSec
printf "%A\n" x

//Part F
let constant = 0.00000009<sec>
let v1 = covertSecToMicrosec constant
let v2 = covertSecToNanosec constant
printf "%A\n" v1
printf "%A\n" v2