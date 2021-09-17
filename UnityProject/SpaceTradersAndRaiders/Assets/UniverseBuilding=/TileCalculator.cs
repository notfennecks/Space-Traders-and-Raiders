using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCalculator : MonoBehaviour
{    
    public Vector3 totalTiles;  //Stores all values needed for universe building
    void Start()
    {
        int players = Random.Range(2, 8);
        int size = Random.Range(1, 3);
        totalTiles = calculateTotalTiles(players, size);
        Debug.Log("Player count:" + players + " size:" + size);
        Debug.Log("x:" + totalTiles.x + " y:" + totalTiles.y + " total:" + totalTiles.z);
    }

    private Vector3 calculateTotalTiles(int playerCount, int size)
    {
        //x and y are width and height
        int xSize = playerCount;
        int ySize = playerCount + (size - 1);
        int total = xSize * ySize;
        Vector3 dimensions = new Vector3(xSize, ySize, total);
        return dimensions;
    }
}
