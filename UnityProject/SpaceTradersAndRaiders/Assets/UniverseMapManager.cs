using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseMapManager : MonoBehaviour
{
    public string viewMode;
    private int currentSector;
    private GameObject currentPlanetView = null;

    public GameObject SectorView;
    public GameObject TileViews;
    public GameObject PlanetViews;


    public Camera camera;
    private Vector2 defaultCamPos = new Vector2(0f, 0f);
    private Vector2 sector1CamPos = new Vector2(-1.62f, 1.6f);
    private Vector2 sector2CamPos = new Vector2(1.62f, 1.6f);
    private Vector2 sector3CamPos = new Vector2(-1.63f, -1.63f);
    private Vector2 sector4CamPos = new Vector2(1.62f, -1.63f);


    void Start() 
    {
        viewMode = "Sector";
        camera.orthographicSize = 3.5f;
        SectorView.SetActive(true);
        TileViews.SetActive(false);
        PlanetViews.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if(viewMode == "Tile")
            {
                SwitchToSectorView();
            }
            if(viewMode == "Planet")
            {
                SwitchToTileView(currentSector);
            }
        }
    }

    public void SwitchToSectorView()
    {
        camera.orthographicSize = 3.5f;
        camera.transform.position = defaultCamPos;
        viewMode = "Sector";
        SectorView.SetActive(true);
        TileViews.SetActive(false);
        PlanetViews.SetActive(false);
    }

    public void SwitchToTileView(int sector)
    {
        camera.orthographicSize = 1.7f;
        viewMode = "Tile";
        TileViews.SetActive(true);
        SectorView.SetActive(false);
        PlanetViews.SetActive(false);
        if(sector == 1)
        {
            camera.transform.position = sector1CamPos;
            TileViews.transform.GetChild(0).gameObject.SetActive(true);
            TileViews.transform.GetChild(1).gameObject.SetActive(false);
            TileViews.transform.GetChild(2).gameObject.SetActive(false);
            TileViews.transform.GetChild(3).gameObject.SetActive(false);
        }
        if(sector == 2)
        {
            camera.transform.position = sector2CamPos;
            TileViews.transform.GetChild(0).gameObject.SetActive(false);
            TileViews.transform.GetChild(1).gameObject.SetActive(true);
            TileViews.transform.GetChild(2).gameObject.SetActive(false);
            TileViews.transform.GetChild(3).gameObject.SetActive(false);
        }
        if(sector == 3)
        {
            camera.transform.position = sector3CamPos;
            TileViews.transform.GetChild(0).gameObject.SetActive(false);
            TileViews.transform.GetChild(1).gameObject.SetActive(false);
            TileViews.transform.GetChild(2).gameObject.SetActive(true);
            TileViews.transform.GetChild(3).gameObject.SetActive(false);
        }
        if(sector == 4)
        {
            camera.transform.position = sector4CamPos;
            TileViews.transform.GetChild(0).gameObject.SetActive(false);
            TileViews.transform.GetChild(1).gameObject.SetActive(false);
            TileViews.transform.GetChild(2).gameObject.SetActive(false);
            TileViews.transform.GetChild(3).gameObject.SetActive(true);
        }

    }

    public void SwitchToPlanetView(int sector, int tile)
    {
        camera.orthographicSize = 3.5f;
        camera.transform.position = defaultCamPos;
        viewMode = "Planet";
        TileViews.SetActive(false);
        PlanetViews.SetActive(true);
        PlanetViews.transform.GetChild(sector - 1).transform.GetChild(tile - 1).gameObject.SetActive(true);
        currentPlanetView = PlanetViews.transform.GetChild(sector - 1).transform.GetChild(tile - 1).gameObject;
        currentSector = sector;
    }

}
