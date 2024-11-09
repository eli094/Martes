//using System;
//using System.Collections.Generic;

//public class GrafoLabyrinth
//{
//    private Dictionary<Node, List<Node>> adjacencyList;

//    public GrafoLabyrinth()
//    {
//        adjacencyList = new Dictionary<Node, List<Node>>();

//        GenerateMaze();
//    }

//    private void GenerateMaze()
//    {
//        int rows = 5;
//        int cols = 5;

//        Node[,] nodes = new Node[rows, cols];

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                nodes[i, j] = new Node(i, j);

//                adjacencyList[nodes[i, j]] = new List<Node>();
//            }
//        }

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < cols; j++)
//            {
//                Node currentNode = nodes[i, j];

//                if (i > 0) adjacencyList[currentNode].Add(nodes[i - 1, j]);
//                if (i < rows - 1) adjacencyList[currentNode].Add(nodes[i + 1, j]);
//                if (j > 0) adjacencyList[currentNode].Add(nodes[i, j - 1]);
//                if (j < cols - 1) adjacencyList[currentNode].Add(nodes[i, j + 1]);
//            }
//        }
//    }

//    public List<Node> GetNodes()
//    {
//        return new List<Node>(adjacencyList.Keys);
//    }

//    public List<Node> GetNeighbors(Node node)
//    {
//        return adjacencyList.ContainsKey(node) ? adjacencyList[node] : new List<Node>();
//    }
//}







