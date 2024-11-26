using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LabyrinthManager : MonoBehaviour
{
    public static LabyrinthManager instance;

    public Graph<LabyrinthNode> labyrinthNodeGraph;
    public Stack<LabyrinthNode> posiblePaths = new Stack<LabyrinthNode>();
    public List<LabyrinthNode> nodeListAlreadyExplored = new List<LabyrinthNode>();

    public NodePrefab[,] nodePrefabArray;
    public NodePrefab nodePrefab;
    public NodePrefab selectedNode;

    public int Row = 11;
    public int Column = 11;

    public LayerMask nodeLayerMask;

    public LabyrinthNode beginningNode;
    public LabyrinthNode endingNode;

    [SerializeField] private GameObject player;

    [SerializeField] private TextMeshProUGUI solutionText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        labyrinthNodeGraph = new Graph<LabyrinthNode>();

        nodePrefabArray = new NodePrefab[Row, Column];

        nodeSpawn();

        solutionText.text = "Please set the start and end points.";
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleNodeSelection();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) SetStart();
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetEnd();
        if (Input.GetKeyDown(KeyCode.Alpha3)) SetFloor();
        if (Input.GetKeyDown(KeyCode.Alpha4)) SetWall();

        if (Input.GetKeyDown(KeyCode.Return))
        {
            FindExit();
        }
    }

    private void nodeSpawn()
    {
        for (int i = 0; i < Row; i++)
        {
            for (int j = 0; j < Column; j++)
            {
                NodePrefab nodePrefabs = Instantiate(nodePrefab);

                nodePrefabs.CreateCube(i, j, labyrinthNodeGraph);
                nodePrefabs.transform.position = new Vector2(j, -i);

                nodePrefabArray[i, j] = nodePrefabs;
            }
        }

        for (int i = 0; i < Row; i++)
        {
            for (int j = 0; j < Column; j++)
            {
                nodePrefabArray[i, j].AddNextConnection();
            }
        }
    }

    private void HandleNodeSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000, nodeLayerMask))
        {
            Debug.Log(hit.transform.gameObject.name);

            if (hit.collider != null && hit.collider.CompareTag("Node"))
            {
                selectedNode = hit.collider.GetComponent<NodePrefab>();
            }
        }
    }

    public void SetStart()
    {
        if (selectedNode != null)
        {
            selectedNode.labyrinthCubes.color = Color.blue; // Blue for Beginning.
            selectedNode.isWall = false;

            beginningNode = selectedNode.labyrinthNode;
        }

        UpdateSolutionText();
    }

    public void SetEnd()
    {
        if (selectedNode != null)
        {
            selectedNode.labyrinthCubes.color = Color.red; // Red for Ending.
            selectedNode.isWall = false;
            endingNode = selectedNode.labyrinthNode;
        }

        UpdateSolutionText();
    }

    public void SetFloor()
    {
        if (selectedNode != null)
        {
            selectedNode.labyrinthCubes.color = Color.white; // White for Floor.
            selectedNode.isWall = false;
        }

        UpdateSolutionText();
    }

    public void SetWall()
    {
        if (selectedNode != null)
        {
            selectedNode.labyrinthCubes.color = Color.black; // Black for Wall.
            selectedNode.isWall = true;
        }

        UpdateSolutionText();
    }

    private void UpdateSolutionText()
    {
        if (beginningNode == null || endingNode == null)
        {
            solutionText.text = "Please set both start and end points.";
        }
        else
        {
            if (CheckPathExists(beginningNode, endingNode))
            {
                solutionText.text = "The labyrinth is solvable.";
            }
            else
            {
                solutionText.text = "The labyrinth is not solvable.";
            }
        }
    }

    private bool CheckPathExists(LabyrinthNode startNode, LabyrinthNode endNode)
    {
        HashSet<LabyrinthNode> visited = new HashSet<LabyrinthNode>();
        Queue<LabyrinthNode> queue = new Queue<LabyrinthNode>();

        queue.Enqueue(startNode);
        visited.Add(startNode);

        while (queue.Count > 0)
        {
            LabyrinthNode currentNode = queue.Dequeue();

            if (currentNode == endNode)
            {
                return true;
            }

            foreach (var neighbor in GetValidNeighbors(currentNode))
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }

        return false;
    }

    private IEnumerable<LabyrinthNode> GetValidNeighbors(LabyrinthNode node)
    {
        LabyrinthNode upNode = FindNodeByPosition(node.rows - 1, node.columns);
        LabyrinthNode downNode = FindNodeByPosition(node.rows + 1, node.columns);
        LabyrinthNode rightNode = FindNodeByPosition(node.rows, node.columns + 1);
        LabyrinthNode leftNode = FindNodeByPosition(node.rows, node.columns - 1);

        if (upNode != null && !nodePrefabArray[upNode.rows, upNode.columns].isWall)
            yield return upNode;
        if (downNode != null && !nodePrefabArray[downNode.rows, downNode.columns].isWall)
            yield return downNode;
        if (rightNode != null && !nodePrefabArray[rightNode.rows, rightNode.columns].isWall)
            yield return rightNode;
        if (leftNode != null && !nodePrefabArray[leftNode.rows, leftNode.columns].isWall)
            yield return leftNode;
    }

    public IEnumerator MoveThroughTheMaze(LabyrinthNode actualNode)
    {
        while (actualNode != endingNode && posiblePaths.Count > 0)
        {
            actualNode = posiblePaths.Pop();

            Debug.Log(actualNode.rows + " " + actualNode.columns);

            player.transform.position = new Vector2(actualNode.columns, -actualNode.rows);

            NodePrefab nodePrefab = LabyrinthManager.instance.nodePrefabArray[actualNode.rows, actualNode.columns];

            bool isValidNode(LabyrinthNode node)
            {
                if (node == null)
                    return false;

                NodePrefab nodePrefab = LabyrinthManager.instance.nodePrefabArray[node.rows, node.columns];

                return !nodePrefab.isWall && !nodeListAlreadyExplored.Contains(node);
            }

            LabyrinthNode upNode = FindNodeByPosition(actualNode.rows - 1, actualNode.columns);
            LabyrinthNode downNode = FindNodeByPosition(actualNode.rows + 1, actualNode.columns);
            LabyrinthNode rightNode = FindNodeByPosition(actualNode.rows, actualNode.columns + 1);
            LabyrinthNode leftNode = FindNodeByPosition(actualNode.rows, actualNode.columns - 1);

            if (isValidNode(upNode) && labyrinthNodeGraph.ConnectionsExist(actualNode, upNode) && !nodePrefabArray[upNode.rows, upNode.columns].isWall)
            {
                posiblePaths.Push(upNode);
                nodeListAlreadyExplored.Add(upNode);
            }

            if (isValidNode(downNode) && labyrinthNodeGraph.ConnectionsExist(actualNode, downNode) && !nodePrefabArray[downNode.rows, downNode.columns].isWall)
            {
                posiblePaths.Push(downNode);
                nodeListAlreadyExplored.Add(downNode);
            }

            if (isValidNode(rightNode) && labyrinthNodeGraph.ConnectionsExist(actualNode, rightNode) && !nodePrefabArray[rightNode.rows, rightNode.columns].isWall)
            {
                posiblePaths.Push(rightNode);
                nodeListAlreadyExplored.Add(rightNode);
            }

            if (isValidNode(leftNode) && labyrinthNodeGraph.ConnectionsExist(actualNode, leftNode) && !nodePrefabArray[leftNode.rows, leftNode.columns].isWall)
            {
                posiblePaths.Push(leftNode);
                nodeListAlreadyExplored.Add(leftNode);
            }

            yield return new WaitForSeconds(1.5f);
        }

        if (actualNode == endingNode)
        {
            Debug.Log("You have reached the end!");
            solutionText.text = "Solution Found!";
        }

        else
        {
            Debug.Log("No solution found.");
            solutionText.text = "No Solution Found.";
        }
    }

    public LabyrinthNode FindNodeByPosition(int row, int column)
    {
        foreach (var eachNode in labyrinthNodeGraph.nodeList)
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
}

