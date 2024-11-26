using UnityEngine;

public class NodePrefab : MonoBehaviour
{
    public LabyrinthNode labyrinthNode;

    public SpriteRenderer labyrinthCubes;

    public Graph<LabyrinthNode> labyrinthNodesConnections;

    public bool isWall;

    public void Awake()
    {
        labyrinthCubes = GetComponent<SpriteRenderer>();   
    }

    public void CreateCube(int row, int column, Graph<LabyrinthNode> labyrinthNodes)
    {
        labyrinthNode = new LabyrinthNode(row, column);

        this.labyrinthNodesConnections = labyrinthNodes;

        labyrinthNodesConnections.AddNodes(labyrinthNode);

        isWall = true;
    }

    public void AddNextConnection()
    {
        if (labyrinthNode.rows - 1 > 0)
        {
            labyrinthNodesConnections.AddConnections(labyrinthNode, LabyrinthManager.instance.nodePrefabArray[labyrinthNode.rows -1, labyrinthNode.columns].labyrinthNode, 0);
        }

        if (labyrinthNode.rows + 1 < LabyrinthManager.instance.Row)
        {
            labyrinthNodesConnections.AddConnections(labyrinthNode, LabyrinthManager.instance.nodePrefabArray[labyrinthNode.rows + 1, labyrinthNode.columns].labyrinthNode, 0);
        }

        if (labyrinthNode.columns + 1 < LabyrinthManager.instance.Column)
        {
            labyrinthNodesConnections.AddConnections(labyrinthNode, LabyrinthManager.instance.nodePrefabArray[labyrinthNode.rows, labyrinthNode.columns + 1].labyrinthNode, 0);
        }

        if (labyrinthNode.columns - 1 > 0)
        {
            labyrinthNodesConnections.AddConnections(labyrinthNode, LabyrinthManager.instance.nodePrefabArray[labyrinthNode.rows, labyrinthNode.columns - 1].labyrinthNode, 0);
        }
    }

    public void OnMouseDown()
    {
        LabyrinthManager.instance.selectedNode = this;
    }
}
