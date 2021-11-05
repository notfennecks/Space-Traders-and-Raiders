using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileScript : MonoBehaviour
{
    [SerializeField] private Color originalColor;
    [SerializeField] private GameObject highlightedTile;
    [SerializeField] private GameObject playerShip1, playerShip2;
    private bool p1inMoveRange = false;
    private bool p2inMoveRange = false;
    public GameManager gameManager;

    // Start is called before the first frame update
    public void Start()
    {
        if (playerShip1 == null || playerShip2 == null)
        {
            StartCoroutine(assignVariables());
        }
    }
    
    IEnumerator assignVariables()
    {
        yield return new WaitForSeconds(.5f);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerShip1 = GameObject.Find("Player1Ship");
        playerShip2 = GameObject.Find("Player2Ship");
    }
    public void OnMouseDown()
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
    public void OnMouseEnter()
    {
        //for player1
        float distYP1 = Mathf.Abs((playerShip1.transform.position.y - transform.position.y));
        float distXP1 = Mathf.Abs((playerShip1.transform.position.x - transform.position.x));
        if (gameManager.currentState.ToString() == "PLAYER1TURN" && distYP1 < 3 && distXP1 < 3)
        {
            highlightedTile.SetActive(true);
            p1inMoveRange = true;
        }
        else { p1inMoveRange = false; }

        //for player2
        float distYP2 = Mathf.Abs((playerShip2.transform.position.y - transform.position.y));
        float distXP2 = Mathf.Abs((playerShip2.transform.position.x - transform.position.x));
        if (gameManager.currentState.ToString() == "PLAYER2TURN" && distYP2 < 3 && distXP2 < 3)
        {
            highlightedTile.SetActive(true);
            p2inMoveRange = true;
        }
        else { p2inMoveRange = false; }
    }

    public void OnMouseExit()
    {
        highlightedTile.SetActive(false);
    }
}
