using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI setText;
    private DynamicTDA<int> set;

    void Start()
    {
        set = new DynamicTDA<int>();
        UpdateSetText();
    }
    public void AddElement()
    {
        set.Add(20);
        UpdateSetText();
    }
    public void RemoveElement()
    {
        set.Remove(20);
        UpdateSetText();
    }
    public void ShowSet()
    {
        setText.text = "Show set: [" + set.Show() + "]";
    }
    private void UpdateSetText()
    {
        setText.text = "Set: [" + set.Show() + "]";
    }
    public void SetCardinality()
    {
        int cardinality = set.Cardinality();
        setText.text = "Set cardinality: " + cardinality;
    }
    public void Empty()
    {
        bool empty = set.IsEmpty();
        setText.text = "Is the element empty: " + (empty ? "Yes" : "No");
    }
    public void SetUnion()
    {
        TDA<int> setB = new DynamicTDA<int>();
        TDA<int> union = set.Union(setB);
        setText.text = "Set union: " + union.Show();
    }
    public void SetIntersection()
    {
        TDA<int> setB = new DynamicTDA<int>();
        TDA<int> intersection = set.Intersect(setB);
        setText.text = "Set intersection: " + intersection.Show();
    }
    public void SetDifference()
    {
        TDA<int> setB = new DynamicTDA<int>();
        TDA<int> difference = set.Difference(setB);
        setText.text = "Set difference: " + difference.Show();
    }
    public void ContainsElement()
    {
        int elementSearch = 20;
        bool contains = set.Contains(elementSearch);

        setText.text = "Contains the element " + elementSearch + "? " + (contains ? "Yes" : "No");
    }
}
