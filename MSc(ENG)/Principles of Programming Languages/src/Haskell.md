[Starting Out - Learn You a Haskell for Great Good!](http://learnyouahaskell.com/starting-out#babys-first-functions) <- bel sito 
[Haskell Online Compiler & Interpreter - Replit](https://replit.com/languages/haskell) 

# Haskell 



Riguardare la parte in cui parla di dynamic typed languages based on hashtables . <- also python organizes stuff using hashtables


Call by need ... a optimized version of called by name evaluation . (remember that [Scheme](Scheme.md) is call by value)


[Template (C++) - Wikipedia](https://en.wikipedia.org/wiki/Template_(C%2B%2B)) and generics in java ... here in Haskell we have type parameter



In haskell le liste devono essere omogenee..



function is decleared using :: 


product types are 'structs' in C

_ is don't care ... when you don't need a parameter


When you want to define a new type you use data. 


type keyword is used to make synonims ... basically for readability . 

````Haskell
map  (1 +)  [1,2,3]
````



Call by need permits us to make infinite computations and infinite lists <- that's very cool 

tail is cdr 
while head is car 



bot is 'never ending computation' and all errors have value bot

bisogna integrare con [impara haskell e mettilo da parte](../../../../../kb/impara%20haskell%20e%20mettilo%20da%20parte.md) 



https://en.wikipedia.org/wiki/Lua_(programming_language)


# Haskell del 26/10 


Recursive types

````Haskell
let x = 3
y = 12
in x+y -- => 15

--or 
let {x = 3 ; y = 12} in x+y
````

fold-left 

note: in Racket it is defined with (f x z)

In Scheme fold left is more efficient (tail recursive) while fold right uses stack in Haskell this is not true. 

Canonical operator to force evaluation is ```seq :: a -> t -> t``` . 

````Haskell
foldl ’ f z [] = z --this is to forcing the evaluation 

($!) :: (a -> b) -> a -> b --another way to force .. "function application"
````


There is a convenient strict variant of $ (function application) called $!

Haskell has a simple module system, with import, export and namespaces

modules provide the only way to build abstract data types (ADT)
the characteristic feature of an ADT is that the representation type is hidden:
all operations on the ADT are done at an abstract level which does not
depend on the representation

````Haskell
module TreeADT (Tree , leaf , branch , cell ,
							left , right , isLeaf ) where
data Tree a = Leaf a | Branch ( Tree a) ( Tree a)
leaf = Leaf
branch = Branch
cell ( Leaf a) = a
left ( Branch l r) = l
right ( Branch l r) = r
isLeaf ( Leaf _) = True
isLeaf _ = False
````

in the export list the type name Tree appears without its constructors
so the only way to build or take apart trees outside of the module is by using
the various (abstract) operations
the advantage of this information hiding is that at a later time we could
change the representation type without affecting users of the type


# Type classes

A type is a set of values. A type-class is a set of types. 
A type-class is a way to define operations to other types ... very similar to interfaces in for example Java. 

type classes are the mechanism provided by Haskell for ad hoc polymorphism.

type classes are used for overloading: a class is a "container" of overloaded
operations
we can declare a type to be an instance of a type class, meaning that it implements its operations
an implementation of (\=\=) is called a method

$$\begin{array}{|c|c|}
\hline \hline 
\text { Haskell } & \text { Java } \\
\hline \text { Type Class } & \text { Interface } \\
\hline \text { Type } & \text { Class } \\
\hline \text { Value } & \text { Object } \\
\hline \text { Method } & \text { Method } 
\end{array} $$



# List comprehension 

If you've ever taken a course in mathematics, you've probably run into _set comprehensions_. They're normally used for building more specific sets out of general sets. A basic comprehension for a set that contains the first ten even natural numbers is $S = \{ 2 \cdot x | x \in \mathbb{N} , x \le 10 \}$ The part before the pipe is called the output function, x is the variable, N is the input set and x <= 10 is the predicate. That means that the set contains the doubles of all natural numbers that satisfy the predicate.   

```<-``` is used to 'bound' elements in the list comprehensions. 

```length' xs = sum [1 | _ <- xs]``` 

fi xs = [x | x <- xs, odd x == False]


A cool function that produces a list of pairs: zip. It takes two lists and then zips them together into one list by joining the matching elements into pairs. It's a really simple function but it has loads of uses. It's especially useful for when you want to combine two lists in a way or traverse two lists simultaneously. Here's a demonstration.

````Haskell
zip [1,2,3,4,5] [5,5,5,5,5]  -- [(1,5),(2,5),(3,5),(4,5),(5,5)]  
zip [1 .. 5] ["one", "two", "three", "four", "five"]  -- [(1,"one"),(2,"two"),(3,"three"),(4,"four"),(5,"five")]
````


# video random su yt 


Currying is an important concept.
````Haskell
answerToEverything = 42

complexcalc x y z=x * y *  z * answerToEverything

:t complexcalc
complexcalc : : Integer -> Integer -> Integer -> Integer
complexcalc : : Integer-> (Integer -> (Integer -> Integer))
````

````Haskell
numbers =[1,3,5,7]
numbers !! 2  -> 5 
null numbers -> False --tell us if the list is empty
head numbers -> 1 
tail numbers -> [3,5,7]
init numbers -> [1,3,5]
last numbers -> 7 
drop 2 numbers -> [5,7]
take 2 numbers -> [1,3]
elem 5 numbers -> True 
````

type classes 

a type is a set/domain of values. 

members of type class num have for example defined a ```+``` so all they have that operation.

Haskell always try to keep generic variables. 

this is called functions constraints. 

Language that I used (from most to less):


Pattern matching 

one definition of some complex function and then many lines that described the function 


# Back experimenting with learnyouhaskell.com 


Try to make Fibonacci function 


Read is sort of the opposite typeclass of Show. The read function takes a string and returns a type which is a member of Read. 


````Haskell
1.  ghci> read "4"  
2.  <interactive>:1:0:  
3.      Ambiguous type variable `a' in the constraint:  
4.        `Read a' arising from a use of `read' at <interactive>:1:0-7  
5.      Probable fix: add a type signature that fixes these type variable(s)  
````

What GHCI is telling us here is that it doesn't know what we want in return. Notice that in the previous uses of read we did something with the result afterwards. That way, GHCI could infer what kind of result we wanted out of our read. If we used it as a boolean, it knew it had to return a Bool. But now, it knows we want some type that is part of the Read class, it just doesn't know which one. Let's take a look at the type signature of read.

````Haskell
1.  ghci> :t read  
2.  read :: (Read a) => String -> a  
````

See? It returns a type that's part of Read but if we don't try to use it in some way later, it has no way of knowing which type. That's why we can use explicit _type annotations_. Type annotations are a way of explicitly saying what the type of an expression should be. We do that by adding :: at the end of the expression and then specifying a type. Observe:



> it seems that GHCI knows how to read inferring the type of ```a``` looking the type of the operations it's in. 


Enum members are sequentially ordered types — they can be enumerated. The main advantage of the Enum typeclass is that we can use its types in list ranges. They also have defined successors and predecesors, which you can get with the succ and pred functions.

# Pattern matching 

````haskell 
first (x,_,_) = x
second (_,x,_) = x
third (_,_,z) = z
first (1,2,3) -> 1
second (1,2,3) -> 2
third (1,2,3) -> 3
````

The _ means the same thing as it does in list comprehensions. It means that we really don't care what that part is, so we just write a _.


scrivere codice poi fare :load fdadsa.hs 
e compilare quello che scrivo .. serve per dichiarare su che tipo operano le funzioni ... altirmenti mi da errore ghci = non so why 



difference between ```data``` and ```type``` ? The ```type``` keyboard is not a new data type but just an **alias** . 

```newtype``` is 'weird' in since we want to make an alias 'basically identical' to another already define ```type``` but I want to say to ghc to consider them two different types.
````Haskell
sum' :: Num a => [a] -> a
sum' = foldr (+) 0
````

## recap of 02/11 

usually it is not necessary to explicitly define instances of some classes. Haskell can be quite smart and do it automatically, by using deriving. 

````Haskell
data Point = Point Float Float deriving (Show,Eq)
````


Enumeration: 

````Haskell
data RPS = Rock | Paper | Scissors deriving (Show, Eq)

instance Ord RPS where
x <= y | x == y = True
Rock <= Paper = True
Paper <= Scissors = True
Scissors <= Rock = True
_ <= _ = False

````

# IO

IO is not 'compatible' with the functional philosophy. 
In general, IO computation is based on state change (e.g. of a file), hence if
we perform a sequence of operations, they must be performed in order
(and this is not easy with call-by-need)

````Haskell
getChar :: Time -> Char. 
````

can be seen as a function  indeed, it is an IO action (in this case for Input):

````Haskell
getChar :: IO Char
````

quite naturally, to print a character we use ```putChar``` that has type:

````Haskell 
putChar :: Char -> IO ()
````

```IO``` is an instance of the monad class, and in Haskell it is considered as an indelible stain of impurity.

main is the default entry point of the program
````Haskell
main = do { --sequence of IO actions
putStr "Please, tell me something>";
thing <- getLine; --a way to get the input
putStrLn $ "You told me \"" ++ thing ++ "\".";
}
````
 
````Haskell
import System.IO
import System.Environment

readfile = do {
args <- getArgs; -- command line arguments
handle <- openFile (head args) ReadMode;
contents <- hGetContents handle; -- note: lazy
putStr contents;
hClose handle;
}

main = readfile
````

We saw that IO is a type constructor, instance of Monad
But we still do not know what a Monad is

Foldable (not required, but useful)
Functor: note that in CS functor is used with different meanings. 
Applicative (Functor)
Monad 



## Foldable 

````Haskell
sum' xs = foldl (\acc x -> acc + x) 0 xs 
````

where ```\acc x -> acc + x``` is the binary function and 0 is the starting value. 

foldl => the list is 'consumed' up from the left side. 

I'm sure you all know that elem checks whether a value is part of a list so I won't go into that again

````Haskell
isThere y ys = foldl (\acc x -> if x == y then True else acc) False ys
````

The right fold, foldr works in a similar way to the left fold, only the accumulator eats up the values from the right.

Foldl can be expressed in term of foldr (id is the identity function):
````Haskell
foldl f a bs = foldr (\b g x -> g (f x b))
````

id bs a
the converse is not true, since foldr may work on infinite lists, unlike foldl:
in the presence of call-by-need evaluation, foldr will immediately return the
application of f to the recursive case of folding over the rest of the list
if f is able to produce some part of its result without reference to the recursive
case, then the recursion will stop
on the other hand, foldl will immediately call itself with new parameters until
it reaches the end of the list.

foldr works with infinite data structures, foldl nope. 

the concept is that foldl starts from left to right but actually it starts to compute the recurrence from the last element (but if it doesn't exists .. that's not possible). 

## Maybe 

Maybe is used to represent computations that may fail: we either have
data Maybe a = Nothing | Just a

It is adopted in many recent languages, to avoid NULL and limit exceptions
usage: mainly because exceptions are sometimes complex to manage. 

## Functor 

Functor is the class of all the types that offer a map operation 

Generally it s natural to make every data structure an instance of functor. 

- ```fmap id = id``` (where id is the identity function)
- ```fmap (f.g) = (fmap (f)).(fmap (g))``` (homomorphism)

````Haskell
tmap f (Leaf x) = Leaf $ f x
````

## Applicative Functors 

````Haskell
class (Functor f) => Applicative f where
pure :: a -> f a
(<*>) :: f (a -> b) -> f a -> f b -- <*> means  apply 
````

````Haskell
concat [[1,2],[3],[4,5]] 
[1,2,3,4,5] 

ghci> concatMap (\x -> [x, x+1]) [1,2,3] 
[1,2,2,3,3,4]

ghci> concatMap (++"?") ["a","b","c"]
"a?b?c?"

ghci> concatMap (++"") ["a","b","c"]
"abc"

ghci> concatMap (return "a") ["a","b","c"]
"aaa"


-- with concatMap, we get the standard implementation of <*> (the main op of applicative)

ghci> [(+1),(*2)] <*> [1,2,3]
[2,3,4,2,4,6] 

````


foldable is some kind of data structure providing fold operations

functor is a data structure providing the map operations 

applicative are similar to a functor but we apply a 'container' of functions


# Monad 

introduced by Eugenio Moggi in 1991, a monad is a kind of algebraic data
type used to represent computations (instead of data in the domain model) -
we will often call these computations actions . 

monads allow the programmer to chain actions together to build an ordered
sequence, in which each action is decorated with additional processing
rules provided by the monad and performed automatically 

monads are flexible and abstract. This makes some of their applications a
bit hard to understand.

monads can also be used to make imperative programming easier in a pure
functional language 

Monad is a subclass of Applicative . 

The monad is just a way to composing your actions and computations. 


-- Sequentially compose two actions, passing any value produced
-- by the first as an argument to the second.
(>>=)
:: m a -> (a -> m b) -> m b

-- Sequentially compose two actions, discarding any value produced
-- by the first, like sequencing operators (such as the semicolon)
-- in imperative languages.
(>>)

bind is a way to compose computations making a sequence of actions. 

1) return is the identity element:
(return x) >>= f <=> f x
m >>= return <=> m
2) associativity for binds:
(m >>= f) >>= g <=> m >>= (\x -> (f x >>= g))



We couldn't have achieved this by just using Maybe as an applicative. If you try it, you'll get stuck, because applicative functors don't allow for the applicative values to interact with each other very much. They can, at best, be used as parameters to a function by using the applicative style. The applicative operators will fetch their results and feed them to the function in a manner appropriate for each applicative and then put the final applicative value together, but there isn't that much interaction going on between them. Here, however, each step relies on the previous one's result. On every landing, the possible result from the previous one is examined and the pole is checked for balance. This determines whether the landing will succeed or fail.

[A Fistful of Monads - Learn You a Haskell for Great Good!](http://learnyouahaskell.com/a-fistful-of-monads#getting-our-feet-wet-with-maybe)


A value of type Maybe a represents a value of type a with the context of possible failure attached. A value of Just "dharma" means that the string "dharma" is there whereas a value of Nothing represents its absence, or if you look at the string as the result of a computation, it means that the computation has failed.

allows us to feed a monadic value to a function that takes a normal one.

Converting this monstrosity into a neat chain of monadic applications with >>= is a classic example of how the Maybe monad saves us a lot of time when we have to successively do computations that are based on computations that might have failed.


Monads in Haskell are so useful that they got their own special syntax called do notation. We've already encountered do notation when we were doing I/O and there we said that it was for gluing together several I/O actions into one. Well, as it turns out, do notation isn't just for IO, but can be used for any monad. Its principle is still the same: gluing together monadic values in sequence. We're going to take a look at how do notation works and why it's useful.

````Haskell
ghci> show [1,13..100] 
[1,13,25,37,49,61,73,85,97]
-- [x,k..u] is a a list with upper bound "u" and a step of "x-k"  
````

[Haskell/Indentation - Wikibooks, open books for an open world](https://en.wikibooks.org/wiki/Haskell/Indentation)

[haskell - What are the benefits of currying? - Stack Overflow](https://stackoverflow.com/questions/12413495/what-are-the-benefits-of-currying)


[Currying - HaskellWiki](https://wiki.haskell.org/Currying)

[Haskell (linguaggio) - Wikipedia](https://it.wikipedia.org/wiki/Haskell_(linguaggio)#Algoritmo_di_ordinamento_generico_quicksort)