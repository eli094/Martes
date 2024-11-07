using System.Collections.Generic;
using UnityEngine;

public class LabyrinthVisualization : MonoBehaviour
{
    public Labyrinth labyrinth;

    public GameObject prefabPath;
    public GameObject prefabWall;
    public GameObject prefabEntrance;
    public GameObject prefabExit;

    private GrafoLabyrinth grafo;

    private Node nodeEntrance;
    private Node nodeExit;

    void Start()
    {
        labyrinth.CreateMaze();

        grafo = new GrafoLabyrinth(labyrinth.map);

        ShowLabyrinth();

        nodeEntrance = grafo.nodes[0, 0];
        nodeExit = grafo.nodes[labyrinth.rows - 1, labyrinth.columns - 1];

        List<Node> path = Search.FindPath(nodeEntrance, nodeExit);

        if (path != null)
        {
            ShowPath(path);
        }
    }

    void ShowLabyrinth()
    {
        for (int i = 0; i < labyrinth.rows; i++)
        {
            for (int j = 0; j < labyrinth.columns; j++)
            {
                if (labyrinth.map[i, j] == 1)
                {
                    Instantiate(prefabWall, new Vector3(j, -i, 0), Quaternion.identity);
                }
                else
                {
                    if (i == 0 && j == 0)
                        Instantiate(prefabEntrance, new Vector3(j, -i, 0), Quaternion.identity);
                    else if (i == labyrinth.rows - 1 && j == labyrinth.columns - 1)
                        Instantiate(prefabExit, new Vector3(j, -i, 0), Quaternion.identity);
                }
            }
        }
    }

    void ShowPath(List<Node> path)
    {
        foreach (Node node in path)
        {
            Instantiate(prefabPath, new Vector3(node.y, -node.x, 0), Quaternion.identity);
        }
    }
}

