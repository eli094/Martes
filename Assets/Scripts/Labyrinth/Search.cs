//using System;
//using System.Collections.Generic;

//public class Search
//{
//    public static List<Node> FindPath(Node start, Node end, GrafoLabyrinth grafo)
//    {
//        Queue<Node> queue = new Queue<Node>();

//        Dictionary<Node, Node> parents = new Dictionary<Node, Node>();

//        List<Node> path = new List<Node>();

//        queue.Enqueue(start);

//        parents[start] = null;

//        while (queue.Count > 0)
//        {
//            Node currentNode = queue.Dequeue();

//            if (currentNode == end)
//            {
//                Node node = end;

//                while (node != null)
//                {
//                    path.Insert(0, node);

//                    node = parents[node];
//                }

//                return path;
//            }

//            foreach (Node neighbor in grafo.GetNeighbors(currentNode))
//            {
//                if (!parents.ContainsKey(neighbor))
//                {
//                    queue.Enqueue(neighbor);

//                    parents[neighbor] = currentNode;
//                }
//            }
//        }

//        return null;
//    }
//}


