using System.Collections.Generic;

public class Node
{
    public int x, y;

    public Node(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public override bool Equals(object obj)
    {
        if (obj is Node other)
        {
            return x == other.x && y == other.y;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return (x, y).GetHashCode();
    }
}


