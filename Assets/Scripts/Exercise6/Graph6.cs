using System.Collections.Generic;

public class Graph6<T>
{
    public List<T> nodes;
    public Dictionary<T, List<T>> adjacencyList;

    public Graph6()
    {
        nodes = new List<T>();
        adjacencyList = new Dictionary<T, List<T>>();
    }

    public void AddNode(T node)
    {
        nodes.Add(node);
        adjacencyList[node] = new List<T>();
    }

    public void AddEdge(T from, T to)
    {
        if (adjacencyList.ContainsKey(from))
            adjacencyList[from].Add(to);
    }

    public bool AreConnected(T from, T to)
    {
        return adjacencyList.ContainsKey(from) && adjacencyList[from].Contains(to);
    }
}

