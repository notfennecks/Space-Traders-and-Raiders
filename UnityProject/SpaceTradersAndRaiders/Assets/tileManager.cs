using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    [HideInInspector]
    public GameManager gameManager;
    public SpriteRenderer highlight;
    public GameObject playerShip1, playerShip2;
    private bool p1inMoveRange = false;
    private bool p2inMoveRange = false;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    private void Update()
    {
        if (playerShip1 == null)
        {
            playerShip1 = GameObject.Find("Player1Frigate1");
        }
        if (playerShip2 == null)
        {
            playerShip2 = GameObject.Find("Player2Frigate1");
        }
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
        if (gameManager.state == "MOVE") 
        {
            //for player1
            float distYP1 = Mathf.Abs((playerShip1.transform.position.y - transform.position.y));
            float distXP1 = Mathf.Abs((playerShip1.transform.position.x - transform.position.x));
            if (gameManager.currentState.ToString() == "PLAYER1TURN" && distYP1 <= 5 && distXP1 <= 5)
            {
                highlight.enabled = true;
                p1inMoveRange = true;
            }
            else { p1inMoveRange = false; }

            //for player2
            float distYP2 = Mathf.Abs((playerShip2.transform.position.y - transform.position.y));
            float distXP2 = Mathf.Abs((playerShip2.transform.position.x - transform.position.x));
            if (gameManager.currentState.ToString() == "PLAYER2TURN" && distYP2 <= 5 && distXP2 <= 5)
            {
                highlight.enabled = true;
                p2inMoveRange = true;
            }
            else { p2inMoveRange = false; }
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
        if (gameManager.state == "MOVE")
        {
            highlight.enabled = false;
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
        if (gameManager.state == "MOVE") 
        {
            if (p1inMoveRange)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y);
                playerShip1.SendMessage("MovePlayer", pos);

            }
            if (p2inMoveRange)
            {
                Vector3 pos = new Vector3(transform.position.x, transform.position.y);
                playerShip2.SendMessage("MovePlayer", pos);
            }
        }
    }
}
