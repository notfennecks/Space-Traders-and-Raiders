using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatButtons : MonoBehaviour
{
    [SerializeField] public GameObject attackButton, fleeButton;

    public int choice;
    
    public void attackButtonPressed()
    {
        choice = 1;
        Debug.Log("Choice = 1");
    }
    public void fleeButtonPressed()
    {
        choice = 2;
        Debug.Log("Choice = 2");
    }
   
    
}
