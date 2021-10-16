using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COMBAT : State
{
    private int choice = -1;
    public COMBAT(gameManager system) : base(system)
    {
        Debug.Log("Welcome to Combat");
        _system.StartCoroutine(Combat(_system.attacker, _system.defender));
    }

    public override IEnumerator Combat(GameObject attacker, GameObject defender)
    {
        attacker = _system.attacker;
        defender = _system.defender;
        Debug.Log("Attacker" + _system.attacker.gameObject.name + " Defender " + _system.defender.gameObject.name);
        _system.StartCoroutine(attackerTurn());
        return base.Combat(attacker, defender);
    }

    IEnumerator attackerTurn()
    {
        Debug.Log("Attack(1) or FLee(2)?");
        yield return _system.StartCoroutine(WaitForKeyDown(new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2 }));
        switch (choice)
        {
            case 1:
                _system.StartCoroutine(fight());
                break;
            case 2:
                flee();
                break;

        }
    }
    IEnumerator defenderTurn()
    {
        Debug.Log("Attack(1) or FLee(2)?");
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            yield return _system.StartCoroutine(fight());
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           flee();
        }
        yield return new WaitForSeconds(0f);
    }

    IEnumerator fight()
    {
        Debug.Log("In Fight");
        //roll die for lasers and subtract health and armor
        //then _system.StartCoroutine(defenderTurn());
        yield return new WaitForSeconds(0f);
    }
   public void flee()
    {
        Debug.Log("Fleeing");
        _system.StopCoroutine(attackerTurn());
        _system.StopCoroutine(defenderTurn());
        _system.StopCoroutine(attackerTurn());
        //roll die first to see if they can flee and then:
        string defenderName = _system.defender.gameObject.name;
        Debug.Log(defenderName);
        switch (defenderName)
        {
            case "Player1Ship":
                _system.SetState(new PLAYER1TURN(_system));
                break;
            case "Player2Ship":
                _system.SetState(new PLAYER2TURN(_system));
                break;
        }
        
        // should be defenders turn
    }
    IEnumerator WaitForKeyDown(KeyCode[] codes)
    {
        bool pressed = false;
        while (!pressed)
        {
            foreach (KeyCode k in codes)
            {
                if (Input.GetKey(k))
                {
                    pressed = true;
                    SetChoiceTo(k);
                    break;
                }
            }
           yield return new WaitForEndOfFrame();
        }
    }

    private void SetChoiceTo(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case (KeyCode.Alpha1):
                choice = 1;
                break;
            case (KeyCode.Alpha2):
                choice = 2;
                break;
        }
        Debug.Log(choice);
    }

  
}
