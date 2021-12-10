using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    private UniverseMapManager universeMapManager;

    private void Start() 
    {
        universeMapManager = this.transform.root.GetChild(2).GetComponent<UniverseMapManager>();
    }

    private void OnMouseDown()
    {
        
        //Sector View
        if(this.name.Contains("Sector"))
        {
            int sectorNum = 0;
            if(this.name.Contains("1"))
            {
                sectorNum = 1;
            }
            else if(this.name.Contains("2"))
            {
                sectorNum = 2;
            }
            else if(this.name.Contains("3"))
            {
                sectorNum = 3;
            }
            else if(this.name.Contains("4"))
            {
                sectorNum = 4;
            }
            universeMapManager.SwitchToTileView(sectorNum);
        }

        //Tile View
        if(this.name.Contains("Tile"))
        {
            string tileNum = this.name.Remove(0, 4);
            string sectorNum = this.transform.parent.name.Remove(0, 8);
            universeMapManager.SwitchToPlanetView(int.Parse(sectorNum), int.Parse(tileNum));
            
        }
    }
}
