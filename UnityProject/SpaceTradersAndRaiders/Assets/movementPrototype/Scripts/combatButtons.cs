using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatButtons : MonoBehaviour
{
    [SerializeField] public GameObject attackButton, fleeButton;
    [SerializeField] public gameManager manager;
    public int playerChoice;

    public void Start()
    {
        manager = GameObject.Find("gameManager").GetComponent<gameManager>();
    }
    public void attackButtonPressed()
    {
        manager.choice = 1;
        Debug.Log("Choice = 1");
    }
    public void fleeButtonPressed()
    {

        manager.choice = 2;
        Debug.Log("Choice = 2");
    }
   
    
}
