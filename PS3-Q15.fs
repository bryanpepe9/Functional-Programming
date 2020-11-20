let makeMonitoredFun f =
      let c = ref 0
      (fun x -> c := !c+1; printf "Called %d times.\n" !c; f x);;

let mrev1 = makeMonitoredFun List.rev

let mrev2 = fun x -> (makeMonitoredFun List.rev) x

let test () = 
      mrev1 [1..10] |> printfn "%A"
      mrev2 [1..10] |> printfn "%A"

(* The first function mrev1 does not work because it is not a syntactic value and therefore can not have a polymorphic 
type, resulting in a value restriction. List.rev is polymorphic and as stated in the question, makeMonitored is also 
polymorphic, however when we combine both as seen in mrev1, it becomes non-syntactic and therefore, can not have a 
polymorphic type.

Yes, rewriting the declaration using eta expansion solves the problem because as seen in mrev2 the result of using a 
eta expansion turns the declaration into a function definition which is a syntactic value. Since function definitions are
syntactic they can totally polymorphic, so when we call it, the function is going to work. It is important to note, 
that although this solves the initial problem, mrev2 still wont work for everything. For example, if we try to pass
in an empty list, then we would get a value restriction because the mrev2 is trying to be totally polymorphic, we now 
now need to define what type it is.*)