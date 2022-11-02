# Randomized data structures 


# Disjoint sets 

Disjoint sets is a data structure very useful for operations on graphs. 
A collection of a set of objects where there are not intersections between sets. 
each set is identified by a representative

a representative is some member of the set (often it often does not matter which element is the representative irrelevant).

A couple of operations over the disjoint sets:
````C
make(x);
union(x,y);
find-set(x);

````

A possible way to implement it is using linked list, but the union will not be very efficient O(n^2) while make and find-set in O(1)




A more efficient way is using 'forests' : rooted trees, where each tree is a set. 
It resolves the problem with the union but change find-set to O(height of x's tree) and this is bad. 
Let's solve it with these 2 optimizations: 

Union by Rank: Each node is associated with a rank,
which is the upper bound on the height of the node
(i.e., the height of subtree rooted at the node), then
when UNION, let the root with smaller rank point to
the root with larger rank.

Path Compression: used in FIND SET( x ) operation,
make each node in the path from x to the root
directly point to the root. Thus reduce the tree
height. ???

Worst case running time for
m MAKE SET, UNION, FIND SET operations is:
O
m  n )) where  n  4. So nearly linear in m


Disjoint-set data structures model the partitioning of a set, for example to keep track of the connected components "Connected component (graph theory)") of an undirected graph. This model can then be used to determine whether two vertices belong to the same component, or whether adding an edge between them would result in a cycle. The Union–Find algorithm is used in high-performance implementations of unification "Unification (computer science)").
This data structure is used by the Boost Graph Library to implement its Incremental Connected Components functionality. It is also a key component in implementing Kruskal's algorithm to find the minimum spanning tree of a graph.
Note that the regular implementation as disjoint-set forests does not allow the deletion of edges, even without path compression or the rank heuristic. However, there exist modern implementations that allow for constant-time deletion.
Sharir and Agarwal report connections between the worst-case behavior of disjoint-sets and the length of Davenport–Schinzel sequences, a combinatorial structure from computational geometry.[18

[random maze generation challenge](random%20maze%20generation%20challenge.md) 

## Treaps 

Treaps are binary trees where each child has a greater priority to his parent, like max heap. To do this, each element $x$ is assigned a priority chosen uniformly at random before the insertion.
With this magic trick, Treaps achieve essentially the same time bounds of balanced trees without requiring any explicit balance information. Also the expected number of rotations performed is smaller (an average of 2 rotations for each operation) than other self-balanced data structures. Also they are very simple to implement compared to AVL or RB trees for example.  If $n$ elements are inserted in random order into a binary search tree, the expected depth is always $1.39 log(n)$. 
Explained in spaghettata mode: I have a binary tree (so very good to search) but I have always the problem to balance it. So I assign to each key a random priority and then I consider my tree not only as a tree but also as a heap and I want to preserve the property of the heap using rotations. Note that the heap can be min heap or max heap without problems. 

## Skip Lists 

Skip lists similar benefits to Treaps but are based on an alternative randomized data structure. 
The starting point is a sorted linked list, a dynamic structure with $O(n)$ for search elements.
The next step is adding a second sorted linked list shorter to 'skip' some elements of the list.


![](Pasted%20image%2020221019124724.png)

Let's expand the idea further: 

![](Pasted%20image%2020221019125724.png)


How we decide to promote an element to upper level? Randomly.

Randomize the probability to 'promote' elements. 




