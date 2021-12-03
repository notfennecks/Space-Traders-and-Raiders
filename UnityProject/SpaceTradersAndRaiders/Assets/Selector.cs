using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    private UniverseMapManager universeMapManager;

    private void Start() 
    {
        universeMapManager = this.transform.root.GetComponent<UniverseMapManager>();
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked: " + this.name);

        //Sector View
        if(this.name.Contains("Sector"))
        {
            int tileNum = 0;
            if(this.name.Contains("1"))
            {
                tileNum = 1;
            }
            else if(this.name.Contains("2"))
            {
                tileNum = 2;
            }
            else if(this.name.Contains("3"))
            {
                tileNum = 3;
            }
            else if(this.name.Contains("4"))
            {
                tileNum = 4;
            }
            universeMapManager.SwitchToTileView(tileNum);
        }
    }
}
