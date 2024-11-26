using System;

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
        if (count < elements.Length && !Contains(element))
        {
            elements[count] = element;
            count++;
            return true;
        }
        return false;
    }

    public override bool Remove(T element)
    {
        for (int i = 0; i < count; i++)
        {
            if (elements[i].Equals(element))
            {
                elements[i] = elements[count - 1];
                elements[count - 1] = default;
                count--;
                return true;
            }
        }
        return false;
    }

    public override bool Contains(T element)
    {
        for (int i = 0; i < count; i++)
        {
            if (elements[i].Equals(element))
                return true;
        }
        return false;
    }

    public override string Show()
    {
        T[] result = new T[count];
        Array.Copy(elements, result, count);
        return string.Join(", ", result);
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
        var result = new StaticTDA<T>(elements.Length + otherSet.Cardinality());
        foreach (var elem in elements)
            result.Add(elem);

        for (int i = 0; i < otherSet.Cardinality(); i++)
        {
            if (otherSet is StaticTDA<T> staticSet)
            {
                foreach (var elem in staticSet.elements)
                {
                    result.Add(elem);
                }
            }
        }

        return result;
    }

    public override TDA<T> Intersect(TDA<T> otherSet)
    {
        var result = new StaticTDA<T>(elements.Length);
        foreach (var elem in elements)
        {
            if (otherSet.Contains(elem))
                result.Add(elem);
        }
        return result;
    }

    public override TDA<T> Difference(TDA<T> otherSet)
    {
        var result = new StaticTDA<T>(elements.Length);
        foreach (var elem in elements)
        {
            if (!otherSet.Contains(elem))
                result.Add(elem);
        }
        return result;
    }
}
