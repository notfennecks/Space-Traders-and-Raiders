using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    [HideInInspector]
    public GameManager gameManager;
    public SpriteRenderer highlight;
    private GameObject playerShip1, playerShip2;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerShip1 = GameObject.Find("Player1Frigate1");
        playerShip2 = GameObject.Find("Player2Frigate1");
    }
    void OnMouseEnter()
    {
        if(gameManager.state == "BASE_SELECTION")
        {
            if(gameManager.BasesSelected == false && gameManager.Player1HomeTile != this.name)
            {
                highlight.enabled = true;
                Debug.Log(this.name);
            }
        }
    }
    void OnMouseExit()
    {
        if(gameManager.state == "BASE_SELECTION")
        {
            if(gameManager.BasesSelected == false)
            {
                highlight.enabled = false;
            }
        }
    }
    void OnMouseDown()
    {
        if(gameManager.state == "BASE_SELECTION")
        {
            if(gameManager.BaseSelectionTurn == 1)
            {
                gameManager.Player1HomeTile = this.name;
                gameManager.BaseSelectionTurn = 2;

                gameManager.Player1HomePlanet = this.transform.GetChild(1).name;
            }
            else if(gameManager.BaseSelectionTurn == 2)
            {
                if(this.name == gameManager.Player1HomeTile)
                {
                    return;
                }
                gameManager.Player2HomeTile = this.name;
                gameManager.BasesSelected = true;
                highlight.enabled = false;
                gameManager.Player2HomePlanet = this.transform.GetChild(1).name;
                gameManager.AssignStartingFacilities();
            }
        }
    }
}
