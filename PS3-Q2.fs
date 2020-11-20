(* 
S → 0A | 1B
A → 0AA | 1S | 1
B → 1BB | 0S | 0 
*)

//Part A
//The smallest strings that this CFG can recognize are 01 and 10
//Other strings that it can recognize include: 0011,1100,0101,1010 and etc.
//This CFG recognizes strings that contain 0's and 1's, these can be in any order as long as 
//the string contains both values, and there is an equal amount of 0's and 1's.
//Here is a complex string to prove this point:
//S -> 0A
//0A -> 00AA
//00AA -> 000AAA
//000AAA -> 0001SAA
//0001SAA -> 00010AAA
//00010AAA -> 000101SAA
//000101SAA -> 0001011BAA
//0001011BAA -> 0001011011 
//In the above we have an equal amount of 0 and ones. 

//Also, it is important to note that every time we see a 0 we get two more A's and we get rid of an A
//when we see a 1. The same can be said for b but with the 0's and 1's swapped.  

//Part B
//String with two derivations: 1100100110

//Part C
(*      
             Parse Tree 1                                         Parse Tree 2
                  S                                                     S
                  |                                                     |
                 1B                                                    1B
                  |                                                     |
                 1BB                                                   1BB
                 /  \                                                  /  \  
               0S    0                                               0S    0S
                |                                                     |     |
               0A                                                    0A    0A
                |                                                     |     |
               1S                                                     1    1S
                |                                                           |
               0A                                                          1B
                |                                                           |
               0AA                                                          0
               /  \
              1   1
              
Derivation: 1100100110                                              1100100110 
*)