using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Sprite Player1Mine, Player2Mine;
    public Sprite Player1SpaceDock, Player2SpaceDock;
    public GameObject Frigate;
    public Sprite Player1Frigate, Player2Frigate;
    public string Player1Role = "Trader", Player2Role = "Trader";
    public GameObject playerPrefab, player1Ship, player2Ship, Player1Obj, Player2Obj;
    [SerializeField] public GameObject[] Player;
    [SerializeField] Sprite[] shipSprites;
    [SerializeField] public GameObject attacker, defender;
    [SerializeField] public GameObject presetMap;
    public movementScript moveScript;
    public tileManager tileManager;
    public bool playerMoved = false;
    public bool clickedOnPlayer = false;
    public State currentState;
    public int choice = 0;
    public bool buttonPressed = false;
   
    public void Awake()
    {
        DontDestroyOnLoad(this);
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
        SetState(new START(system: this));


    }

    public void AssignStartingFacilities()
    {
        //Assign Player 1's mine
        GameObject.Find(Player1HomeTile + "/" + Player1HomePlanet + "/Facility1").GetComponent<SpriteRenderer>().sprite = Player1Mine;
        //Assign Player 2's mine
        GameObject.Find(Player2HomeTile + "/" + Player2HomePlanet + "/Facility1").GetComponent<SpriteRenderer>().sprite = Player2Mine;
        //Assign Player 1's space dock
        GameObject.Find(Player1HomeTile + "/" + Player1HomePlanet + "/Facility2").GetComponent<SpriteRenderer>().sprite = Player1SpaceDock;
        //Assign Player 2's space dock
        GameObject.Find(Player2HomeTile + "/" + Player2HomePlanet + "/Facility2").GetComponent<SpriteRenderer>().sprite = Player2SpaceDock;
        SpawnStartingShips();
    }

    private void SpawnStartingShips()
    {
        GameObject frigate;
        //Player 1 starting frigate
        Vector3 p1Start = GameObject.Find(Player1HomeTile + "/" + Player1HomePlanet).transform.position;
        frigate = Instantiate(Frigate, p1Start, Quaternion.identity);
        frigate.name = ("Player1Frigate1");
        frigate.tag = ("Player");
        //frigate.transform.parent = Player1Obj.transform;
        frigate.GetComponent<SpriteRenderer>().sprite = Player1Frigate;
        frigate.GetComponent<SpriteRenderer>().sortingOrder = 3;
        _ = frigate.AddComponent<movementScript>() as movementScript;
        tileManager.playerShip1 = GameObject.Find("Player1Frigate1");
        player1Ship = tileManager.playerShip1;
        //Player 2 starting frigate
        Vector3 p2Start = GameObject.Find(Player2HomeTile + "/" + Player2HomePlanet).transform.position;
        frigate = Instantiate(Frigate, p2Start, Quaternion.identity);
        frigate.name = ("Player2Frigate1");
        frigate.tag = ("Player");
       // frigate.transform.parent = Player2Obj.transform;
        frigate.GetComponent<SpriteRenderer>().sprite = Player2Frigate;
        frigate.GetComponent<SpriteRenderer>().sortingOrder = 3;
        _ = frigate.AddComponent<movementScript>() as movementScript;
        tileManager.playerShip2 = GameObject.Find("Player2Frigate1");
        player2Ship = tileManager.playerShip2;

        state = "MOVE";
    }
    private void Update()
    {
        if (currentState.ToString() == "PLAYER1TURN")
        {
            if (playerMoved)
            {
                Debug.Log("Player1 Moved");
                playerMoved = false;
                SetState(new PLAYER2TURN(system: this));

            }
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider.tag == "Player" && hit.collider.name != "Player1Frigate1")
                {
                    float distY = Mathf.Abs((player1Ship.transform.position.y - hit.collider.gameObject.transform.position.y));
                    float distX = Mathf.Abs((player1Ship.transform.position.x - hit.collider.gameObject.transform.position.x));
                    if (distY <= 5 && distX <= 5)
                    {
                        Debug.Log(hit.collider.name);
                        attacker = player1Ship;
                        defender = hit.collider.gameObject;
                        SetState(new COMBAT(system: this));
                    }
                }
            }

        }
        if (currentState.ToString() == "PLAYER2TURN")
        {
            if (playerMoved)
            {
                Debug.Log("Player2 Moved");
                playerMoved = false;
                SetState(new PLAYER1TURN(system: this));

            }
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider.tag == "Player" && hit.collider.name != "Player2Frigate1")
                {
                    float distY = Mathf.Abs((player2Ship.transform.position.y - hit.collider.gameObject.transform.position.y));
                    float distX = Mathf.Abs((player2Ship.transform.position.x - hit.collider.gameObject.transform.position.x));
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


        if (Player1Obj = null)
        {
            Debug.Log("All Player1 ships destroyed, Player 2 wins!");
        }
        if (Player2Obj = null)
        {
            Debug.Log("All Player2 ships destroyed, Player 1 wins!");
        }
        if (choice != 0)
        {
            buttonPressed = true;
        }
        else
        {
            buttonPressed = false;
        }
    }

    private void Player1Turn()
    {
        SetState(new PLAYER1TURN(system: this));
    }
    private void Player2Turn()
    {
        SetState(new PLAYER2TURN(system: this));
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