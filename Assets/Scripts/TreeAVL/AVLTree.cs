using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[System.Serializable]
public class AVLTree : BinarySearchTree
{
    public AVLTree()
    {
        Root = null;
    }

    protected override TreeNode Insert(TreeNode node, int value)
    {
        if (node == null)
        {
            Debug.Log("Insert: " + value);
            return new TreeNode(value);
        }

        if (value < node.value)
            node.left = Insert(node.left, value);
        else if (value > node.value)
            node.right = Insert(node.right, value);

        node.height = Mathf.Max(GetHeight(node.left), GetHeight(node.right)) + 1;

        int balance = GetBalanceFactor(node);

        if (balance > 1 && value < node.left.value)
        {
            Debug.Log("Simple Right Rotation");
            return RightRotate(node);
        }
        if (balance < -1 && value > node.right.value)
        {
            Debug.Log("Simple Left Rotation");
            return LeftRotate(node);
        }
        if (balance > 1 && value > node.left.value)
        {
            Debug.Log("Double Right Rotation");
            node.left = LeftRotate(node.left);
            return RightRotate(node);
        }
        if (balance < -1 && value < node.right.value)
        {
            Debug.Log("Double Left Rotation");
            node.right = RightRotate(node.right);
            return LeftRotate(node);
        }

        return node;
    }

    public TreeNode RightRotate(TreeNode y)
    {
        TreeNode x = y.left;
        TreeNode T2 = x.right;

        x.right = y;
        y.left = T2;

        y.height = Mathf.Max(GetHeight(y.left), GetHeight(y.right)) + 1;
        x.height = Mathf.Max(GetHeight(x.left), GetHeight(x.right)) + 1;

        return x;
    }

    public TreeNode LeftRotate(TreeNode x)
    {
        TreeNode y = x.right;
        TreeNode T2 = y.left;

        y.left = x;
        x.right = T2;

        x.height = Mathf.Max(GetHeight(x.left), GetHeight(x.right)) + 1;
        y.height = Mathf.Max(GetHeight(y.left), GetHeight(y.right)) + 1;

        return y;
    }

    public int GetBalanceFactor(TreeNode node)
    {
        if (node == null)
            return 0;
        return GetHeight(node.left) - GetHeight(node.right);
    }
}
