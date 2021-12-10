using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    [HideInInspector]
    public GameManager gameManager;
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
        if (gameManager.state == "MOVE")
        {
            //for player1
            foreach (Transform playerShips in GlobalData.Player1Obj.transform)
            {
                movementScript player1Ships = playerShips.GetComponent<movementScript>();
                float distYP1 = Mathf.Abs((playerShips.transform.position.y - transform.position.y));
                float distXP1 = Mathf.Abs((playerShips.transform.position.x - transform.position.x));
                if (gameManager.currentState.ToString() == "PLAYER1TURN" && distYP1 <= 5 && distXP1 <= 5 && player1Ships.movesLeft >=1)
                {
                    //p1inMoveRange = true;
                    playerShips.GetComponent<movementScript>().inRange = true;
                }
                else { playerShips.GetComponent<movementScript>().inRange = false; }
            }
            //for player2
            foreach (Transform playerShips in GlobalData.Player2Obj.transform)
            {
                movementScript player2Ships = playerShips.GetComponent<movementScript>();
                float distYP2 = Mathf.Abs((playerShips.transform.position.y - transform.position.y));
                float distXP2 = Mathf.Abs((playerShips.transform.position.x - transform.position.x));
                if (gameManager.currentState.ToString() == "PLAYER2TURN" && distYP2 <= 5 && distXP2 <= 5 && player2Ships.movesLeft >=1)
                {
                    //p2inMoveRange = true;
                    playerShips.GetComponent<movementScript>().inRange = true;
                }
                else { playerShips.GetComponent<movementScript>().inRange = false; }
            }
        }
    }
    void OnMouseExit()
    {
       
    }

    void OnMouseDown()
    {
       
        if(gameManager.state == "BASE_SELECTION")
        {
            if(gameManager.BaseSelectionTurn == 1)
            {
                Debug.Log("base: " + this.name);
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
                gameManager.Player2HomePlanet = this.transform.GetChild(1).name;
                gameManager.AssignStartingFacilities();
            }
        }

        if (gameManager.state == "MOVE") 
        {
            foreach (Transform player1Ships in GlobalData.Player1Obj.transform)
            {
                movementScript player1Ship = player1Ships.GetComponent<movementScript>();
                if (player1Ship.inRange == true && player1Ship.movesLeft >=1)
                {
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y);
                    player1Ships.SendMessage("MovePlayer", pos); // needs to be tested for multiple ships controlled by player1. This might move all of their ships in range at once
                    player1Ship.movesLeft--;
                }
            }
            foreach (Transform player2Ships in GlobalData.Player2Obj.transform)
            {
                movementScript player2Ship = player2Ships.GetComponent<movementScript>();
                if (player2Ship.inRange == true && player2Ship.movesLeft >=1)
                {
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y);
                    player2Ships.SendMessage("MovePlayer", pos); // needs to be tested for multiple ships controlled by player2. This might move all of their ships in range at once
                    player2Ship.movesLeft--;
                }
            }
        }
    }
}
