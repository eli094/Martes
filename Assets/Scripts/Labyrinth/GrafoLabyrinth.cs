using System.Collections.Generic;

public class GrafoLabyrinth
{
    private Dictionary<Node, List<Node>> adjacencyList;

    public GrafoLabyrinth(int[,] map)
    {
        adjacencyList = new Dictionary<Node, List<Node>>();

        int rows = map.GetLength(0);
        int columns = map.GetLength(1);

        Node[,] nodes = new Node[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (map[i, j] == 0)
                {
                    Node currentNode = new Node(i, j);

                    nodes[i, j] = currentNode;

                    adjacencyList[currentNode] = new List<Node>();
                }
            }
        }

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (map[i, j] == 0)
                {
                    Node currentNode = nodes[i, j];

                    if (i > 0 && map[i - 1, j] == 0)
                        adjacencyList[currentNode].Add(nodes[i - 1, j]);

                    if (i < rows - 1 && map[i + 1, j] == 0)
                        adjacencyList[currentNode].Add(nodes[i + 1, j]);

                    if (j > 0 && map[i, j - 1] == 0)
                        adjacencyList[currentNode].Add(nodes[i, j - 1]);

                    if (j < columns - 1 && map[i, j + 1] == 0)
                        adjacencyList[currentNode].Add(nodes[i, j + 1]);
                }
            }
        }
    }

    public List<Node> GetNodes()
    {
        List<Node> nodes = new List<Node>(adjacencyList.Keys);
        return nodes;
    }

    public List<Node> GetNeighbors(Node node)
    {
        if (adjacencyList.ContainsKey(node))
        {
            return adjacencyList[node];
        }
        return new List<Node>();
    }
}






