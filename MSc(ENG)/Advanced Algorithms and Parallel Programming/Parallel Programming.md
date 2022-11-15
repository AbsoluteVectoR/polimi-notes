Why parallel programming? 

- time saving
- money saving 
- basically the ''big problems'' can only solved by parallel algorithms 

There is also automatic parallelization: where sequential algorithms (at high level code) are automatically parallelized in high efficiency assembly instructions. 

The compiler is not able to know if for example 2 pointers of 2 arrays are pointing different region of RAM and are not overlapping.
Complete automatic
parallelization is (at the
moment?) not feasible

Tools are not able to
extract all the available
parallelism from a
specification designed
to be executed in
sequential way

at the moment Parallelization by hand. The programmer needs to give hints to the tools...
There are three critical aspects:
Which
type
of parallelism has to be considered
How to
design
the parallel algorithm
•
Trying to parallelize existing sequential
algorithms
•
From scratch
How to
provide information
about the
parallelism to the tools

There is not a single kind of parallelism:
Instruction Parallelism
Data Parallelism
- combination of them 


single instruction, single data (all the single core architectures)
single instruction, multiple data (most of the modern GPUs)
multiple instruction, single data (experimental)
multiple instruction, multiple data (pthread or running in parallel on different data)

We can classify parallelism over different levels:

- bits level: It is very relevant in Hardware Implementation of
algorithm. 
- instructions level: Different instructions executed at the same time on the same core. Supported by multiple execution units, pipeline, vector, SIMD units etc. This type of parallelism can be easily extracted by
compilers
- tasks level: Task: a logically discrete section of computational work. Typically a program or program like set of instructions that is executed by a processor supported by shared memory and cache mechanisms. Usually difficult to be automatically extracted. 


Design a «good» parallel algorithm by extracting
all the available parallelism is not enough
not
all the extracted parallelism is
exploitable
on a real architecture

We need to consider which parallelism is available
on the considered architecture
Non suitable parallelism can introduce
overhead

Real architectures differ so much that now
compilers are not able to fill the gap between an
abstract model and real implementation
Optimized applications can not be generated
starting from generic parallel code
Code extensions have been specialized for
particular types
of applications/architectures

$$\begin{array}{|c|c|c|c|}
\hline \text { TECHNOLOGY } & \text { TYPE } & \text { YEAR } & \text { AUTHORS } \\
\hline \text { Verilog/VHDL } & \text { Languages } & 1984 / 1987 & \text {US Government }\\
\hline \text { MPI } & \text { Library } & 1994 & \text {MPI Forum}\\
\hline \text { PThread } & \text { Library } & 1995 & \text {IEEE}\\
\hline \text { OpenMP } & \text { C/Fortran Extensions } & 1997  & \text {OpenMP}\\
\hline \text { CUDA } & \text { C Extensions } & 2007 & \text {NVIDIA}\\
\hline \text { OpenCL } & \text { C/C++ Extensions + API } & 2008 & \text {Apple}\\
\hline \text { Apache Spark } & \text { API } & 2014 & \text {Berkeley}\\
\hline
\end{array}$$

$$\begin{array}{|l|l|l|l|}
\hline \text { TECHNOLOGY } & \text { Bit } & \text { Instruction } & \text { Task } \\
\hline \text { Verilog/VHDL } & \text { Yes } & \text { Yes } & \text { No } \\
\hline \text { MPI } & \text { (Yes) } & \text { (Yes) } & \text { Yes } \\
\hline \text { PThread } & \text { (Yes) } & \text { (Yes) } & \text { Yes } \\
\hline \text { OpenMP } & \text { (Yes) } & \text { (Yes) } & \text { Yes } \\
\hline \text { CUDA } & \text { (Yes) } & \text { No } & \text { (Yes) } \\
\hline \text { OpenCL } & \text { (Yes) } & \text { No } & \text { Yes } \\
\hline \text { Apache Spark } & \text { (Yes) } & \text { No } & \text { (Yes)} \\
\hline
\end{array}$$

$$\begin{array}{|l|l|l|l|}
\hline \text { TECHNOLOGY } & \text { SIMD } & \text { MISD } & \text { MIMD } \\
\hline \text { Verilog/VHDL } & \text { Yes } & \text { Yes } & \text { Yes } \\
\hline \text { MPI } & \text { Yes } & \text { Yes } & \text { Yes } \\
\hline \text { PThread } & \text { Yes } & \text { (Yes) } & \text { Yes } \\
\hline \text { OpenMP } & \text { Yes } & \text { Yes } & \text { Yels } \\
\hline \text { CUDA } & \text { Yes } & \text { No } & \text { Yes) } \\
\hline \text { OpenCL } & \text { Yes } & \text { (Yes) } & \text { Yes } \\
\hline \text { Apache Spark } & \text { Yes } & \text { No } & \text { No } \\
\hline
\end{array}$$

![](Pasted%20image%2020221028164604.png)


# Parallel programming pt 2

PThread is working very low level: threads management very explicit! 
CUDA is very similar to OPENCL, since the last one is a try to extend CUDA to all types of architectures and not only Nvidia. 


We can classify technologies and libraries looking if the management of memory/communications are implicitly/explicitly . 


# Parallel programmings patterns 








