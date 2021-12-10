using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    //Player mineral + currency ------------------
    public static string State = "BASE_SELECTION";
    public static int BaseSelectTracker = 1;
    //Player 1
    public static string Player1Name = "";
    public static string Player1Color = "";
    public static int Player1Stells = 0;
    public static int Player1OrangeGalacite = 0;
    public static int Player1PurpleGalacite = 0;
    public static GameObject Player1Obj = GameObject.Find("Player1Obj");
    public static int Player1HomeSector;
    public static int Player1HomePlanet;
    public static int Player1TotalMines;
    //Player 2
    public static string Player2Name = "";
    public static string Player2Color = "";
    public static int Player2Stells = 0;
    public static int Player2OrangeGalacite = 0;
    public static int Player2PurpleGalacite = 0;
    public static GameObject Player2Obj = GameObject.Find("Player2Obj");
    public static int Player2HomeSector;
    public static int Player2HomePlanet;
    public static int Player2TotalMines;
    //Player 3
    //public static int Player3Stells = 0;
    //public static int Player3OrangeGalacite = 0;
    //public static int Player3PurpleGalacite = 0;
    //Player 4
    //public static int Player4Stells = 0; 
    //public static int Player4OrangeGalacite = 0;
    //public static int Player4PurpleGalacite = 0;
    //--------------------------------------------

    //Victory Markers ----------------------------
    //Player 1
    public static int Player1Power = 0;  //System (planet with at least one facility) = 5 pts; Ships = 1-5 pts(frigate, destroyer, cruiser, battleship, dreadnaught)
    public static int Player1Wealth = 0;  //Stells = Wealth
    public static int Player1Achievement = 0;  //Each Facility = 3 pts
    //Player 2
    public static int Player2Power = 0;
    public static int Player2Wealth = 0;
    public static int Player2Achievement = 0;
    //Player 3
    //public static int Player3Power = 0;
    //public static int Player3Wealth = 0;
    //public static int Player3Achievement = 0;
    //Player 4
    //public static int Player4Power = 0;
    //public static int Player4Wealth = 0;
    //public static int Player4Achievement = 0;
    //--------------------------------------------

}
