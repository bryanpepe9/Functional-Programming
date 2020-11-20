//Below are the following steps for how F# determines the type for: fun f -> f (f 17.3)
1. 'a -> 'b
2. ('c -> 'd) -> 'b
3. (float -> 'd) -> b
4. (float -> float) -> 'b
5. (float -> float) -> float