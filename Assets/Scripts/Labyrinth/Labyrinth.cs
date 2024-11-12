using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Labyrinth : MonoBehaviour
{
    public int rows = 5;
    public int columns = 5;

    public int[,] map;

    float prefabSize = 1.0f;

    void Start()
    {
        
    }

    

    void ShowMaze()
    {
        for (int i = 0; i < rows; i++)
        {
            string fila = "";
            for (int j = 0; j < columns; j++)
            {
                fila += map[i, j] == 1 ? "#" : " ";
            }
            Debug.Log(fila);
        }
    }
}
