using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileManager : MonoBehaviour
{
    public GameManager gameManager;
    public SpriteRenderer highlight;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void OnMouseEnter()
    {
        if(gameManager.BasesSelected == false)
        {
            highlight.enabled = true;
        }
    }
    void OnMouseExit()
    {
        if(gameManager.BasesSelected == false)
        {
            highlight.enabled = false;
        }
    }
    void OnMouseDown()
    {
        if(gameManager.BaseSelectionTurn == 1)
        {
            gameManager.Player1HomeBase = this.name;
            gameManager.BaseSelectionTurn = 2;
        }
        else if(gameManager.BaseSelectionTurn == 2)
        {
            if(this.name == gameManager.Player1HomeBase)
            {
                return;
            }
            gameManager.Player2HomeBase = this.name;
            gameManager.BasesSelected = true;
            highlight.enabled = false;
        }
    }
    void Update()
    {
        
    }
}
