//using System.Collections.Generic;
//using UnityEngine;

//public class LabyrinthVisualization : MonoBehaviour
//{
//    public GameObject prefabNode;  // Prefab para los nodos (esferas)
//    public GameObject prefabWall;  // Prefab para las paredes (cubos)
//    public GameObject prefabPath;  // Prefab para el camino (líneas)

//    private GrafoLabyrinth grafo;
//    private Node nodeEntrance;
//    private Node nodeExit;

//    void Start()
//    {
//        grafo = new GrafoLabyrinth();
//        ShowLabyrinth();

//        List<Node> nodes = grafo.GetNodes();

//        nodeEntrance = nodes[0];
//        nodeExit = nodes[grafo.GetNodes().Count - 1];

//        List<Node> path = Search.FindPath(nodeEntrance, nodeExit, grafo);

//        if (path != null)
//        {
//            ShowPath(path);
//        }
//        else
//        {
//            Debug.Log("A path wasn't found.");
//        }
//    }

//    void ShowLabyrinth()
//    {
//        foreach (Node node in grafo.GetNodes())
//        {
//            Vector3 position = new Vector3(node.y, -node.x, 0);
//            Instantiate(prefabNode, position, Quaternion.identity); // Crear nodo
//        }

//        foreach (Node node in grafo.GetNodes())
//        {
//            foreach (Node neighbor in grafo.GetNeighbors(node))
//            {
//                Vector3 startPos = new Vector3(node.y, -node.x, 0);
//                Vector3 endPos = new Vector3(neighbor.y, -neighbor.x, 0);
//                Debug.DrawLine(startPos, endPos, Color.blue, 100f); // Dibujar arista entre nodos
//            }
//        }
//    }

//    void ShowPath(List<Node> path)
//    {
//        for (int i = 0; i < path.Count - 1; i++)
//        {
//            Vector3 startPos = new Vector3(path[i].y, -path[i].x, 0);
//            Vector3 endPos = new Vector3(path[i + 1].y, -path[i + 1].x, 0);
//            Instantiate(prefabPath, (startPos + endPos) / 2, Quaternion.identity); // Crear líneas para el camino
//        }
//    }
//}





