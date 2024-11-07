using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public class Search
{
    public static List<Node> FindPath(Node beginning, Node end)
    {
        Queue<Node> queue = new Queue<Node>();
       
        Dictionary<Node, Node> parents = new Dictionary<Node, Node>();

        List<Node> path = new List<Node>();

        queue.Enqueue(beginning);

        parents[beginning] = null;

        while (queue.Count > 0)
        {
            Node currentNode = queue.Dequeue();

            if (currentNode == end)
            {
                Node node = end;

                while (node != null)
                {
                    path.Insert(0, node);

                    node = parents[node];
                }

                return path;
            }

            foreach (Node edge in currentNode.edges)
            {
                if (!parents.ContainsKey(edge))
                {
                    queue.Enqueue(edge);

                    parents[edge] = currentNode;
                }
            }
        }

        return null;
    }
}

