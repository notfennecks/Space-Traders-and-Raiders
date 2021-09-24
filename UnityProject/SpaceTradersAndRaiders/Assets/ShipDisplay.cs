using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipDisplay : MonoBehaviour
{
    public Ship ship;

    public Text nameText;

    public Image artworkImage;

    public Text maxText;
    public Text healthText;
    public Text gunsText;
    public Text engineText;

    void Start()
    {
        //ship.Print(); //Send info to console test
        nameText.text = ship.name;
        artworkImage.sprite = ship.artwork;

        maxText.text = "/" + ship.max_health.ToString();
        healthText.text =  ship.health.ToString();
        gunsText.text = ship.gun_num.ToString() + " guns";
        engineText.text = ship.engine_num.ToString() + " engines";

    }

}
