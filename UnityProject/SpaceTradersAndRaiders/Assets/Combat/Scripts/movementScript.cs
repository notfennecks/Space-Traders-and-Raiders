using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    
    public GameManager gameManage;


    private void Start()
    {
        gameManage = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void MovePlayer(Vector3 newpos)
    {
        transform.position = newpos;
        gameManage.playerMoved = true;


    }
    
}
