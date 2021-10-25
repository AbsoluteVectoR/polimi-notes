import processing.core.PApplet;

public class MainClass extends PApplet {
    public static void main(String[] args) {
        PApplet.main("MainClass",args);
    }

    public void settings() {
        size(800,800);
    }

    Node[][] grid;

    public void draw(){
        background(110,136,152);
        for (int x=0;x<40;x++) {
            for (int y = 0; y < 40; y++) {
                noStroke();
                if(random(0,1) >0.54)grid[x][y].free = false;
                if(grid[x][y].free)fill(159, 177, 188);
                else fill(0,0,0);
                circle(grid[x][y].x*20 + 10, grid[x][y].y*20 + 10, 20);
            }
            if(x==39) noLoop();
        }

    }

    public void setup(){
        setupgrid();
    }

    public void setupgrid(){
        grid = new Node[40][40];
        for(int x = 0; x<40;x++){
            for(int y = 0; y<40;y++){
                grid[x][y] = new Node(x,y,true, Integer.MAX_VALUE);
            }
        }
    }


    /*
    1) node generation
    2) is it a goal node? is it in the closed list?
    3) expand

    I will use the euclidean distance as h(n).
    I will use a min-heap to always select the node with f(n) lower.
    I will calculate f(n) when I expand the nodes.. when I expand the node I will make
    current node + cost to reach the node + euclidian distance.
    And I will put everything in a min heap.

    each node is a class that contains the distance and if is it visited. If is it visited I will not add him in the queue.
    is it necessary to remove stuff from the queue? maybe only when the first min heap has the closed list bool set to true.

     */
}
