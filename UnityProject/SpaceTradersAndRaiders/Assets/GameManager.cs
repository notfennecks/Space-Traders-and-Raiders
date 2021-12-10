using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int BaseSelectionTurn = 1;
    [HideInInspector]
    public bool BasesSelected = false;

    public string state = "BASE_SELECTION";

    [HideInInspector]
    public string Player1HomeTile, Player1HomePlanet, Player2HomeTile, Player2HomePlanet;

    //Mineral and Currency Aquisition
    //Gained at start of every turn (must have mine owned on that planet),
    //Minerals---------------------------- (per planet)
    //Home: 50 orange + 30 purple
    //Ringed: 30 orange + 20 purple
    //Terrestrial: 20 orange + 20 purple
    //Atmospheric: 10 orange + 20 purple
    //Gas: 10 orange + 0 purple
    //Stells------------------------------
    //Home: 12 stells
    //Ringed: 6 stells
    //Terrestrial: 9 stells
    //Atmospheric: 3 stells
    //Gas: 6 stells

    public Text[] player1Currency;
    public Text[] player2Currency;

    public GameObject GreenPlayerCurrencies;
    public GameObject YellowPlayerCurrencies;
    public GameObject BluePlayerCurrencies;
    public GameObject RedPlayerCurrencies;

    public Sprite Player1Mine, Player2Mine;
    public Sprite Player1SpaceDock, Player2SpaceDock;
    public GameObject Frigate;
    public Sprite Player1Frigate, Player2Frigate;
    public string Player1Role = "Trader", Player2Role = "Trader";
    public GameObject playerPrefab, player1Ship, player2Ship;
    [SerializeField] public GameObject[] Player;
    [SerializeField] Sprite[] shipSprites;
    [SerializeField] public GameObject attacker, defender;
    [SerializeField] public GameObject presetMap;
    public movementScript moveScript;
    public shipDataScript shipData; //temp until scroptObjects
    public tileManager tileManager;
    public bool playerMoved = false;
    public bool clickedOnPlayer = false;
    public State currentState;
    public int choice = 0;
    public bool buttonPressed = false;
   
    public void Awake()
    {
        DontDestroyOnLoad(this);
        GlobalData.State = state;
    }
    public void SetState(State state)
    {
        currentState = state;
        StartCoroutine(currentState.Start());
    }
    public void Start()
    {
        moveScript = GameObject.Find("movementScript").GetComponent<movementScript>();
        tileManager = GameObject.Find("tileManager").GetComponent<tileManager>();
        shipData = GameObject.Find("shipDataManager").GetComponent<shipDataScript>();
        SetState(new START(system: this));

    }

    public void AssignStartingFacilities()
    {
        //Assign Player 1's mine
        GameObject.Find("UniverseScreen").transform.GetChild(2).GetChild(2).GetChild(GlobalData.Player1HomeSector - 1).GetChild(GlobalData.Player1HomePlanet - 1).GetChild(1).GetComponent<SpriteRenderer>().sprite = Player1Mine;
        GlobalData.Player1TotalMines++;
        //Assign Players 2's mine
        GameObject.Find("UniverseScreen").transform.GetChild(2).GetChild(2).GetChild(GlobalData.Player2HomeSector - 1).GetChild(GlobalData.Player2HomePlanet - 1).GetChild(1).GetComponent<SpriteRenderer>().sprite = Player2Mine;
        GlobalData.Player2TotalMines++;
        //SpawnStartingShips();
    }

    private void SpawnStartingShips()
    {
        GameObject frigate;
        //Player 1 starting frigate
        Vector3 p1Start = GameObject.Find(Player1HomeTile + "/" + Player1HomePlanet).transform.position;
        frigate = Instantiate(Frigate, p1Start, Quaternion.identity);
        frigate.name = ("Player1Frigate1");
        frigate.tag = ("Player");
        frigate.GetComponent<SpriteRenderer>().sprite = Player1Frigate;
        frigate.GetComponent<SpriteRenderer>().sortingOrder = 3;
        _ = frigate.AddComponent<movementScript>() as movementScript;
        _ = frigate.AddComponent<shipDataScript>() as shipDataScript;
        player1Ship = GameObject.Find("Player1Frigate1");
        player1Ship.transform.parent = GlobalData.Player1Obj.transform;

        //Player 2 starting frigate
        Vector3 p2Start = GameObject.Find(Player2HomeTile + "/" + Player2HomePlanet).transform.position;
        frigate = Instantiate(Frigate, p2Start, Quaternion.identity);
        frigate.name = ("Player2Frigate1");
        frigate.tag = ("Player");
        frigate.GetComponent<SpriteRenderer>().sprite = Player2Frigate;
        frigate.GetComponent<SpriteRenderer>().sortingOrder = 3;
        _ = frigate.AddComponent<movementScript>() as movementScript;
        _ = frigate.AddComponent<shipDataScript>() as shipDataScript;
        player2Ship = GameObject.Find("Player2Frigate1");
        player2Ship.transform.parent = GlobalData.Player2Obj.transform;
        state = "MOVE";
    }
    private void Update()
    {
        PlayerTurnsFunction();
        if (choice != 0)
        {
            buttonPressed = true;
        }
        else
        {
            buttonPressed = false;
        }

        //Finished with base selection
        if(GlobalData.BaseSelectTracker == 3)
        {
            AssignStartingFacilities();
            GlobalData.BaseSelectTracker++;
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            GenerateResources("Player1");
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void Player1Turn()
    {
        SetState(new PLAYER1TURN(system: this));
        GenerateResources("Player1");
    }
    private void Player2Turn()
    {
        SetState(new PLAYER2TURN(system: this));
        GenerateResources("Player2");
    }

    public void GenerateResources(string player)
    {
        if(player == "Player1")
        {
            Debug.Log("Generated Player 1 resources for turn | Total mines: " + GlobalData.Player1TotalMines);
            GlobalData.Player1Stells += 12 * GlobalData.Player1TotalMines;
            player1Currency[0].text =  GlobalData.Player1Stells.ToString();    
            GlobalData.Player1PurpleGalacite += 30 * GlobalData.Player1TotalMines;
            player1Currency[1].text =  GlobalData.Player1PurpleGalacite.ToString();
            GlobalData.Player1OrangeGalacite += 50 * GlobalData.Player1TotalMines;
            player1Currency[2].text =  GlobalData.Player1OrangeGalacite.ToString();
        }
        if(player == "Player2")
        {
            Debug.Log("Generated Player 2 resources for turn | Total mines: " + GlobalData.Player2TotalMines);
            GlobalData.Player2Stells += 12 * GlobalData.Player2TotalMines;
            player2Currency[0].text =  GlobalData.Player2Stells.ToString();    
            GlobalData.Player2PurpleGalacite += 30 * GlobalData.Player2TotalMines;
            player2Currency[1].text =  GlobalData.Player2PurpleGalacite.ToString();
            GlobalData.Player2OrangeGalacite += 50 * GlobalData.Player2TotalMines;
            player2Currency[2].text =  GlobalData.Player2OrangeGalacite.ToString();
        }
    }

    public void PlayerTurnsFunction()
    {
        if (currentState.ToString() == "PLAYER1TURN")
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Debug.Log("Player1 Turn has ended");
                //playerMoved = false;
                SetState(new PLAYER2TURN(system: this));
                GenerateResources("Player2");

            }
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                /*
                if (hit.collider.tag == "Player" && hit.collider.transform.parent.name != "Player1Obj")
                {
                    foreach (Transform playerShips in GlobalData.Player1Obj.transform)
                    {
                        float distY = Mathf.Abs((playerShips.transform.position.y - hit.collider.gameObject.transform.position.y));
                        float distX = Mathf.Abs((playerShips.transform.position.x - hit.collider.gameObject.transform.position.x));

                        if (distY <= 5 && distX <= 5)
                        {
                            Debug.Log(hit.collider.name);
                            attacker = player1Ship;
                            defender = hit.collider.gameObject;
                            SetState(new COMBAT(system: this));
                        }
                    }
                }
                */
            }

        }
        if (currentState.ToString() == "PLAYER2TURN")
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Debug.Log("Player2 Turn has ended");
               // playerMoved = false;
                SetState(new PLAYER1TURN(system: this));
                GenerateResources("Player1");

            }
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider.tag == "Player" && hit.collider.transform.parent.name != "Player2Obj")
                {
                    foreach (Transform playerShips in GlobalData.Player2Obj.transform)
                    {
                        float distY = Mathf.Abs((playerShips.transform.position.y - hit.collider.gameObject.transform.position.y));
                        float distX = Mathf.Abs((playerShips.transform.position.x - hit.collider.gameObject.transform.position.x));
                        if (distY <= 5 && distX <= 5)
                        {
                            Debug.Log(hit.collider.name);
                            attacker = player2Ship;
                            defender = hit.collider.gameObject;
                            SetState(new COMBAT(system: this));
                        }
                    }
                }
            }
        }
    }
    public void TestForWinCondition()
    {
        //Test at the end of every turn phase

        //You control more than half of all the planets in the universe
        //or
        //You control planets and no other players control any planets
        //or
        //You are a trader and you have 50 wealth, 50 power, and 50 achievements
        //or
        //You are a raider and you have 60 wealth, 60 power, and 12 achievements
    }
}