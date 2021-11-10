using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PLAYER1TURN : State
    {
        public PLAYER1TURN(GameManager system) : base(system)
        {
        _system.StartCoroutine(Player1Turn());
        }
    
    public override IEnumerator Player1Turn()
    {
        Debug.Log("Player 1, choose to MOVE, SKIP, or ATTACK, if you are close enough to an enemy. Press (1) to end your turn.");
        foreach(Transform player1Ship in GlobalData.Player1Obj.transform)
        {
            player1Ship.GetComponent<movementScript>().movesLeft = 1;
        }
        _system.StartCoroutine(_Player1Turn());

        
        return base.Player1Turn();
    }
    IEnumerator _Player1Turn()
    {

        /* if (_system.playerMoved) //not working for some reason
         {
             Debug.Log("Player1 Moved");
             _system.playerMoved = false;
             _system.SetState(new PLAYER2TURN(_system));
             yield return new WaitForSeconds(1f);

         }*/
         
        
        yield return new WaitForSeconds(1f);

        //if they initiate combat, gamestate changed to combat
    }


    
}

