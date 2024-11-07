using System;
using System.Collections.Generic;

public class Node
{
    public int x, y; 

    public List<Node> edges;

    public Node(int x, int y)
    {
        this.x = x;
        this.y = y;

        edges = new List<Node>();
    }

    public void AddEdges(Node edge)
    {
        edges.Add(edge);
    }
}
