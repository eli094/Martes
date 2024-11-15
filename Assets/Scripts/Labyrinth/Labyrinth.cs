using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Labyrinth : MonoBehaviour
{
    public Graph<LabyrinthNode> graph;
    public Stack<LabyrinthNode> posiblePaths;
    public List<LabyrinthNode> nodeListAlreadyExplored;

    public GameObject[] nodePrefabs;
    public GameObject player;

    public LabyrinthNode beginningNode;
    public LabyrinthNode endingNode;

    public int rows = 5;
    public int columns = 6;

    public void Awake()
    {
        graph = new Graph<LabyrinthNode>();
        posiblePaths = new Stack<LabyrinthNode>();
        nodeListAlreadyExplored = new List<LabyrinthNode>();

        NodeValue();
        AddEdges();

        beginningNode = FindNodeByPosition(4,0);
        endingNode = FindNodeByPosition(4,5);

        player.transform.position = new Vector2(0, -4);

    }

    public void NodeValue()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                LabyrinthNode labyrinthNode = new LabyrinthNode(i, j);

                graph.AddNodes(labyrinthNode);
            }
        }
    }

    public void AddEdges()
    {
        AddDualConnectionEdges(FindNodeByPosition(0, 0), FindNodeByPosition (0, 1));
        AddDualConnectionEdges(FindNodeByPosition(0, 0), FindNodeByPosition (1, 0));
        AddDualConnectionEdges(FindNodeByPosition(0, 2), FindNodeByPosition(0, 3));
        AddDualConnectionEdges(FindNodeByPosition(0, 3), FindNodeByPosition(0, 4));

        AddDualConnectionEdges(FindNodeByPosition(1, 1), FindNodeByPosition(0, 1));
        AddDualConnectionEdges(FindNodeByPosition(1, 1), FindNodeByPosition(1, 2));
        AddDualConnectionEdges(FindNodeByPosition(1, 2), FindNodeByPosition(0, 2));
        AddDualConnectionEdges(FindNodeByPosition(1, 2), FindNodeByPosition(1, 3));
        AddDualConnectionEdges(FindNodeByPosition(1, 3), FindNodeByPosition(1, 4));
        AddDualConnectionEdges(FindNodeByPosition(1, 3), FindNodeByPosition(2, 3));
        AddDualConnectionEdges(FindNodeByPosition(1, 5), FindNodeByPosition(0, 5));

        AddDualConnectionEdges(FindNodeByPosition(2, 3), FindNodeByPosition(2, 2));
        AddDualConnectionEdges(FindNodeByPosition(2, 2), FindNodeByPosition(2, 1));
        AddDualConnectionEdges(FindNodeByPosition(2, 1), FindNodeByPosition(3, 1));
        AddDualConnectionEdges(FindNodeByPosition(2, 2), FindNodeByPosition(3, 2));
        AddDualConnectionEdges(FindNodeByPosition(2, 4), FindNodeByPosition(2, 5));
        AddDualConnectionEdges(FindNodeByPosition(2, 5), FindNodeByPosition(1, 5));
        AddDualConnectionEdges(FindNodeByPosition(2, 5), FindNodeByPosition(3, 5));

        AddDualConnectionEdges(FindNodeByPosition(3, 1), FindNodeByPosition(3, 0));
        AddDualConnectionEdges(FindNodeByPosition(3, 0), FindNodeByPosition(2, 0));
        AddDualConnectionEdges(FindNodeByPosition(3, 2), FindNodeByPosition(3, 3));
        AddDualConnectionEdges(FindNodeByPosition(3, 2), FindNodeByPosition(3, 3));
        AddDualConnectionEdges(FindNodeByPosition(3, 2), FindNodeByPosition(4, 2));
        AddDualConnectionEdges(FindNodeByPosition(3, 4), FindNodeByPosition(2, 4));
        AddDualConnectionEdges(FindNodeByPosition(3, 5), FindNodeByPosition(4, 5));

        AddDualConnectionEdges(FindNodeByPosition(4, 2), FindNodeByPosition(4, 1));
        AddDualConnectionEdges(FindNodeByPosition(4, 2), FindNodeByPosition(4, 1));
        AddDualConnectionEdges(FindNodeByPosition(4, 1), FindNodeByPosition(4, 0));
        AddDualConnectionEdges(FindNodeByPosition(4, 2), FindNodeByPosition(4, 3));
        AddDualConnectionEdges(FindNodeByPosition(4, 3), FindNodeByPosition(4, 4));
        AddDualConnectionEdges(FindNodeByPosition(4, 4), FindNodeByPosition(3, 4));

    }

    public void AddDualConnectionEdges(LabyrinthNode go, LabyrinthNode back)
    {
        graph.AddConnections(go, back, 0);
        graph.AddConnections(back, go, 0);
    }

    public LabyrinthNode FindNodeByPosition(int row, int column)
    {
        foreach (var eachNode in graph.nodeList)
        {
            if (eachNode.columns == column && eachNode.rows == row)
            {
                return eachNode;
            }
        }

        return null;
    }

    public void FindExit()
    {
        LabyrinthNode actualNode = beginningNode;

        player.transform.position = new Vector2(actualNode.columns, -actualNode.rows);

        posiblePaths.Push(actualNode);
        nodeListAlreadyExplored.Add(actualNode);

        StartCoroutine(MoveThroughTheMaze(actualNode));
    }

    public IEnumerator MoveThroughTheMaze(LabyrinthNode actualNode)
    {
        while(actualNode != endingNode && posiblePaths.Count > 0)
        {
            actualNode = posiblePaths.Pop();

            Debug.Log(actualNode.rows + " " + actualNode.columns);

            player.transform.position = new Vector2(actualNode.columns, -actualNode.rows);

            LabyrinthNode upNode = FindNodeByPosition(actualNode.rows - 1, actualNode.columns);
            LabyrinthNode downNode = FindNodeByPosition(actualNode.rows + 1, actualNode.columns);

            LabyrinthNode rightNode = FindNodeByPosition(actualNode.rows, actualNode.columns + 1);
            LabyrinthNode leftNode = FindNodeByPosition(actualNode.rows, actualNode.columns - 1);

            if (upNode != null && !nodeListAlreadyExplored.Contains(upNode) && graph.ConnectionsExist(actualNode, upNode))
            {
                posiblePaths.Push(upNode);
                nodeListAlreadyExplored.Add(upNode);
            }

            if (downNode != null && !nodeListAlreadyExplored.Contains(downNode) && graph.ConnectionsExist(actualNode, downNode))
            {
                posiblePaths.Push(downNode);
                nodeListAlreadyExplored.Add(downNode);
            }

            if (rightNode != null && !nodeListAlreadyExplored.Contains(rightNode) && graph.ConnectionsExist(actualNode, rightNode))
            {
                posiblePaths.Push(rightNode);
                nodeListAlreadyExplored.Add(rightNode);
            }

            if (leftNode != null && !nodeListAlreadyExplored.Contains(leftNode) && graph.ConnectionsExist(actualNode, leftNode))
            {
                posiblePaths.Push(leftNode);
                nodeListAlreadyExplored.Add(leftNode);
            }

            yield return new WaitForSeconds(1.5f);
        }

        if (actualNode == endingNode)
        {
            Debug.Log("You have reached the end!");
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            FindExit();
        }
    }
}
