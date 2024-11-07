using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public class GrafoLabyrinth
{
    public Node[,] nodes;

    public GrafoLabyrinth(int[,] map)
    {
        int rows = map.GetLength(0);
        int columns = map.GetLength(1);

        nodes = new Node[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (map[i, j] == 0)
                {
                    nodes[i, j] = new Node(i, j);
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

                    if (j > 0 && map[i, j - 1] == 0)
                        currentNode.AddEdges(nodes[i, j - 1]);

                    if (j < columns - 1 && map[i, j + 1] == 0)
                        currentNode.AddEdges(nodes[i, j + 1]);

                    if (i > 0 && map[i - 1, j] == 0)
                        currentNode.AddEdges(nodes[i - 1, j]);

                    if (i < rows - 1 && map[i + 1, j] == 0)
                        currentNode.AddEdges(nodes[i + 1, j]);
                }
            }
        }
    }
}

