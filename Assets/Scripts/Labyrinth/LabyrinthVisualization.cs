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

        List<Node> nodes = grafo.GetNodes();

        nodeEntrance = nodes.Find(n => n.x == 0 && n.y == 0);
        nodeExit = nodes.Find(n => n.x == labyrinth.rows - 1 && n.y == labyrinth.columns - 1);

        List<Node> path = Search.FindPath(nodeEntrance, nodeExit, grafo);

        if (path != null)
        {
            ShowPath(path);
        }
        else
        {
            Debug.Log("A path wasn't found.");
        }
    }

    void ShowLabyrinth()
    {
        for (int i = 0; i < labyrinth.rows; i++)
        {
            for (int j = 0; j < labyrinth.columns; j++)
            {
                Vector3 position = new Vector3(j, -i, 0);

                if (labyrinth.map[i, j] == 1)
                {
                    Instantiate(prefabWall, position, Quaternion.identity);
                }
                else
                {
                    if (i == 0 && j == 0)
                    {
                        Instantiate(prefabEntrance, position, Quaternion.identity);
                    }
                    else if (i == labyrinth.rows - 1 && j == labyrinth.columns - 1)
                    {
                        Instantiate(prefabExit, position, Quaternion.identity);
                    }
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




