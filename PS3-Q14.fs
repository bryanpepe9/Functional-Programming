(*
{ int *x;
  int a[15];

  *x = 7;
  a[*x] = *x + 4;
}

E(x) = int * var 
------------------ (ID)
E |- x : int * var 
------------------ (R-VAL)
E |- x : int*
------------------ (L-VAL)
E |- *x : int var    E |- 7 : int
---------------------------------- (ASSIGN)
E |- *x = 7 : int
*)
