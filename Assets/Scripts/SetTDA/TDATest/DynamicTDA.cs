using System.Collections.Generic;

public class DynamicTDA<T> : TDA<T>
{
    private HashSet<T> elements = new HashSet<T>();

    public override bool Add(T element)
    {
        return elements.Add(element);
    }
    public override bool Remove(T element)
    {
        return elements.Remove(element);
    }
    public override bool Contains(T element)
    {
        return elements.Contains(element);
    }
    public override string Show()
    {
        return string.Join(", ", elements);
    }
    public override int Cardinality()
    {
        return elements.Count;
    }
    public override bool IsEmpty()
    {
        return elements.Count == 0;
    }
    public override TDA<T> Union(TDA<T> otherSet)
    {
        DynamicTDA<T> unionSet = new DynamicTDA<T>();
        foreach (var elem in elements)
            unionSet.Add(elem);
        foreach (var elem in (otherSet as DynamicTDA<T>).elements)
            unionSet.Add(elem);
        return unionSet;
    }
    public override TDA<T> Intersect(TDA<T> otherSet)
    {
        DynamicTDA<T> intersectSet = new DynamicTDA<T>();
        foreach (var elem in elements)
            if (otherSet.Contains(elem))
                intersectSet.Add(elem);
        return intersectSet;
    }
    public override TDA<T> Difference(TDA<T> otherSet)
    {
        DynamicTDA<T> differenceSet = new DynamicTDA<T>();
        foreach (var elem in elements)
            if (!otherSet.Contains(elem))
                differenceSet.Add(elem);
        return differenceSet;
    }
}

