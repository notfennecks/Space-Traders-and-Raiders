using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    
    public gameManager gameManage;


    private void Start()
    {
        gameManage = GameObject.Find("gameManager").GetComponent<gameManager>();
    }
    public void MovePlayer(Vector3 newpos)
    {
        transform.position = newpos;
        gameManage.playerMoved = true;


    }
    
}
