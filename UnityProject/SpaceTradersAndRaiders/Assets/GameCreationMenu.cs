using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameCreationMenu : MonoBehaviour
{
    string[] mapTypes = new string[] {"Created", "Preset"};
    int mapTypeTracker = 0;
    public Text mapTypeDisplay;

    string[] universeSizes = new string[] {"Small" , "Medium", "Large"};
    int universeSizeTracker = 0;
    public Text universeSizeDisplay;

    string[] density = new string[] {"Sparse" , "Normal", "Dense"};
    int densityTracker = 0;
    public Text densityDisplay;

    string[] maps = new string[] {"PresetMap1" , "PresetMap2", "PresetMap3", "PresetMap4"};
    int mapTracker = 0;
    public Text mapDisplay;
    public CanvasGroup mapsCanvasGroup;

    public CanvasGroup uniSizeCanvasGroup;
    public CanvasGroup densityCanvasGroup;

    public Image Green;
    public Image Yellow;
    public Image Blue;
    public Image Red;
    private Color full = new Color32(255, 255, 255, 255);
    private Color tint = new Color32(255, 255, 255, 50);

    public Button GreenAdd;
    public Button YellowAdd;
    public Button BlueAdd;
    public Button RedAdd;

    public Sprite ready;
    public Sprite notReady;
    public Image greenReadyStatus;
    public Image yellowReadyStatus;
    public Image blueReadyStatus;
    public Image redReadyStatus;

    public TMP_InputField greenPlayerName;
    public TMP_InputField yellowPlayerName;
    public TMP_InputField bluePlayerName;
    public TMP_InputField redPlayerName;
 
    string player1 = "";
    bool player1Ready = false;
    string player2 = "";
    bool player2Ready = false;

    void Start() 
    {
        mapTypeDisplay.text = mapTypes[mapTypeTracker];
        universeSizeDisplay.text = universeSizes[universeSizeTracker];
        densityDisplay.text = density[densityTracker];
    }

    public void StartGame()
    {
        if(player1Ready == true && player2Ready == true)
        {
            SceneManager.LoadScene(2);
            GlobalData.Player1Color = player1;
            GlobalData.Player2Color = player2;

            switch (player1)
            {
            case "Green":
                GlobalData.Player1Name = greenPlayerName.text;
                break;
            case "Yellow":
                GlobalData.Player1Name = yellowPlayerName.text;
                break;
            case "Blue":
                GlobalData.Player1Name = bluePlayerName.text;
                break;
            case "Red":
                GlobalData.Player1Name = redPlayerName.text;
                break;
            default:
                //nice
                break;
            }

            switch (player2)
            {
            case "Green":
                GlobalData.Player2Name = greenPlayerName.text;
                break;
            case "Yellow":
                GlobalData.Player2Name = yellowPlayerName.text;
                break;
            case "Blue":
                GlobalData.Player2Name = bluePlayerName.text;
                break;
            case "Red":
                GlobalData.Player2Name = redPlayerName.text;
                break;
            default:
                //nice
                break;
            }
        }
    }

    private void Update()
    {
        ShowTintMapSelection();
        ShowTintUniSizeDensitySelection();
        if(player2 != "")
        {
            GreenAdd.interactable = false;
            YellowAdd.interactable = false;
            BlueAdd.interactable = false;
            RedAdd.interactable = false;  
        }
        else
        {
            GreenAdd.interactable = true;
            YellowAdd.interactable = true;
            BlueAdd.interactable = true;
            RedAdd.interactable = true;
        }
    }

    private void ShowTintMapSelection()
    {
        if(mapTypeDisplay.text == "Preset")
        {
            mapsCanvasGroup.alpha = 1f;
        }
        else
        {
            mapsCanvasGroup.alpha = 0.2f;
            mapDisplay.text = "....";
        }
    }

    private void ShowTintUniSizeDensitySelection()
    {
        if(mapTypeDisplay.text == "Preset")
        {
            uniSizeCanvasGroup.alpha = 0.2f;
            densityCanvasGroup.alpha = 0.2f;
            universeSizeDisplay.text = "....";
            densityDisplay.text = "....";
        }
        else
        {
            uniSizeCanvasGroup.alpha = 1f;
            densityCanvasGroup.alpha = 1f;
        }
    }

    public void NextMapType()
    {
        mapTypeTracker++;
        if(mapTypeTracker == mapTypes.Length)
        {
            mapTypeTracker = 0;
        }
        mapTypeDisplay.text = mapTypes[mapTypeTracker];
    }

    public void PrevMapType()
    {
        mapTypeTracker--;
        if(mapTypeTracker == -1)
        {
            mapTypeTracker = mapTypes.Length - 1;
        }
        mapTypeDisplay.text = mapTypes[mapTypeTracker];
    }

    public void NextUniverseSize()
    {
        universeSizeTracker++;
        if(universeSizeTracker == universeSizes.Length)
        {
            universeSizeTracker = 0;
        }
        universeSizeDisplay.text = universeSizes[universeSizeTracker];
    }

    public void PrevUniverseSize()
    {
        universeSizeTracker--;
        if(universeSizeTracker == -1)
        {
            universeSizeTracker = universeSizes.Length - 1;
        }
        universeSizeDisplay.text = universeSizes[universeSizeTracker];
    }

    public void NextDensity()
    {
        densityTracker++;
        if(densityTracker == density.Length)
        {
            densityTracker = 0;
        }
        densityDisplay.text = density[densityTracker];
    }

    public void PrevDensity()
    {
        densityTracker--;
        if(densityTracker == -1)
        {
            densityTracker = density.Length - 1;
        }
        densityDisplay.text = density[densityTracker];
    }

    public void NextMap()
    {
        mapTracker++;
        if(mapTracker == maps.Length)
        {
            mapTracker = 0;
        }
        mapDisplay.text = maps[mapTracker];
    }

    public void PrevMap()
    {
        mapTracker--;
        if(mapTracker == -1)
        {
            mapTracker = maps.Length - 1;
        }
        mapDisplay.text = maps[mapTracker];
    }

    public void AddGreenPlayer()
    {
        if(player1 == "")
        {
            player1 = "Green";
            Green.color = full;
        }
        else if(player2 == "")
        {
            player2 = "Green";
            Green.color = full;
        }
        Debug.Log("Player 1 is: " + player1 + " Player 2 is: " + player2);
    }

    public void RemoveGreenPlayer()
    {
        Green.color = tint;
        greenReadyStatus.sprite = notReady;
        if(player1 == "Green")
        {
            player1 = "";
        }
        else if(player2 == "Green")
        {
            player2 = "";
        }
    }

    public void AddYellowPlayer()
    {
        if(player1 == "")
        {
            player1 = "Yellow";
            Yellow.color = full;
        }
        else if(player2 == "")
        {
            player2 = "Yellow";
            Yellow.color = full;
        }
        Debug.Log("Player 1 is: " + player1 + " Player 2 is: " + player2);
        
    }

    public void RemoveYellowPlayer()
    {
        Yellow.color = tint;
        yellowReadyStatus.sprite = notReady;
        if(player1 == "Yellow")
        {
            player1 = "";
        }
        else if(player2 == "Yellow")
        {
            player2 = "";
        }
    }

    public void AddBluePlayer()
    {
        if(player1 == "")
        {
            player1 = "Blue";
            Blue.color = full;
        }
        else if(player2 == "")
        {
            player2 = "Blue";
            Blue.color = full;
        }
        Debug.Log("Player 1 is: " + player1 + " Player 2 is: " + player2);
        
    }

    public void RemoveBluePlayer()
    {
        Blue.color = tint;
        blueReadyStatus.sprite = notReady;
        if(player1 == "Blue")
        {
            player1 = "";
        }
        else if(player2 == "Blue")
        {
            player2 = "";
        }
    }

    public void AddRedPlayer()
    {
        if(player1 == "")
        {
            player1 = "Red";
            Red.color = full;
        }
        else if(player2 == "")
        {
            player2 = "Red";
            Red.color = full;
        }
        Debug.Log("Player 1 is: " + player1 + " Player 2 is: " + player2);

    }

    public void RemoveRedPlayer()
    {
        Red.color = tint;
        redReadyStatus.sprite = notReady;
        if(player1 == "Red")
        {
            player1 = "";
        }
        else if(player2 == "Red")
        {
            player2 = "";
        }
    }

    public void ToggleGreenReady()
    {
        if(greenReadyStatus.sprite == ready)
        {
            greenReadyStatus.sprite = notReady;
            if(player1 == "Green")
            {
                player1Ready = false;
            }
            else if(player2 == "Green")
            {
                player2Ready = false;
            }
        }
        else
        {
            greenReadyStatus.sprite = ready;
            if(player1 == "Green")
            {
                player1Ready = true;
            }
            else if(player2 == "Green")
            {
                player2Ready = true;
            }
        }
    }

    public void ToggleYellowReady()
    {
        if(yellowReadyStatus.sprite == ready)
        {
            yellowReadyStatus.sprite = notReady;
            if(player1 == "Yellow")
            {
                player1Ready = false;
            }
            else if(player2 == "Yellow")
            {
                player2Ready = false;
            }
        }
        else
        {
            yellowReadyStatus.sprite = ready;
            if(player1 == "Yellow")
            {
                player1Ready = true;
            }
            else if(player2 == "Yellow")
            {
                player2Ready = true;
            }
        }
    }

    public void ToggleBlueReady()
    {
        if(blueReadyStatus.sprite == ready)
        {
            blueReadyStatus.sprite = notReady;
            if(player1 == "Blue")
            {
                player1Ready = false;
            }
            else if(player2 == "Blue")
            {
                player2Ready = false;
            }
        }
        else
        {
            blueReadyStatus.sprite = ready;
            if(player1 == "Blue")
            {
                player1Ready = true;
            }
            else if(player2 == "Blue")
            {
                player2Ready = true;
            }
        }
    }

    public void ToggleRedReady()
    {
        if(redReadyStatus.sprite == ready)
        {
            redReadyStatus.sprite = notReady;
            if(player1 == "Red")
            {
                player1Ready = false;
            }
            else if(player2 == "Red")
            {
                player2Ready = false;
            }
        }
        else
        {
            redReadyStatus.sprite = ready;
            if(player1 == "Red")
            {
                player1Ready = true;
            }
            else if(player2 == "Red")
            {
                player2Ready = true;
            }
        }
    }
}
