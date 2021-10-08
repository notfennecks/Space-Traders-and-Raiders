using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridScript : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Camera cam;
    [SerializeField] private movementScript movementScript;
    // Start is called before the first frame update

    public void Start()
    {
        GenerateGrid();
    }
    public void GenerateGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = "Tile" + (x) + (y);
            }
        }
        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
        if (width > height)
        {
            cam.orthographicSize = (float)height - 6f;
        }
        else
        {
            cam.orthographicSize = (float)width - 6f;
        }
    }
}
