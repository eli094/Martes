using System;

[System.Serializable]
public class BinarySearchTree
{
    [field: UnityEngine.SerializeField] public TreeNode Root { get; protected set; }

    public BinarySearchTree()
    {
        Root = null;
    }

    public void Insert(int value)
    {
        Root = Insert(Root, value);
    }

    protected virtual TreeNode Insert(TreeNode root, int value)
    {
        if (root == null)
        {
            root = new TreeNode(value);

            return root;
        }

        if (value < root.value)
        {
            root.left = Insert(root.left, value);
        }

        else
        {
            root.right = Insert(root.right, value);
        }

        return root;
    }

    public int GetTreeDepth(TreeNode node)
    {
        if (node == null)
        {
            return 0;
        }

        int leftDepth = GetTreeDepth(node.left);
        int rightDepth = GetTreeDepth(node.right);

        return UnityEngine.Mathf.Max(leftDepth, rightDepth) + 1;
    }

    public void InOrderTraversal(TreeNode node)
    {
        if (node != null)
        {
            InOrderTraversal(node.left);
            UnityEngine.Debug.Log(node.value);
            InOrderTraversal(node.right);
        }
    }

    public void PreOrderTraversal(TreeNode node)
    {
        if (node != null)
        {
            UnityEngine.Debug.Log(node.value);
            PreOrderTraversal(node.left);
            PreOrderTraversal(node.right);
        }
    }

    public void PostOrderTraversal(TreeNode node)
    {
        if (node != null)
        {
            PostOrderTraversal(node.left);
            PostOrderTraversal(node.right);
            UnityEngine.Debug.Log(node.value);
        }
    }

    protected int GetHeight(TreeNode node) => node?.height ?? 0;
}
