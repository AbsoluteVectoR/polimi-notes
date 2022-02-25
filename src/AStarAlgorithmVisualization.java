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
        SizeNode = 15;
        bgcolor = new Color(0xFF08001A, true);
        obstaclecolor = new Color(0x7171FF);
        linecolor = new Color(0xFFD500);
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
                grid[x][y] = new Node(x,y,true, MAX_INT);
            }
        }
    }

    public void drawgrid(){
        background(bgcolor.getRGB());
        for (int x = 0; x < w / SizeNode; x++) {
            for (int y = 0; y < h / SizeNode; y++) {
                noStroke();
                if (random(0, 1) > 0.51f) grid[x][y].free = false;
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
        start.cost = 0 + heuristic(start, target);
        OpenSet.add(start);
        Node expanded;
        while(!OpenSet.isEmpty()){
                current = OpenSet.poll();
                if (current.equals(t)){
                    finished = true;
                    current.visited=true;
                    break;
                }
                if(!current.visited){
                    if (current.x > 0) {
                        expanded = grid[current.x - 1][current.y];
                        if(expanded.free && !finished){
                            int tentativecost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 10;
                            if (expanded.cost > tentativecost){
                                expanded.cost = tentativecost;
                                expanded.predecessor = current;
                                if(OpenSet.contains(grid[current.x - 1][current.y]))OpenSet.remove(grid[current.x - 1][current.y]);
                                OpenSet.add(grid[current.x - 1][current.y]);
                            }
                        }
                    }
                    if (current.x + 1 < w / SizeNode && !finished) {
                        expanded = grid[current.x + 1][current.y];
                        if (expanded.free && !finished) {
                            int tentativecost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 10;
                            if (expanded.cost > tentativecost) {
                                expanded.cost = tentativecost;
                                expanded.predecessor = current;
                                if(OpenSet.contains(grid[current.x + 1][current.y]))OpenSet.remove(grid[current.x + 1][current.y]);
                                OpenSet.add(grid[current.x + 1][current.y]);
                            }
                        }
                    }
                    if (current.y + 1 < h / SizeNode && !finished){
                        expanded = grid[current.x][current.y + 1];
                        if (expanded.free && !finished) {
                            int tentativecost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 10;
                            if (expanded.cost > tentativecost) {
                                expanded.cost = tentativecost;
                                expanded.predecessor = current;
                                if(OpenSet.contains(grid[current.x][current.y + 1]))OpenSet.remove(grid[current.x][current.y + 1]);
                                OpenSet.add(grid[current.x][current.y + 1]);
                            }
                        }
                    }
                    if (current.y > 0 && !finished) {
                        expanded = grid[current.x][current.y - 1];
                        if (expanded.free && !finished) {
                            int tentativecost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 10;
                            if (expanded.cost > tentativecost) {
                                expanded.cost = tentativecost;
                                expanded.predecessor = current;
                                if(OpenSet.contains(grid[current.x][current.y - 1]))OpenSet.remove(grid[current.x][current.y - 1]);
                                OpenSet.add(grid[current.x][current.y - 1]);
                            }
                        }
                    }
                    if (current.y > 0 & current.x + 1 < w / SizeNode && !finished) {
                        expanded = grid[current.x + 1][current.y - 1];
                        if (expanded.free && !finished) {
                            int tentativecost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 14;
                            if (expanded.cost > tentativecost) {
                                expanded.cost = tentativecost;
                                expanded.predecessor = current;
                                if(OpenSet.contains(grid[current.x + 1][current.y - 1]))OpenSet.remove(grid[current.x + 1][current.y - 1]);
                                OpenSet.add(grid[current.x + 1][current.y - 1]);
                            }
                        }
                    }
                    if (current.y > 0 & current.x > 0 && !finished) {
                        expanded = grid[current.x - 1][current.y - 1];
                        if (expanded.free && !finished) {
                            int tentativecost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 14;
                            if (expanded.cost > tentativecost) {
                                expanded.cost = tentativecost;
                                expanded.predecessor = current;
                                if(OpenSet.contains(grid[current.x - 1][current.y - 1]))OpenSet.remove(grid[current.x - 1][current.y - 1]);
                                OpenSet.add(grid[current.x - 1][current.y - 1]);
                            }
                        }
                    }
                    if (current.y + 1 < h / SizeNode & current.x > 0 && !finished) {
                        expanded = grid[current.x - 1][current.y + 1];
                        if (expanded.free && !finished) {
                            int tentativecost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 14;
                            if (expanded.cost > tentativecost) {
                                expanded.cost = tentativecost;
                                expanded.predecessor = current;
                                if(OpenSet.contains(grid[current.x - 1][current.y + 1]))OpenSet.remove(grid[current.x - 1][current.y + 1]);
                                OpenSet.add(grid[current.x - 1][current.y + 1]);
                            }
                        }
                    }
                    if (current.y + 1 < h / SizeNode & current.x + 1 < w / SizeNode && !finished) {
                        expanded = grid[current.x + 1][current.y + 1];
                        if (expanded.free && !finished) {
                            int tentativecost = current.cost - heuristic(current, t) + heuristic(expanded, t) + 14;
                            if (expanded.cost > tentativecost){
                                expanded.cost = tentativecost;
                                expanded.predecessor = current;
                                if(OpenSet.contains(grid[current.x + 1][current.y + 1]))OpenSet.remove(grid[current.x + 1][current.y + 1]);
                                OpenSet.add(grid[current.x + 1][current.y + 1]);
                            }
                        }
                    }
                    current.visited = true;
                }
        }
        if(!finished){
                println("Path doesn't exist.");
        }
    }

    public int heuristic(Node a,Node b){
        //Octile distance, variant of Diagonal Distance
        int dx = abs(a.x - b.x);
        int dy = abs(a.y - b.y);
        return max(dx,dy)  + 4*min(dx,dy); //the 4 derives from (14-10) where 14 is the Diagonal Cost and 10 the 'normal cost'
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
