using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreatorAI : MonoBehaviour
{
    TileCalculator tileCalc;  //Variable of TileCalculatur(script) type named tileCalc. We can access all public variables in TileCalculator script via "tileCalc" name.
    private Vector2Int uniDim;  //Vector2 for storing dimension data.
    void Start()
    {
        tileCalc = GetComponent<TileCalculator>();  //Sets tileCalc equal to script componenet TileCalculator. This is needed for referencing variables in that script.
        uniDim.x = (int)tileCalc.totalTiles.x;  //Copies data values over.
        uniDim.y = (int)tileCalc.totalTiles.y;
        Debug.Log("Dimensions are x: " + uniDim.x + " y: " + uniDim.y);  //Simple debug log

        //-------------------2D Array for displaying map tile status-------------------
        int[,] universe = new int[uniDim.x, uniDim.y]; //Creates 2D array with dimensions equal to # of players and map size
        //Key
        //0: null
        //1: Can place tile
        //2: Populated
        for (int i = 0; i < universe.GetLength(0); i++)
        {
            for (int j = 0; j < universe.GetLength(1); j++)
            {
                universe[i, j] = 0;
            }
        }
        PlayerPlaceTile(1);
        //-----------------------------------------------------------------------------

    }

    void PlayerPlaceTile(int playerNumber)
    {
        universe[1,1] = 1;
    }

    void Update()
    {
        
    }
}
