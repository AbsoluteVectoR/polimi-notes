https://docs.google.com/spreadsheets/u/1/d/e/2PACX-1vRbfc9IS3b-qYzE-EJUxXl0nKOWEjKD_L6CmMggIEVe3rz-mU_i1hgRx3yP7E87dg/pubhtml?gid=1284356776&single=true

# Introduction to software engineering

Why software engineering is important? Software is everywhere and our society is now totally dependent on software-intensive systems.Society could not function without software.


## Software lifecycles 

Waterfall lifecycle: As a reaction to the many problems: traditional “waterfall” model identify phases and activities force linear progression from a phase to the next. No returns (they are harmful), better planning and control, standardize outputs (artifacts) from each phase. Software like manufacturing. 

![](Pasted%20image%2020220916122239.png)
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

![](Pasted%20image%2020220929190226.png)

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

![](Pasted%20image%2020220930133221.png)


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


## Quiz

In sostanza i requirements dovevano tutti avere natura tecnica e non lasciare spazio ad interpretazione ???? <- da verificare


copiare dal riassunto di infsoft2 shared phenomena etc 



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

Architecture is the vehicle for communication: internal (different teams), external (teams and stakeholders) Architecture manifests the earliest set of design decisions Introduces constraints on implementation Introduces organizational structure Inhibits or enables quality attributes Architecture is a transferable abstraction of a system Product lines share a common architecture Allows for template-based development Basis for trainin


he notion of quality is central: the SA is derived according to qualities of the system at the earliest possible stage. External qualities: performance, security, availability, functionality, usability Internal qualities: modifiability, portability, reusability, integrability, testability

Architectural style


# Layered style
![](Pasted%20image%2020221030185136.png)

Layers enable separation of concerns We can identify the main focuses of each layer at a glance. Each layer can be implemented using a different team Each layer remains independent from the others, provided that it respects the protocols defined for communication with the neighbour layers


![](Pasted%20image%2020221030185228.png)

Abstraction layers to dominate complexity When it is possible to identify a specific (bounded) concern for each layer When it is possible to identify clearly the communication protocols between layers


# Client/Server

![](Pasted%20image%2020221030185632.png)

Remote communication Separation of concerns between the clients and the server Note that a client-server architecture is a kind of layered architecture with two layers, also called tiers in this case Possibility to execute on heterogeneous computational units (virtual/physical) E.g., servers on powerful machines (complex computations), clients on commodity machines

![](Pasted%20image%2020221030185723.png)


## Three-tier architecture

Note how the middle tier plays 2 roles (server and client ). 

![](Pasted%20image%2020221102165853.png)


# Event-based systems


This kind of style is popular in distributed systems (systems heavily distributed and decentralized). 

![](Pasted%20image%2020221102170135.png)



There are producers of events and consumers of this event. Each consumer will register itself at the event dispatcher, so that they can receive the event. 

Components can register to / send events • Events are broadcast to all registered components • No explicit naming of target component

Often called publish-subscribe Publish event generation Subscribe declaration of interest Different kinds of event languages possible

Very common in modern development practices + E.g., continuous integration / deployment (such as GitHub Actions)
Easy addition/deletion of components + Publishers/subscribers are decoupled + The event dispatcher handles this dynamic set


Potential scalability problems
The event dispatcher may become a bottleneck (under high workloads)
Ordering of events – Not guaranteed, not straightforward

Asynchrony send and forget Reactive computation driven by receipt of message Location/identity abstraction destination determined by receiver, not sender Loose coupling senders/receivers added without reconfiguration Flexible one-to-many, many-to-one, many-to-many

# Service-oriented architecture (SOA)



![](Pasted%20image%2020221102170557.png)

Pros Enables reuse of registries and providers across organizational boundaries Relies on runtime discovery and dynamic binding Services offered through a well-defined Application Programming Interface (API) à Interface documented in a machine-interpretable form Cons Dynamic orchestration of discovered services is not trivial A lot of glue code is needed SOA systems are usually monolithic SOAP (XML based protocol) considered too heav

# Microservice architectural style

Each service uses its own technology stack Technology stack can be selected to fit the task best E.g., Data analysis vs Video streaming Teams can experiment with new technologies within a single microservice E.g., we can deploy the two versions and do A/B testing No unnecessary dependencies or libraries for each service


![](Pasted%20image%2020221102170646.png)








Microservices key benefits: technology heterogeneity

Microservices key benefits: resilience

Microservices key benefits: scaling
Each microservice can be scaled independently Identified bottlenecks can be addressed directly Parts of the system that do not represent bottlenecks can remain simple and un-scale

Microservices key benefits: independent codebases and deployment
Each service has its own software repository Favor distributed teams No cross-dependencies between codebases Tools work faster Building, testing, refactoring, deployment takes seconds Each service can be deployed independently Independent CI/CD Startup takes a smaller amount of time

Microservices key benefits: reuse and composability
The functionality offered by a microservice can be used and reused in multiple contexts E.g., authentication It is possible to compose multiple microservices in different ways

Microservices key benefit: replaceability
Monolithic systems are often big and complex and their replacement is risky and costly Given its small size, replacing a microservice implementation is much easier The team can develop a new implementation As soon as the service is ready for operation, it can be moved in the operational environment The previous service can be shutdown




PROBLEMS

Issues with frequent deployments Need to redeploy everything to change one component Interrupt long running background jobs Increase risk of failure Overloaded containers Obstacle to scaling development Difficult fault localization Difficult maintenance Require long-term commitment to a technology stack
If a microservice fails the others can still work, possibly with a degraded functionality (until the failure is resolved) Note: microservices can introduce other types of failures related to network and communication (microservices systems are typically more “chatty”)
Forbid fine-grained scaling strategies It is not possible to scale “Product Catalog” up differently from “Customer Service” May lead to availability issues [~2008] Netflix reported that a single minor mistake (i.e., missing “;”) brought down the whole platform for many hours


# Analysis of architectures

Scalability   Usability


Availability: A service shall be continuously available to the user 

Reliability: means that the service is available for an agreed period without interruptions (frequency). Note that a system could be available for 99% of time but have a lack of reliability since it continues to 'crash' and quickly restart. 

Availability: The probability that a component is working properly at time t A = MTTF / (MTTF+MTTR) Reliability: The probability that a component has always been working properly during a time interval



Reliability requires that the component never fails in the interval 

From the availability perspective a given component could have failed in the interval (0,t), but it could have been repaired before


Mean Time to Repair (MTTR): Average time between the occurrence of a fault and service recovery, also known as the downtime Mean Time To Failures (MTTF): Mean time between the recovery from one incident and the occurrence of the next incident, also known as uptime Mean Time Between Failures (MTBF): Mean time between the occurrences of two consecutive incidents

![](Pasted%20image%2020221102172739.png)


A = MTTF / (MTTF+MTTR)


R = e-λt  where λ = 1/MTTF

Probability distribution about the failure 


Availability of a complex structure 

alculated by modeling the system as an interconnection of parts in series and parallel If failure of a part leads to the combination becoming inoperable, the two parts are considered to be operating in series If failure of a part leads to the other part taking over the operations of the failed part, the two parts are considered to be operating in parallel


series = one depends from the other The combined system is operational only if every part is available. A chain is as strong as the weakest link!



parallel = one is basically the replica of the other. The combined system is operational if at least one part is available


ission critical systems are designed with redundant components!




