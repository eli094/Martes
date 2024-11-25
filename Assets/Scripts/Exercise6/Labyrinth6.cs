using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Labyrinth6 : MonoBehaviour
{
    public Graph6<LabyrinthNode6> graph;

    public LabyrinthNode6 startingNode;
    public LabyrinthNode6 endingNode;

    public GameObject player;

    public int rows = 12;
    public int columns = 12;

    public TMP_Text solutionText;

    public void Awake()
    {
        graph = new Graph6<LabyrinthNode6>();

        GenerateNodes();
        BuildGraph();
    }

    public void GenerateNodes()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var node = new LabyrinthNode6(i, j);
                graph.AddNode(node);
            }
        }
    }

    public void BuildGraph()
    {
        foreach (var node in graph.nodes)
        {
            int row = node.row;
            int col = node.column;

            if (node.isPassable)
            {
                if (row > 0 && GetNode(row - 1, col).isPassable) graph.AddEdge(node, GetNode(row - 1, col));
                if (row < rows - 1 && GetNode(row + 1, col).isPassable) graph.AddEdge(node, GetNode(row + 1, col));
                if (col > 0 && GetNode(row, col - 1).isPassable) graph.AddEdge(node, GetNode(row, col - 1));
                if (col < columns - 1 && GetNode(row, col + 1).isPassable) graph.AddEdge(node, GetNode(row, col + 1));
            }
        }
    }


    public LabyrinthNode6 GetNode(int row, int col)
    {
        foreach (var node in graph.nodes)
        {
            if (node.row == row && node.column == col)
                return node;
        }
        return null;
    }

    public bool HasSolution()
    {
        if (startingNode == null || endingNode == null) return false;

        Stack<LabyrinthNode6> stack = new Stack<LabyrinthNode6>();
        HashSet<LabyrinthNode6> visited = new HashSet<LabyrinthNode6>();

        stack.Push(startingNode);

        while (stack.Count > 0)
        {
            var currentNode = stack.Pop();
            if (currentNode == endingNode) return true;

            visited.Add(currentNode);
            foreach (var neighbor in graph.adjacencyList[currentNode])
            {
                if (!visited.Contains(neighbor) && neighbor.isPassable)
                    stack.Push(neighbor);
            }
        }

        return false;
    }


    public void Update()
    {
    if (HasSolution())
        solutionText.text = "Labyrinth solved!";
    else
        solutionText.text = "It does not have a solution.";
    }

}

