module ClassLibrary2.Problemss

type 'a coordinate =
    	|TUPLE of first : 'a * second : 'a
        |THREEPLE of first : 'a * second : 'a * third : 'a
        |FOURPLE of first : 'a * second : 'a * third : 'a * fourth : 'a
			
		let valints = TUPLE (3, 4)
        let valfloats = THREEPLE (1.2, 2.4, 5.5)
        let valstrings = FOURPLE ("one", "two", "three", "four")
        	
        let myfunction binaryfunction coordinate =
            match coordinate with
            |TUPLE(x,y) -> binaryfunction x y
            |THREEPLE(x,y,z) -> binaryfunciton (binaryfunction x y) z
            |FOURPLE(x,y,z,a) -> binaryfunction (binaryfunction (binaryfunction x y) z) a
              	
        printf "%A" (myfunction (+) valints)
        printf "%A" (myfunction (+) valstrings)
        printf "%A" (myfunc (-) somefloats)