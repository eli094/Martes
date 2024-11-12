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

    // Mantener el historial de mensajes
    private string messageHistory = "";

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
                    AppendMessage("Elemento agregado: " + value);
                }
                else
                    AppendMessage("Comando Add requiere un número válido.");
                break;

            case "remove":
                if (args.Length > 1 && int.TryParse(args[1], out value))
                {
                    dynamicSet.Remove(value);
                    AppendMessage("Elemento eliminado: " + value);
                }
                else
                    AppendMessage("Comando Remove requiere un número válido.");
                break;

            case "show":
                AppendMessage("Conjunto: " + dynamicSet.Show());
                break;

            case "cardinality":
                AppendMessage("Cardinalidad: " + dynamicSet.Cardinality());
                break;

            case "isempty":
                AppendMessage("¿Está vacío? " + (dynamicSet.IsEmpty() ? "Sí" : "No"));
                break;

            default:
                AppendMessage("Comando desconocido.");
                break;
        }

        inputField.text = ""; // Limpiar el campo de entrada
        inputField.ActivateInputField(); // Refocus para nuevo comando
    }

    // Agregar los mensajes al historial
    void AppendMessage(string message)
    {
        messageHistory += message + "\n";  // Acumular mensajes con salto de línea
        DisplayMessage(messageHistory);    // Mostrar todo el historial en TextMeshPro
    }

    // Mostrar el historial completo de mensajes
    void DisplayMessage(string message)
    {
        displayText.text = message;  // Actualiza el TextMeshPro con el historial acumulado
    }
}
