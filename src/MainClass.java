import processing.core.PApplet;
import java.util.*;

public class MainClass extends PApplet {
    public static void main(String[] args) {
        PApplet.main("MainClass",args);
    }

    final int w = 800;
    final int h = 800;
    final int SizeNode = 12;
    Node[][] grid;
    Node target;
    Node start;
    Node current;
    PriorityQueue<Node> OpenSet;
    boolean finished = false;
    public void settings() {
        size(w,h);
    }



    public void draw(){
        if(start!=null && target!=null){
            drawpath();
        }
    }

    public void drawpath(){
    if(current.predecessor!=null){
        if(finished) {
            stroke(233,203,142);
            strokeWeight(SizeNode/2f);
        }else{ stroke(233,203,142,5);
        strokeWeight(SizeNode/2f);}
        line(current.x*SizeNode + SizeNode/2f,current.y*SizeNode+SizeNode/2f,current.predecessor.x*SizeNode+SizeNode/2,current.predecessor.y*SizeNode+SizeNode/2);
        current = current.predecessor;
    }
    }

    public void mousePressed(){
        if (start==null||target==null){
            fill(233,203,142);
            circle((mouseX/SizeNode)*SizeNode + SizeNode/2, mouseY/SizeNode*SizeNode + SizeNode/2, SizeNode);
            if (start == null) {
                start = grid[mouseX / SizeNode][mouseY / SizeNode];
                start.cost = 0;
                println("registered start");
            } else if (target == null) {
                if (!grid[mouseX / SizeNode][mouseY / SizeNode].equals(start)){
                    target = grid[mouseX / SizeNode][mouseY / SizeNode];
                    println("registered target");
                    OpenSet = new PriorityQueue<Node>();
                    start.cost = 0.0f + heuristic(start, target);
                    OpenSet.add(start);
                    Astar(start,target);
                }
            }
        }


    }

    public void setup(){
        setupgrid();
        drawgrid(true);
    }


    public void Astar(Node s, Node t){
        while(!finished) {
            Node expanded;
            current = OpenSet.poll();
            if (!finished) {
                //expansion
                if (current.x - 1 > 0) {
                    expanded = grid[current.x - 1][current.y];
                    if(expanded.equals(t)){finished=true;expanded.predecessor=current;current=expanded;}
                    if (expanded.free && !expanded.visited&& !finished) {
                        expanded.cost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 1;
                        expanded.predecessor=current;
                        OpenSet.add(grid[current.x - 1][current.y]);
                    }
                }
                if (current.x + 1 < w / SizeNode && !finished) {
                    expanded = grid[current.x + 1][current.y];
                    if(expanded.equals(t)){finished=true;expanded.predecessor=current;current=expanded;}
                    if (expanded.free && !expanded.visited&& !finished) {
                        expanded.cost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 1;
                        expanded.predecessor=current;
                        OpenSet.add(expanded);
                    }
                }
                if (current.y + 1 < h / SizeNode&& !finished) {
                    expanded = grid[current.x][current.y + 1];
                    if(expanded.equals(t)){finished=true;expanded.predecessor=current;current=expanded;}
                    if (expanded.free && !expanded.visited&& !finished) {
                        expanded.cost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 1;
                        expanded.predecessor=current;
                        OpenSet.add(expanded);
                    }
                }
                if (current.y - 1 > 0&& !finished) {
                    expanded = grid[current.x][current.y - 1];
                    if(expanded.equals(t)){finished=true;expanded.predecessor=current;current=expanded;}
                    if (expanded.free && !expanded.visited&& !finished) {
                        expanded.cost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 1;
                        expanded.predecessor=current;
                        OpenSet.add(expanded);
                    }
                }
                if (current.y - 1 > 0 & current.x + 1 < w / SizeNode&& !finished) {
                    expanded = grid[current.x + 1][current.y - 1];
                    if(expanded.equals(t)){finished=true;expanded.predecessor=current;current=expanded;}
                    if (expanded.free && !expanded.visited&& !finished) {
                        expanded.cost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 1.42f;
                        expanded.predecessor=current;
                        OpenSet.add(expanded);
                    }
                }
                if (current.y - 1 > 0 & current.x - 1 > 0&& !finished) {
                    expanded = grid[current.x - 1][current.y - 1];
                    if(expanded.equals(t)){finished=true;expanded.predecessor=current;current=expanded;}
                    if (expanded.free && !expanded.visited&& !finished) {
                        expanded.cost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 1.42f;
                        expanded.predecessor=current;
                        OpenSet.add(expanded);
                    }
                }
                if (current.y + 1 < h / SizeNode & current.x - 1 > 0 && !finished) {
                    expanded = grid[current.x - 1][current.y + 1];
                    if(expanded.equals(t)){finished=true;expanded.predecessor=current;current=expanded;}
                    if (expanded.free && !expanded.visited && !finished) {
                        expanded.cost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 1.42f;
                        expanded.predecessor=current;
                        OpenSet.add(expanded);
                    }
                }
                if (current.y + 1 < h / SizeNode & current.x + 1 < w / SizeNode && !finished) {
                    expanded = grid[current.x + 1][current.y + 1];
                    if(expanded.equals(t)){finished=true;expanded.predecessor=current;current=expanded;}
                    if (expanded.free && !expanded.visited && !finished) {
                        expanded.cost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 1.42f;
                        expanded.predecessor=current;
                        OpenSet.add(expanded);
                    }
                }

                current.visited = true;

            } else {
                finished=true;
            }
        }
    }

    public float heuristic(Node a,Node b){
        //return SizeNode*sqrt(pow(a.x* -b.x,2)+pow(a.y-b.y,2)); //euclidean distance
        return abs(a.x - b.x) + abs(a.y - b.y) - min(abs(a.x - b.x),abs(a.y - b.y))*1.41f; //octile distance
        //return abs(a.x-b.x + a.y-b.y); //manhattan distance
    }


    public void drawgrid(boolean init){
        if(init){
            background(102,40,12);
            for (int x = 0; x < w / SizeNode; x++) {
                for (int y = 0; y < h / SizeNode; y++) {
                    noStroke();
                    if (random(0, 1) > 0.54) grid[x][y].free = false;
                    if (grid[x][y].free) fill(102,40,12);
                    else fill(255,90,0);
                    circle(grid[x][y].x * SizeNode + SizeNode / 2, grid[x][y].y * SizeNode + SizeNode / 2, SizeNode);
                }
            }
        }else{
            for (int x = 0; x < w / SizeNode; x++) {
                for (int y = 0; y < h / SizeNode; y++) {
                    noStroke();
                    if(grid[x][y].visited){fill(233,203,142,1);
                    circle(grid[x][y].x * SizeNode + SizeNode / 2, grid[x][y].y * SizeNode + SizeNode / 2, SizeNode);
                }}
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
