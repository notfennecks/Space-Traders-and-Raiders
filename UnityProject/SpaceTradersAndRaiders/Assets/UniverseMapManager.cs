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


    void Start() 
    {
        viewMode = "Sector";
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

        if(Input.GetKeyDown("space") && GlobalData.State == "BASE_SELECTION" && viewMode == "Planet")
        {
            if(GlobalData.BaseSelectTracker == 1)
            {
                GlobalData.Player1HomeSector = currentSector;
                string planetName = currentPlanetView.name.Replace("Tile", "");
                GlobalData.Player1HomePlanet = int.Parse(planetName);
                GlobalData.BaseSelectTracker++;
            }
            else if(GlobalData.BaseSelectTracker == 2)
            {
                if(GlobalData.Player1HomeSector != currentSector)
                {
                    GlobalData.Player2HomeSector = currentSector;
                    string planetName = currentPlanetView.name.Replace("Tile", "");
                    GlobalData.Player2HomePlanet = int.Parse(planetName);
                    GlobalData.BaseSelectTracker++;
                }
            }
        }
    }

    public void SwitchToSectorView()
    {
        viewMode = "Sector";
        SectorView.SetActive(true);
        TileViews.SetActive(false);
        PlanetViews.SetActive(false);
    }

    public void SwitchToTileView(int sector)
    {
        viewMode = "Tile";
        TileViews.SetActive(true);
        SectorView.SetActive(false);
        PlanetViews.SetActive(false);
        if(sector == 1)
        {
            TileViews.transform.GetChild(0).gameObject.SetActive(true);
            TileViews.transform.GetChild(1).gameObject.SetActive(false);
            TileViews.transform.GetChild(2).gameObject.SetActive(false);
            TileViews.transform.GetChild(3).gameObject.SetActive(false);
        }
        if(sector == 2)
        {
            TileViews.transform.GetChild(0).gameObject.SetActive(false);
            TileViews.transform.GetChild(1).gameObject.SetActive(true);
            TileViews.transform.GetChild(2).gameObject.SetActive(false);
            TileViews.transform.GetChild(3).gameObject.SetActive(false);
        }
        if(sector == 3)
        {
            TileViews.transform.GetChild(0).gameObject.SetActive(false);
            TileViews.transform.GetChild(1).gameObject.SetActive(false);
            TileViews.transform.GetChild(2).gameObject.SetActive(true);
            TileViews.transform.GetChild(3).gameObject.SetActive(false);
        }
        if(sector == 4)
        {
            TileViews.transform.GetChild(0).gameObject.SetActive(false);
            TileViews.transform.GetChild(1).gameObject.SetActive(false);
            TileViews.transform.GetChild(2).gameObject.SetActive(false);
            TileViews.transform.GetChild(3).gameObject.SetActive(true);
        }

    }

    public void SwitchToPlanetView(int sector, int tile)
    {
        if(PlanetViews.transform.GetChild(sector - 1).transform.GetChild(tile - 1).gameObject.transform.childCount == 0)
        {
            return;
        }
        else
        {
            viewMode = "Planet";
            PlanetViews.SetActive(true);
            HidePlanets();
            TileViews.SetActive(false);
            PlanetViews.transform.GetChild(sector - 1).transform.GetChild(tile - 1).gameObject.SetActive(true);
            currentPlanetView = PlanetViews.transform.GetChild(sector - 1).transform.GetChild(tile - 1).gameObject;
            currentSector = sector;
        }
    }

    private void HidePlanets()
    {
        for(int i = 0; i < 4; i++)
        {
            for(int x = 0; x < 16; x++)
            {
                PlanetViews.transform.GetChild(i).transform.GetChild(x).gameObject.SetActive(false);
            }
        }
    }

}
