using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSet<T> : MySet<T>
{
    private T[] elementos;
    private int tama�o;
    private int capacidad;

    public StaticSet(int capacidad = 10)
    {
        this.capacidad = capacidad;
        elementos = new T[capacidad];
        tama�o = 0;
    }

    public void Add(T elemento)
    {
        if (Contains(elemento)) return;

        if (tama�o < capacidad)
        {
            elementos[tama�o] = elemento;
            tama�o++;
        }
        else
        {
            Console.WriteLine("Capacidad m�xima alcanzada");
        }
    }

    public void Remove(T elemento)
    {
        int index = Array.IndexOf(elementos, elemento);

        if (index != -1)
        {
            for (int i = index; i < tama�o - 1; i++)
            {
                elementos[i] = elementos[i + 1];
            }

            elementos[tama�o - 1] = default(T);
            tama�o--;
        }
    }

    public bool Contains(T elemento)
    {
        return Array.IndexOf(elementos, elemento) != -1;
    }

    public string Show()
    {
        return string.Join(", ", elementos);
    }

    public int Cardinality()
    {
        return tama�o;
    }

    public bool IsEmpty()
    {
        return tama�o == 0;
    }

    public MySet<T> Union(MySet<T> otroConjunto)
    {
        MySet<T> union = new StaticSet<T>(this.capacidad + otroConjunto.Cardinality());

        foreach (var elem in elementos)
            union.Add(elem);

        foreach (var elem in ((StaticSet<T>)otroConjunto).elementos)
            union.Add(elem);

        return union;
    }

    public MySet<T> Intersect(MySet<T> otroConjunto)
    {
        MySet<T> interseccion = new StaticSet<T>();

        foreach (var elem in elementos)
        {
            if (otroConjunto.Contains(elem))
                interseccion.Add(elem);
        }

        return interseccion;
    }

    public MySet<T> Difference(MySet<T> otroConjunto)
    {
        MySet<T> diferencia = new StaticSet<T>();

        foreach (var elem in elementos)
        {
            if (!otroConjunto.Contains(elem))
                diferencia.Add(elem);
        }

        return diferencia;
    }
}
