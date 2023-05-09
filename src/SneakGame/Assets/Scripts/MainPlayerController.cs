using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using Mono.Cecil;

public enum RobState { Plant, Security, Scientist, Normal}
public class MainPlayerController : MainPlayer
{
    internal enum ConditionState { Active, Caught, Winner}
    internal ConditionState gameState;

    internal RobState state;
    public Sprite plant;
    public Sprite Security;
    public Sprite Scientist;
    private Sprite Normal;

    private float DisguiseRate = 5000f; //milliseconds -> 5 seconds 

    private float DisguisTime;
    //expose this 

    public float DisguisePercent { 
        get
        {
            return DisguisTime;
        }
        set
        {
            DisguisTime = value / DisguiseRate;
        }
    }
    //return 1-0

    private bool hasDisguiseEquipped;
    public List<GameObject> hasDisguise; 

    public Transform[] locations;
    internal int locationNum;

    private DefaultPlayerControl defaultPlayerControl;

    private InputAction MoveAction;
    private InputAction ResetAction;

    private InputAction PlantAction; //might be a better way: tec debt
    private InputAction HatAction;
    private InputAction CoatAction;

    private void Awake()
    {
        defaultPlayerControl = new DefaultPlayerControl();
    }

    void Start()
    {
        locationNum = 0;
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();

        MovementSpeed = 8;
        DefaultSpeed = MovementSpeed;
        Normal = this.GetComponent<SpriteRenderer>().sprite;
        state = RobState.Normal;

        hasDisguiseEquipped = false;

        this.transform.position = locations[locationNum].position;

        gameState = ConditionState.Active;
        
    }

    private void OnEnable()
    {
        MoveAction = defaultPlayerControl.Player.Move;
        MoveAction.Enable();

        ResetAction = defaultPlayerControl.Player.Restart;
        ResetAction.Enable();

        PlantAction = defaultPlayerControl.Player.PlantDisguise; 
        PlantAction.Enable();

        HatAction = defaultPlayerControl.Player.SecurityDisguise;
        HatAction.Enable();

        CoatAction = defaultPlayerControl.Player.ScientistDisguise;
        CoatAction.Enable();
    }

    private void OnDisable()
    {
        MoveAction.Disable();
        ResetAction.Disable();
        PlantAction.Disable();
        HatAction.Disable();
        CoatAction.Disable();
    }

    void FixedUpdate()
    {
        switch (gameState)
        {
            case ConditionState.Active:
                PlayerController();
                break;
            case ConditionState.Caught:
            case ConditionState.Winner:
                ResetGame();
                break;
        }
    }

    private void PlayerController()
    {
        Movement();
        ChangeDisguise();
    }

    private void ChangeDisguise()
    {
        var plantV = PlantAction.ReadValue<float>();
        var hatV = HatAction.ReadValue<float>();
        var coatV = CoatAction.ReadValue<float>();

        if (!hasDisguiseEquipped)
        {
            if (hatV > 0 && hasDisguise.Find(x => x.name == "HatObject"))
            {
                state = RobState.Security;
            }
            if (coatV > 0 && hasDisguise.Find(x => x.name == "CoatObject"))
            {
                state = RobState.Scientist;
            }
            if (plantV > 0 && hasDisguise.Find(x => x.name == "PlantObject"))
            {
                state = RobState.Plant;
            }
        }
        ChangeAppearance(state);
    }

    private void Movement()
    {
        var value = MoveAction.ReadValue<Vector2>();
        Direction.x = value.x;
        Direction.y = value.y; 

        if(value.x < 0)
        {
            spriteRen.flipX = true;
        }
        else if(value.x > 0)
        {
            spriteRen.flipX = false;
        }

        transform.Translate(Direction * MovementSpeed * Time.deltaTime);
    
        
    }

    private void ResetGame()
    {
        var value = ResetAction.ReadValue<float>();
        if(value > 0)
        {
            SceneManager.LoadScene("Final");
        }
       
    }
    private void ChangeAppearance(RobState currentState)
    {        
        switch (currentState)
        {
            case RobState.Plant:
                this.GetComponent<SpriteRenderer>().sprite = plant;
                hasDisguiseEquipped = true;
                break;
            case RobState.Security:
                this.GetComponent<SpriteRenderer>().sprite = Security;
                hasDisguiseEquipped = true;
                break;
            case RobState.Scientist:
                this.GetComponent<SpriteRenderer>().sprite = Scientist;
                hasDisguiseEquipped = true;
                break;
            case RobState.Normal:
                this.GetComponent<SpriteRenderer>().sprite = Normal;
                break;
        }

        if (state != RobState.Normal)
        {

            ResetSprite();

            
        }
    }

    public void ResetSprite()
    {
        //alter with https://answers.unity.com/questions/1381157/health-bar-goes-down-with-time.html
        DisguisTime = Time.deltaTime + DisguiseRate / 60;
        StartCoroutine(ResetConditions());
        
        //if (Time.time > DisguisTime)
        //{
            //DisguisTime = Time.time + DisguiseRate / 1000;
            //state = RobState.Normal;
            //hasDisguiseEquipped = false;

            //DisguisePercent = DisguisTime * DisguiseRate;

            //percentage = time/rate
        //}
        
    }

    public void GoToNextLocation()
    {
        locationNum++;
        transform.position = locations[locationNum].position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
            gameState = ConditionState.Winner;
            //Debug.Log(gameState.ToString());
        }
    }

    IEnumerator ResetConditions()
    {
        yield return new WaitForSeconds(5);
        
        state = RobState.Normal;
        hasDisguiseEquipped = false;
        StopAllCoroutines();
    }
}
