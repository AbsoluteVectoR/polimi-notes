https://www.dropbox.com/sh/jq1mmyjdk4pzqx5/AABlNlsFdOEJgRbh_ZwR_KgTa?dl=0


# Formal Language Theory an Introduction

## Basic terminology

- Alphabet $\Sigma$ is any **finite** set of symbols $\Sigma=\left\{a_{1}, a_{2}, \ldots a_{\mathrm{k}}\right\}$
- Cardinality of the alphabet $|\Sigma|=k$
- String is a sequence of alphabet elements 
- Language is any set of strings

$$
\Sigma=\{a, b, c\} \quad L_{1}=\{a b, a c\} \quad L_{2}=\{b c, b b c\} L_{3}=\{a b c, a a b b c c, a a a b b b c c c, \ldots\}
$$
- Universal language: the set of all strings over the alphabet $\Sigma$, of any length. 


## Operations on strings 

- Concatenation is a product $x \cdot y$ or $x y$ for short
- Empty string (or null string) $\varepsilon$ is the neutral element for concatenation. Notice: $\varepsilon$ is $N O T$ the empty set:$\varepsilon \neq \varnothing$
- Substrings: if $x=u y v \quad(\mathrm{NB}$ : both $u$ and $v$ can be $\varepsilon$ ) then 
	- $y$ is a substring of $x$
	- $y$ is a proper substring iff $u \neq \varepsilon$ or $v \neq \varepsilon$
	- $u$ is a prefix of $x$
	- $v$ is a suffix of $x$
- Reflection: 
	- $x=a_{1} a_{2} \ldots a_{h} \rightarrow x^{R}=a_{h} a_{h-1} \ldots a_{2} a_{1}$
	- $(x^{R})^{R}=x$ 
- Repetition: $m$-th power $(m \geq 1)$ of string $x$ : concatenation of $x$ with itself $m-1$ times.
- Operator precedence: repetition and reflection take precedence over concatenation
$$
\begin{aligned}
& a b^{2}=a b b \quad(a b)^{2}=a b a b \\
& a b^{R}=a b \quad(a b)^{R}=b a 
\end{aligned}
$$


### Operations on languages 

Operations are typically defined on a language by extending the string operation to all its phrases:

- Reflection $L^{R}: \quad L^{R}=\left\{x \mid \exists y\left(y \in L \wedge x=y^{R}\right)\right\}$ def. by characteristic predicate
- Prefixes of $L = \{y \mid y \neq \varepsilon \wedge \exists x \exists z(x \in L \wedge x=y z \wedge z \neq \varepsilon)\}$ (*proper prefixes*). Prefix-free language $L$ is a language with no proper prefix of its phrases:  
	- $L_{1}=\left\{x \mid x=a^{n} b^{n} \wedge n \geq 1\right\} \quad$ is prefix-free: $a^{2} b^{2} \in L_{1} \quad a^{2} b \notin L_{1}$
	- $L_{2}=\left\{x \mid x=a^{m} b^{n} \wedge m>n \geq 1\right\} \quad$ is not prefix-free: $a^{4} b^{3} \in L_{2} \quad a^{4} b^{2} \in L_{2}$ 

- Concatenation

$$
L^{\prime} L^{\prime \prime}=\left\{x y \mid x \in L^{\prime} \wedge y \in L^{\prime \prime}\right\}
$$

- $m$-th POWER
- Union
- Intersection
- Difference
- Inclusion
- Etrict inclusion
- Equality
- Complement of a language $L$ over alphabet $\Sigma$ is the difference with respect to the universal language. The complement of a finite language is always infinite. The complement of an infinite one is not necessarily finite.
$$
\neg L=L_{\text {universal }} \backslash L
$$
- Star operator (also called Kleene star) is the union of all the powers of the language. Every string of the star language $L^{*}$ can be chopped into substrings $\in L$ . Technically is the reflexive and transitive closure of the language on the concatenation operator.
- Cross operator $\boldsymbol{L}^{+}$. It can be derived from the star operator $*$ :
$$
\boldsymbol{L}^{+}=\boldsymbol{L} \cdot \boldsymbol{L}^{*}
$$
- Quotient operator $\boldsymbol{L}_{\mathbf{1}} / \boldsymbol{L}_{\mathbf{2}}$ : it shortens the phrases of $\boldsymbol{L}_{\mathbf{1}}$ by cutting off a suffix that belongs to $L_{2}$. NB: forward slash (backward slash denotes set difference)

$$
\boldsymbol{L}=\boldsymbol{L}_{1} / \boldsymbol{L}_{2}=\left\{y \mid \exists \mathrm{x} \in L_{1} \exists z \in \boldsymbol{L}_{2}\left(x=y z_{1}\right)\right\}
$$

Example: $L_{1}=\left\{a^{2 n} b^{2 n} \mid n>0\right\} \quad L_{2}=\left\{b^{2 n+1} \mid n \geq 0\right\}$

$$
\begin{aligned}
L_{1} / L_{2} &=\left\{a^{r} b^{s} \mid(r \geq 2, \quad r \operatorname{even}) \wedge(1 \leq s<r, \quad s \text { odd })\right\} \\
&=\left\{a^{2} b, a^{4} b, a^{4} b^{3}, \ldots\right\}
\end{aligned}
$$

$\boldsymbol{L}_{\mathbf{2}} / \boldsymbol{L}_{\mathbf{1}}=\varnothing \quad$ because no string in $L_{2}$ has a string in $L_{1}$ as a suffix



# Regular Expressions

Regular expression.

The family of REGULAR LANGUAGES is our simplest formal language family. It can be defined in three ways:

- Algebraically (we start from this)
- By means of generative grammars
- By means of recognizer automataa regular expression


a regular language is a language denoted by a regular expression


The family of REG is the collection of all regular languages. 
THE FAMILY OF FINITE LANGUAGES (FIN)It is the collection of all languages having a finite cardinalityEVERY FINITE LANGUAGE IS REGULAR (hence FINREG)because it is the union of a finite number of stringseach one being the concatention of a finite number of alphabet symbols


derivation relation can be applied repeatedly, yielding relation


POWER: $a^h=a a \ldots a(h$ times $): a^n$
REPETITION: from $k$ to $n>k:[a]_k^n=a^k \cup a^{k+1} \cup \ldots a^n$
OPTIONALITY: $(\varepsilon \cup a)$ or $[a]$
ORDERED INTERVAL: $(0 \ldots 9)(a \ldots z)(A \ldots Z)$


property: the REGfamily is closed underconcatenation, union, star. 

REGis also closed under INTERSECTION and COMPLEMENT.


### APPLICATION: REPRESENTATION OF LISTS BY MEANS OF R.E.

a list contains an unspecified number of elements e of the same type generated by the r.e. e+, or e* if it can be emptye can be a terminal symbol or any regular subexpression


## Regular Languages 

A language on an alphabet is regular if it can be defined by a regular expression. So only if it is defined by concatanation, union and star over the elementary languages of $L$ ($\{a_1\} , \{a_2\} , \{a_3\} \dots$). 

REG is the family of all regular languages (indipendently by the alphabet which each language is based on).


# Free grammars

Regular expressions can provide lists but not nesting (recursion). 
 $$G =<V,\Sigma,P,S>$$
 where:
 - $V$ is the set of non terminals symbols
 - $\Sigma$ is the set of terminals symbols
 - $P$ is the set of productions 
 - $S$ is the axiom, a particular symbol of $V$ 


Recursion is the key to create infinite grammars. The necessary and sufficient condition for a grammar to be infinite is that there is a recursive derivation. Note that a grammar have a recursive derivations iff the corrisponding graph has a circuit. 

Clean grammars are grammars without a circular axioms. 

Syntax tree. 

Given a grammar $G$ and a string in $L(G)$ we can build a syntax tree of the string where the root is the axiom $S$, the leafs are the sequence of the symbols of the string and all the branches are the productions used to generate the string. 


With the definition of Syntax Tree we can also specify what is an ambiguity in the context of grammars.
A sentence is ambiguous if it admits different syntax trees. The number of distinct trees is also the degree of the ambiguity.

> Avoid the ambiguity in the grammar design phase. 

Ambiguity can be caused by bilateral recursion


# Finite State Automata 



# Pushdown automata




# Lab 1 from Cattaneo

Lab is 20% of the exam. 

Some applications: 
- The standard regular expression syntax 
- Standard unix tools for text editing 
- Parser generation with flex and bison 
- The internal organization and workflow of a real-world compiler 
- How to modify and extend a simple compiler called ACSE

Regex basics:
- ```x``` the ```x``` character 
- ```.``` any character except newline
- ```[xyz]``` means ```x``` or ```y``` or ```z``` 
- ```[a-z]``` any character between ```a``` and ```z``` 
- ```[^a-z]``` any character except those between ```a``` and ```z```

Said ```R``` a regular expression:
- ```RS``` concatenation of ```R``` and ```S```
- ```R|S``` either ```R``` or ```S``` 
- ```R*``` zero or more occurrences of ```R```
- ```R+``` one or more occurrences of ```R``` 
- ```R?``` zero or one occurrence of ```R ```
- ```R{m,n}``` a number or ```R``` occurrences ranging from ```n``` to ```m ```
- ```R{n,}``` at least n occurrences 
- ```R{n}``` exactly n occurrences of ```R```

## Flex 

It's implemented as non-deterministic finite state automaton. 

![](Pasted%20image%2020221024161609.png)

- definitions: where you can declare useful REs
- rules: most important part where you bind RE combinations to actions 
- user code: C code

Each part is separated by ```%%```  


Longest matching rule 
The flex scanner in case of more than one match (with more one rules) the longer match will always win: if a longer regular expression match an expression and then others regular expression match subsets of the expression, the longer rule willl have precedence. 

the first rule 




# prima ese di Breveglieri 

## Berry Sethy

Convert a regular expression to finite state automaton 

1) rename all the symbols
2) find initial / terminals / followers symbols 
3) eventually collapse lines in the table
4) build actual automaton and in each state you put in the followers 


note that the terminals are not the symbols that appear at the end of a string! But all the symbols that are not initials.
Followers are all the symbols that can follow a terminal. 

Procedure to check if it s minimal is to use a matrix where each column is a state and each line a transition letter. 

Berry sethi can work also viceversa !!!!


### Brozozowski rule is very intuitive


### Two possible way to eliminate $\epsilon$ transition :

- backword propagation (BP)
- forward propagation (FP)

note that eliminating the $\epsilon$ - moves produce indeterministic automatons. 


# Seconda esercitazione 



# Terza ese (2 laboratorio del 20/10)

# Byson

Semantic of an input is the semantic analysis. 
Syntactic analysis does not determine the meaning of the input. It just make a syntax tree.
Byson, from a grammar, create a code that parse a source code/file that corrisponds with that grammar. So basically Byson using the LALR algorithm builds LR parsers. 

- prologue: useful place where to put header file inclusions and variable declarations
- definitions
- rules 
- user code 
````C
%{
//prologue and headers 
}%
// definitions
%%
//rules like a context-free grammar 
not_terminal : terminal1 
				   | terminal2 TOKEN_A  
				   | terminal3 { /* C code */ }
%%
//user code
````


(very similar to Flex). 

Very similar to grammar ... uppercase tokens are non terminals and lowercase tokens are terminals symbols. 

You can add semantic actions for each grammar rule. 

Byson uses bottom-up parsing: it always gives precedence to the inner-most rule. 


