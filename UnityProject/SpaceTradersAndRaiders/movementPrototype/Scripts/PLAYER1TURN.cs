using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class PLAYER1TURN : State
    {
        public PLAYER1TURN(gameManager system) : base(system)
        {
        _system.StartCoroutine(Player1Turn());
        }
    
    public override IEnumerator Player1Turn()
    {
        Debug.Log("Player 1, choose to MOVE, SKIP, or ATTACK, if you are close enough to an enemy");
        _system.StartCoroutine(_Player1Turn());

        
        return base.Player1Turn();
    }
    IEnumerator _Player1Turn()
    {
        
        yield return new WaitForSeconds(1f);
        if (_system.playerMoved) //not working for some reason
        {
            Debug.Log("Player1 Moved");
            _system.playerMoved = false;
            _system.SetState(new PLAYER2TURN(_system));
            yield return new WaitForSeconds(1f);
            
        }
        
        //if they initiate combat, gamestate changed to combat
    }

    
}

