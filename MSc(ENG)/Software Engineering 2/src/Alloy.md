# Alloy 

Alloy is a tool for specifying models of systems and softwares with the goal of seeing if they are designed correctly. It is basically a **declarative** OO language with a strong mathematical foundation.

## Signatures 

Signatures define types and relationships. 

````alloy
sig Book {}
````

Alloy generates instances of each signature, called **atoms**. 
Since we care about the relationships between the parts of our systems we add **relations** inside of the signature body.

````alloy
sig Addr {}
sig Person {}

sig Book{
	addr: Addr
	owner: Person
}
````

### Cardinality 

Each relation has a **cardinality**, which represents how many atoms it includes. Cardinality types:

- one: exactly one (by default Alloy uses this if no others are specified)
- lone: 0 or 1 atoms in the relation 
- set: any number of atoms in the relation 
- some: at least one atom in the relation
- disj: can be prepend to any multiplicity to guarantee that it will be disjoint among all atoms of the relation.

````alloy
sig Key{
	locks: disj one Door -- not two keys will share a Door
}
````

In the signature relations declaration we can also use field expressions: 

````alloy
sig Node {
  edges: set Node - this -- no self loops
}
````


We can make some signatures subtypes of other signatures. 
Using `extends` keyword we can make disjoint **subtypes**.
Using `in` keyword we make **subset** signatures: not necessary pairwise disjoint.
A signature can be `abstract` : there won't be atoms that are just the supertype but not any of the subtypes.
Enums are a special signature: ```sig weather{Cloudy, Sunny, Rainy}```. 
Relations in Alloy are first class objects, and can be manipulated and used in expressions.

## Expressions and Formulas

Expressions are use in every everywhere in Alloy.



Let 




`x in A` means that x is an element of the set A

`A in B` 

````alloy
expr1 or {
  expr2
  expr3
    ...
}

-- means expr1 or (expr 2 and expr3 and ...) 

````

Set comprehensions permit to explicit the set of all elements of a where `expr[x]` is true.
````alloy
{x: Set1 | expr[x]}
{x: Set1, y: Set2, ... | expr[x,y]}
````

Can be used anywhere a set or set expression is valid.

There are also operators: 

- Unary operators: 
	- $\sim r$ (transpose/inverse) 
	- $^{\wedge}r$ (positive transitive closure)
	- $*r$ (reflexive transitive closure)
- Dot join: $a \cdot b$ combines two or more sets into a single set
- Box join: ????? 
- Restriction: $\mathbf{s}<: a$ (domain restriction), $a$ : $>$ s (range restriction) ???? 
- Arrow product: $\mathrm{a} \rightarrow \mathrm{b}$ (Cartesian product)
- Intersection: $a$ \& $b$ (intersection*)
- Union, difference: $a+b$ (union* $), a-b($ difference* $)$
- Expression quantifiers are also used in expressions and not only in relations: 
	- some var : bounding-expr | expr  
	- all var : bounding-expr | expr  
	- one var : bounding-expr | expr  
	- lone var : bounding-expr | expr  
	- no var : bounding-expr | expr
- Comparison operators: in $=,<,>,=,=<,=>$
- Let 
````alloy
let x = A + B, y = C + D |
   x + y
````
- Logical operators (both symbolic and english form)
|word|symbol|
|:--:|:---:|
|and|&&|
|or|\|\||
|not|!|
|implies|=>|
|iff|<=>|

## Predicates 

A predicate is like a programming function that returns a boolean. Predicates are mainly use to model constraints since they are reusable expressions.

````alloy
pred name {
       constraint
}

pred foo[arg1: <> , arg2: <> ] {
  expr
}

pred deleteBook [b, b': Book, n: Name] {  
b'.addr = b.addr - n ->Addr  
}

````

## Functions 

Alloy functions have the same structure as predicates but also return a value. Unlike functions in programming languages, they are always executed within an execution run, so their results are available in the visualisation and the evaluator even if you haven’t called them directly. This is very useful for some visualisations, although the supporting code can be disorienting when transitioning from “regular” programming languages.

````alloy
fun name[a: Set1, b: Set2]: output_type {
  expression
}
````

- show() built in Alloy Analyzer to show us a visual rapresentation 
- fun /functions reusable expressions
- pred Predicates reusable expressions. True o False. Each line is in conjuction with the others.
- assert Assertions: properties we want to check.
- fact :  Facts: properties of models (constraints!) 
- run PRED for #ENTITIES but exactly #PARTICULAR EXCEPTIONS

operations: 

- join construct: entity.(entity.attribute)
- ^ transitive closure on binary relations 
- * reflexive transitive closure on binary relations
- tilde transpose operator always on binary relations


You must remember that when you join, the result of the join is 'the header'.

keywords: 

- all
- iff 
	

## Facts 

A fact is a property of the model. It's a predicate which is always considered true by the Analyzer. Any models that would violate the fact are discarded instead of checked.

````alloy
fact { 
	all m: Man, w: Woman | m.wife = w iff w.husband = m 
}
````

## Commands 

A _command_ is what actually runs the analyzer. It can either find models that satisfy your specification, or counterexamples to given properties.


- run: finds a matching example of the specifications. You will always use with a bound: `run {} for 42 but 4 Bananas, 2 Pears` .
- run {constraint} : Finds an example satisfying the ad-hoc constraint in the braces.
- check: **check** tells the Analyzer to find a counterexample to a given constraint. 
````alloy
assert no_self_loops {
    no n: Node | self_loop[n]
}

check no_self_loops
````


useful links: 

https://alloy.readthedocs.io/en/latest/language/expressions-and-constraints.html#expressions 