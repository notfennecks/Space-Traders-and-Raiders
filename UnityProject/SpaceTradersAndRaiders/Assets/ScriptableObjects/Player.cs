using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player", menuName = "Player")]
public class Player : ScriptableObject
{
    public new string name;
    public string description;
    public string team;

    public int victory_points;
    public bool Raider = true;
}
