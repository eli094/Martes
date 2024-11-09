//using UnityEngine;

//public class Labyrinth : MonoBehaviour
//{
//    public int rows = 5;
//    public int columns = 5;

//    public int[,] map;

//    void Start()
//    {
//        CreateMaze();
//    }

//    public void CreateMaze()
//    {
//        map = new int[rows, columns];

//        for (int i = 0; i < rows; i++)
//        {
//            for (int j = 0; j < columns; j++)
//            {
//                if (i == 0 || i == rows - 1 || j == 0 || j == columns - 1)
//                {
//                    map[i, j] = 1;
//                }
//                else
//                {
//                    map[i, j] = Random.Range(0, 2);
//                }
//            }
//        }

//        map[0, 0] = 0;
//        map[rows - 1, columns - 1] = 0;

//        map[0, 1] = 0;
//        map[1, 0] = 0;
//    }



//    void ShowMaze()
//    {
//        for (int i = 0; i < rows; i++)
//        {
//            string row = "";

//            for (int j = 0; j < columns; j++)
//            {
//                row += map[i, j] == 1 ? "#" : " ";
//            }

//            Debug.Log(row);
//        }
//    }
//}
