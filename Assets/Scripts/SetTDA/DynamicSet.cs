using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DynamicSet<T> : MySet<T>
{
    private List<T> setList = new List<T>();

    public DynamicSet()
    {
        setList = new List<T>();
    }

    public override bool Add(T element)
    {
        if (!setList.Contains(element))
        {
            setList.Add(element);
            Debug.Log("Elemento agregado a la lista: " + element);
        }
        else
        {
            Debug.Log("El elemento ya existe en ela lista");
        }
        return true;
    }

    public override bool Remove(T element)
    {
        return setList.Remove(element);
    }

    public override bool Contains(T element)
    {
        return setList.Contains(element);
    }

    public override void Show()
    {
        Console.Write("{ ");
        foreach (T element in setList)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine("}");
    }

    public override int Cardinality()
    {
        return setList.Count;
    }

    public override bool IsEmpty()
    {
        return setList.Count == 0;
    }

    // Uni�n de conjuntos
    public override MySet<T> Union(MySet<T> otherSet)
    {
        DynamicSet<T> resultSet = new DynamicSet<T>();
        resultSet.setList.AddRange(this.setList); // A�adir todos los elementos actuales

        foreach (T element in ((DynamicSet<T>)otherSet).setList)
        {
            resultSet.Add(element); // A�adir solo si no est� presente
        }

        return resultSet;
    }

    // Intersecci�n de conjuntos
    public override MySet<T> Intersection(MySet<T> otherSet)
    {
        DynamicSet<T> resultSet = new DynamicSet<T>();

        foreach (T element in this.setList)
        {
            if (otherSet.Contains(element))
            {
                resultSet.Add(element);
            }
        }

        return resultSet;
    }

    public override MySet<T> Difference(MySet<T> otherSet)
    {
        DynamicSet<T> resultSet = new DynamicSet<T>();

        foreach (T element in this.setList)
        {
            if (!otherSet.Contains(element))
            {
                resultSet.Add(element);
            }
        }

        return resultSet;
    }


}
