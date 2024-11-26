using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TextMeshProUGUI dynamicSetDisplay;
    public TextMeshProUGUI staticSetDisplay;
    public TextMeshProUGUI resultDisplay;
    public TMP_InputField inputField;

    private TDA<int> dynamicSet;
    private TDA<int> staticSet;

    void Start()
    {
        dynamicSet = new DynamicTDA<int>();  // Dynamic set que maneja ints
        staticSet = new StaticTDA<int>(10); // Static set que maneja ints, con capacidad 10
        UpdateUI();
    }

    public void AddToDynamicSet()
    {
        if (int.TryParse(inputField.text, out int element))  // Verifica si el valor es un int
        {
            if (dynamicSet.Add(element))
            {
                resultDisplay.text = $"Added {element} to Dynamic Set.";
            }
            else
            {
                resultDisplay.text = $"{element} is already in Dynamic Set.";
            }
            UpdateUI();
        }
        else
        {
            resultDisplay.text = "Please add a valid element.";
        }
    }

    public void AddToStaticSet()
    {
        if (int.TryParse(inputField.text, out int element))  // Verifica si el valor es un int
        {
            if (staticSet.Add(element))
            {
                resultDisplay.text = $"Added {element} to Static Set.";
            }
            else
            {
                resultDisplay.text = $"{element} could not be added to Static Set (maybe it’s full).";
            }
            UpdateUI();
        }
        else
        {
            resultDisplay.text = "Please add a valid element.";
        }
    }

    public void RemoveFromDynamicSet()
    {
        if (int.TryParse(inputField.text, out int element))
        {
            if (dynamicSet.Remove(element))
            {
                resultDisplay.text = $"Removed {element} from Dynamic Set.";
            }
            else
            {
                resultDisplay.text = $"{element} not found in Dynamic Set.";
            }
            UpdateUI();
        }
        else
        {
            resultDisplay.text = "Please add a valid element.";
        }
    }

    public void RemoveFromStaticSet()
    {
        if (int.TryParse(inputField.text, out int element))
        {
            if (staticSet.Remove(element))
            {
                resultDisplay.text = $"Removed {element} from Static Set.";
            }
            else
            {
                resultDisplay.text = $"{element} not found in Static Set.";
            }
            UpdateUI();
        }
        else
        {
            resultDisplay.text = "Please add a valid element.";
        }
    }

    public void ContainsInDynamicSet()
    {
        if (int.TryParse(inputField.text, out int element))
        {
            if (dynamicSet.Contains(element))
            {
                resultDisplay.text = $"Dynamic Set contains {element}.";
            }
            else
            {
                resultDisplay.text = $"Dynamic Set does not contain {element}.";
            }
        }
        else
        {
            resultDisplay.text = "Please add a valid element.";
        }
    }

    public void ContainsInStaticSet()
    {
        if (int.TryParse(inputField.text, out int element))
        {
            if (staticSet.Contains(element))
            {
                resultDisplay.text = $"Static Set contains {element}.";
            }
            else
            {
                resultDisplay.text = $"Static Set does not contain {element}.";
            }
        }
        else
        {
            resultDisplay.text = "Please add a valid element.";
        }
    }

    public void ShowDynamicSet()
    {
        resultDisplay.text = "Dynamic Set: " + dynamicSet.Show();
    }

    public void ShowStaticSet()
    {
        resultDisplay.text = "Static Set: " + staticSet.Show();
    }

    public void CardinalityOfDynamicSet()
    {
        resultDisplay.text = $"Dynamic Set Cardinality: {dynamicSet.Cardinality()}";
    }

    public void CardinalityOfStaticSet()
    {
        resultDisplay.text = $"Static Set Cardinality: {staticSet.Cardinality()}";
    }

    public void IsEmptyDynamicSet()
    {
        if (dynamicSet.IsEmpty())
        {
            resultDisplay.text = "Dynamic Set is empty.";
        }
        else
        {
            resultDisplay.text = "Dynamic Set is not empty.";
        }
    }

    public void IsEmptyStaticSet()
    {
        if (staticSet.IsEmpty())
        {
            resultDisplay.text = "Static Set is empty.";
        }
        else
        {
            resultDisplay.text = "Static Set is not empty.";
        }
    }

    public void ShowUnion()
    {
        var unionSet = dynamicSet.Union(staticSet);
        resultDisplay.text = "Union: " + unionSet.Show();
    }

    public void ShowIntersection()
    {
        var intersectSet = dynamicSet.Intersect(staticSet);  // Intersección entre los dos conjuntos
        resultDisplay.text = "Intersection: " + intersectSet.Show();  // Muestra la intersección en el UI
    }

    public void ShowDifference()
    {
        var differenceSet = dynamicSet.Difference(staticSet);
        resultDisplay.text = "Difference (Dynamic - Static): " + differenceSet.Show();
    }

    private void UpdateUI()
    {
        dynamicSetDisplay.text = "Dynamic Set: " + dynamicSet.Show();
        staticSetDisplay.text = "Static Set: " + staticSet.Show();
    }
}