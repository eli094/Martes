[System.Serializable]
public class TreeNode
{
    public int value;

    public TreeNode left;
    public TreeNode right;
    public int height;

    public TreeNode(int value)
    {
        this.value = value;

        left = null;
        right = null;
        height = 1;
    }
}