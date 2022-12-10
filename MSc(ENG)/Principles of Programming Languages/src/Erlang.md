Pattern matching is more expressive than Haskell. 

Concurrent part is the most important part of the language. 
Erlang is nice to write concurrent programs.
Actor Model. Actor=independent unit of computation. Actors can only communicate through messages. 
Processes are represented using different actors communicating only through messages. Each actor is a lightweight process, handled by the VM: it is not mapped directly to a thread or a system process, and the VM schedules its execution The VM handles multiple cores and the distribution of actors in a network Creating a process is fast, and highly concurrent applications can be faster than the equivalent in other programming languages

```!``` to send anything to any process. Then ```receive``` and ```extract``` operation. 

````erlang

B ! {self(),{mymessage,[1,2,3,42]}}

Then in b: 

receive
	{A,{mymessage,D}} -> work_on_data(D);
end
````

With Erlang library you can make very easily and quickly a client-server system. 

There is construct to make  
````erlang
sleep (T) ->   
	receive   
		foo -> Actions1 //if foo it's not present, this construct waits Time and then makes actions2
	after   
	... Time -> Actions2
	end.
````
In this way we can build sleep function: 
````erlang
sleep (T) ->   
	receive   
	after   
		T -> true   
	end.
````

```register(Alias,Pid)``` is a way to make an alias in complex applications. 
There is also ```Flush()``` to clear message queue. 

Applications structure is based on the concept of supervision: "let it crash" principle for any process. Support to code hot-swap: application code can be loaded at runtime, and code can be upgraded: the processes running the previous version continue to execute, while any new invocation will execute the new code. 

