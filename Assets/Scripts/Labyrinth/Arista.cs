[System.Serializable]
public class Arista
{
    public Vertice OriginVert = null;
    public Vertice DestinationVert = null;
    public int Weight;

    public Arista(int weight)
    {
        Weight = weight;
    }

    public void SetPoints<T>(T Origin, T End)
    {
        if (Equals(typeof(T), typeof(Vertice))) // Si el valor que se recibe es de clase Vertice.
        {
            OriginVert = Origin as Vertice; // "as" Operador que convierte T, en el tipo Vertice.
            DestinationVert = End as Vertice; // Si la conversi�n no es posible, devuelve NULL. (Evitando una excepci�n, como puede tirar el casteo).
        }
        else
        {
            return;
        }

        OriginVert.AristasSalientes.Add(this);

        (Origin, End) = (End, Origin);

        DestinationVert.AristasEntrantes.Add(this);
    }
}
