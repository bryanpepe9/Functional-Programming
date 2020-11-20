(*
Part A
(i)
In the enviroonment, there are four typing rules and int x has two values because of it. The rules are R-VAL,
ASSIGN, ADDRESS, and L-VAL.

(ii)
E(p) = int var
--------------------- (ID)
E |- p : int var 
--------------------- (R-VAL)
E |- p : int
--------------------- (L-VAL)
E |- p : int var 

E |- e1 : t var    E|- e2 : t
-----------------------------
E |- e1 = e2 : t

(iii)
E(p) = int var
--------------------- (ID)
E |- p : int var 
--------------------- (R-VAL)
E |- p : int
--------------------- (L-VAL)
E |- p : int var 

E |- e1 : t var    E|- e2 : t
-----------------------------
E |- e1 = e2 : t
*)