using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipDisplay : MonoBehaviour
{
    public Ship ship;

    public Text nameText;
    public Text descText;

    public Image artworkImage;

    public Text maxhitText;
    public Text hitText;
    public Text engineText;
    public Text beamText;
    public Text missileText;
    public Text shieldText;
    public Text antimissileText;


    void Start()
    {
        //ship.Print(); //Send info to console test
        nameText.text = ship.name;
        descText.text = ship.description;
        artworkImage.sprite = ship.artwork;

        maxhitText.text = "/" + ship.max_hits.ToString();
        hitText.text = ship.crit_hits.ToString();
        engineText.text = ship.engine_num.ToString() + " engines";
        beamText.text = ship.beam_num.ToString() + " beams";
        missileText.text = ship.missile_num.ToString() + " missiles";
        shieldText.text = ship.shield_num.ToString() + " shields";
        antimissileText.text = ship.anti_missile_num.ToString() + " anti-missiles";
    }
     
}
