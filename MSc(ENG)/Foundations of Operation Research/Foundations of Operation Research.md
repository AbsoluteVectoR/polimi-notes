In [computer science](https://en.wikipedia.org/wiki/Computer_science "Computer science") and [operations research](https://en.wikipedia.org/wiki/Operations_research "Operations research"), **exact algorithms** are [algorithms](https://en.wikipedia.org/wiki/Algorithm "Algorithm") that always solve an optimization problem to optimality.

# 20 - 09 - 22 

Spanning trees have a lot of applications: 
- network design 
- IP network protocols 
- compact memory storage (DNA) 

A possible example could be to broadcast a network packet to all the nodes in a network. 


# Network optimization problems

# Optimal cost spanning trees 


A complete graph wqith n nodes ($n \ge 1$) has $n^{n-2}$ spanning trees.

## Prim's algorithm 

Iteratively build a spanning tree. 
Start from a single node and at each step you add to the current partial tree an edge of minimum cost. 
The cooler thing about this algorithm is that you can start from any node and the spanning tree will be optimal. 
Worst case is $O(nm)$ where $m$ is the total number of edges. 


Prim's algorithm is exact: it provides an optimal solution for every instance of the problem. 

Greedy algorithm constructs a feasible solution iteratively by making at each step a 'local optimal' choice, without reconsidering previous choices. 
Prim's algorithm is a greedy algorithm. 

Other implementations of the algorithm with proper data structures give us complexity of $O(n^2)$ or $O(m \log n)$ where the graph is sparse. 

An edge is cost decresing if is not in the tree and if is add to it, it will decrease the cost to reach a node. 

A tree T is of minimum total cost iff no cost-decresing edge exists. <- so this is a way to check if the spanning tree is the optimal one. 

# Kruskal 

In other words, we order the edges by increasing (non-decreasing) cost, we consider the edges in that order and, at each step, we select the current edge (which is one of the cheapest edges still available) only if it does not create a cycle with the previously selected edges. To determine if the edge creates a cycle, we can just check if the starting or ending node are already in the forest. The algorithm terminates when $n - 1$ edges have been selected.

# Optimal paths with Dijkstra 21-09 

Mainly used for navigation problems. 

Optimal path with Dijkstra in graphs with non-negative arc costs.
A little note: remember that for each node you store the cost of the optimal path and the predecessor of that node in the optimal path.
Remember that the 'labels' of distance are permanent and you need 2 'sets' of nodes to indicate the nodes already discovered or the nodes that will be discovered: the prof called them 'with permanent labels' and 'non permament labels'.

The complexity depends a lot on implementation, but the upper bounds is surely $O(nm)$ where $m$ is the number of edges. It's shown that is $O(n^2)$ . 

We also saw the proof that Dijkstra algorithm always 'choose' the best optimal path. Remember that an edge with negative cost is sufficient to invalidate the algorithm.


# Floyd Marshall algorithm

If the graph contains a circuit of n
egative cost the shortest past problem may not well-defined.
The Floyd / Marshall operation is based on iteratively applying the 'triangular operation' : for each pair of nodes it tries to find another path using less cost .

in particular, the path [2,1,3] is found, replacing the path [2,3] which has fewer edges but is longer (in terms of weight). 

The distance matrix at each iteration of k, with the updated distances in **bold**, will be.

$$d_{iu} + d_{uj} \le d_{ij}$$

It should compute the shortest path from all nodes to all nodes and also find if there is a negative cycle. (it stops if it finds a negative cycle).

To use the algorithm you use a matrix. If on the diagonal there is a negative cost you will immediately stop. 

## DAG  and Dynamic programming

A DAG can be always ordered topologically.  
At each step we delete the node (or one of the nodes if there are more than one node) that has not any edge arriving in it. 


If it's DAG, it's guaranteed to find always at least one node that hasn't any edge arriving in it. So if it's DAG there is always a topological order. 

The shortest path of a DAG? Dynamic programming algorithm.

The dynamic programming is very efficient and it's used every time the solution of the main problem is the sum of the same problem of smaller subsets of the main problem: the best path from 1 to x is the shortest path form 1 to x-1 node that depends on the shortest path form x-2 etc. etc. 

While in a generic graph any node can be the predecessor of any other node. In a DAG, after topologically ordered, the only possible predecessors of a node t have necessary an index smaller that t. 
The constraint of this algorithm so it's to not have any cycle. 

The dynamic programming algorithm for finding shortest/longest paths in DAGs is optimal and exact. 

Any optimal solution is composed by optimal subsolutions. 
Each best path can be divided into two smaller paths: 

- the optimal path from $1$ to $i$  (optimal subsolution)
- the cost between $i$ and $j$ 

Proposed in 1953 by Richard Bellman (1920-1984).
General technique in which an optimal solution, composed of a sequence of elementary decisions, is determined by solving a set of recursive equations.
DP is applicable to any "sequential decision problem" for which the optimality property is satisfied.

Wide range of applications: 

- optimal control (rocket launch)
- equipment maintenance and replacement
- selection of inspection points along a production line

# Project planning

## Gantt Chart 




## Critical path method (CPM)

Overall minimum duration of more activities and the slack (the maximum time the activity can be delayed) of each activity. 





# Flow of a graph

Problems involving the distribution of a given "product" (e.g., water, gas, data, ... ) from a set of "sources" to a set of "users" so as to optimize a given objective function (e.g., amount of product, total cost, ... ). 

## Flow balanced constraint

The flow balance constraints at each intermediate node amount entering is equal to the amount exiting (except obv the source and the destination). 

There is a dual relationship between the minimum capacity problem and maximum flow problem. 

We define: 

- a cut is a collection of arcs 
- the capacity of a cut is the sum of the capacity of each arc (don't look the direction of them)
- the vaIue of the feasible flow through the cut is the sum of the flow of each arc in the cut (look the direction of each flow, consider it negative if it is 'opposite' to the direction of the flow). 


# Ford algorithm 

The **Ford–Fulkerson method** or **Ford–Fulkerson algorithm** (**FFA**) is a greedy and exact algorithm that computes the maximum flow. 
First we have to define: 

- A path is augmenting if:
	- exists a forward arc along the path where the flow is less than the maximum capacity. This means we can pump more flow through. 
	- exists a backward arc along the path where the flow is greater than zero. 


The residual network of a graph is the graph constructed by associating all the possible flow variations of empty edges and not saturated edges. 
Since a network is at maximum flow iff there is no augmenting path in the residual network, the algorithm is based on continuing find an augmenting path at each iteration, until we stop. 

## Question in exercise lesson is what to do in case of capacity over node <- interesting, add it


# Geometry of Linear Programming Problem 

feasible region 

vertices 

moving along each vertex 

canonical form and standard form 

transformations using slack variables

matrix notation and algebra stuff 

### Foundamental theorem of LP 

# Simplex Algorithm 

### Tableu method 



# Example Packet Routing 

With $a_i$ the capacity consumed by $i-$th packet , $c_{i1}$ cost consumed by the $i-$th packet on link 1, $k_1$ and $k_2$ the constraints on each link and $x_i$ decision variables.


$$\begin{array}{cl}
\text{min} \space \sum_{i \in I} c_{i 1} x_i+c_{i 2}\left(1-x_i\right) & \text { (cost) } \\
\sum_{i \in I} a_i x_i \leq k_1 & \text { (capacity 1) } \\
\sum_{i \in I} a_i\left(1-x_i\right) \leq k_2 & \text { (capacity 2) } \\
\quad x_i \in\{0,1\}, i \in I & \text { (binary variables) }
\end{array}$$

We can also 'expand' this formulation obviously for many links. In that case the decision variables will be $x_{ij}$ : set to 1 if packet $i-$th is sent over $j-$th link. 
Also remember to explicit the constraint: $\sum_ j ^ {\text{\# links}} x_ij = 1$ which in case of 2 links was kept 'implicit'.




## Lab: Python MIP

We use Jupyter Notebook e il package per python di MIP. https://www.python-mip.com/ # (Mixed-Integer Linear Programming). 



