using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum GameState { START, PLAYER1TURN, PLAYER2TURN, COMBAT }
public class gameManager : MonoBehaviour
{
   // public GameState state;
    public GameObject playerPrefab, player1, player2;
    [SerializeField] public GameObject[] Player;
    public movementScript moveScript;
    public bool playerMoved = false;
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
        }
        if (currentState.ToString() == "PLAYER2TURN")
        {
            if (playerMoved)
            {
                Debug.Log("Player2 Moved");
                playerMoved = false;
                SetState(new PLAYER1TURN(system: this));

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