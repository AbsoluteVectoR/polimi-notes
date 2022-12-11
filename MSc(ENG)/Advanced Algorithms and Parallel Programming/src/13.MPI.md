MPI is a library-based specification for parallel and distributed computing developed by the MPI Forum. 
This single standard is supported by multiple implementations from multiple groups and vendors, in a similar fashion to OpenMP. The specification focuses on Fortran and C languages. 
POSIX threads and OpenMP are two implementations of a shared memory parallel programming model with threads, while MPI is designed for explicitly implementing parallelism in distributed memory environments with processes, using a library-based syntax.
With this concept, implementations support many parallel architectures and not necessarily distributed. Compilation tools are typically wrappers that set the required flags and environment on top of existing compilers. 

MPI API is used to message buffers and mapping processes and also communication management. 

```#include<mpi.h>```

```MPI_init(int * argc_p, char *** argv_p)``` is the first function called, where ```argc_p``` and ```argv_p``` are the parameters of the main function. In case of multithreaded programs it is used ```MPI_Init_thread``` when the program has to run on threads and not on a cluster. 

```int MPI_Finalize(void)``` is to de-allocates the message buffers and cleans up all. 

Point to point communication is possible through "communicators". A communicator is a collection of processes that can send messages to each other. ```MPI_COMM_WORLD``` is the default one, and collects all the processes created when launching the main program. 
```int MPI_Comm_size(MPI_Comm comm, int *size)``` and ```int MPI_Comm_rank(MPI_Comm comm, int *rank)``` are functions to respectively set the number of processes a communicator collects and the rank to identify each process. Note that (for both functions) the return value is an error while the data are inserted in the pointer in the second argument. 

```` cpp
int MPI_Send (const void *buf, int count, MPI_Datatype datatype, int dest, int tag, MPI_Comm comm, MPI_Status *status)

//MPI_Datatype is use to indicate the kind of message
//tag is a int > 0 and it is used to distinguish messages that are otherwise identical
````
The ```MPI_Recv``` routine is used to read a message from a communicator This is a blocking routine by default, in other words it will not return until the source target has written something in the buffer Sending and receiving messages introduces a synchronization element between processes. Where there is synchronization, deadlocks may arise. 

# fix this > 

```` cpp
int MPI_Send (const void *buf, int count, MPI_Datatype datatype, int dest, int tag, MPI_Comm comm, MPI_Status *status)
````

Typically al processes can access the standard output, while only the process 0 can access the standard input. 


https://dvalters.github.io/code/2016/07/13/MPI-CPP.html 