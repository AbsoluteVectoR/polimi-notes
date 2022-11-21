https://docs.google.com/spreadsheets/u/1/d/e/2PACX-1vRbfc9IS3b-qYzE-EJUxXl0nKOWEjKD_L6CmMggIEVe3rz-mU_i1hgRx3yP7E87dg/pubhtml?gid=1284356776&single=true

# Introduction to software engineering

Why software engineering is important? Software is everywhere and our society is now totally dependent on software-intensive systems.Society could not function without software.


## Software lifecycles 

Waterfall lifecycle: As a reaction to the many problems: traditional “waterfall” model identify phases and activities force linear progression from a phase to the next. No returns (they are harmful), better planning and control, standardize outputs (artifacts) from each phase. Software like manufacturing. 

![](images/8272b5865e427d2bb09ac1f33fb8d2d3.png)
Feasibility study & project estimation
Cost/benefits analysis
Determines whether the project should be started (e.g., buy vs
make), possible alternatives, needed resources
Produces a Feasibility Study Document
	Preliminary problem description
	Scenarios describing possible solutions
	Costs and schedule for the different alternatives
-


Req. analysis and specification

Analyze the domain in which the application takes place
Identify requirements
Derive specifications for the software
	Requires an interaction with the user
	Requires an understanding of the properties of the domain
Produces a Requirements Analysis and Specification
Document (RASD)

Design
Defines the software architecture
	Components (modules)
	Relations among components
	Interactions among components
Goal
	Support concurrent development, separate responsibilities

Produces the Design Document


Coding&Unit level quality assurance
Each module is implemented using the chosen
programming language
Each module is tested in isolation by the module
developer
Inspection can be used as an additional quality
assurance approach
Programs include their documentation


Integration&System test
Modules are integrated into (sub)systems and integrated
(sub)systems are tested
This phase and the previous one may be integrated in an
incremental implementation scheme
Complete system test needed to verify overall properties
Sometimes we have alpha test and beta test


Maintenance


validation -> are we building the right product? It depends by the users / stakeholders . 

verification -> are we building the product right?


Nowadays:
- scrum
- extreme programming
- DevOps: infinite loop (more a set of practices than a production process)

based on incremental releases

2 macro areas in this course: requirements and design documents




# Requirements Engineering (RE)

22/9/2022

![](images/7c0217f50e455cdd0b176c4ecc4cb7e5.png)

Some definitions:

- **The machine** is the portion of system to be developed typically, software and hardware.
- **The world** is the portion of the real-world affected by the machine. 
- **Phenomena** can be **shared** between world and machine. Shared phenomena can be controlled by the machine and observed by the world, or viceversa.
- **D** = Domain assumptions are descriptive assertions assumed to hold in the world. They are real world properties and they don't depend on the machine.
- **G** = Goals are assertions formulated in terms of world phenomena. 
- **R** = Requirements are assertions formulated in terms of shared phenomena. 

The requirements are complete if :

1) **R** ensures satisfaction of the goals **G** in the context of the domain properties   
2) **G** adequately capture all the stakeholders’s needs  
3) **D** represents valid properties/assumptions about the world

When the domain assumptions **D** are wrong the software design could lead to disasters. Note that we are not talking about bugs on the code: problems could caused purely because bad design of the software. 

RE is a relatively young domain, there's no consensus on terminology yet, in particular about what is a requirement.

The boundary between the World & the Machine is generally not given at the start of a development project .
The purpose of a RE activity is to:

- to identify the real goals of the project 
- to explore alternative ways to satisfy the goals, through alternative pairs (Req, Dom) such that Req and Dom always satisfy G 
- to evaluate the strengths and risks of each alternative interfaces between the world and the machine


## Steps to solve first exercise typology 

1) (Trivial) Give a name to the use case: the use case is the flow of events in the system
2) Find the actors  
3) Then concentrate on the flow of events using informal natural language:
	- entry conditions
	- exit conditions: use case terminates when the following condition holds
4) Exceptions (Describe what happens if things go wrong) 
5) Special requirements (Nonfunctional Requirements, Constraints)

Some notes:

- Note that each use case may lead to one or more requirements.
- We should separate as much as possible different activities. It's better to keep concerns separated. For example a generic use case of an app will probably need the user logged in before posting a useless meme. But in the activity of posting the meme, we will not specify **in the flow of events** the action of 'logging in' , but only in the entry conditions. 
- Requirements identification needs to take into account the needs of many stakeholders: identify priorities of requirements is the task of a requirement engineer. 
- Implementations concerns are not related to a Requirement Engineer. The RE only focus on 'the world' not the machine. 
- the requirement validation is not 'a monolitich static step'. You continue to search error: the earlier you catch the errors, the earlier you can fix them. 

associations are rapresented by lines. You can have association between actors and use cases. 

![](images/5bfe46f9d7c3c3505fea247137fc4bfb.png)


# 12 10 22 

# Introduction to Alloy 

Alloy is a formal notation for specifying models of systems and software.
Alloy looks like a **declarative** OO language but also has a strong mathematical foundation.

> everything is a relation here. 

keywords: 

logic quantifiers
- lone : is a relation that says "at most one" . Example: 
	wife: lone Woman
set any number
all 
some at least one
no 
lone F holds for at most one x
one

- all
- iff 
	fact { all m: Man, w: Woman | m.wife = w iff w.husband = m }



- sig : Signatures: define types and relationships. 
sig Book {addr: Name -> lone Addr}

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

### Esercizi per cazzi miei 

Tutte le variabili si indicano 

nome: cardinality type 

nelle funzioni e predicati si dichiarano con [ nome: tipo ]

You must remember that when you join, the result of the join is 'the header'

Tutte le volte che voglio indicare la cardinalitá uso ```#nome_variabile``` . 


let wants the ```=``` while the declarations want 

# RASD 

**Describe at most three between strengths and weaknesses you see in Sections 1 and 2. Be concise and clear. **

(-) Since in the assignment is explicitly wrote that DREAMS will support three actors, I would have considered also the agronomists. This affect also the other sections, for example in the UML there is written under the diagram that Product-suggest is managed by agronomist, but this leads to incoherence since there is no agronomist considered in the rest of the document.

(-) I would have considered a generic 'user unregistered' and not only 'unregistered farmer'. It isn't a wrong assumption itself (the Policy Makers could be already registered by the government) but if this is the motivation of the absence of 'user unregistered’, it must be written in the Domain Assumptions (it's not).

(-) In the domain assumptions D7 and D9 are redundant.

(-) In the Class UML diagram seems forced the use of 'composition relation' between User, Forum Thread and Help Request. I would have used an 'aggregation' relationship.

**Describe at most three between strengths and weaknesses you see you see in Section 3. Be concise and clear. **

(-) In ' 3.2.1 Mapping on goals section ' I would have inserted in the same page a recall of the goals and domain assumptions to increase the readability of the document. I don't think the requirements are a problem since they are in the previous page while the goals and the domain assumptions are in different pages and 'go back and forth between pages' makes a little bit difficult understanding the mapping.

(+) The use cases are well described and very clear.

(-) Since it's a RASD in 3.3 they should not write about different technological details such as CSS and JavaScript.

**Describe at most three between strengths and weaknesses you see in Section 4. Be concise and clear. **

(+) The Alloy part is very clear and well documented and surely the consideration of the dynamic model helps.


# Software Design

Architecture is a transferable abstraction of a system.  The architecture manifests the earliest set of design decisions:

- it introduces design constraints on implementation
- it introduces organizational structure 
- it inhibits or enables quality attributes 

# Architectural style 

## Layered style

![](images/48d7d6ff6297508149cef6322b5d3704.png)

Layers archtecture enable separation of concerns, claryfying the main focuses of each layer. Each layer can be considered 'independent' from the others. Layered style can be used when it is possible to identify a specific (bounded) concern for each layer and clearly communication protocol between layers.

![](images/55a68953529fd27b7c28c006d2d0fe6d.png)

## Client/Server

![](images/4d827fc73360a16e7e6e4d3959042b29.png)

A client-server architecture is a kind of layered architecture with two layers (also called tiers).

![](images/663e7b6d5518489d0f06d2958786b96c.png)


### Three-tier architecture


![](../../Databases%202/src/images/8a8aa806fc6734d7b864a87fa0864371.png)

Note how the middle tier plays 2 roles (server and client). 

## Event-based systems

This kind of style is popular in distributed systems (systems heavily distributed and decentralized). 

![](images/1ea7126c94b4f01a1aff0696bf0fd2f3.png)

There are producers of events and consumers of evens and everything is coordinated by an event dispatcher:

- components can "register to" or  "send events"  
- events are broadcast to all registered components by the event dispatcher

Since publishers/subscribers are decoupled, addition/deletion of components is easy. The main problem is the scalability since the event dispatcher may become a bottleneck (under high workloads). Also notice that the architecture has an asynchronous nature so the ordering of events is not guaranteed.

## Service-oriented architecture (SOA)

![](images/adb8c00dbf94a576c014632442014891.png)

Services offered through a API. 

## Microservice architectural style

Each service uses its own technology stack and it's isolated. 

![](images/3094155438237d129e989f4285aa59c6.png)

Microservices architecture is very resilience and scalable. Each service has its own software repository and there is no cross-dependencies between codebases. 
While monolithic systems are often big and complex and their replacement is risky and costly; replacing a microservice implementation is much easier. 

# Analysis of architectures

A couple of parameters:

- Mean Time to Repair ($MTTR$): time between the occurrence of a fault and service recovery, also known as the mean downtime.
- Mean Time To Failures ($MTTF$): time between the recovery from one incident and the occurrence of the next incident, also known as uptime. 
- Mean Time Between Failures ($MTBF$): Mean time between the occurrences of two consecutive incidents


![](images/235f1627b058ea2dfd2a003976d60f09.png)

The we can define availability:


$$A = \frac{MTTF}{(MTTF+MTTR)}$$

The probability that a component is working properly at time (actual uptime).

Reliability: means that the service is available for an agreed period without interruptions (frequency of interruptions). 


$$R = e - \lambda t  \text{ where } \lambda = \frac{1}{MTTF}$$


Note that a system could be available for 99% of time but have a lack of reliability since it continues to 'crash' and quickly restart. 


# 03 11 

Example of sequence UML diagram. 

An example with two examples. One asynchronous and the other one synchronous. online/offline difference. 


Example of 3 components in series, so the total availability is the multiplication of all the 3 components availability. 

Then the example of parallelize the weakest component of the chain to increase the availability. 

# UML models


![](images/858f15c235cc4b58f21ee44de1e7a797.png)


Objects diagrams is the Class diagram with only distances. It is used to show links between instances. 

Composite Structure Diagram captures the internal modular structure of a component. You can described nested components, bus and ports. Exist tools that mechanically extract structure diagrams from class diagrams. Strong focused on low-level details. Developed by architects and used by programmers. 

Component Diagram used to show interfaces between components. 

Deployment Diagram captures topology of a system: hardware, software and communications protocol between them. It is used to specify the distribution of components and identify performance bottlenecks. 

![](images/eb29c998a8cc5110e24e57a626e616af.png)

Sequence Diagram used to describe behavior time-oriented. Focused on internal message exchange among components. It is used to show the control flow and illustrate typical scenarios. 



The top-down design generally produces more elegant systems but the individual components reuse is rare. The bottom up design is a bit rough end result, but it's very efficient since we re-use components and it s generally quicker. 

In real life generally is used a trade-off between the two approaches. 

# JEE

JEE is a software framework. 
A software framework facilitates and speeds the software development up through pre-built blocks. The framework itself forces some architectural styles, design patterns and design principles. Any library is also a software framework.
An integrated collection of components, set of specifications, conventions and principles. Frameworks follow the open-closed design principle. 

JEE, Java Platform Enterprise Edition is a Java based software framework for development of Enterprise Applications (EA). 
EAs often deal with huge amount of data. 
Generally EAs involve source control stuff, multi-threading, synchronization, concurrency, transaction processing, distributed system, messaging and service management. 

JEE: 

- Enterprise JavaBean (EJB): server-side components that implement the main business logic of the application 
- Java Persistence API (JPA): manages data base connectivity, relational data management, execution of queries. 
- Java Messaging Service (JMS) common interface for message protocols to implement communication among distributed systems
- Java Transaction API (JTA): specifies standard interfaces between a transaction manager and the parties involved in a distributed transaction system

JEE follows a multi-tier architecture:

- Client tier 
- Web tier 
- Business tier 
- Enterprise Information System tier (it also includes DBMS and other technologies)

Tier = logical group of components that are served for a specific purpose. 

Component = self-contained software units deployed onto the tiers of a EA. 

![](images/eb5acc4a07332025fdeba1fefc5b4403.png)


### Client tier

Java applets are dead because security concerns (client tier). 

When the UI is complex it's possible to build a client machine. 

Application clients container 


### Web tier 

Servlets a small server-side Java application. HttpServlet acts as a middleware between request coming from a http client 

Java Server Pages JSP are a ''going to death'' technology but still are not deprecated. 


Modern web applications use oftenly this stack: 

![](a710c4fc31121e95040b15f19231055c.png)

The business and web tier expose APIs to interact with business functions Communication uses the HTTP protocol The web clients use the APIs (e.g., HTML/JavaScript frontend, using frameworks such as AngularJS, Backbone.js, React). 

### Business tier 

$$\begin{array}{|l|l|}
\hline \text { Enterprise Bean Type } & \text { Purpose } \\
\hline \text { Session } & \begin{array}{l}
\text { Performs a task upon client requests; tasks } \\
\text { typically invoked by the servlets }
\end{array} \\
\hline \text { Message-driven } & \begin{array}{l}
\text { Acts as a listener for a particular messages, } \\
\text { such as the Java Message Service API }
\end{array} \\
\hline
\end{array}$$ 
The session Bean is more used and it encapsulates the business logic that can be invoked programmatically by a client. Session beans are of three types: 

- Stateful Session Beans: each stateful bean has only one client and there is a ''conversational state''. When the session bean terminates, it is no longer associated with that client. Example when you are buying a ticket. 
- Stateless Session Beans: there is no maintain any kind of ''conversational state'' , there is just a reply to a a request. 
- Singleton Session Beans: unique bean, generally used to keep system level configurations. 


## Platform Mechanisms

Injection mechanism simplify the code and decouples the creation/usage of existing components. 
Two types:

- Resource Injection: in a distributed environments it is used to access objects physically maintain by others machines/servers. There is a JNDI (Java Naming and Directory Interface) that provides mapping from an unique name to an instance. 
- Dependency Injection: since we typically have object creation tightly coupled with their usage (the classical object creation in Java).  

$$\begin{array}{|l|c|c|}
\hline \space & \text { Resource Injection} & \text { Dependency Injection } \\
\hline \text { Can Inject JNDI Resources Directly } & \text { Yes } & \text { No } \\
\hline \text { Can Inject Regular Classes Directly } & \text { No } & \text { Yes } \\
\hline \text { Resolves By } & \text { Resource Name } & \text { Type } \\
\hline \text { Type safe } & \text { No } & \text { Yes } \\
\hline
\end{array}$$


### JEE Resource Management 

JEE servers achieve heavy workloads with good performance using two commons distributed systems: 

- instance pooling: it consists in avoiding continue creation/deletion of objects using a ''pool'' . Mainly used for stateless and message-driven beans.
- activation/passivation: the EJB container "passivates" a stateful bean when it is in "idle" state and "activates" (recover) it whenever it is needed. Mainly used for stateful beans and it's convenient since the time between two requests by the client is usually bigger than the service time. 

## JWW APIs 

Java Messaging Service (JMS) is composed by: 

- JMS provider: exchanger 
- JMS client: source and target components 
- Messages: objects exchanged between components. 

Messages: 

- P2P (point-to-point): queues, senders and receivers. Senders put each message into a specific queue, receivers pull messages from the queue. Each message has at most one consumer. It's an asynchronous communication: senders are not forced to wait for answers. 
- Publish/subscribe: components topics which groups messages, publishers and subscribers. Topics do not keep the messages, they only broadcast them to subscribers (so subscribers can only access the messages generated after their subscription). Each message can have multiple consumers. 

 