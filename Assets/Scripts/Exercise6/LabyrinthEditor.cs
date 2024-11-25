using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LabyrinthEditor : MonoBehaviour
{
    public Labyrinth6 labyrinth;

    public GameObject floorPrefab;
    public GameObject wallPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) SetFloor();
        if (Input.GetKeyDown(KeyCode.P)) SetWall();
        if (Input.GetKeyDown(KeyCode.Alpha1)) SetStart();
        if (Input.GetKeyDown(KeyCode.Alpha2)) SetEnd();
    }

    public void SetFloor()
    {
        var node = GetNodeAtMouse();
        if (node != null)
        {
            node.isPassable = true;
            labyrinth.BuildGraph();
            Instantiate(floorPrefab, new Vector3(node.column, node.row, 0), Quaternion.identity);
        }
    }

    public void SetWall()
    {
        var node = GetNodeAtMouse();
        if (node != null)
        {
            node.isPassable = false;

            foreach (var neighbor in labyrinth.graph.adjacencyList[node])
            {
                labyrinth.graph.adjacencyList[neighbor].Remove(node);
            }
            labyrinth.graph.adjacencyList[node].Clear();
            Instantiate(wallPrefab, new Vector3(node.column, node.row, 0), Quaternion.identity);
        }
    }



    public void SetStart()
    {
        var node = GetNodeAtMouse();
        if (node != null) labyrinth.startingNode = node;
    }

    public void SetEnd()
    {
        var node = GetNodeAtMouse();
        if (node != null) labyrinth.endingNode = node;
    }

    LabyrinthNode6 GetNodeAtMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int row = Mathf.FloorToInt(mousePos.y);
        int col = Mathf.FloorToInt(mousePos.x);
        return labyrinth.GetNode(row, col);
    }
}


