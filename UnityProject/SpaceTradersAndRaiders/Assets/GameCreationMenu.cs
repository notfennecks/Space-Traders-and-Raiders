using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public Image Green;
    public Image Yellow;
    public Image Blue;
    public Image Red;
    private Color full = new Color32(255, 255, 255, 255);
    private Color tint = new Color32(255, 255, 255, 50);

    public Sprite ready;
    public Sprite notReady;
    public Image greenReadyStatus;
    public Image yellowReadyStatus;
    public Image blueReadyStatus;
    public Image redReadyStatus;

    void Start() 
    {
        mapTypeDisplay.text = mapTypes[mapTypeTracker];
        universeSizeDisplay.text = universeSizes[universeSizeTracker];
        densityDisplay.text = density[densityTracker];
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    private void Update()
    {
        ShowTintMapSelection();
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
        Green.color = full;
    }

    public void RemoveGreenPlayer()
    {
        Green.color = tint;
        greenReadyStatus.sprite = notReady;
    }

    public void AddYellowPlayer()
    {
        Yellow.color = full;
    }

    public void RemoveYellowPlayer()
    {
        Yellow.color = tint;
        yellowReadyStatus.sprite = notReady;
    }

    public void AddBluePlayer()
    {
        Blue.color = full;
    }

    public void RemoveBluePlayer()
    {
        Blue.color = tint;
        blueReadyStatus.sprite = notReady;
    }

    public void AddRedPlayer()
    {
        Red.color = full;
    }

    public void RemoveRedPlayer()
    {
        Red.color = tint;
        redReadyStatus.sprite = notReady;
    }

    public void ToggleGreenReady()
    {
        if(greenReadyStatus.sprite == ready)
        {
            greenReadyStatus.sprite = notReady;
        }
        else
        {
            greenReadyStatus.sprite = ready;
        }
    }

    public void ToggleYellowReady()
    {
        if(yellowReadyStatus.sprite == ready)
        {
            yellowReadyStatus.sprite = notReady;
        }
        else
        {
            yellowReadyStatus.sprite = ready;
        }
    }

    public void ToggleBlueReady()
    {
        if(blueReadyStatus.sprite == ready)
        {
            blueReadyStatus.sprite = notReady;
        }
        else
        {
            blueReadyStatus.sprite = ready;
        }
    }

    public void ToggleRedReady()
    {
        if(redReadyStatus.sprite == ready)
        {
            redReadyStatus.sprite = notReady;
        }
        else
        {
            redReadyStatus.sprite = ready;
        }
    }
}
