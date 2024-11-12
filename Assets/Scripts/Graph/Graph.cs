using System.Collections.Generic;

public class Graph<T>
{
    public List<T> nodeList;
    public Dictionary<T, List<(T, int)>> adjacencyList;
    public Graph()
    {
        nodeList = new List<T>();
        adjacencyList = new Dictionary<T, List<(T, int)>>();
    }
    public void AddNodes(T node)
    {
        if (ReturnNodes(node) == null)
        {
            nodeList.Add(node);
            adjacencyList.Add(node, new List<(T, int)>());
        }
    }
    public T ReturnNodes(T node)
    {
        foreach (var nodes in nodeList)
        {
            if (nodes.Equals(node))
                return nodes;
        }
        return default;
    }
    public void AddConnections(T start, T destination, int travelCost)
    {
        if (!ConnectionsExist(start, destination))
            adjacencyList[ReturnNodes(start)].Add((ReturnNodes(destination), travelCost));
    }
    public bool ConnectionsExist(T start, T destination)
    {
        if (adjacencyList.ContainsKey(start))
        {
            foreach (var node in adjacencyList[start])
                if (node.Item1.Equals(ReturnNodes(destination)))
                   return true;
        }
        return false;
    }
    public int ReturnTravelCost(T start, T destination)
    {
        if (ConnectionsExist(start, destination))
        {
            foreach (var node in adjacencyList[ReturnNodes(start)])
                if (node.Item1.Equals(ReturnNodes(destination)))
                    return node.Item2;
        }
        return -1;
    }
}
