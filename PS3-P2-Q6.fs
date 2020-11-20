//Part A
subst (APP(SUCC, ID "a")) "a" (NUM 3)

APP((SUCC, ID "a")) -> APP(subst(SUCC) "a" (NUM 3), subst(ID "a") "a" (NUM 3)
Returned Tree: APP(SUCC, NUM 3)

//Part B
subst (IF (BOOL true, FUN ("a", APP (SUCC, ID "a")), FUN ("b", APP (SUCC, ID "a")))) "a" (NUM 3)

subst (IF (BOOL true, FUN ("a", APP (SUCC, ID "a")), FUN ("b", APP (SUCC, (NUM 3)))))