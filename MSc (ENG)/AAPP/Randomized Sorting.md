
# Limits of sorting 

All the sorting algorithms we have seen so far are
comparison sorts :
only use comparisons to determine the relative order of elements.

We can prove this using a decision-tree view of the problem: the tree represents the sorting algorithm and it splits whenever it compares two elements.

![](Pasted%20image%2020221031124020.png)

Some properties about this kind of tree: 

- The tree contains the comparisons along all possible instruction traces
- The running time of the algorithm is the length of the path taken
- Worst-case running time is the height of tree
- Since the leaves are $n!$ because there are $n!$ possible permutations of the initial array and a binary tree has $\le 2^h$ we can solve $n! \le 2^h$ to find $h \ge n \log (n)$ .  

So Heapsort and merge sort are asymptotically optimal comparison sorting algorithms and it's not possible to build better sorting algorithms **based on comparisons**. 
Since Counting Sort is not based on comparison, it can perform better results than others sorting algorithms. It is also stable: it preserves the input order. 


# Quicksort randomized

Since the worst case in $O(n^2)$ , there is a benefit to randomized the original vector. 
Partition around a random pivot $\rightarrow$ reduces the probability to be in the worst cases. 

?? the problem is to have an empty partition ?? <- approfondire


# Radix Sort
**Radix sort** is a non-comparative sorting algorithm: it avoids comparison by sorting on least significant digits first. It is also called **bucket sort** and **digital sort**.
The cool thing about this algorithm is that we can use Counting Sort as the auxiliary stable sort because the limit domain of each sorting (0-9). 
Correctness of Radix Sort proved by induction on digit position. 
Also we can split each word of $b$ in group of digits, so that we can divide a word in $r$ groups. The complexity is $T(n)=\Theta(mn)$ where $n$ is the number of words and $m$ the length of each word. 
In practice, radix sort is fast for **large inputs**, as well as simple to code.  Example on 32 bit numbers:

- At most 3 passes when sorting 2000 numbers
- Merge sort and quicksort do at least 11 passes

# Randomized selection algorithm


In statistics, the _k_th **order statistic** of a statistical sample is equal to its _k_th-smallest value. 
The best-known selection algorithm is [Quickselect](https://en.wikipedia.org/wiki/Quickselect "Quickselect"), which is related to [Quicksort](https://en.wikipedia.org/wiki/Quicksort "Quicksort"); like Quicksort, it has (asymptotically) optimal average performance, but poor worst-case performance, though it can be modified to give optimal worst-case performance as well

Select the
i th smallest of n elements (the element with rank i
Two versions:
•
## Randomized divide and conquer algorithm 

We use a 'randomized divide-and-conquer algorithm that is based on quicksort. We don't do recursive calls to both the partitions of quick-sort but just to the one where we will know there is the i-th element. How do we know where there is the i-th element? Simply remember that in quicksort the position of the pivot after the iteration is the final one, even if the algorithm has not finished! 

![](Pasted%20image%2020221012161039.png)

So we can proceed searching the i-th element recursively without ordering all the array.     
Works fast: linear expected time.
•
Excellent algorithm in practice.

Average case: $\Theta(n)$ but worst case is $\Theta (n^2)$ that is worst than sorting! 


## Deterministic version
 
Group all the elements in group of 5 and find the median of each group. 
Then select as pivot the median of the median group. 

![](Pasted%20image%2020221012171346.png)

Since the work at each level of recursion is a
constant fraction ( 19/20 ) smaller, the work
per level is a geometric series dominated by
the linear work at the root.
•
In practice, this algorithm runs slowly,
because the constant in front of n is large.
•
The randomized algorithm is far more
practical.

$$T(n)=T\left(\frac{1}{5} n\right)+T\left(\frac{3}{4} n\right)+\Theta(n)$$

Since the work at each level of recursion is a
constant fraction ( 19/20 ) smaller, the work
per level is a geometric series dominated by
the linear work at the root.
•
In practice, this algorithm runs slowly,
because the constant in front of n is large.
•
The randomized algorithm is far more
practical.

Developing the recurrence 

1.	Divide the $n$ elements into groups of 5. Find the median of each 5-element group by rote.
2.	**Recursively** select the median $x$ of the medians to be the pivot.
3.	Partition around the pivot $x$.  Let $k = rank(x)$
4. if  $i = k$ then return $x$ else if  repeat step _2_ recursively search the _i-th_ element in the lower or the _(i-k)-th_ element in the upper part