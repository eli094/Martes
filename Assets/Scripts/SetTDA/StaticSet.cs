using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSet<T> : MySet<T>
{
    private T[] elementos;
    private int tamaño;
    private int capacidad;

    public StaticSet(int capacidad = 10)
    {
        this.capacidad = capacidad;
        elementos = new T[capacidad];
        tamaño = 0;
    }

    public void Add(T elemento)
    {
        if (Contains(elemento)) return;

        if (tamaño < capacidad)
        {
            elementos[tamaño] = elemento;
            tamaño++;
        }
        else
        {
            Console.WriteLine("Capacidad máxima alcanzada");
        }
    }

    public void Remove(T elemento)
    {
        int index = Array.IndexOf(elementos, elemento);

        if (index != -1)
        {
            for (int i = index; i < tamaño - 1; i++)
            {
                elementos[i] = elementos[i + 1];
            }

            elementos[tamaño - 1] = default(T);
            tamaño--;
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
        return tamaño;
    }

    public bool IsEmpty()
    {
        return tamaño == 0;
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
