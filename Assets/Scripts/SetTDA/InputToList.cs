using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputToList : MonoBehaviour
{
    public InputField inputField;          // Asigna el InputField desde el Inspector
    public Button addButton;
    public TextMeshProUGUI showList;
    public DynamicSet<int> dynamicSet;     // Instancia genérica de DynamicSet (int en este caso)

    void Start()
    {
        addButton.onClick.AddListener(AddItemToList); // Vincula el método al evento onEndEdit
        UpdateListDisplay();
    }

    void AddItemToList()
    {
        if (int.TryParse(inputField.text, out int inputValue)) // Convierte a int (u otro tipo)
        {
            dynamicSet.Add(inputValue);   // Agrega el valor convertido a DynamicSet
            UpdateListDisplay();
            inputField.text = "";              // Limpia el campo de entrada
            
        }
        else
        {
            Debug.Log("El valor ingresado no es un número válido");
        }
    }
    void UpdateListDisplay()
    {
        showList.text = "Elementos en la lista:\n";
        foreach (var item in dynamicSet.GetElements())
        {
            showList.text += item + "\n";
        }
    }
}

