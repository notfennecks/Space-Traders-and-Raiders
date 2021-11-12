using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatButtons : MonoBehaviour
{
    [SerializeField] public GameObject beamButton, fleeButton, skipButton, inspectButton, useButton, surrenderButton;
    [SerializeField] public GameManager manager;
    public int playerChoice;

    public void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void beamButtonPressed()
    {
        manager.choice = 1;
        Debug.Log("Choice = 1");
    }
    public void fleeButtonPressed()
    {

        manager.choice = 2;
        Debug.Log("Choice = 2");
    }

    public void surrenderButtonPressed()
    {
        manager.choice = 3;
        Debug.Log("Choice = 3");
    }
    public void skipButtonPressed()
    {
        manager.choice = 4;
        Debug.Log("Choice = 4");
    }

    
    //inspect, and skip and use button
   
    
}
