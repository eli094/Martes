public abstract class TDA<T>
{
    public abstract bool Add(T element);
    public abstract bool Remove(T element);
    public abstract bool Contains(T element);
    public abstract string Show();
    public abstract int Cardinality();
    public abstract bool IsEmpty();
    public abstract TDA<T> Union(TDA<T> otherSet);
    public abstract TDA<T> Intersect(TDA<T> otherSet);
    public abstract TDA<T> Difference(TDA<T> otherSet);
}
