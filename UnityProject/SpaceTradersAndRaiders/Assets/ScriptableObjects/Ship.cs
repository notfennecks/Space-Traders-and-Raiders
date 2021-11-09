using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ship", menuName = "Ship")]
public class Ship : ScriptableObject
{
    public new string name;
    public string description;

    public int max_hits;
    public int crit_hits;
    public int engine_num;
    public int beam_num;
    public int missile_num;
    public int shield_num;
    public int anti_missile_num;

    public int component_num;
    public int max_components;


    public Sprite artwork;

    /* public void Print()
    {
        Debug.Log(name + ": " + description + "this ship has " + engine_num + " engines" + " and " + gun_num + " guns");
    }
    //Send info to console test
    */
}
