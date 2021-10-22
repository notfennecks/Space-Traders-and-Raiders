using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int BaseSelectionTurn = 1;
    public bool BasesSelected = false;

    public string state = "BASE_SELECTION";
    public string Player1HomeTile;
    public string Player1HomePlanet;
    public string Player2HomeTile;
    public string Player2HomePlanet;
    public int Player1Stells, Player2Stells;

    public Sprite Player1Mine, Player2Mine;
    public Sprite Player1SpaceDock, Player2SpaceDock;
    public GameObject Frigate;
    public Sprite Player1Frigate, Player2Frigate;
    public string Player1Role = "Trader", Player2Role = "Trader";
    void Start()
    {
        //Player Home Base Selection
    }

    public void AssignStartingFacilities()
    {
        //Assign Player 1's mine
        GameObject.Find(Player1HomeTile + "/" + Player1HomePlanet + "/Facility1").GetComponent<SpriteRenderer>().sprite = Player1Mine;
        //Assign Player 2's mine
        GameObject.Find(Player2HomeTile + "/" + Player2HomePlanet + "/Facility1").GetComponent<SpriteRenderer>().sprite = Player2Mine;
        //Assign Player 1's space dock
        GameObject.Find(Player1HomeTile + "/" + Player1HomePlanet + "/Facility2").GetComponent<SpriteRenderer>().sprite = Player1SpaceDock;
        //Assign Player 2's space dock
        GameObject.Find(Player2HomeTile + "/" + Player2HomePlanet + "/Facility2").GetComponent<SpriteRenderer>().sprite = Player2SpaceDock;
        SpawnStartingShips();
    }

    private void SpawnStartingShips()
    {
        GameObject frigate;
        //Player 1 starting frigate
        Vector3 p1Start = GameObject.Find(Player1HomeTile + "/" + Player1HomePlanet).transform.position;
        frigate = Instantiate(Frigate, p1Start, Quaternion.identity);
        frigate.name = ("Player1Frigate1");
        frigate.GetComponent<SpriteRenderer>().sprite = Player1Frigate;
        frigate.GetComponent<SpriteRenderer>().sortingOrder = 3;
        //Player 2 starting frigate
        Vector3 p2Start = GameObject.Find(Player2HomeTile + "/" + Player2HomePlanet).transform.position;
        frigate = Instantiate(Frigate, p2Start, Quaternion.identity);
        frigate.name = ("Player2Frigate1");
        frigate.GetComponent<SpriteRenderer>().sprite = Player2Frigate;
        frigate.GetComponent<SpriteRenderer>().sortingOrder = 3;

        state = "MOVE";
    }
}