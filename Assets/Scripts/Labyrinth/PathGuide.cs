using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGuide : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public Node currentNode; // Nodo actual asociado al c�rculo negro
    public Node endNode;     // Nodo de salida final

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // Configura el LineRenderer para tener dos puntos
        lineRenderer.enabled = false;   // Oculta la l�nea inicialmente
    }

    void OnMouseDown() // Detecta cuando se hace clic en el objeto
    {
        List<Node> path = Search.FindPath(currentNode, endNode); // Encuentra el camino desde el nodo actual hasta el final

        if (path != null && path.Count > 1)
        {
            Node nextNode = path[1]; // El siguiente nodo en el camino

            // Dibujar la l�nea desde el c�rculo actual al siguiente
            lineRenderer.SetPosition(0, transform.position);                // Punto inicial (este c�rculo)
            lineRenderer.SetPosition(1, new Vector3(nextNode.y, -nextNode.x, 0)); // Punto final (siguiente c�rculo)
            lineRenderer.enabled = true; // Muestra la l�nea
        }
    }
}


