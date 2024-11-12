using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum NodeType
{
    Entrance,
    Path, // Círculo negro (camino)
    NoEnd, // Nodo de fin de camino
    Exit,  
    Divide  // Nodo de bifurcación

}

public class NodeController : MonoBehaviour
{
    public NodeType nodeType;           // Define el tipo de nodo
    private LineRenderer lineRenderer;
    public Node associatedNode;         // Nodo del grafo representado por este GameObject
    public Node nodeExit;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void OnMouseDown()
    {
        // Suponiendo que tienes un nodo objetivo definido
        
        Node targetNode = nodeExit/* Define o asigna el nodo objetivo */;
        List<Node> path = Search.FindPath(associatedNode, targetNode);

        if (path != null && path.Count > 1)
        {
            Node nextNode = path[1];

            switch (nodeType)
            {
                case NodeType.Path:
                    ShowPathLine(nextNode);
                    break;

                case NodeType.NoEnd:
                    ShowReturnPath(path);
                    break;

                case NodeType.Divide:
                    ShowForkOptions(path);
                    break;
                case NodeType.Exit:
                    ShowForkOptions(path);
                    break;
                case NodeType.Entrance:
                    ShowForkOptions(path);
                    break;

            }
        }
    }

    private void ShowPathLine(Node nextNode)
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, new Vector3(nextNode.y, -nextNode.x, 0));
        lineRenderer.enabled = true;
    }

    private void ShowReturnPath(List<Node> path)
    {
        lineRenderer.positionCount = path.Count;
        for (int i = 0; i < path.Count; i++)
        {
            lineRenderer.SetPosition(i, new Vector3(path[i].y, -path[i].x, 0));
        }
    }

    private void ShowForkOptions(List<Node> path)
    {
        if (path.Count > 2)
        {
            Node option1 = path[1];
            Node option2 = path[2];

            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, new Vector3(option1.y, -option1.x, 0));

            // Implementa lógica adicional para otras opciones de bifurcación
        }
    }
}   

