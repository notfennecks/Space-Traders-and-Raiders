using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship", menuName = "Ship")]
public class Ship : ScriptableObject
{
    public new string name;
    public string description;

    public int engine_num;
    public int gun_num;
    public int max_health;
    public int health;

    public Sprite artwork;

    /* public void Print()
    {
        Debug.Log(name + ": " + description + "this ship has " + engine_num + " engines" + " and " + gun_num + " guns");
    }
    //Send info to console test
    */
}
