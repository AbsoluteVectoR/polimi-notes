Bibliography and references  

Notes: advanced/optional papers are marked with (§). I advise to use as a reference at least one book for each language - most of them are freely available online.

-   Scheme
    
    -   Implementation and documentation: [Racket](http://racket-lang.org/)
    -   [A good book on Scheme](http://www.scheme.com/tspl4/)
    -   [Standards](http://scheme-reports.org/)
    -   [For fans of macros](https://pradella.faculty.polimi.it/PL/syntax-rules-primer.txt) (§)
-   Haskell
    
    -   [Learn you a Haskell...](http://learnyouahaskell.com/chapters)
    -   [Real World Haskell](http://book.realworldhaskell.org/)
    -   Suggested implementation: [The Glorious Glasgow Haskell Compiler](http://www.haskell.org/ghc/)
    -   [Standard](http://www.haskell.org/haskellwiki/Language_and_library_specification)
    -   [A gentle introduction to Haskell](http://www.haskell.org/tutorial/)
    -   [Haskell Cheatsheet](http://cheatsheet.codeslower.com/)
    -   [All about monads](http://www.haskell.org/haskellwiki/All_about_monads) (§)
-   Erlang
    
    -   [Learn you some Erlang](http://learnyousomeerlang.com/content)
    -   [Main Erlang site, with the standard implementation and documentation](http://www.erlang.org/)
    -   [Elixir, an Erlang VM-based language](http://elixir-lang.org/)
    -   [LFE, an Erlang-based Lisp](http://lfe.io/)
-   OO
    
    -   [D. Ungar and R. B. Smith, Self: the power of simplicity, Lisp and Symbolic Computation 4(3), June, 1991](http://bibliography.selflanguage.org/self-power.html)
    -   [W. Cook, On Understanding Data Abstraction, Revisited, 2009](http://www.cs.utexas.edu/~wcook/Drafts/2009/essay.pdf) (§)
    -   [Alan Kay, The Early History of Smalltalk, 1993](http://propella.sakura.ne.jp/earlyHistoryST/EarlyHistoryST.html) (§)
    -   [R. Gabriel, J. White, D. Boborow, CLOS: Integrating Object-Oriented and Functional Programming, CACM, 1991](http://dreamsongs.com/Files/clos-cacm.pdf) (§)
-   JavaScript
    
    -   [A re-introduction to JavaScript](https://developer.mozilla.org/en-US/docs/Web/JavaScript/A_re-introduction_to_JavaScript)
-   Prolog
    
    -   [A free Prolog course](http://www.learnprolognow.org/)
    -   [Logic, Programming and Prolog](http://www.ida.liu.se/~ulfni/lpp/)
    -   [Prolog for Programmers](https://sites.google.com/site/prologforprogrammers/)
    -   [The power of Prolog](https://www.metalevel.at/prolog)
    -   Suggested implementation: [SWI-Prolog](http://www.swi-prolog.org/)
    -   Logic programming in a few lines of Scheme: [Sokuza-Kanren](https://pradella.faculty.polimi.it/PL/sokuza-kanren.scm)
-   Other interesting stuff (§)
    
    -   [Lisp history](http://www.dreamsongs.com/Files/HOPL2-Uncut.pdf)
    -   [Other historical Lisp stuff](http://www.softwarepreservation.org/projects/LISP/)
    -   [A. Colmerauer, P. Roussel, The birth of Prolog, 1992](http://www.google.it/url?sa=t&rct=j&q=history%20of%20prolog&source=web&cd=3&ved=0CEIQFjAC&url=http%3A%2F%2Fciteseerx.ist.psu.edu%2Fviewdoc%2Fdownload%3Fdoi%3D10.1.1.85.7438%26rep%3Drep1%26type%3Dpdf&ei=_VoiT4CKNsGaOvuv9OQE&usg=AFQjCNG60HeXPPxFnluwlEQRVnWTVZBuBA&cad=rja)
    -   [L. Cardelli, Type Systems, The Computer Science and Engineering Handbook. CRC Press, Chapter 103, 1997](http://lucacardelli.name/Papers/TypeSystems%201st%20Edition.US.pdf)
    -   [R. P. Gabriel, Patterns of Software, 1996](http://dreamsongs.com/Files/PatternsOfSoftware.pdf), an inspiring book on Software, Design, Languages and Achitecture (both soft and _hard_!)
    -   [P. Hudak, Conception, evolution, and application of functional programming languages, ACM Comput. Surv. 21, 3, 1989](http://portal.acm.org/citation.cfm?doid=72551.72554)
    -   [J. Backus, Can Programming be Liberated from the von Neumann style?, CACM 21(8): 613-641, 1978](http://www.cs.cmu.edu/~crary/819-f09/Backus78.pdf)
    -   Fabrizio Ferrai's [Haskell is mainstream](https://pradella.faculty.polimi.it/PL/Haskell-mainstream.pdf)



# First Lesson 

The idea is to understand programming languages deeply. To do this we will see languages that probably I will never use in my career.  
- 1957 Fortran (Formula Translator)
- 1958 LISP (LISt Processor)
- 1959 COBOL (Common Business Oriented Language)
- 1960 ALGOL 60 (Algorithmic Language)
- 1964 BASIC (Beginner's All-purpose Symbolic Instruction Code)
- 1967 Simula (first object-oriented lang.)
- 1970 Pascal, Forth
- 1972 C, Prolog (Datalog is a non-Turing complete subset of Prolog), Smalltalk
- 1975 Scheme (Lisp + Algol)
- 1978 ML (Meta-Language)
- 1980 Ada
- 1983 C++, Objective-C
- 1984 Common Lisp (Lisp + OO)
- 1986 Erlang (not very relevant at time, but totally different: concurrent and functional)
- 1987 Perl
- 1990 Haskell
- 1991 Python
- 1995 Java, JavaScript, Ruby, PHP
- 2001 C# (basically a variant of Java for dot environment)
- 2002 F# 
- 2003 Scala (strange mix, quite interesting)
- 2007 Clojure 
- 2009 Go 
- 2011 Dart
- 2012 Rust
- 2014 Swift 


Languages we will see:

- Scheme, for basics, memory management, introduction to functional programming and object orientation, meta-stuff
- Haskell, for static type systems and algebraic data types, functional "purity"
- Erlang, for concurrency-oriented programming

Not very useful to write real stuff, more useful to learn new concepts and be flexible. We will never used this languages (probably) in our careers.  

# Scheme
Scheme is a little bit strange because the structure of the program is given by its syntax itself.
Scheme -> quite ancient! -> not to write stuff but to write new stuff. Scheme is cool to thinking about new constructs and a new language. This course is for becoming 'flexible' . After this course you will learn any languages very easily. 


Scheme ... a lot of Parentesys. 
- Booleans: ````#t, #f````
- Numbers: ````132897132989731289713, 1.23e+33, 23/169, 12+4i````
- Characters: ````#a, #Z````
- Symbols: ````a-symbol, another-symbol?, indeed!````
- Vectors: ````#( 1  2 3 4)```` 
- Strings: ````"this is a string"````
- Pairs and Lists: ````(1 2 #\a), (a . b),()````

Scheme is mainly functional language: every program is an expression and computation is based on evaluating expressions. 
!!!! The evaluation order of parameters is unspecified: Scheme doesn't make left-to-right evaluation like humans. 


Static vs Dynamic scoping


The **scope** of a variable x in the region of the program in which the use of x refers to its declaration. One of the basic reasons for scoping is to keep variables in different parts of the program distinct from one another. Since there are only a small number of short variable names, and programmers share habits about naming of variables (e.g., I for an array index), in any program of moderate size the same variable name will be used in multiple different scopes.  
Scoping is generally divided into two classes:   
**1.** Static Scoping   
**2.** Dynamic Scoping  



**Static Scoping:**   
Static scoping is also called **lexical scoping**. In this scoping, a variable always refers to its top-level environment. This is a property of the program text and is unrelated to the run-time call stack. Static scoping also makes it much easier to make a modular code as a programmer can figure out the scope just by looking at the code. In contrast, dynamic scope requires the programmer to anticipate all possible dynamic contexts.  
In most programming languages including C, C++, and Java, variables are always statically (or lexically) scoped i.e., binding of a variable can be determined by program text and is independent of the run-time function call stack.   
For example, the output for the below program is 10, i.e., the value returned by f() is not dependent on who is calling it (Like g() calls it and has a x with value 20). f() always returns the value of global variable x.

To sum up, in static scoping the compiler first searches in the current block, then in global variables, then in successively smaller scopes.  

**Dynamic Scoping:**   
The main idea is that in any moment of the software to know which value a variable is assigned to you have to 'look into the stack' or in some way run it. While the static scoping is (as the name is telling) static. 
With dynamic scope, a global identifier refers to the identifier associated with the most recent environment and is uncommon in modern languages. In technical terms, this means that each identifier has a global stack of bindings and the occurrence of an identifier is searched in the most recent binding.   
In simpler terms, in dynamic scoping, the compiler first searches the current block and then successively all the calling functions.


Let is not assignment, is creating a new variable. 
Let is used to bind variables.

```` Scheme
(let ((x 3) 
	(y 2)) ;It's parallel 
)

(let* ((x 3) ;It's sequential
	(y 2))  
)
````

Variables created by let are local. To create top-level bindings there is  
define:  
````Scheme
(define x 12)  
(define y #(1 2 3))
````


NB: in general, procedures with side effects have a trailing bang (!) character.


Lambdas ae unnamed procedures ````((lambda (x y) (+ (* x x) (* y y))) 2 3) = 13````. 


# Homoiconicity

It means that there is no distinction between code and data, as in von Neumann's architectural code This could be complicated, but very effective for meta-programming purposes Since code is very much a given, it is very easy to design code which creates and composes other code.


Woow it is possible to create syntax using the language. Let and Lambda are just symbol used by the syntax but you, using macros could create new syntax. 


Modello di storage Le variabili e gli oggetti sono riferiti implicitamente a locazioni presenti nella memoria heap

Sequence of operations: begin  
If we are writing a block of procedural code, we can use the begin construct


# Lists

Lisp (di cui Scheme é un dialetto) deriva da LISt Processor La gestione delle liste é esattamente identica quella del lisp: sono trattate come coppie concatenate di due parti: • car (Content of the Address Register) a.k.a. first • cdr (Content of the Data Register) a.k.a. rest


https://www.tutorialspoint.com/execute_scheme_online.php

````Scheme
(define ( minimum L )
(let ((x ( car L ))
    (xs ( cdr L )))
(if (null? xs) ; is xs = ()?
x ; then return x
(minimum ; else : recursive call
(cons
(if (< x (car xs ))
x
(car xs ))
(cdr xs ))))))

(minimum '(110 63 52 43 43 42 54))
````

Here another way using ````apply```` . 

````Scheme
(define (minimum x . rest )  
  (if ( null ? rest ) ; is rest = ()? 
  x ; then return x 
  (apply minimum ; else : recursive call 
	  (cons (if (< x (car rest )) 
		  x 
		  (car rest )) 
		  ( cdr rest ))))) 
		  
		  (minimum 110 63 52 43 43 42 54)
````


````when```` is the same of ````if```` without the 'else' part . 
````Scheme
(let label (( x 0)) 
	  (when ( < x 10) 
	  (display x) 
	  (newline) 
	  (label (+ x 1)))) ; x++
````

Every Scheme implementation is required to be properly tail recursive A procedure is called tail recursive if its recursive call is "at the tail", i.e. is the last operation performed
````Scheme
(define ( fact-low-level-idiomatic n ) 
	  (let loop (( x n ) ( accum 1)) ( if (= x 0) accum ( loop (- x 1)(* x accum )))))````

but note that this looks like a tail call. . . (In reality, the named let is translated into a local recursive function. If tail recursive, when compiled it becomes a simple jump.)


vector-ref  , vector-length sono funzioni. 

semantics is very straight forward. The syntax is a little bit different from usual.


Predicates

are procedures that return boolean. 

- null?
- equal? 
- eq? (same objects?)
- equal?

the compilers rapresent the code as a tree structure.

Evaluation strategy???

Struct


# first exercise 

differenza tra list e vector ?


concept of evaluation 

lambda is used to encapsulate piece of code inside the code, without the evaluation. 
It can be evaluated in any moment using '()' .

Never used eval because -> 

cons always create a cons node -> you must have an object and a list

append takes only 2 lists .


# 30 - 09 class

## Inheritance and structs 

It's not OOP but in some sense is similar 


Structs 


Closures is essentially a function but with a referencing environment. It's a closure if the definition is based on variables that are stored in the 'environment of the function'. 
In some sense a closure is not just a behavour (like a lambda function) but it's something more: data. 
A simple and immediate application of a closure is the 'iterator'! 

Lambda function + static environment with variables that are closed by the closure is very similar to OOP ! 

Indeed the main idea of OOP is something (an entity) that has both behaviour and data.

There are the concept of map, filter and also foldr and foldl. 

ricordati l'aritá ! 

expected: at least 3

folds: foldr and foldl (aka reduce in Python, inject in Ruby, std::accumulate in C++) <- approfondire accumulate in C++ . 

## While and macros

> You don't evaluate macros, you expand them. 

Scheme has a very powerful Turing-complete macro system. 
Macros are of course expanded at compile-time 3 macros are defined through define-syntax and syntax-rules. 

````Scheme
(define-syntax while
(syntax-rules () ; no other needed keywords
((_ condition body ...)    ; pattern P
(let loop () ; expansion of P
(when condition
(begin
body ...
(loop)))))))
````

Note that _ is just a shorthand notation and "..." is a way to say that you can have multiple elements as body. Note that Scheme is cool because you can define recursive macros. 


## Hygiene of macros 

Scheme macros are hygienic: this means that symbols used in their definitions are actually replaced with special symbols not used anywhere else in the program. In this way it's impossible to have name clashes when the macro is expanded. For example a macro could be expanded into a piece of code that contains a label that has the same name of a variable used by the user for example -> so the name clash. 


e.g. without hygene the following code
( define ( fact-with-while n)
(let ((x n)( loop 1))
( while (> x 0)
(set! loop (* x loop ))
(set! x (- x 1)))
loop ))
would be expanded into:
( define ( fact-with-while n)
(let ((x n)( loop 1))
(let loop ()
( when (> x 0)
(set! loop (* x loop ))
(set! x (- x 1))
( loop )))
loop ))


# Continuations 

A continuation is a data structure used to represent the state of a running program. 

call/cc always takes a lambda function as argument. 

The argument of call/cc is also called an escape procedure: basically we save/restore  the 'call stack'.
When a continuation object is applied to an argument, the existing continuation is eliminated and the applied continuation is restored in its place, so that the program flow will continue at the point at which the continuation was captured and _the argument of the continuation_ then becomes the "return value" of the call/cc invocation. 

How continuations are implemented? We consider here two approaches (there are many variants):

- the garbage-collection strategy (slower)
- the stack strategy 


````Scheme
(+ 23 (call/cc (lambda (k) (+ 10 9)))) ;Risultato: 42

(+ 0 (call/cc (lambda (k) (+ 42 (k 42))))) ;Risultato: 42 poichè si esce subito da call/cc appena a k è stato assegnato un valore
````

Un uso comune della call/cc é per le uscite strutturate non locali da cicli o da corpi di procedure, ma in realtá la call/cc é molto utile anche per implementare strutture di controllo molto piú complesse, come gli iteratori.
Le continuazioni sono molto potenti, ma rendono difficile capire qual’é il flusso del programma: spesso vengono definite GOTO glorificati.



## Exceptions 

Exception handling is quite common in programming languages (see e.g. Java, where they are pervasive).
Recent Scheme standards have exception handling but we would like to implement *our*  throw / catch exception mechanism using continuations.

https://matt.might.net/articles/programming-with-continuations--exceptions-backtracking-search-threads-generators-coroutines/



# OOP 

Inheritance in python is multi.
Java no. 

It is possible to use closures to do some basic OO programming
the main idea is to define a procedure which assumes the role of a class
this procedure, when called, returns a closure that works like an object
it works by implementing information hiding through the "enclosed" values of
the closure
access to the state is through messages to a function that works like a
dispatcher
Matteo
 



L’espressione \#t definisce vero, mentre \#f definisce falso. In aggiunta qualsiasi altra
cosa diversa \#f é considerata vera rispetto alle forme condizionali come if, and, or o
cond.


# esercitazione del 12-10

In questa esercitazione ha fatto un esercizio abbastanza semplice sulle struct e sulla creazione di un albero binario (dovrei rifarlo come esercizio)

Poi per il resto ha fatto un po' di define-syntax ... 


#:mutable usato per indicare quando un campo di una struct (quindi un oggetto) è mutabile. 


'()
```#f``` used to rapresent the null


per accedere a un attributo di una struct basta usare - . 

(struct node node-base ;per indicare inheritance
  (left right))

remember list-ref to access n elements on a list


Macros are expendaded at compile time!!! Not all the parameters are completely evaluated at compile time! The most of them just copied.


the dots ... in the macros definitions are a way of extracting just specific parameters from the functions. 



## esercitazione del 19 di Scheme 'tosta' sulle continuations 


capita in parte

INTERESTING: last exercise is about storing continuations in a stack



# esercitazione del 28/10 ancora una ripresa su continuations


[Haskell](Haskell.md) 
[Scheme](Scheme.md) 
