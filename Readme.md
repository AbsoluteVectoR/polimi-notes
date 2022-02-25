# A* algorithm visualization in Java 

A* search algorithm written in Java with Processing graphic library.  Note that this program is not intend to have optimal performance, it's just a personal exercise to visualize the algorithm. 

#### Functions overview 
```Java
public void settings()
public void setup() //Processing function, the first that is called
public void setupgrid() //makes the grid
public void drawgrid() //draws the grid
public void mousePressed() //Processing function used to determine when mouse is pressed
public void Astar() //the search algorithm
public float heuristic() //the Heuristic function used by the algorithm
public void draw() //Processing function used to update the screen
public void drawpath() //it draws the path starting from the Target node and backtracking all the predecessors
```
#### Changing the settings
```Java
public void settings() {  
    w = 800;  
    h = 800;  
    SizeNode = 10;  
    bgcolor = new Color(0x03045e);  
    obstaclecolor = new Color(0x0077b6);  
    linecolor = new Color(0xcaf0f8);  
    size(w,h);  
}
```
You can easily change the dimensions of the window, the size of the nodes (smaller nodes = slower program) and the color palette. 


#### You need the Processing library 
![[Just download from here](https://processing.org/download)] and remember to import it in your IDE. For example in Intellij Idea, select and add the folder 'processing/core/library' in Project Structure/Project Settings/Libraries from the editor.
