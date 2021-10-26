import processing.awt.PShapeJava2D;

import javax.management.ObjectInstance;

public class Node {
    final public int x;
    final public int y;
    public boolean free;
    public float cost;

    public Node(int x,int y,boolean free, float cost) {
        this.x = x;
        this.y = y;
        this.free = free;
        this.cost = cost;
    }

    public boolean equals(Node o){
        if(o.x == this.x && o.y == this.y)return true;
        else return false;
    }
}
