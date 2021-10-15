using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum GameState { START, PLAYER1TURN, PLAYER2TURN, COMBAT }
public class gameManager : MonoBehaviour
{
   // public GameState state;
    public GameObject playerPrefab, player1, player2, attacker, defender;
    [SerializeField] public GameObject[] Player;
    public movementScript moveScript;
    public bool playerMoved = false;
    public bool clickedOnPlayer = false;
    public State currentState;

    public void SetState(State state)
    {
        currentState = state;
        StartCoroutine(currentState.Start());
    }
    public void Start()
    {
        moveScript = GameObject.Find("movementScript").GetComponent<movementScript>();
        SetState(new START(system:this));

    }
    private void Update()
    {
        if (currentState.ToString() == "PLAYER1TURN")
        {
            if (playerMoved)
            {
                Debug.Log("Player1 Moved");
                playerMoved = false;
                SetState(new PLAYER2TURN(system: this));

            }
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider.tag == "Player" && hit.collider.name != "Player1")
                {
                    float distY = Mathf.Abs((player1.transform.position.y - hit.collider.gameObject.transform.position.y));
                    float distX = Mathf.Abs((player1.transform.position.x - hit.collider.gameObject.transform.position.x));
                    if (distY <= 1 && distX <= 1)
                    {
                        Debug.Log(hit.collider.name);
                        attacker = player1;
                        defender = hit.collider.gameObject;
                        SetState(new COMBAT(system: this));
                    }
                }
            }

        }
        if (currentState.ToString() == "PLAYER2TURN")
        {
            if (playerMoved)
            {
                Debug.Log("Player2 Moved");
                playerMoved = false;
                SetState(new PLAYER1TURN(system: this));

            }
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider.tag == "Player" && hit.collider.name != "Player2")
                {
                    float distY = Mathf.Abs((player1.transform.position.y - hit.collider.gameObject.transform.position.y));
                    float distX = Mathf.Abs((player1.transform.position.x - hit.collider.gameObject.transform.position.x));
                    if (distY <= 1 && distX <= 1)
                    {
                        Debug.Log(hit.collider.name);
                        attacker = player2;
                        defender = hit.collider.gameObject;
                        SetState(new COMBAT(system: this));
                    }
                }
            }
        }
    }
    
    private void  Player1Turn()
    {
        SetState(new PLAYER1TURN(system: this));
    }
    private void Player2Turn()
    {
        SetState(new PLAYER2TURN(system: this));
    }
    

   
}