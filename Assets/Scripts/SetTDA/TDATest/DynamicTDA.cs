using System.Collections.Generic;

public class DynamicTDA<T> : TDA<T>
{
    private HashSet<T> elements = new HashSet<T>();

    public override bool Add(T element)
    {
        return elements.Add(element); // HashSet.Add devuelve true si el elemento es nuevo.
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
        var result = new DynamicTDA<T>();
        foreach (var elem in elements)
            result.Add(elem);

        for (int i = 0; i < otherSet.Cardinality(); i++)
        {
            if (otherSet is DynamicTDA<T> dynamicSet)
            {
                foreach (var elem in dynamicSet.elements)
                {
                    result.Add(elem);
                }
            }
        }

        return result;
    }

    public override TDA<T> Intersect(TDA<T> otherSet)
    {
        var result = new DynamicTDA<T>();
        foreach (var elem in elements)
        {
            if (otherSet.Contains(elem))
                result.Add(elem);
        }
        return result;
    }

    public override TDA<T> Difference(TDA<T> otherSet)
    {
        var result = new DynamicTDA<T>();
        foreach (var elem in elements)
        {
            if (!otherSet.Contains(elem))
                result.Add(elem);
        }
        return result;
    }
}

