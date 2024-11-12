using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public interface MySet<T>
{
    void Add(T elemento);                // Agrega un elemento al conjunto
    void Remove(T elemento);             // Elimina un elemento del conjunto
    bool Contains(T elemento);           // Verifica si el conjunto contiene un elemento
    string Show();                       // Muestra los elementos como una cadena
    int Cardinality();                   // Devuelve la cantidad de elementos en el conjunto
    bool IsEmpty();                      // Verifica si el conjunto está vacío
    MySet<T> Union(MySet<T> otroConjunto);   // Devuelve la unión de dos conjuntos
    MySet<T> Intersect(MySet<T> otroConjunto);   // Devuelve la intersección de dos conjuntos
    MySet<T> Difference(MySet<T> otroConjunto);   // Devuelve la diferencia entre dos conjuntos
}
