using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipDataScript : MonoBehaviour
{
    [SerializeField] public List<int> laserBeams = new List<int>();
    [SerializeField] public List<int> Engines = new List<int>();
    [SerializeField] public int armor = 2;
    [SerializeField] public int maxCriticalHits = 2;
    [SerializeField] public int criticalHitsTaken = 0;
    [SerializeField] public bool isChasingPLayer = false;
    [SerializeField] public Sprite sprite;

    private void Start()
    {
        laserBeams.Add(0);
        laserBeams.Add(0);
        Engines.Add(2);
        Engines.Add(2);
    }
}
