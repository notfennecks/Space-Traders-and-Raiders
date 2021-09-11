using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCalculator : MonoBehaviour
{
    int players;
    int size;
    int totalTiles;
    
    void Start()
    {     
        players = Random.Range(2, 8);
        size = Random.Range(1, 3);
        totalTiles = calculateTotalTiles(players, size);
        Debug.Log("Players: " + players + " Size: " + size + " Tiles: " + totalTiles);
    }
    void Update()
    {
        
    }

    int calculateTotalTiles(int playerCount, int size)
    {
        int x;
        int y;
        x = players;
        y = players + (size - 1);
        int total = x * y;
        return total;
    }
}
