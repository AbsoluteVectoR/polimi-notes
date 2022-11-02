# Amortized Analysis

# Aggregated analysis 

$$\text{amortized cost}=\frac{\text{Total cost}}{\text{number of operations}}$$$$\sum^{}_{operations} \text{amortized cost} \ge\sum^{}_{operations} \text{actual cost} $$
# Accounting analysis 

The concept is that you can 'store' some value during the analysis of the operations. For example an insertion uses a coin and store another coin. And then during the elimination I can consume the coins stored. Obviously all of this is. 

$$\text{amortized cost} = \text{actual cost} + \text{deposits}-\text{withdraws}$$

An example for this could be the **table doubling** 


# Potential analysis

Basically we would like to have a 0 potential energy at the "start" of the data structure. 
Dynamic table -> $\phi = 2(D.num - \frac{D.size}{2})$   so that when the dynamic table is just ''respawned and re-filled" the potential is zero. 
I mean ... we don't want 0 potential when the data structure is empty; we want 0 potential when the data structure has just ' respawned ' .  

First find the potential function then we have to find the amortized cost for each operation

general the amortized cost is actual cost + the difference in potential $\Delta ( \phi)$  

### Binary counter 

The potential function could be the number of 1s. More there are and more you are near the carry. 


