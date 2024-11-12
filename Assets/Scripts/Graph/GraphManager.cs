using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    public Graph<VisualNode> graph;
    [SerializeField] private GameObject[] verticesPrefab;
    [SerializeField] private GameObject traveler;
    [SerializeField] private TextMeshProUGUI travelCost;
    private VisualNode currentDestination;
    private Stack<VisualNode> travelToDestination = new Stack<VisualNode>();
    private int totalTravelCost;

    private void Awake()
    {
        Debug.Log(traveler);
        graph = new Graph<VisualNode>();

        for (int i = 0; i < verticesPrefab.Length; i++)
        {
            verticesPrefab[i].GetComponentInChildren<TextMeshProUGUI>().text = (i + 1).ToString();
            VisualNode visualNode = new VisualNode(i + 1);
            graph.AddNodes(visualNode);
        }
        NodeConnections();
        currentDestination = graph.nodeList[0];
        traveler.transform.position = new Vector2 (verticesPrefab[0].transform.position.x, verticesPrefab[0].transform.position.y);
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = NodeIdentifier();
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Node"))
                TravelToDestination(hit);
        }
    }

    private void NodeConnections()
    {
        graph.AddConnections(graph.nodeList[0], graph.nodeList[1], 5);
        graph.AddConnections(graph.nodeList[0], graph.nodeList[2], 6);
        graph.AddConnections(graph.nodeList[1], graph.nodeList[3], 8);
        graph.AddConnections(graph.nodeList[3], graph.nodeList[2], 3);
        graph.AddConnections(graph.nodeList[3], graph.nodeList[5], 7);
        graph.AddConnections(graph.nodeList[2], graph.nodeList[5], 5);
        graph.AddConnections(graph.nodeList[2], graph.nodeList[4], 6);
        graph.AddConnections(graph.nodeList[5], graph.nodeList[6], 8);
        graph.AddConnections(graph.nodeList[4], graph.nodeList[6], 3);
    }

    private RaycastHit2D NodeIdentifier()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        return hit;
    }

    private void TravelToDestination(RaycastHit2D ray)
    {
        GameObject node = ray.collider.gameObject;
        int nodeIndex = int.Parse(node.GetComponentInChildren<TextMeshProUGUI>().text);
        VisualNode visualNode = new VisualNode(nodeIndex);
        visualNode = graph.ReturnNodes(visualNode);
        totalTravelCost = 0;
        travelToDestination.Push(graph.nodeList[nodeIndex - 1]);
        CreatePath(currentDestination, graph.nodeList[nodeIndex - 1]);
        if (travelToDestination.Count > 0)
        {
            StartCoroutine(TravelerAnimations());
        }
    }
    private IEnumerator TravelerAnimations()
    {
        int visualNodes;
        while (travelToDestination.Count > 0)
        {
            visualNodes = travelToDestination.Pop().NodeID;
            totalTravelCost += graph.ReturnTravelCost(currentDestination, graph.nodeList[visualNodes - 1]);
            Debug.Log(verticesPrefab[visualNodes - 1]);
            traveler.transform.position = verticesPrefab[visualNodes - 1].transform.position;
            currentDestination = graph.ReturnNodes(graph.nodeList[visualNodes - 1]);
            yield return new WaitForSeconds(1f);
        }
        Debug.Log(totalTravelCost);
        travelCost.text = totalTravelCost.ToString();
    }
    private void CreatePath(VisualNode start, VisualNode destination)
    {
        foreach (var connections in graph.adjacencyList)
        {
            foreach (var edge in connections.Value)
            {
                if (edge.Item1 == graph.ReturnNodes(destination))
                {
                    if (connections.Key.NodeID == start.NodeID)
                    {
                        Debug.Log("Doing1");
                        return;
                    }
                    else
                    {
                        Debug.Log("Doing2");
                        travelToDestination.Push(connections.Key);
                        CreatePath(start, connections.Key);
                        return;
                    }
                }
            }
        }
    }
}

