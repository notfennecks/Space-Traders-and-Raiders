using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER2TURN : State
{

    public PLAYER2TURN(GameManager system) : base(system)
    {
        _system.StartCoroutine(Player2Turn());
    }

    public override IEnumerator Player2Turn()
    {
        Debug.Log("Player 2, choose to MOVE, SKIP, or ATTACK, if you are close enough to an enemy");
        _system.StartCoroutine(_Player2Turn());
        return base.Player2Turn();
    }

    IEnumerator _Player2Turn()
    {
       
       /* if (_system.playerMoved)
        {
            Debug.Log("Player2 Moved");
            _system.playerMoved = false;
            _system.SetState(new PLAYER1TURN(_system));
            yield return new WaitForSeconds(1f);

        }*/
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);

                
            }
            
        }
        yield return new WaitForSeconds(1f);
        //if they initiate combat, gamestate changed to combat
    }



}