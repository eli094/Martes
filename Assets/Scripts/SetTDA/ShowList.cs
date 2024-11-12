using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowList : MonoBehaviour
{
    public InputField inputField;
    public TextMeshProUGUI displayText;

    private DynamicSet<int> dynamicSet = new DynamicSet<int>();

    void Start()
    {
        inputField.onEndEdit.AddListener(ExecuteCommand);
        inputField.ActivateInputField();
        DisplayMessage("Escribe un comando (Add <n>, Remove <n>, Show, Cardinality, IsEmpty)");
    }

    void ExecuteCommand(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return;

        var args = input.Split(' ');
        var command = args[0].ToLower();
        int value;

        switch (command)
        {
            case "add":
                if (args.Length > 1 && int.TryParse(args[1], out value))
                {
                    dynamicSet.Add(value);
                    DisplayMessage("Elemento agregado: " + value);
                }
                else
                    DisplayMessage("Comando Add requiere un número válido.");
                break;

            case "remove":
                if (args.Length > 1 && int.TryParse(args[1], out value))
                {
                    dynamicSet.Remove(value);
                    DisplayMessage("Elemento eliminado: " + value);
                }
                else
                    DisplayMessage("Comando Remove requiere un número válido.");
                break;

            case "show":
                DisplayMessage("Conjunto: " + dynamicSet.Show());
                break;

            case "cardinality":
                DisplayMessage("Cardinalidad: " + dynamicSet.Cardinality());
                break;

            case "isempty":
                DisplayMessage("¿Está vacío? " + (dynamicSet.IsEmpty() ? "Sí" : "No"));
                break;

            default:
                DisplayMessage("Comando desconocido.");
                break;
        }

        inputField.text = ""; // Limpiar el campo de entrada
        inputField.ActivateInputField(); // Refocus para nuevo comando
    }

    void DisplayMessage(string message)
    {
        displayText.text = message;
    }
}
