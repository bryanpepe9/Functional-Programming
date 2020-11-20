// Single line comments use a double slash
(* Multi line comments use an opening brace followed by a star to open and a star followed by a closing brace to close.*)

//==================Variables==================
//The "let" keyword defines an immutable variable. An immutable variable is one that cannot change its value.
let myInt = 5 //Assigning an integer to the variable myInt
let myFloat = 3.14 //Assigning a float to the variable myFloat
let myString = "Hello F#" //Assigning a string to the variable myString
// Note above that F# has type inference and so, unlike Java we do not need to specify a type when creating a variable.

//==================Lists======================
let twoToFive = [2;3;4;5] //Here we created a list with numbers from one to five
//Note that to create a list you must use the square brackets and unlike other languages we use the semicolons as delimiters.
//Never uses commas as delimiters, they have another functionality when dealing with tuples but never for lists.
let oneToFive = 1 :: twoToFive //This prints a list with numbers from one to five.
//Note above that I used the cons operator "::" to create a list with a new first element.
//The cons operator can only be used to attach a number to a list, but not to lists.
let zeroToFive = [0;1] @ twoToFive //Prints a list from zero to five. The append operator "@" is used to connect to lists.

List.head twoToFive //Returns the first element of the list. In this case 2. Note, that it just returns the element and not a list. 
List.tail twoToFive //Returns all elements in the list aside from the first one. In this case [3;4;5]
List.map (fun n -> n*n) twoToFive //Perfoms some operation in the function, takes in a function and a list as arguments, in this case it squares a list. 
List.filter (fun x -> x%2=0) twoToFive //Filters out the elements that do not meed the specify condition defined in the argument. In this case, even numbers.
List.reduce (*) [1..5] //List.Reduce applies a binary function to successive elements in the list, accumulating a single value. Result: 120.

//=================Functions===================
//The "let" keyword is also used to define a named function
let square x = x * x //Defined a function named square that takes in a single parameter and returns that value squared.
//As you can see above we no parenthesis are used for the parameters. 
square 8 //applying the function to the value 8, this returns 8 squared or 64. Note that parenthesis are omitted as well.

let add x y = x + y //Function named add that takes in two parameters x and y, and returns the sum.
//Again, dont use (x,y) it means something completely different.
add 2 3 //The sum of both inputs, returns 5.

// To define a multi line function just use indents, no semicolon needed.
let Evens list = //Defining "isEven" as an inner nested function of Evens which takes in a list
    let isEven x = x % 2 = 0 //Created a function isEven that takes in a variable x and checks if the variable is even
    List.filter isEven list //Applied the List.filter function which used the isEven function to check for even elements in a list
Evens oneToFive //Applied the evens function to the shown list and it returned a list with only the even values. Result: [2;4].
//Note that the "List.filter" function is a library function that takes two parameters a boolean function and a list to operate on.

//You can also used parenthesis to clarify precedence. In the example below, do map first with two args, then do sum on the results.
//If the parenthesis were used, list.map would be passed as an arg to list.sum.
let sumOfSquaresTo100 = //Function that returns the sum of all squares from 1-100.
    List.sum (List.map square [1..100]) //Returns: 338350. The "List.map function is used to apply a function to all elements in a list.
    //Note that if you have a list with many numbers and you dont want to write them all you can use "[..]" with the ranges at each side.
    
//You can pipe the output of one operation to the next using "|>"
//Below is the same function as the one above, but using pipes.
let sumOfSquaresTo100Piped =
    [1..100]|> List.map square |> List.sum //Start with the inside when using pipes.
    
//You can define Lambda (anonymous functions) using the "fun" keyword.
let sumOfSquaresTo100WithFun =
    [1..100]|> List.map (fun x -> x * x) |> List.sum //Used the Lambda function instead of calling square.
//In F# returns are implicit, no return is needed. A function always returns the value of the last expression used.

//================Pattern Matching===============
//"match...with" is a supercharged case/switch statement.
let simplePatternMatch =
    let x = "a"
    match x with
    |"a" -> printfn "x is a" //If x is a then it will print out "x is a". //The arrow "->" means "then".
    |"b" -> printfn "x is b" //If x is b then it will print out "x is b".
    |_ -> printfn "x is anything" //The underscore matches anything. So if the first two fail, where x is not a and b, then it will print x is anything.
    
//Some and none are roughly analogous to nullable wrappers.
let validValue = Some(99)
let invalidValue = None

//In the example below, "match...with" matches the "Some" and the "None", and also unpacks the value in "Some" at the same time.
let optionPatternMatch input =
    match input with
    |Some i -> printfn "input is an int = %d" i
    |None -> printfn "input is missing"
    
optionPatternMatch validValue //Returns the value in some which is 99 and also removes the wrap by returning "()" separately.
optionPatternMatch invalidValue //Returns a message saying input is missing.

//==================Complex Data Type===================
//Tuple types are pairs, triples, etc. Tuples use commas.
let twoTuple = 1,2 //Two values separated by commas, no parenthesis is needed here either.
let threeTuple = "a",2,"true" //Tuples can be comprised of different data types unlike lists.

//Record types have named fields and used semicolons as separators.
type Person = {First:string; Last:string} //We use curly braces in record types. Use ":" in between the type and the variable name.
//Unlike in java, string in F# is written with lower case 's'.
let person1 = {First="John"; Last="Doe"} //Here we use "=" to assign a value to the type indicated above.

//Union types have choices. Vertical bars are separators.

type Temp =
    |DegreesC of float
    |DegreesF of float
let temp = DegreesF 98.6

//Types can be combined recursively in complex ways, below is a union type that contains a list of the same type.
type Employee =
    |Worker of Person //The keyword "of" means that it belongs to that type. The record type "Person" was defined earlier
    |Manager of Employee list
let jdoe = {First="John"; Last="Doe"}
let worker = Worker jdoe

//====================Printing=====================
//The printf/printfn function are similar to the ones in Java.
printfn "Printing an int %i, a float %f, a boolean %b" 1 2.0 true
printfn "A string %s, and something generic %A" "Hello" [1;2;3;4;5;6;7;8;9;10]

//All complex data types have pretty printing build in.
printfn "twoTuple=%A,\nPerson=%A,\nTemp=%A,\nEmployee=%A" 
         twoTuple person1 temp worker
//There are also sprintf/sprintfn for formatting data into a string, similar to String.Format.

//=================Class Work======================
//The program below shows how to use classic recursion for fibonacci numbers
let rec fib1 = function //The keyword "function is a shorthand", parameter is not named int the signiture.
    |0->0I//The default parameters is matched against several OR options 
    |1->1I
    |n->fib1(n-1)+fib1(n-2)
    
//This same statement can also be written in a different way.
let rec fib1a x = //When function is not used, you need to specify a parameter and include the match statment with the parameter.
    match x with
    |0->0I
    |1->1I
    |n->fib1a(n-1)+fib1a(n-2)
    
//Polymorphic Exponentiation
//The last statement executed by a function is its return value. 
let mk_expon times one = //Function can be declared inside other function, and if so they are only visible in the scope of the outer function. 
    let rec expon n x = //In this case expon is a local function which is returned by the outer function mk_expon.
        if n = 0 then one //If the value is equal to zero then return one, base case. 
        elif n%2=0 then expon (times x x) (n/2) //If the value is even then apply the recursive function expon on the times function and divide n by 2
        else times x (expon x (n-1)) //If the first two are not matched thatn call the function times on x and the result of expon x on n-1.
    expon //The local function is created and returned
//The function above is an example of a first class function. Functions in F# are just like variables, the can be passed into other function and returned from functions.

//Here are some different versions of the function mk_expon created above that perform exponentiation.
//Int exponentiation
let expon1 = mk_expon (*) 1
expon1 4 3 //Returns 4^3 = 64
//String exponentiation
let expon2 = mk_expon (+) ""
expon2 "cat" 3 //Returns the word cat 3 times one after the other: catcatcat.

//Matrix multiplication
//Multiply matrices by calculating the inner product of a row from the first matrix with a column of the second matrix
//If you have two two-by-two matrices you could create 8 different parameters, but it would be more efficient to create two 4-tuples instead.
let matmult (a:bigint,b,c,d) (e,f,g,h) = //Declaring one parameter as bigint default all parameters to bigint
    (a*e+b*g, a*f+b*h, c*e+d*g, c*f+d*h)
let identity = (1I,0I,0I,1I)

//Local Declarations
//Local declarations use the following syntax:
let y = 17 in 3 * y  //The function will use the result of y in 3*y and will print the product which is 51.

//Below is a great example of how local declarations work.
let z = 5 in (let z = 3 * z + 1 in 2 * z) + z //Here, the first z takes the value of 5, the second z takes the value of 3*5+1=16,
//and the last z takes the value of 5 because it is defined outside the parenthesis. Result is 37.

//Function Declarations
let suc n = n + 1 //Declared a function that takes adds one to the input
let succ = fun n -> n + 1 //Same function as the one above but using lambda instead
//Lambda functions are useful when you are only using the function once.

//It is quite common for local declarations to be used in the body of a function, when doing so we omit the "in" keyword and use indentation.
let cos_squared r =
    let c = cos r
    c*c;;


//Tuples
//New value can be formed by combining values into a tuple
let tuple1 = (17,"abc",true) //Tuples can be of different types, they are separated by commas and enclosed in standard brackets
fst(3,true) //Returns the first value int the tuple, ie 3.
snd(3,true) //Returns the second value in the tuple, ie true.
//Note: fst and snd only work on 2-tuples.

//Usually we use pattern matching syntax to process tuples
let (a,b,c) = (17,"bird",true) //tuples are matched based on their location.

//It is also common to use pattern matching in function, this is shown below.
let rec power (m,n) =
    if n = 0
    then 1.0
    else m * power(m,n-1)
    power(2.0,10)
    
 
//Type inference and polymorphism.
let swap (x,y) = (y,x) //Here we see a very useful functionality of F# known as polymorphism.
//Because no specific type was defined above, f# left the types as 'a and 'b which doesnt limit the function for later use.

let double x = x + x //The overloaded operator "+" is defined for numbers and string, but it is not polymorphic in the way that swap is.
//F# tends to deal with overloaded numeric operators in very crude way, if no type is defined then it defaults to int.

let double (x:string) = x + x //If you want a different type for a function, you must use type annotation.

let inorder (x,y,z) = (x<=y)&&(y<=z) //For overloaded comparison operators we dont get the same problem.
//For this comparison operators, the function type does not default to int and thus it is polymorphic.


//Using Lambda Functions
let cadd a = (fun b -> a+b) //We can write functions that take in an argument a and returns another function that takes an argument b.
//The function above is in curried form and is also known as a curried function.

//Below are two different types of curried functions, the first is a normal function and the second is a lambda(anonymous) function. 
let valadd a b = a + b
fun a b -> a + b


//Curried Infix Operators
let triple = (*) 7 //An infix operator can not be used without variable, but in f# we can transform an infix to a prefix by including parenthesis around that operator. 

//Value Restriction
//Just like for normal variable list can also have polymorphic type, however, using them causes an error due to value restriction.
List.rev ([]: int list) //If we dont specify a type for this empty list then we get a value restriction error.

//Using the "function" key work
let rec prod = function
    |[]->1
    |n::ns -> n * (prod ns)
//Using explicit matching
let rec prodexp ms = //Note that the match with statement has the same use as function keyword.
    match ms with
    |[] -> 0
    |n::ns -> n * (prod ns)
    
//Down From Example
let rec downfrom = function
    |0 -> [] //Integers can be used in patterns too.
    |n -> n::downfrom(n-1)
downfrom 5 //Returns: [5;4;3;2;1]

//Pipelining
//The forward pipe operator "|>" is a powerful tool that combines existing functions into new functions.
let fact n = n|> downfrom |> prod
fact 6 //Returns then factorial of 6 which is 720.


//Recursion
let rec append = function //To use recursion, we must pass the four steps of the checklist with recursion. 
    |([],ys) -> ys //Here step 1 is met because we have included he only base case, since list 2 cannot be empty.
    |(x::xs, ys) -> let partial = append (xs,ys) //Step 2 is correct because the base case is correct and returns the correct result after each recursive call. 
                    x :: partial //Step 3 is also correct as seen in the line above because (xs,ys) is smaller than (x::xs, ys).
                   
let rec fact = function
    |0->1
    |n->n*fact(n-1)
    
let rec sort = function
    |[]->[]
    |[n]->[n]
    |n::ns -> n :: sort ns
    
let rec f x = f x


//Permutation
//First create a helper function called insert which will allow the problem to be broken down.
let rec insert x = function
    |[]->[[]]
    |y::ys -> (x::y::ys) :: List.map (fun zs -> y::zs) (insert x ys)
    

//Find all permutations of a list of distinct elements.
let rec permute = function
    |[]->[[]]
    |x::xs -> List.collect (insert x) (permute xs)
insert 5 [20;30] //Result:[[5; 20; 30]; [20; 5; 30]; [20; 30]]

//NEW TYPES
//Records: they are the same as tuples except the components are accessed by name. Records are also the simplest of the new types.
type Person1 = {Name:string; Age:int} //Created a record type for person.
let p = {Name = "Bryan"; Age = 20} //Here I assigned values to my record. Note that we use "=" and not ":" like we did when creating the record.
p.Name //Returns the name
p.Age  //Returns the age

//Discriminated Unions: Provide support for values that can be one of a number of different cases, possibly each with different values and types.
type Shape =
    |Rectangle of width : float * length : float
    |Circle of radius : float
    |Prism of width : float * float * height : float

let rect = Rectangle(width = 10.0, length = 1.3)
let circ = Circle(1.0)
let pris = Prism(5.0, 2.0, height = 3.0)


//Polymorphic Discriminated Unions
//The Shape type defined above only worked on float, instead of defining a new shapeInt type, make the shape type polymorphic by passing a type to it.
type Shape <'a> = //The "<'a>" is used to make the function polymorphic, and every instance of a type in the union must be switched to 'a as well. 
    |Rectangle of width : 'a * length : 'a
    |Circle of radius : 'a
    |Prism of width : 'a * 'a * height : 'a


//Simple Unions
//Simple Unions only contain identifiers. Below red, green, and blue are called constructors. Pattern matching on colours is supported.
type Color =
    |Red
    |Green
    |Blue

let emotion = function
    |Red -> "love"
    |Green -> "Luck"
    |Blue -> "Peace"
//Important: constructors such as Red, Green, and Blue must all begin with a capitalized letter as they are constructors.


//Incomplete Patter Matches
let rec last = function
    |[] -> failwith "Empty list has no last element" //"failwith" is a way to throw you own error message, in this case an error message is thrown on the empty list.
    |[x] -> x
    |x::xs -> last xs
//Note: if patterns are matched in the wrong order, like if we considered the last to lines in the function above to be switched, w would get an error. 

//Wildcard and Expressions
//Wildcard pattern matching matches anything but does not create a binding
//We can use the wildcard patter matching to select a specific element in a list, the is shown in the function below where the third element is selected.
let third (_ :: _ :: x :: _) = x //Use underscore "_" for other locations.

//We can also use patterns in match expressions to match an intermediate value instead of just the input to the function.
let foo s =
    match String.length s with
    |0 -> "Empty"
    |1 -> "Short"
    |_ -> "Long"


//Local Declarations
//A use of local declarations is to define auxiliary functions within the definition of an outer function.
//Such auxiliary function are not visible outside, also they have access to the outer functions parameters

let map f xs =
    let rec map_aux = function
        |[] -> []
        |y::ys -> f y :: map_aux ys
    map_aux xs
//Note that map_aux does not need to pass the function parameter f to its recursive calls.


//Mutual Recursion
//It is not possible to declare two function that call each other because the first declaration does not know about the second declaration.
//However, simultaneous declarations using the keyword "and" allows for mutual recursion.

let rec f n = if n = 0
              then 1
              else g n
and g m = m * f (m-1)

//Static Scoping, Eager Evaluation, and Lazy Evaluation
//Static Scoping - use the binding for a variable when the function is defined, not when it is called.
let x = 3 in let f y = x + y
             let x = 8
             f x //Returns the sum of 3 and 8 which is 11.
             
//Eager Evaluation - Evaluates the value of a parameter when the function is called, not when the parameter is used.
let myand1 (e1,e2) = if e1 then e2 else false
let x = 0
x > 0 && 10/x > 2 //10/2 is not executed
myand1 (x>0,10/x>2)

//Lazy Evaluation - Evaluates functions arguments only when needed.
let myand2 (e1,e2) = if e1() then e2() else false
myand2 ((fun() -> x > 0), (fun() -> 10/x > 2))


//Quicksort
let rec split pivot = function
    |[] -> ([],[])
    |x::xs -> let(left,right) = split pivot xs
              if x < pivot
              then (x::left, right)
              else (left, x::right)
split 4 [6;2;9;1;4;6;1]

let rec qsort = function //Quicksort function
    |[]->[] //Base case: if the list is empty no need to sort
    |[x]->[x] //Base case: if the list has one element no need to sort
    |x::xs -> //x is the pivot
              let(left,right) = split x xs
              qsort left @ (x::qsort right)
qsort [6;2;9;1;4;6;1]

//Trees 
//Discriminated unions can contain heterogeneous types. Unions can be polymorphic or recursive.
//A tree can is either a leaf or a branch and a branch contains other trees.
type Tree <'a> =
    |Lf //Base Case
    |Br of 'a * 'a tree * 'a tree
    
//Creating a recursive function that sums up all the values in a binary search tree.
let rec sum = function
    |Lf -> 0
    |Br(m,t1,t2) -> m + sum t1 + sum t2
    
//Insert Values in Binary Tree
let rec element n = function
    |Lf -> false
    ||Br(m,t1,t2) -> n = m then true
                     elif n < m then elment n t1
                     else element n t2
                     
let rec insert n = function
    |Lf -> Br(n,Lf,Lf)
    |Br(m,t1,t2) -> if n < m
                    then Br(m, insert n t1, t2)//New tree constructor
                    else Br(m, t1, insert n t2)
                    
//Building a Binary Tree from a List
let rec buildtree = function
    |[] -> Lf
    |x::xs -> insert x (buildtree xs)
let t = builtree [3;1;4]
        
//Non-homogeneous Lists
//Discriminated unions can combine whatever types we want, use them in effect to create non-homogeneous lists
type stew =
    |Int of int
    |Str of string
    |Boo of boolean
let stewList = [Int 5; Str "abc"; Boo true]

//Built in Union Types
//F# has a built in discriminated union that can be used to fix some of our earlier problems
type 'a option =
    |Some of 'a
    |None
    
//Instead of using "failwith" to send an exception, use an option type. This is shown below with the last function used earlier.
let rec last2 = function
    |[] -> None
    |[x] -> Some(x)
    |x::xs -> last xs
    
//Using option
//The caller can extract the value from the return type or test it for Some or None
let testoption = function
|None -> "No value"
|Some(n) -> sprintf "%i" n

testoption Some (15) //string = "15"
testoption None //string = "None"

//Memories and Variables
//We model memory "M" as a mapping from identifiers to intgers 
//The behaviour of a program in memory "M" depends on the behaviour of expressions and commands
//-An expression e should produce an integer value n
(M,e) -> n
//-A command c should produce a new memory M'. Intuitively, command changes the state of memory.
(M,c) -> M' //M' represents new memory

//Example Judgements
//Here are some example judgements that we would expect our semantics to prove:
({x=7, y=15}, 2*x+3) => 17 //The sybol "=>" means resolves to
({x=7, y=15}, y:= 2*x+3) => {x=7, y=17} 
({x=7, y=15}, x+z) =/=> //The symbol "=/=>" means does not resolve to


Type BT
     |Lf
     |Br of int * BT * BT

let rec order = function 
     |Lf -> []
     |Br(n,l,r) -> 
                   let left = order l
                   let right = order r
                   left @ n :: right 
                   
                   
//===LEXICAL ANALYSIS=== 
//The lexer is a part of a computer and it is responsible for doing lexical analysis
//Lexical analysis is the process of transforming the source file, from a sequence of characters to a sequence of tokens.
//Usually this includes the striping of white space and comments.
//Below is a statement in F# which is converted into a list of tokens.
if x <= 27 (* comment *) else
IF ID(x) LEQ INT(27) ELSE EOF //Notice what we have to capitalize all the legal words and add ID for variable and and the type for numbers
//The value actual number and variables are placed inside brackets next to the token. Comments and white spaces are ignored.
//EOF refers to End Of FIle and is always present at the end of the statement.
//As far as syntax analysis is concerned, it doesnt matter if we have ID(identifier) or INT(integer literal), but it matters type checking and code generation late on.

if                 {return IF;}
[a-z][a-z0-9]*     {return ID;}
[0-9]+             {return INT;}
(" "|\n)+          { }


//===Context-Free Grammars===
//Parsing is the problem of checking whether the sequence of tokens produced by the lexer is legal.
//To specify what is legal we use we use the formalism of context free grammars or CFG's.
//A CFG is a set of non-terminals. Usually, there is one for each category being defines. For example we can have non-terminals for expressions, command, declarations, and etc.
//The non-terminals are represented by capital letters and are to teh left of the arrow of statements.
//Each non-terminal has a set of rules that defines all the possible forms that they can take. //This is shown below for expressions "E".
//Each rule is in the form of A->alpha, where A is the non-terminal and alpha is the string of nonterminals and tokens.

//Suppose for example that we wish to specify arithmetic expressions build from identifiers using binary operators +, -, *, and /.
//In this case we only need one non-terminal, seven tokens, and six rules to cover all possibilities from the range of values.
E -> i //I represents a terminal, and we must always have a rule where a non-terminal resolves to a terminal. 
E -> E+E //Addition
E -> E-E //Subtraction
E -> E*E //Multiplication
E -> E/E //Division
E -> (E) //Brackets

//Normally, the rules above will be written out more compactly while having the same meaning:
E -> i | E+E | E-E | E*E | E/E |(E)

//Using this CFG we can generate legal arithmetic expression by repeatedly replacing E for whatever rule we like.
//For example here is a derivation of the rule (i-i)+i*i
E -> E+E //Started off with this one to get the middle addition done. Can be solved differntly.
E -> E+E*E
E -> E+i*E
E -> (E)+i*E
E -> (E)+i*i
E -> (E-E)+i*i
E -> (i-E)+i*i
E -> (i-i)+i*i

//Note that to avoid copying we can build a parse tree instead. In a parse tree all non terminal have its derivations or children
//and the binary operators that are applied to these rules. It is much nicer to a derivation as a parse tree.
//A parse tree shows that the given expression is syntactically legal, but most importantly, it reveals the structure of the expression.

//As we have seen, a context free grammar can be written in more than one way since there is no order of precedence
//between the operators and so more than one parse tree can be created.
//A CGF is ambiguous if there is at least one string with more than one parse tree.
//To resolve this problem, we can define a new grammar where expressions remain the same, grammar is unambiguous, there is associativity and precedence.
//The grammar bellow gives * and / higher precedence than + and -. The new expression requires 3 non terminals and is a bit more complicated.
E -> E+T | E-T | T //There must be a link to the other non terminal. Here the last rule allows for E to be swapped for T.
T -> T*F | T/F | F
F -> i | (E)

//Lets derive the same rule from before but with the new grammar. Rule: (i-i)+i*i
E -> E+T
E -> T+T
T -> T+T*F
T -> T+F*F
T -> F+F*F
F -> (E)+F*F
E -> (E-T)+F*F
E -> (T-T)+F*F
T -> (T-F)+F*F
T -> (F-F)+F*F
F -> (F-F)+F*i
F -> (F-F)+i*i
F -> (F-i)+i*i
F -> (i-i)+i*i

//===RECURSIVE DECENT PARSING===
//Given a CFG, the parsing problem is to find an algorithm that takes as input a sequence of tokens and either builds a parse tree or reports a syntax error.
//Recursive decent parsing is based on the idea that for some CFG's a single lookahead is enough to determine what rule to use next.
//Consider for example the following grammar fo a little programming language:
S -> if E then S else S | begin S L | print E
L -> end | ; S L
E -> i
//It can generate programs like this:
if a then begin print b; print c end else print d
//Note that while it isn't obvious at first, I am substituting the non terminals by their legal expressions and creating a sentence.

//Suppose that we are trying to parse an S. Notice that there are only three tokens that start with an S: if, begin, and print.
//Each of these tokens corresponds to a different rule, hence if the parser knows what token is coming next, it can know what rule to use.
//This same property holds for L and E.

//===Pattern Matching===
//Experience F# programmers dont ordinarily program with List.Empty, List.head, and List.tail, they instead prefer using pattern matching.
//There are four main advantages to pattern matching
//1. It is pretty, looks more organized.
//2. If you accidentally apply List.head or List.tail to an empty list, then you will get an exception.
//On the other hand, x:xs only matches to an non-empty list, where x binds to teh head and xs to the the tail.
//3. The F# compiler check if you have included enough patters to match all possible inputs, if not it returns an incomplete pattern match warning.
//4. The F# compiler also checks if patterns are redundant, in the sense that no input will cause it to be used, it gives a this rule will never be matched warning.
//Advantage 3 is particularly useful, for example here is a function to find the last element in a list.

let rec last = function
    |[x] -> x
    |x::xs -> last xs
//Here I got an error from the compiler for incomplete pattern match because I was missing the base case for an empty list.
last ([]:int list) //Note that without type annotation on [], we would have gotten a value restriction.
//It is important to note that it is not an error to have incomplete pattern matches but only a warning. Whether you decide
//to get rid of the warning is simply a matter of taste. In the the case of function 'last' it is reasonable to omit the
//case for empty list. However, doing so we lead to a non-specific MatchFailureException.

//To get a clearer error message we can raise our own exception. The easiest way to do this is by using 'failwith' function
//which takes a string argument with the desired error message.
let rec last = function
    |[] -> failwith "empty list has no element"
    |[x] -> x
    |x::xs -> last xs
//Since a empty list does not concern us when finding the last element of a list, we through a failwith exception to make
//personalized error message as seen above.

//The last function can also be used to illustrate advantage 2. Here is the last function without pattern matching: 

let rec last xs =
      if List.isEmpty (List.tail xs) then List.head xs else last (List.tail xs);;
//Now the compiler no longer warns us of the possibility of an exception.

//Finally, here is an example of advantage 4. Suppose we are trying to define the last function but we put patterns in the wrong order.
let rec last = function
    |[] -> failwith "empty list has no element"
    |x::xs -> last xs
    |[x] -> x
//We get a error saying that "this rule will never be matched", this is because the input will never reach the last statement.

//Here are a few aspects of pattern matching:
//we can use complex patterns to select a given element in the list. Below is a pattern match to select the third pattern.
let third(_::_::x::_) = x
//In the example above we used wildcard pattern '_' which matches anything but does not create binding.
//We can use patterns on match expressions letting us match on a intermediate value rather than just on the input of the function.
let foo s =
    match List.length s with
    |0 -> "empty"
    |1 -> "short"
    |_ -> "long"
    
//Note that the indentation of nested match expressions can be significant.
let foo x = fuction
|1 -> match x with
      |0 -> true
      |1 -> false
|2-> true

//A significant restriction in pattern matching, is that you can not use the same identifier more than once in a pattern.
let same = function
    |(n,n) -> true
    |_ -> false 
//This function generates an error because 'n' is bound twice in the same pattern.

//===LOCAL DECLARATIONS===
//As we have seen we can make a sequence of local declarations in the body of a function.
let roots (a,b,c) =
    let disc = sqrt (b*b - 4.0*a*c)
    let twoa = 2.0*a
    (-b+disc)/twoa, (-b-disc)/twoa);;
//The most important use of local declarations is to avoid recomputation.
//In roots for example we calculate disc and twoa once but use them twice. This is important for efficiency.

//Another less important use of local declarations is to define an auxiliary function within the definition of the outer function.
//These auxiliary functions are not visible outside and they can use the parameters of the outer function. Here's an example:

let map f xs =
    let rec map_aux = function //The inside auxiliary function is the recursive function in this case. 
    | []    -> []
    | y::ys -> f y :: map_aux ys //Using the outer functions parameters.
    map_aux xs;;
//Note that map_aux does not need to pass the function parameter f to its recursive calls.

//When defining functions simultaneous declarations using the keyword 'and' allows for mutual recursion.
let rec f n = if n = 0 then 1 else g n
and g m = m * f(m-1)

//===STATIC SCOPING and EAGER EVALUATION===
//Suppose a function contains a free identifier, how do we find its binding?
//One possibility is to use the binding effect where the function is defined, this is called static scoping.
//Another possibility is to use the binding effect where the function is called, this is called dynamic scoping.
//Here is an example that shows that F# uses static scoping:
let x = 3 in let f y = x + y //the free identifier x is being binded to the value of 3 where the function is being defined, this is static scoping
             let x = 6
             f x
//x is binding at the place where the function f above is being defined. Notice that when f is called the binding of x is 6. 
//The function above makes it clear that x = 6 is the declaration of a constant and not the assignment of a variable.

//There is a general consensus that static scoping is better than dynamic scoping because under dynamic scoping, you cannot
//understand a function with free identifiers by simply studying its definition - at the time of the call to a function,
//there could be new bindings that would completely change the functions behaviour.


//===EAGER EVALUATION===
//An F# function call first evaluates the arguments and then passes them to the function. That implies that the built in
//&& operation can not be implemented as a user defined function. For suppose we make the following attempt:
let myand (e1,e2) = if e1 then e2 else false
//As you can see, the trouble is that under eager evaluation we dont get short-circuit evaluation.
//Under eager evaluation, F# immediately evaluates both e1 and e2, even though myand needs e2 only when the value of e1 is true.

let x = 0
myand(x>0 && 10/x>2)

//Some functional languages such as Haskell use lazy evaluation, in which function arguments are evaluated only when they are actually needed.
//Interestingly, we can fake lazy evaluation in F# by using first class functions, we can make each argument into a
//parameterless function, which we call only when we need to use the arguments value:
let lazymyand (e1,e2) = if e1() then e2() else false
lazymyand ((fun () -> x > 0), (fun () -> 10/x > 2));;

//===QUICK SORT===
//Quick sort needs a function to split a list around its pivot element.
let rec split pivot = function //This is a function to partition elements greater and smaller than pivot.
    |[] -> ([],[]) //In case the input is an empty list, then we return two empty lists.
    |x::xs -> let(left,right) = split pivot xs //If we are given a list with head an tail, then we create another function that takes two arguments left and right.
              if x < pivot then (x :: left, right) //If x is smaller that the pivot then we place value on left of pivot.
              else (left, x :: right)//If it is not smaller than pivot, it must be larger or equal, so be place on right of pivot.
 split 4 [1;2;3;4;5;6] //Returns:([1; 2; 3], [4; 5; 6])
 
//Given split quicksort takes only a few lines of code.
 let rec qsort = function
     |[] -> [] //If list is empty it is already organized.
     |[x] -> [x] //If list has one element it is already organized.
     |x::xs -> let (left,right) = split x xs //x is the pivot, as we have defined above in the split function.
               qsort left @ x :: qsort right //Since append can only be used in lists, we cons x to the right list, and then append both lists.
     
 qsort [3;1;4;1;5;9;2;6;5] //Returns: [1; 1; 2; 3; 4; 5; 5; 6; 9]
//Note that the pivot to the list above is the first element or the head of the list as defined in the function above.
////Using the first element is not always a good thing to do, can be less efficient.

//===DEFINING NEW TYPES===
//Records
//This simplest types are records
type Person = {Name:string; Age:int}
let p1 = {Name="Bryan"; Age=20}
p1.Name //Returns "Bryan"
//Notice that record types are essentially the same as tuples but the components are accessed by name and not position.

//Discriminated Unions
//These types are a bit more interesting and can be written in two ways
type primarycolor = Red|Blue|Yellow
type secondarycolor =
    |Purple
    |Orange
    |Green

//Identifiers such at Red, Blue, and Yellow are called constructors. Pattern matching on color is supported.
let option = function
    |Purple -> "Grape"
    |Orange -> "Carrot"
    |Green -> "Spinach"
option Purple //Returns "Grape""
//F# requires that constructors be capitalized to distinguish them from identifiers. Misspelling a constructor can be very bad.

//Note that record field labels and union constructors have module scope:
fun p -> p.Age //Person->int

//This can lead to name clashes, sometimes requiring prefixed names:
type mood = Happy|Blue
Blue //mood = Blue
Red //color = Red
option.Blue //color = Blue


//Binary Search Trees
//More interestingly we can polymorphic, recursive types.
//Again, since we are using discriminated union format, we can write it either on the same line, or pattern matching style.
//I will only include the patter matching style as it seems to be more common.
type 'a tree =
    |Lf
    |Br of 'a * 'a tree *'a tree //We use the "of" keyword when defining binary trees, but it has other uses.
Lf //val it: 'a tree
Br("cat",Lf,Lf);; //val it: string tree = Br("cat",Lf,Lf)
//Here 'a tree is either a leaf Lf, or a branch Br(e,t1,t2), where e is the key, t1 is the left subtree and t2 is the right subtree.

//Recall that a binary search tree has a property, where the key in any Br node is greater than all the keys on the left
//subtree and smaller than or equal to all keys on the write subtree.
//Here is how we can implement a binary search tree in F#:

let rec element n = function
    |Lf -> Br(n,Lf,LF)
    |Br(m,t1,t2) -> 
                    if n < m then elemetn n t1
                    else element n t2

let rec insert n = function
    |Lf -> Br(n,Lf,Lf)
    |Br(m,t1,t2) -> if n < m then Br(m, insert n t1, t2)
                             else Br(m, t1 ,insert n t2)

let rec buildtree = function
    |[] -> Lf
    |x::xs -> insert x (buildtree xs)

let rec sum = function
    |Lf -> 0
    |Br(m, t1, t2) -> m + sum t1 + sum t2
    
//Here are some sample calls:
let t = buildtree [3;1;4] //Returns: int tree = Br (4,Br (1,Lf,Br (3,Lf,Lf)),Lf)
element 1 t //Returns: bool = true
element 2 t ////Returns: bool = false
sum t //Returns: int = 8
//Notice that to process values of a discriminated union, we must use pattern matching.

//Similar to how it was with list operations, tree operations are also non-destructive. For instance insert n t returns
//the result of inserting n into t without destroying t. But because of sharing this can be done efficiently.
//Here's an example:
let tr1 = buildtree[3;1;4;0;6;9;2;7;6]
//int tree = Br(6,Br (2,Br (0,Lf,Br (1,Lf,Lf)),Br (4,Br (3,Lf,Lf),Lf)),Br (7,Br (6,Lf,Lf),Br (9,Lf,Lf)))
//Now suppose we insert 5 into tr1
let tr2 = insert 5 tr1
//int tree =Br(6,Br (2,Br (0,Lf,Br (1,Lf,Lf)),Br (4,Br (3,Lf,Lf),Br (5,Lf,Lf))),Br (7,Br (6,Lf,Lf),Br (9,Lf,Lf)))

//Look at diagram for better understanding of this:
//Notice that we have allocate new Br nodes along the path from root to new node. All other nodes are shared with tr1,
//which still exists. More generally, if we have a well balance binary search tree containing a million Br nodes, then
//inserting a new value requires just allocating allocating just 20 Br nodes, since log_2(1,000,000) is 20.


//Non-Homogeneous Lists
//Because discriminated unions can combine whatever type we want, we can use them to create non-homogeneous lists.
type stew2 =
    |Int of int
    |Str of string
    |Bool of boolean
    
[Int 5; Str "abc"; Bool true]

let rec add2 = function
    |[]-> 0
    |Int n :: xs -> n + add xs
    |_::xs -> add xs
    
    
//Subtyping and Overloading
//There are a number of restrictions and limitations on the F# type system that are important know about.
//As it is clear F# does not support subtyping of numeric operators. For instance, F# does not regard int the same as
//float, so if we try to divide 4/3.2 we will get an error.

//Overloaded numeric operators are another source of trouble for F# type inference. Numeric operators such as +,-, and *
//are defined on many numeric types, but F# demand that each occurrence of such and operator be given a unique type.
//Rather than allowing it to be used polymorphically. For example:
let square x = x * x //x:int -> int
//Since F# can tell which version of the numeric operator '*' is intended, it pics int version by default. A stronger
//type system might have concluded that square has many types. This can be achieved by using the constraint quantification
//mechanism that is used on comparison operators. This is illustrated by the function bellow which compares lists lexicographically:
let rec leq = function
    |([],ys) -> true
    |(xs,[]) -> false
    |(x::xs,y::ys) -> x<y||(x=y && leq(xs,ys)) //val leq : 'a list * 'a list -> bool when 'a : comparison
    
//Interestingly enough, for some reason, F# does use constraint quantification on overloaded numeic operators when they
//are used in inline functions:
let inline double x = x * x //  x: ^a ->  ^b when  ^a : (static member ( * ) :  ^a *  ^a ->  ^b)


//Polymorphic Function Parameters
//Yet another restriction of F# is the parameters of a function are not allowed to be used polymorphically.
let foo f = (f[1;2;3], f[true,false])
//Here get an error saying tha the expression was expected to have teh ype int, but it also has type bool.
//As shown F# does not allow parameter f to be used polymorphically. F# decides that f has type int list -> 'a.

//However, the function foo would work just fine if we called it with a argument that is polymorphic enough such as List.rev.
let f = List.rev in (f[1;2;3], f[true,false]) //int list * (bool * bool) list = ([3; 2; 1], [(true, false)])

//In general, the F# restrictions on subtyping, overloading, and polymorphic uses of function parameters have all been
//imposed to make it easier to do type inference and compilation.


//===VALUE RESTRICTION===
//What is the value restriction?
//In F# we can create identifiers with polymorphic types, either it is at the top level
let lst = (fun x -> [x])
//or inside a local expression
let lst = (fun x -> [x]) in (lst 12, lst true, lst "cat")

//Given a declaration:
let x = e
//the F# value restriction says that if e is not a restricted for called a syntactic value, then x cannot be give a polymorphic type.
//Intuitively, a syntactic value is an expression that can be evaluated without doing any computation.
//Syntactic values are expressions of the following form:
//-literals and identifiers such as 3 or List.rev
//-function expressions such as (fun x -> [x])
//-constructors applied to syntactic values such as (12, x::[true])
//Any other form of expressions is a syntactic value.

//Syntactic value do not include function calls.
let x= List.rev[] //val x : '_a list
//The underscore in '_a is F#'s way of saying that the type variable is not universally quantified.

//Notice however that in a local let, F# may be able to later figure out the type of x, avoiding error.
let x = List.rev [] in 3::x //val it : int list = [3]

//But still, x cannot be used polymorphically:
let x = List.rev [] in (3::x, true::x) //Generates an error

//In contrast:
let x = [] in (3::x, true::x) //val it : int list * bool list = ([3], [true])

//How Do We Deal With Value Restrictions
//Obviously we arent going to write List.rev[] in a program, so it doesnt particularly matter if it isnt polymorphic.
//But what if we create a function with a function call? With curried funtions we do this all the time.
let revlists = List.map List.rev
//Here revlists should be polymorphic but the value restrictions messes it up.
//Fortunately, there is a simple trick that we can use to make revlists polymorphic. We replace the definition of revlists with:
let revlists = (fun xs -> List.map List.rev xs) //xs:'a list list -> 'a list list
//and now everything works just fine since (fun xs -> List.map List.rev xs) is a syntactic value.
//We could have also used a more common syntax to make an equivalent function:
let revlists xs = List.map List.rev xs //xs:'a list list -> 'a list list

//In programming languages literature, the trick of replacing a functioned valued expression e with (fun x -> ex) is
//know as eta expansion. It has been found the eta expansion usually suffices for dealing with value restriction.

//Note however that
let f = e
//and its eta-expanded version
let f = (fun x -> ex)
//are not quite the same semantically. In the first case e is evaluated only one, while in the second e is evaluated
//at every function call. If e causes side effects, this may produce different results. And even if e is pure expansion
//this may make a difference in efficiency.

//Why Do We Need The Value Restriction? The Imperative Side of F#
//If we are only dealing with purely functional F# programming, which is what we have been doing so far in this course,
//then we dont need value restrictions. The value restrictions become necessary only when we use the imperative features
//of F#. Now we will introduce such features.

//F# provides full support for imperative programming including mutable fields of records, while loops, arrays,
//dictionaries, and printf. We however will only focus on a core feature of imperative programming know as mutable
//reference cells, which are supported three key operators, ref, !, and :=.

//In F# we create mutable reference cells by using 'ref':
let r = ref 17 //int ref = { contents = 17 }
//The declaration above binds r to the address of a new reference cell whose initial contents is 17.

//We can get the current contents of the cell by using '!':
!r //int = 17

//And we can update the contents of the cell by using ':=' :
r := !r + 1 //Added one to the value currently stored in the mutable reference cell.
!r //int = 18

//In fact, 'a ref is a an abbreviation for a record type with one mutable field called contents.
//You can see this if you look at the value of r itself:
r //int ref = { contents = 18 }

//Here is how we can use ref to write an imperative factorial function:
let factorial n =
    let ans = ref 1
    let cnt = ref 1
    while !cnt <= n do
        ans := !ans *!cnt
        cnt := !cnt + 1
    !ans
//It is important to realize that the ref values are pointers. This leads to the possibility of aliasing.
//For example, contrast the following two declarations:
let s = r
let t = ref (!r)
//now r and s are aliases for the same cell while t is a different cell:
r := !r + 1 //unit = ()
!s //int = 19
!t //int = 18

//Finally, note that the reference cell operations have polymorphic types:
ref //('a -> 'a ref)
! //'a ref -> 'a
:= //'a ref -> 'a -> unit
;;
//Interestingly, the combination of ref cells, records, and first class functions lets us do object oriented programming.
//Here is how we can create a bank account "object" with "methods" to make deposits and check the current balance.
type Account =
    {deposit: int -> unit
     balance: unti -> int};;
    
let acc =
    let bal = ref 1000
    {deposit = fun d -> bal := !bal + d;
     balance = fun () -> !bal};;

acc;;
acc.balance ();; //int = 1000
acc.deposit 200;; //unit = ()
acc.balance ();; //int = 1200
//Something nice about this code is that the reference bal is encapsulated within the account object; it can only be
//accessed via the deposit and balance methods.

//Now suppose we want to create a stack object with push, pop, and top methods, using a list to hold the current stack contents.
//We code the stack as tuple rather than a record to avoid the need to pre-define the record type.
let stack =
    let stk = ref []
    ((fun x -> stk := x::(!stk)),       //Push
     (fun () -> stk := List.tail(!stk)), //Pop
     (fun () -> List.head(!stk)));;     //Top
//What should the type of stack be? Well, it would seem that stk : 'a list ref, and hence
//stack : ('a -> unit) * (unit -> unit) * (unit -> 'a)
//where as usual the type variable 'a is implicitly universally quantified. But now something is very wrong because
//we cannot use stack to launder the value of whatever type we want. We first use patter matching to extract the three
//methods of stack:
let(push, pop, top) = stack
//Now letting 'a be int we have:
push: int -> unit
//And letting 'a be bool we have:
top: unit -> bool
//Hence the following code type checks, even though it erroneously applies to boolean operator not to 17:
push 17
not (top())
//Understanding what has gone wrong here is not easy, but it is clear that F#'s value restriction suffices in this case.
//Since a let expression is not a syntactic value, stack is not given a polymorphic time and hence, the laundering
//shown above is prohibited.

//Interestingly, the value restriction does not prevent us from writing a polymorphic function to create different types of stacks:
let mkstack init =
      let stk = ref init
      ((fun x -> stk := x :: (!stk)),        // push
       (fun () -> stk := List.tail (!stk)),  // pop
       (fun () -> List.head (!stk)))         // top
    ;; // val mkstack : 'a list -> ('a -> unit) * (unit -> unit) * (unit -> 'a)
//Unlike stack, mkstack is a syntactic value and can be given a polymorphic type. So we can write mkstack[1] to create
//an int stack or mkstack["cat";"dog"] to create a string stack. But if we write mkstack[] we get a '_a stack, where
//'_a is an unquantified type variable.

//We remark that these examples illustrate the key idea behind syntactic values: a syntactic value is guaranteed not to
//create any ref cells when it is evaluated.

let rec split pivot = function
    |[] -> ([],[])
    |x::xs -> let (right, left) = split pivot xs
              if x < pivot then (x::left, right)
                           else (left, x ::right);;

let rec q sort = function
    |[] -> []
    |[x] -> [x]
    |x::xs -> let (left,right) = split x xs
    qsort left @ x :: q sort right 
