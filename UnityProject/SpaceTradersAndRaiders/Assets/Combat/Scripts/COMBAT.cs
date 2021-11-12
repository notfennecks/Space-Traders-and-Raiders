using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class COMBAT : State
{
    private int choice = 0;
    public bool buttonPressed = false;
    public GameObject attacker, defender, attackButton, fleeButton;
    public shipDataScript attackerData, defenderData;
    public int attackerSuccessfulRolls = 0;
    public int defenderSuccessfulRolls = 0;
    public bool attackersTurn = false;
    public bool attackerWantsToFlee = false;
    public bool defenderWantsToFlee = false;
    public COMBAT(GameManager system) : base(system)
    {
        SceneManager.LoadScene("Combat UI");
        Debug.Log("Welcome to Combat");
        // attacker = _system.attacker;
        attacker = _system.attacker;
        attackerData = attacker.GetComponent<shipDataScript>();


        // defender = _system.defender;
        defender = _system.defender;
        defenderData = defender.GetComponent<shipDataScript>();
        Debug.Log(choice);

        _system.StartCoroutine(Combat(_system.attacker, _system.defender));

    }

    public override IEnumerator Combat(GameObject attacker, GameObject defender)
    {
        
        attacker = _system.attacker;
        defender = _system.defender;
        Debug.Log("Attacker" + _system.attacker.gameObject.name + " Defender " + _system.defender.gameObject.name);
        //attackButton = GameObject.Find("attackBtn");
        //fleeButton = GameObject.Find("fleeBtn");
        _system.StartCoroutine(attackerTurn());
        return base.Combat(attacker, defender);
    }

    IEnumerator attackerTurn()
    {
        
        resetButton();
        attackerWantsToFlee = false;
        attackersTurn = true;
        Debug.Log("Attacker, Attack, Skip, or Attempt to Flee?");
        while (!_system.buttonPressed)
        {
            yield return null;
        }
                
        
        Debug.Log(_system.choice);
        switch (_system.choice)
        {

            case 1:
                _system.choice = 0;
                if (attackerData.laserBeams.Count <= 0)
                {

                    Debug.Log("You cannot fight because you do not have any weapons, changing decision to flee...");
                    attackerWantsToFlee = true;
                    break;
                }
                else { attackerWantsToFlee = false; }
                break;
            case 2:
                _system.choice = 0;
                if (attackerData.Engines.Count <= 0)
                {
                    Debug.Log("You cannot flee because you have no engines remaining. Fight(1) or Surrender(2)(surrender not available in prototype)");
                    attackerWantsToFlee = false;

                }
                else { attackerWantsToFlee = true; }
                break;
            

        }
        _system.choice = 0;
        _system.buttonPressed = false;
        _system.StartCoroutine(defenderTurn());
    }
    IEnumerator defenderTurn()
    {

        _system.choice = 0;
        defenderWantsToFlee = false;
        attackersTurn = false;
        Debug.Log("Defender, Attack, Skip, or Attempt to Flee?");
        while (!_system.buttonPressed)
        {
            yield return null;
        }


        Debug.Log(_system.choice);
        switch (_system.choice)
        {
            case 1:
                _system.choice = 0;
                if (defenderData.laserBeams.Count <= 0)
                {
                    Debug.Log("You cannot fight because you do not have any weapons, changing decision to flee...");
                    defenderWantsToFlee = true;
                    break;
                }
                else { defenderWantsToFlee = false; }
                break;
            case 2:
                _system.choice = 0;
                if (defenderData.Engines.Count <= 0)
                {
                    Debug.Log("You cannot flee because you have no engines remaining. Fight(1) or Surrender(2)(surrender not available in prototype)");
                    defenderWantsToFlee = false;

                }
                else { defenderWantsToFlee = true; }
                break;
            

        }
        _system.choice = 0;
        _system.buttonPressed = false;
        determineDecisions();
    }

    private void determineDecisions()
    {

        choice = 0;
        if (attackerWantsToFlee && defenderWantsToFlee) // both want to flee
        {
            Debug.Log("Both players wish to flee, fleeing...");
            flee();
        }
        else if (!attackerWantsToFlee && !defenderWantsToFlee) //both want to fight
        {
            if (attackerData.laserBeams.Count <= 0 && defenderData.laserBeams.Count <= 0) //noone has weapons
            {
                Debug.Log("Nobody has any weapons, fleeing battle...");
                flee();
            }
            else if (attackerData.laserBeams.Count <= 0 && defenderData.laserBeams.Count > 0) //attacker doesn't have weapons
            {
                Debug.Log("Attacker, you do not have any weapons, attempt to Run or Surrender? (No surrender in prototype, destroys instead)");
                


                Debug.Log(_system.choice);
                switch (_system.choice)
                {
                    
                    case 2:
                        _system.choice = 0;
                        if (attackerData.Engines.Count <= 0)
                        {
                            Debug.Log("You cannot flee because you do not have any engines. Surrenduring... (destroy in prototype)");

                            string attackerName1 = _system.attacker.gameObject.name;
                            switch (attackerName1)
                            {
                                case "Player1Ship":
                                    GameObject.Destroy(attacker.gameObject);
                                    _system.SetState(new PLAYER1TURN(_system));
                                    break;
                                case "Player2Ship":
                                    GameObject.Destroy(attacker.gameObject);
                                    _system.SetState(new PLAYER2TURN(_system));
                                    break;
                            }

                        }
                        else
                        {
                            defenderData.isChasingPLayer = true;
                            attemptFlee();
                        }
                        break;
                    case 3:
                        _system.choice = 0;
                        Debug.Log("Surrendering (Destroy in prototype)");
                        string attackerName2 = _system.attacker.gameObject.name;
                        switch (attackerName2)
                        {
                            case "Player1Ship":
                                GameObject.Destroy(attacker.gameObject);
                                _system.SetState(new PLAYER1TURN(_system));
                                break;
                            case "Player2Ship":
                                GameObject.Destroy(attacker.gameObject);
                                _system.SetState(new PLAYER2TURN(_system));
                                break;
                        }
                        break;
                    


                }

                choice = 0;
            }
            else if (attackerData.laserBeams.Count > 0 && defenderData.laserBeams.Count <= 0) //defender doesn't have weapons
            {
                Debug.Log("Defender, you do not have any weapons, attempt to Run or Surrender? (No surrender in prototype, destroys instead)");
               


                Debug.Log(_system.choice);
                switch (_system.choice)
                {
                    
                    case 2:
                        _system.choice = 0;
                        if (defenderData.Engines.Count <= 0)
                        {
                            Debug.Log("You cannot flee because you do not have any engines. Surrenduring... (destroy in prototype)");

                            string defenderName1 = _system.defender.gameObject.name;
                            switch (defenderName1)
                            {
                                case "Player1Ship":
                                    GameObject.Destroy(defender.gameObject);
                                    _system.SetState(new PLAYER1TURN(_system));
                                    break;
                                case "Player2Ship":
                                    GameObject.Destroy(defender.gameObject);
                                    _system.SetState(new PLAYER2TURN(_system));
                                    break;
                            }

                        }
                        else
                        {
                            attackerData.isChasingPLayer = true;
                            attemptFlee();
                        }
                        break;
                    case 3:
                        _system.choice = 0;
                        Debug.Log("Surrendering (Destroy in prototype)");
                        string defenderName2 = _system.defender.gameObject.name;
                        switch (defenderName2)
                        {
                            case "Player1Ship":
                                GameObject.Destroy(defender.gameObject);
                                _system.SetState(new PLAYER1TURN(_system));
                                break;
                            case "Player2Ship":
                                GameObject.Destroy(defender.gameObject);
                                _system.SetState(new PLAYER2TURN(_system));
                                break;
                        }
                        break;
                    

                }

                choice = 0;
            }

            else { _system.StartCoroutine(fight()); } //both have weapons, fight
        }

        else if (attackerWantsToFlee && !defenderWantsToFlee) //attacker wants to flee and defender wants to fight
        {
            if (attackerData.Engines.Count <= 0)
            {
                Debug.Log("Attacker, you do not have any Engines, try to Attack or Surrender? (No surrender in prototype, destroys instead)");

                Debug.Log(_system.choice);
                switch (_system.choice)
                {
                    case 1:
                        _system.choice = 0;
                        if (attackerData.laserBeams.Count <= 0)
                        {
                            Debug.Log("You cannot fight back because you do not have any weapons. Surrenduring... (destroy in prototype)");

                            string attackerName1 = _system.attacker.gameObject.name;
                            switch (attackerName1)
                            {
                                case "Player1Ship":
                                    GameObject.Destroy(attacker.gameObject);
                                    _system.SetState(new PLAYER1TURN(_system));
                                    break;
                                case "Player2Ship":
                                    GameObject.Destroy(attacker.gameObject);
                                    _system.SetState(new PLAYER2TURN(_system));
                                    break;
                            }

                        }
                        else if (defenderData.laserBeams.Count > 0) { fight(); }
                        break;
                    
                    case 3:
                        _system.choice = 0;
                        Debug.Log("Surrendering (Destroy in prototype)");
                        string attackerName2 = _system.attacker.gameObject.name;
                        switch (attackerName2)
                        {
                            case "Player1Ship":
                                GameObject.Destroy(attacker.gameObject);
                                _system.SetState(new PLAYER1TURN(_system));
                                break;
                            case "Player2Ship":
                                GameObject.Destroy(attacker.gameObject);
                                _system.SetState(new PLAYER2TURN(_system));
                                break;
                        }
                        break;
                    


                }

                choice = 0;
            }
            if (defenderData.laserBeams.Count <= 0) //defender wants to fight but doesn't have any weapons
            {
                Debug.Log("Defender, you do not have any weapons, fleeing...");
                flee();
            }

            else
            {
                defenderData.isChasingPLayer = true;
                attemptFlee();
            }
        }


        else if (!attackerWantsToFlee && defenderWantsToFlee) //attacker wants to fight and defender wants to flee
        {
            if (defenderData.Engines.Count <= 0)
            {
                Debug.Log("Defender, you do not have any Engines, try to Attack or Surrender? (No surrender in prototype, destroys instead)");


                Debug.Log(_system.choice);
                switch (_system.choice)
                {
                    case 1:
                        _system.choice = 0;
                        if (defenderData.laserBeams.Count <= 0)
                        {
                            Debug.Log("You cannot fight back because you do not have any weapons. Surrenduring... (destroy in prototype)");

                            string defenderName1 = _system.defender.gameObject.name;
                            switch (defenderName1)
                            {
                                case "Player1Ship":
                                    GameObject.Destroy(defender.gameObject);
                                    _system.SetState(new PLAYER1TURN(_system));
                                    break;
                                case "Player2Ship":
                                    GameObject.Destroy(defender.gameObject);
                                    _system.SetState(new PLAYER2TURN(_system));
                                    break;
                            }

                        }
                        else if (attackerData.laserBeams.Count > 0) { fight(); }
                        break;
                    

                    case 3:
                        _system.choice = 0;
                        Debug.Log("Surrendering (Destroy in prototype)");
                        string defenderName2 = _system.defender.gameObject.name;
                        switch (defenderName2)
                        {
                            case "Player1Ship":
                                GameObject.Destroy(defender.gameObject);
                                _system.SetState(new PLAYER1TURN(_system));
                                break;
                            case "Player2Ship":
                                GameObject.Destroy(defender.gameObject);
                                _system.SetState(new PLAYER2TURN(_system));
                                break;
                        }
                        break;
                        



                }

                choice = 0;
            }
            if (attackerData.laserBeams.Count <= 0) //attacker wants to fight but doesn't have any weapons
            {
                Debug.Log("Attacker, you do not have any weapons, fleeing...");
                flee();
            }

            else
            {
                attackerData.isChasingPLayer = true;
                attemptFlee();
            }
        }
        
    }
    IEnumerator fight()
    {

        choice = 0;
        Debug.Log("In Combat");
        fireLaserBeams();    //roll die for lasers and subtract health and armor
        _system.StartCoroutine(dealDamageToDefender());
        _system.StartCoroutine(dealDamageToAttacker());
        if (attackersTurn)
        {
           _system.StartCoroutine(defenderTurn());
        }
        else
        {
            _system.StartCoroutine(attackerTurn());
        }


        yield return new WaitForSeconds(0f);
    }
    public void attemptFlee()
    {

        choice = 0;
        Debug.Log("Attempting to flee");
        int chasingPlayersEngines;
        int fleeingPlayersEngines;
        if (attackerData.isChasingPLayer)
        {
            chasingPlayersEngines = attackerData.Engines.Count;
            fleeingPlayersEngines = defenderData.Engines.Count;
        }
        else
        {
            chasingPlayersEngines = defenderData.Engines.Count;
            fleeingPlayersEngines = attackerData.Engines.Count;
        }
        int chasingPlayerNum = rollDie() + chasingPlayersEngines;
        int fleeingPlayerNum = rollDie() + fleeingPlayersEngines;
        if (fleeingPlayerNum >= (chasingPlayerNum * 2))
        {
            attackerData.isChasingPLayer = false;
            defenderData.isChasingPLayer = false;
            flee(); //flee immediately
        }
        else if (fleeingPlayerNum > chasingPlayerNum && fleeingPlayerNum < chasingPlayerNum * 2)
        {
            attackerData.isChasingPLayer = false;
            defenderData.isChasingPLayer = false;
            fight();
            //flee after 1 more round of fighting
        }
        else
        {
            attackerData.isChasingPLayer = false;
            defenderData.isChasingPLayer = false;
            fight();
        }
        
    }
   public void flee()
    {

        choice = 0;
        Debug.Log("Fleeing");
        _system.StopCoroutine(attackerTurn());
        _system.StopCoroutine(defenderTurn());
        /*string fleeingPlayersName;
        if (attackerData.isChasingPLayer)
        {
            fleeingPlayersName = defender.name;
        }
        else
        {
            fleeingPlayersName = attacker.name;
        }
        switch (fleeingPlayersName)
        {
            case "Player1Ship":
                attackerData.isChasingPLayer = false;
                defenderData.isChasingPLayer = false;
                _system.SetState(new PLAYER1TURN(_system));
                break;
            case "Player2Ship":
                attackerData.isChasingPLayer = false;
                defenderData.isChasingPLayer = false;
                _system.SetState(new PLAYER2TURN(_system));
                break;
        }*/

        switch (_system.attacker.gameObject.name)
        {
            case "Player1Ship":
                _system.SetState(new PLAYER1TURN(_system));
                break;
            case "Player2Ship":
                _system.SetState(new PLAYER2TURN(_system));
                break;
        }
        
       
    }
    
   

    private void fireLaserBeams()
    {
        if (attackerData.laserBeams.Count > 0)
        {
            foreach (int i in attackerData.laserBeams)
            {
                int result = rollDie();
                if (result <= 3)
                {
                    attackerSuccessfulRolls++;
                }

            }
        }
        if (defenderData.laserBeams.Count > 0)
        {
            foreach (int i in defenderData.laserBeams)
            {
                int result = rollDie();
                if (result <= 3)
                {
                    defenderSuccessfulRolls++;
                }

            }
        }
        Debug.Log("Attacker fired " + attackerSuccessfulRolls + " laser beams");
        Debug.Log("Defender fired " + defenderSuccessfulRolls + " laser beams");
    }
    IEnumerator dealDamageToDefender()
    {

        choice = 0;
        if (defenderData.armor > 0)
        {
            defenderData.armor -= attackerSuccessfulRolls;
        }
        else
        {
            //this is where the player will select the ties on the ship gris 
           
            //**********************************************************************

            /*Debug.Log("Attacker, target empty component for Critical Hit(1), Laser Beams(2), or Engines(3)?");      
            yield return _system.StartCoroutine(WaitForKeyDown(new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3 }));
            _system.StopCoroutine("WaitForKeyDown");
            switch (choice)
            {
                
                case 1:
                    defenderData.criticalHitsTaken++;
                    if (defenderData.criticalHitsTaken >= defenderData.maxCriticalHits)
                    {
                        Debug.Log("Defending ship has been destroyed");
                       
                        attackerData.criticalHitsTaken = 0;
                        string attackerName = _system.attacker.gameObject.name;
                        switch (attackerName)
                        {
                            case "Player1Ship":
                                GameObject.Destroy(defender.gameObject);
                                _system.SetState(new PLAYER1TURN(_system));
                                break;
                            case "Player2Ship":
                                GameObject.Destroy(defender.gameObject);
                                _system.SetState(new PLAYER2TURN(_system));
                                break;
                        }
                        
                    }
                    break;
                case 2:
                    defenderData.laserBeams.Remove(attackerSuccessfulRolls);
                    break;
                case 3:
                    defenderData.Engines.Remove(attackerSuccessfulRolls);
                    break;

            }
            */
            choice = 0;
        }
        attackerSuccessfulRolls = 0;
        yield return new WaitForSeconds(1f);
    }
    IEnumerator dealDamageToAttacker()
    {

        choice = 0;
        if (attackerData.armor > 0)
        {
            attackerData.armor -= defenderSuccessfulRolls;
        }
        else
        {
            //this is where the player will select the ties on the ship gris 

            //**********************************************************************
            /* Debug.Log("Defender, target empty component for Critical Hit(1), Laser Beams(2), or Engines(3)?");
             yield return _system.StartCoroutine(WaitForKeyDown(new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3 }));
             _system.StopCoroutine("WaitForKeyDown");
             switch (choice)
             {
                 case 1:
                     attackerData.criticalHitsTaken++;
                     if (attackerData.criticalHitsTaken >= attackerData.maxCriticalHits)
                     {
                         Debug.Log("Attacking ship has been destroyed");

                         defenderData.criticalHitsTaken = 0;
                         string defenderName = _system.defender.gameObject.name;
                         switch (defenderName)
                         {
                             case "Player1Ship":
                                 GameObject.Destroy(attacker.gameObject);
                                 _system.SetState(new PLAYER1TURN(_system));
                                 break;
                             case "Player2Ship":
                                 GameObject.Destroy(attacker.gameObject);
                                 _system.SetState(new PLAYER2TURN(_system));
                                 break;
                         }

                     }
                     break;
                 case 2:
                     attackerData.laserBeams.Remove(defenderSuccessfulRolls);
             break;
                 case 3:
                     attackerData.Engines.Remove(defenderSuccessfulRolls);
                     break;

             }
             */
            choice = 0;
        }
        defenderSuccessfulRolls = 0;
        yield return new WaitForSeconds(1f);
    }
   
    /*public void ActivateButtons()
    {
        attackButton.SetActive(true);
        fleeButton.SetActive(true); 
    }
    public void DeactivateButtons()
    {
        attackButton.SetActive(false);
        fleeButton.SetActive(false);
    }*/
    public void resetButton()
    {
        choice = 0;
    }
    private int rollDie()
    {
        int randomNum = Random.Range(1, 7);
        return randomNum;
    }
}
