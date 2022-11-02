# PRAM

A machine model is fundamental to reason about algorithms without considering the hardware. For algorithms applicable to parallel computers we use PRAM models.
$M'$ is a PRAM model and it's defined as system $<m, x , y , a >$ where $m_1,m_2 \dots$ are different rams machines called processors, $x_1,x_2, \dots$ are input memory cells, $y_1,y_2, \dots$ are output memory cells and $a_1,a_2 \dots$ are shared memory cells.  

Pram are classified based on their read/write abilities:

- exclusive read: all processors can simultaneously read from distinct memory locations
- exclusive write: all processors can simultaneously write to distinct memory locations
- concurrent read: all processors can simultaneously read from any memory location
- concurrent write: all processors can write to any memory location. Different criteria can apply in this case:
	- priority CW: processors have different priorities 
	- common CW: processors complete writes iff the written values are equals 
	- random CW


Some definitions: 

- $T^*(n)$ is time to solve problem using best sequential algorithm
- $T_p(n)$ is time to solve problem using $p$ processors 
- $S_p(n)=\frac{T^*(n)}{T_p(n)}$ is the speedup on $p$ processors
- $E_p(n)=\frac{T_1(n)}{p T_p(n)}$ is the efficiency 
- $T_{\infty}(n)$ is the shortest run time on any $p$ 
- $\mathrm{C}(\mathrm{n})=\mathrm{P}(\mathrm{n}) \cdot \mathrm{T}(\mathrm{n})$ is the cost that depends on processors and time
- $\mathrm{W}(\mathrm{n})$ is the work, which is the total number of operations

There could be also some variants of PRAM, like for example: 

- bounded number of shared memory cells
- bounded number of processor
- bounded size of a machine word 
- handling conflicts over shared memory cells


## Matrix-vector multiplication 

Embarassingly parallel . -> no cross-dependence
note that the maximum number of processors is the number of rows! 


associativity is necessary to organize operations in binary trees .

![](Pasted%20image%2020221031114536.png)



## Sum of vector elements

paralization of a sum of vector elements

![](Pasted%20image%2020221031114932.png)



it became a parallel pattern!


## Matrix-matrix multiplications

Da rivedere (fine della seconda lezione). 


## Prefix Sum example

The previous algorithms make the same amount of work. 

![](Pasted%20image%2020220930112448.png)

The idea is to make more work in same time taking advantage of idle processors in sum. Basically we used all the processors all the time. We have all the prefixes and not only $s_8$ . Efficiency is $1$ and the complexity is still $log(n)$ . 
Used for example in sorting algorithms, it consists in $S_i = \sum_1 ^i a_j$  
It's a variant of the 'classic parallel sum'. 
The downside is that you have more reads and writes in the same amount of time. 


##  Boolean DNF (sum of product)

Example of CRCW 

not all processors write X , those that do , write 1. 
Very simple parallel solution. Each processor assigned 


A slide about the semplicity and the beatiful of PRAM model. 


## Amdahl's law

Gene Amdhal was one of the three architects of ibm mainframes . he objected to parallelism saying that computation consists of interleaved segments of 2 types:

- a serial segments that cannot be parallelized 
- parallelizable segments 

![](Pasted%20image%2020220930114834.png)
 
The law is 'pessimist' since if a parallelizable part is for example a fixed fraction $f$ of the total computation, this will mean that given a problem with inherent $f=0.9$, there will not sense to use more than 10 processors... showing the limits of parallelization.

![](Pasted%20image%2020221031115816.png)




## Gustafson's law

> "We feel that it is important for the computing research community to overcome the "mental block" against massive parallelism imposed by a misuse of amdahl's speedup formula." 

The key points of Gustafson are that portion $f$ is not fixed and only absolute serial time is fixed. The end result of Gustafson's law is that we could always parallelize the computation **redoing** the sequential work more than one time. 
So basically we map the work to more processors and the we **repeat the initialization/sequential part** more than one time to permits an infinite theoretical speedup. 

![](Pasted%20image%2020220930114916.png)


# First exercitation 

### ISPC for implementing PRAM algorithms. 

ISPC is a compiler for a variant of the C language that focuses on accelerating applications according to the SPMD paradigm. It parallelizes at the instruction level by distributing instructions over vectorized architectures (SSE and **AVX** units) for x86, ARM and GPUs.
The implementation is based on a modification of the LLVM compiler (like many others) and it is supposed to be inter-operable with existing C/C++ programs.
Each parallel programming model, as we will see, has its own terminology. The documentation for ISPC can be found here:

https://ispc.github.io/ispc.html

When a C/C++ function calls an ISPC function, the execution model instantly switches from a serial model to a parallel model, where a set of program instances called **gang** run in parallel. Differently from the programming models that we will see in the course, the parallelization is transparent to the OS and is managed entirely inside the program. However, the number of program instances is typically limited and determined at compile time. The exact amount depends on the architecture that was targeted during compilation.
Control flow descriptions are managed through masks to hide computation's side effects when they are not desired. This is required to support normal C-like syntax containing `for` and `while` loops.
Unless otherwise specified, variables are local to each program instance inside a gang. Doing so is memory-inefficient, and whenever possible variables should have the attribute `uniform` to signal that they are shared among all instances of the gang. This also opens the door to issued arising from concurrent accesses to the same `uniform` variable.

ISPC does not support all C89 types, and defines its own types as well.

Each program instance in a gang has knowledge about the gang's size and its own index within the gang. The gang's size is stored in the `programCount` variable, while the instance's index in the gang is stored in the `programIndex` variable. They can be used to distribute the computation over the gang members by manually assigning the data they should work on.

The same operation can be automatically performed at compile time by ISPC using the `foreach(index = lowerbound ... upperbound) {}` construct, which body execution is automatically assigned to gang members. Typically, each member will execute the loop's body on a set of interleaved members of the indexed vector, although no assumption should be made.

Additionally, ISPC support task-level parallelism. This programming model will be further discussed in the next lectures, but it is worth it to see how it works under this paradigm as well.

Functions that will be executed concurrently, as independent tasks, must be declared using the `task` qualifier, and must return `void`. Once they have been defined, tasks can be launched using the `launch[size]` keyword. Within a function, it is possible to launch `size` tasks at the same time and based on the same function. Tasks, differently from members within a gang, will execute concurrently rather than in parallel. There is no guarantee about the execution order of tasks launched by a function other than that the function will not return before they are all completed. To force the function's execution to wait for tasks completion, the `sync` instruction can be used. Similarly to gang instances, tasks can identify themselves and the task pool size through the `taskCount` and `taskIndex` variables. 



Some links I found: 

About SIMD: 

- https://en.wikipedia.org/wiki/Single_instruction,_multiple_data
- piú volte si é parlato di https://en.wikipedia.org/wiki/Advanced_Vector_Extensions#Advanced_Vector_Extensions AVX . A quanto ho capito sono una serie di istruzioni introdotti nei processori Intel. **
