(*let rec W (env, e) = 
	  match e with
	  | NUM n  -> (I, INTEGER)
	  | BOOL b -> (I, BOOLEAN)
	  | IF (e1, e2, e3) ->
		  let (s1, t1) = W (env, e1)
		  let s2 = unify (t1, BOOLEAN)
		  let (s3, t2) = W (s2 << s1 << env, e2)
		  let (s4, t3) = W (s3 << s2 << s1 << env, e3)
		  let s5 = unify (s4 t2, t3)
		  (s5 << s4 << s3 << s2 << s1, s5 t3)

        /// infer e finds the principal type of e
        let infer e =
          reset ();
          let (s, t) = W (emptyenv, e)
          printf "The principal type is\n %s\n" (typ2str t)*)


//***********************************************************************************************************
type typ =
|BOOL true of boolean
|BOOL false of boolean
|NUM n of int
|SUCC of int * int
|ARROW of typ * typ

