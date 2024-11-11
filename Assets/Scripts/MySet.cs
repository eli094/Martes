using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public abstract class MySet<T> 
{
    public abstract bool Add(T element);
    public abstract bool Remove(T element);
    public abstract bool Contains(T element);
    public abstract void Show();
    public abstract int Cardinality();
    public abstract bool IsEmpty();
    public abstract MySet<T> Union(MySet<T> otherSet);
    public abstract MySet<T> Intersection(MySet<T> otherSet);
    public abstract MySet<T> Difference(MySet<T> otherSet);
}
