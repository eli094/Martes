using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class AVLTreeController : MonoBehaviour
{
    public GameObject nodePrefab;

    public float xSpacing = 4f;
    public float ySpacing = 2f;

    [SerializeField] private AVLTree avlTree;

    [SerializeField] int[] myArray = { 30, 20, 10, 5 };

    void Start()
    {
        avlTree = new AVLTree();

        foreach (int i in myArray)
            avlTree.Insert(i);

        VisualizeTree(avlTree.Root, new Vector3(0, 0, 0), 0);
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
