import processing.core.PApplet;

public class MainClass extends PApplet {
    public static void main(String[] args) {
        PApplet.main("MainClass",args);
    }

    final int w = 800;
    final int h = 800;
    final int SizeNode = 100;
    Node[][] grid;
    Node target;
    Node start;

    public void settings() {
        size(w,h);

    }



    public void draw(){

    }

    public void mousePressed(){
        if (start==null||target==null){
            fill(226, 192, 60);
            circle((mouseX/SizeNode)*SizeNode + SizeNode/2, mouseY/SizeNode*SizeNode + SizeNode/2, SizeNode);
            if (start == null) {
                start = grid[mouseX / SizeNode][mouseY / SizeNode];
                println("registered start");
            } else if (target == null) {
                if (!grid[mouseX / SizeNode][mouseY / SizeNode].equals(start)){
                    target = grid[mouseX / SizeNode][mouseY / SizeNode];
                    println("registered target");
                    Astar(start,target);
                }
            }
        }
    }

    public void setup(){
        setupgrid();
        drawgrid();
    }


    public void Astar(Node Start, Node Target){

    }

    public void drawgrid(){
        background(110,136,152);
        for (int x=0;x<w/SizeNode;x++) {
            for (int y = 0; y < h/SizeNode; y++) {
                noStroke();
                if(random(0,1) >0.54)grid[x][y].free = false;
                if(grid[x][y].free)fill(159, 177, 188);
                else fill(0,0,0);
                circle(grid[x][y].x*SizeNode + SizeNode/2, grid[x][y].y*SizeNode + SizeNode/2, SizeNode);
            }
        }
    }

    public void setupgrid(){
        grid = new Node[w/SizeNode][h/SizeNode];
        for(int x = 0; x<w/SizeNode;x++){
            for(int y = 0; y<h/SizeNode;y++){
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
