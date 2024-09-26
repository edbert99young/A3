using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // Variables to store references to different GameObjects (these could be walls, pellets, etc.)
    public GameObject closeGrid;
    public GameObject m1;
    public GameObject m2;
    public GameObject m3;
    public GameObject m4;
    public GameObject m5;
    public GameObject m6;
    public GameObject m7;

    // Variables to set the starting position of the level grid
    float x = -14.0f;
    float y = 14.0f;

    // 2D array that defines the level layout (using numbers to represent different types of objects)
    int[,] levelMap =
    {
        {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
        {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
        {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
        {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
        {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
        {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
        {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
        {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
        {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
        {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
        {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
        {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
        {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };

    // Start called before the first frame update
    void Start()
    {
        // Disable the closeGrid GameObject initially
        closeGrid.SetActive(false);

        // Call function to draw the level
        drawLevel();
    }

    // function responsible for drawing the level based on the levelMap array
    void drawLevel()
    {
        // Loop through each row of the levelMap array
        for (int row = 0; row < levelMap.GetLength(0); row++)
        {
            // Loop through each column of the levelMap array
            for (int col = 0; col < levelMap.GetLength(1); col++)
            {
                // switch statement to determine what to instantiate based on the value in levelMap
                switch (levelMap[row, col])
                {
                    // If the value is 0, do nothing (an empty space)
                    case 0:
                        break;

                    // If the value is 1, instantiate m1 at the current grid position
                    case 1:
                        Instantiate(m1, new Vector3(x, y, 0f), Quaternion.identity);
                        break;

                    // If the value is 2, instantiate m2 at the current grid position
                    case 2:
                        Instantiate(m2, new Vector3(x, y, 0f), Quaternion.identity);
                        break;

                    // If the value is 3, instantiate m3 at the current grid position
                    case 3:
                        Instantiate(m3, new Vector3(x, y, 0f), Quaternion.identity);
                        break;

                    // If the value is 4, instantiate m4 at the current grid position
                    case 4:
                        Instantiate(m4, new Vector3(x, y, 0f), Quaternion.identity);
                        break;

                    // If the value is 5, instantiate m5 at the current grid position
                    case 5:
                        Instantiate(m5, new Vector3(x, y, 0f), Quaternion.identity);
                        break;

                    // If the value is 6, instantiate m6 at the current grid position
                    case 6:
                        Instantiate(m6, new Vector3(x, y, 0f), Quaternion.identity);
                        break;

                    // If the value is 7, instantiate m7 at the current grid position
                    case 7:
                        Instantiate(m7, new Vector3(x, y, 0f), Quaternion.identity);
                        break;

                    default:
                        break;
                }

                // After placing an object, move the x position to the right for the next object
                x = x + 1.0f;
            }

            // After finishing a row, move the y position down and reset x position to the start
            y = y - 1.0f;
            x = -14.0f;
        }
    }
}
