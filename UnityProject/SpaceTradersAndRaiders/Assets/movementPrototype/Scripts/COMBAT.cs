using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COMBAT : State
{
    public COMBAT(gameManager system) : base(system)
    {
        Debug.Log("Welcome to Combat");
    }

    public override IEnumerator Combat(GameObject attacker, GameObject defender)
    {
        attacker = _system.attacker;
        defender = _system.defender;
        _system.StartCoroutine(attackerTurn());
        return base.Combat(attacker, defender);
    }

    IEnumerator attackerTurn()
    {
        Debug.Log("Attack(1) or FLee(2)?");
        /* if Attack 
        _system.StartCoroutine(fight());
        else
        flee();
        */
        yield return new WaitForSeconds(0f);
    }
    IEnumerator defenderTurn()
    {
        Debug.Log("Attack(1) or FLee(2)?");
        /* if Attack 
        _system.StartCoroutine(fight());
        else
        flee();
        */
        yield return new WaitForSeconds(0f);
    }

    IEnumerator fight()
    {
        //roll die for lasers and subtract health and armor
        yield return new WaitForSeconds(0f);
    }
    public void flee()
    {
        // should be defenders turn
        //_system.SetState(new PLAYER1TURN(_system));
    }
}
