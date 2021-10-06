using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class START : State
{
    public START(gameManager system) : base(system)
    {
        CreatePlayer1();
        CreatePlayer2();
        _system.Player = new GameObject[2];
        _system.Player = GameObject.FindGameObjectsWithTag("Player");
        _system.StartCoroutine(Start());
    }

    public override IEnumerator Start()
    {
        Debug.Log("Creating Universe...");
        _system.StartCoroutine(_setupUniverse());
        _system.SetState(new PLAYER1TURN(_system));
        return base.Start();
    }
    IEnumerator _setupUniverse()
    {
        Debug.Log("Creating Universe...");
        yield return new WaitForSeconds(3f);
    }

    public void CreatePlayer1()
    {
        GameObject firstTile = GameObject.Find("Tile00");
        Vector3 startPos = new Vector3(firstTile.transform.position.x, firstTile.transform.position.y);
        _system.player1 = Object.Instantiate((GameObject)_system.playerPrefab, startPos, Quaternion.identity);
        _system.player1.name = ("Player1");

    }
    public void CreatePlayer2()
    {
        GameObject lastTile = GameObject.Find("Tile1914");
        Vector3 startPos = new Vector3(lastTile.transform.position.x, lastTile.transform.position.y);
        _system.player2 = Object.Instantiate((GameObject)_system.playerPrefab, startPos, Quaternion.identity);
        _system.player2.name = ("Player2");
        _system.player2.GetComponentInChildren<SpriteRenderer>().color = Color.red;
    }

}
