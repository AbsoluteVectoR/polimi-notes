POSIX threads and OpenMP are two implementations of a shared memory parallel programming model with threads.   
 
Mapping patterns to specific hardware prevents the implementation from being portable, so parallel programming models are an abstraction above the hardware. 

A thread is an independent stream of instructions within a process. Threads can be scheduled to run by the operating system. Any thread can execute at the same time as other threads Threads have local resources and can access the shared process resources. 

- Changes made by one thread to shared system resources will be seen by all other threads
- Implicit communication by reading and writing shared variables 
- Reading and writing to the same memory locations requires explicit synchronization by the programmer

We will see two different standards: 

- POSIX Threads (Pthreads)
- OPENMP 

## POSIX

Explicitly synchronization using barriers and mutex. Mutex variables are the basic method to protect shared data when multiple writes occur. 

