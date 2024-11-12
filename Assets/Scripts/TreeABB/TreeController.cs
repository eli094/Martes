using UnityEngine;
using TMPro;

public class TreeController : MonoBehaviour
{
    public GameObject nodePrefab;

    public float xSpacing = 2f;
    public float ySpacing = 0.5f;

    public BinarySearchTree tree;

    void Start()
    {
        tree = new BinarySearchTree();

        int[] myArray = { 20, 10, 1, 26, 35, 40, 18, 12, 15, 14, 30, 23 };

        foreach (int value in myArray)
        {
            tree.Insert(value);
        }

        VisualizeTree(tree.Root, new Vector3(0, 0, 0), 0);

        int depth = tree.GetTreeDepth(tree.Root);

        Debug.Log("The greatest depth of the tree is: " + depth);
    }

    void VisualizeTree(TreeNode node, Vector3 position, int value)
    {
        if (node != null)
        {
            value++;

            GameObject newNode = Instantiate(nodePrefab, position, Quaternion.identity);

            newNode.GetComponentInChildren<TextMeshProUGUI>().text = node.value.ToString();

            if (node.left != null)
            {
                VisualizeTree(node.left, position + new Vector3(-(xSpacing - (0.5f * value)), -ySpacing, 0), value);
            }

            if (node.right != null)
            {
                VisualizeTree(node.right, position + new Vector3((xSpacing - (0.5f * value)), -ySpacing, 0), value);
            }
        }
    }
}
