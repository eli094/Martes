using System.Collections.Generic;
public class StaticTDA<T> : TDA<T>
{
    private T[] elements;
    private int count;

    public StaticTDA(int capacity)
    {
        elements = new T[capacity];
        count = 0;
    }
    public override bool Add(T element)
    {
        if (count >= elements.Length || Contains(element))
            return false;

        elements[count++] = element;
        return true;
    }
    public override bool Remove(T element)
    {
        for (int i = 0; i < count; i++)
            if (elements[i].Equals(element))
            {
                elements[i] = elements[count - 1];
                count--;
                return true;
            }
        return false;
    }
    public override bool Contains(T element)
    {
        for (int i = 0; i < count; i++)
            if (elements[i].Equals(element))
                return true;
        return false;
    }
    public override string Show()
    {
        var list = new List<T>();
        for (int i = 0; i < count; i++)
            list.Add(elements[i]);
        return string.Join(", ", list);
    }
    public override int Cardinality()
    {
        return count;
    }
    public override bool IsEmpty()
    {
        return count == 0;
    }
    public override TDA<T> Union(TDA<T> otherSet)
    {
        StaticTDA<T> unionSet = new StaticTDA<T>(elements.Length + (otherSet as StaticTDA<T>).elements.Length);
        foreach (var elem in elements)
            unionSet.Add(elem);
        foreach (var elem in (otherSet as StaticTDA<T>).elements)
            unionSet.Add(elem);
        return unionSet;
    }
    public override TDA<T> Intersect(TDA<T> otherSet)
    {
        StaticTDA<T> intersectSet = new StaticTDA<T>(count);
        for (int i = 0; i < count; i++)
            if (otherSet.Contains(elements[i]))
                intersectSet.Add(elements[i]);
        return intersectSet;
    }
    public override TDA<T> Difference(TDA<T> otherSet)
    {
        StaticTDA<T> differenceSet = new StaticTDA<T>(count);
        for (int i = 0; i < count; i++)
            if (!otherSet.Contains(elements[i]))
                differenceSet.Add(elements[i]);
        return differenceSet;
    }
}
