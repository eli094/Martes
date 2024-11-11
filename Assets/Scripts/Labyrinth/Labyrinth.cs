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
        CreateMaze();
    }

    public void CreateMaze()
    {


        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (i % 2 == 0 || j % 2 == 0)
                    map[i, j] = 1;
                else
                    map[i, j] = 0; 
            }
        }

        map[rows - 1, columns - 1] = 0;

        map[0, 0] = 0;
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
