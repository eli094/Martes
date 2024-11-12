using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DynamicSet<T> : MySet<T>
{
    private List<T> elementos;

    public DynamicSet()
    {
        elementos = new List<T>();
    }

    public void Add(T elemento)
    {
        if (!Contains(elemento))
            elementos.Add(elemento);
    }

    public void Remove(T elemento)
    {
        if (Contains(elemento))
            elementos.Remove(elemento);
    }

    public bool Contains(T elemento)
    {
        return elementos.Contains(elemento);
    }

    public string Show()
    {
        return string.Join(", ", elementos);
    }

    public int Cardinality()
    {
        return elementos.Count;
    }

    public bool IsEmpty()
    {
        return elementos.Count == 0;
    }

    public MySet<T> Union(MySet<T> otroConjunto)
    {
        MySet<T> union = new DynamicSet<T>();

        foreach (var elem in elementos)
            union.Add(elem);

        foreach (var elem in ((DynamicSet<T>)otroConjunto).elementos)
            union.Add(elem);

        return union;
    }

    public MySet<T> Intersect(MySet<T> otroConjunto)
    {
        MySet<T> interseccion = new DynamicSet<T>();

        foreach (var elem in elementos)
        {
            if (otroConjunto.Contains(elem))
                interseccion.Add(elem);
        }

        return interseccion;
    }

    public MySet<T> Difference(MySet<T> otroConjunto)
    {
        MySet<T> diferencia = new DynamicSet<T>();

        foreach (var elem in elementos)
        {
            if (!otroConjunto.Contains(elem))
                diferencia.Add(elem);
        }

        return diferencia;
    }
}