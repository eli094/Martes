using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSet<T> : MySet<T>
{
    private T[] elements;
    private int count;

    public StaticSet(int capacity)
    {
        elements = new T[capacity];
        count = 0;
    }

    public override bool Add(T element)
    {
        if (count >= elements.Length || Contains(element)) return false;

        elements[count] = element;
        count++;
        Debug.Log("Elemento agregado al conjunto estático: " + element);
        return true;
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
            if (elements[i].Equals(element)) return true;
        }
        return false;
    }

    public override void Show()
    {
        Console.Write("{ ");
        for (int i = 0; i < count; i++)
        {
            Console.Write(elements[i] + " ");
        }
        Console.WriteLine("}");
    }

    public override int Cardinality()
    {
        return count;
    }

    public override bool IsEmpty()
    {
        return count == 0;
    }

    public override MySet<T> Union(MySet<T> otherSet)
    {
        // Implementación similar a `DynamicSet`
        throw new NotImplementedException();
    }

    public override MySet<T> Intersection(MySet<T> otherSet)
    {
        // Implementación similar a `DynamicSet`
        throw new NotImplementedException();
    }

    public override MySet<T> Difference(MySet<T> otherSet)
    {
        // Implementación similar a `DynamicSet`
        throw new NotImplementedException();
    }


}
