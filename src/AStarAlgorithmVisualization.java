import processing.core.PApplet;

import java.awt.*;
import java.util.*;

public class AStarAlgorithmVisualization extends PApplet {
    public static void main(String[] args) {
        PApplet.main("AStarAlgorithmVisualization",args);
    }
    int w;
    int h;
    int SizeNode;
    Node[][] grid;
    Node target;
    Node start;
    Node current;
    PriorityQueue<Node> OpenSet;
    boolean finished;
    Color bgcolor;
    Color obstaclecolor;
    Color linecolor;

    public void settings() {
        w = 800;
        h = 800;
        SizeNode = 10;
        bgcolor = new Color(0x03045e);
        obstaclecolor = new Color(0x0077b6);
        linecolor = new Color(0xcaf0f8);
        size(w,h);
    }

    public void setup(){
        start=null;
        target=null;
        finished = false;
        setupgrid();
        drawgrid();
    }

    public void setupgrid(){
        grid = new Node[w/SizeNode][h/SizeNode];
        for(int x = 0; x<w/SizeNode;x++){
            for(int y = 0; y<h/SizeNode;y++){
                grid[x][y] = new Node(x,y,true, Integer.MAX_VALUE);
            }
        }
    }

    public void drawgrid(){
        background(bgcolor.getRGB());
        for (int x = 0; x < w / SizeNode; x++) {
            for (int y = 0; y < h / SizeNode; y++) {
                noStroke();
                if (random(0, 1) > 0.54) grid[x][y].free = false;
                if (grid[x][y].free) fill(bgcolor.getRGB());
                else fill(obstaclecolor.getRGB());
                circle(grid[x][y].x * SizeNode + SizeNode / 2, grid[x][y].y * SizeNode + SizeNode / 2, SizeNode);
            }
        }
    }

    //mouse event function used to select start and target node and to refresh grid
    public void mousePressed(){
        if ((start==null||target==null)&&(grid[mouseX / SizeNode][mouseY / SizeNode].free)){ //second condition to not select obstacle node
            fill(linecolor.getRGB());
            circle((mouseX/SizeNode)*SizeNode + SizeNode/2, mouseY/SizeNode*SizeNode + SizeNode/2, SizeNode);
            if (start == null) {
                start = grid[mouseX / SizeNode][mouseY / SizeNode];
                start.cost = 0;
                println("registered start");
            }
            else if (target == null){
                if (!grid[mouseX / SizeNode][mouseY / SizeNode].equals(start)){
                    target = grid[mouseX / SizeNode][mouseY / SizeNode];
                    println("registered target");
                    Astar(start,target); //start the pathfinder
                }
            }
        }
        else if((start!=null)&&target!=null){ //refresh grid
            setup();
        }
    }

    public void Astar(Node s, Node t){
        OpenSet = new PriorityQueue<Node>();
        start.cost = 0.0f + heuristic(start, target);
        OpenSet.add(start);
        Node expanded;
        while(!finished){
            if (!OpenSet.isEmpty() && !finished) {
                current = OpenSet.poll();
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
            }else{
                println("Path doesn't exist.");
                break;
            }
        }
    }

    public float heuristic(Node a,Node b){
        return abs(a.x - b.x) + abs(a.y - b.y) - min(abs(a.x - b.x),abs(a.y - b.y))*1.4f; //octile distance
        //return SizeNode*sqrt(pow(a.x* -b.x,2)+pow(a.y-b.y,2)); //euclidean distance
        //return abs(a.x-b.x + a.y-b.y); //manhattan distance
    }

    public void draw(){
        if(start!=null && target!=null && finished){
            drawpath();
        }
    }

    public void drawpath(){
        if(current.predecessor!=null){
            stroke(linecolor.getRGB());
            strokeWeight(SizeNode/2f);
            line(current.x*SizeNode + SizeNode/2f,current.y*SizeNode+SizeNode/2f,current.predecessor.x*SizeNode+SizeNode/2,current.predecessor.y*SizeNode+SizeNode/2);
            current = current.predecessor;
        }
    }
}
