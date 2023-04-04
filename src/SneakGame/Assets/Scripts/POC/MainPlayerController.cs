using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    internal bool hasPlantDisguise, hasHatDisguise, hasCoatDisguise;
    private bool hasDisguiseEquipped;

    public Transform[] locations;
    internal int locationNum;

    void Start()
    {
        locationNum = 0;
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();

        MovementSpeed = 4;
        DefaultSpeed = MovementSpeed;
        Normal = this.GetComponent<SpriteRenderer>().sprite;
        state = RobState.Normal;

        hasDisguiseEquipped = false;

        this.transform.position = locations[locationNum].position;

        gameState = ConditionState.Active;
        
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


        //PlayerController();
    }

    private void PlayerController()
    {
        SetSpeed();
        //Using normal input as temp
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRen.flipX = true;
            Direction.x += -1;
            transform.Translate(Direction * MovementSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            spriteRen.flipX = false;
            Direction.x += 1;
            transform.Translate(Direction * MovementSpeed * Time.deltaTime);
        }
        
        if(Input.GetKey(KeyCode.UpArrow))
        {
            Direction.y += 1;
            transform.Translate(Direction * MovementSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            Direction.y += -1;
            transform.Translate(Direction * MovementSpeed * Time.deltaTime);
        }

        if(!hasDisguiseEquipped)
        {
            if (Input.GetKey(KeyCode.A) && hasPlantDisguise)
            {
                state = RobState.Plant;
                //hasDisguiseEquipped = true;
            }
            else if (Input.GetKey(KeyCode.S) && hasHatDisguise)
            {
                state = RobState.Security;
                //hasDisguiseEquipped = true;
            }
            else if (Input.GetKey(KeyCode.D) && hasCoatDisguise)
            {
                state = RobState.Scientist;
               
            }

           
        }


        ChangeAppearance(state);
        Direction.Normalize();

    }

    private void ResetGame()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("VS");
        }
       
    }
    private void SetSpeed()
    {
        if(!Input.anyKey)
        {
            MovementSpeed = 0;
        }
        else
        {
            MovementSpeed = DefaultSpeed;
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

        if(state != RobState.Normal)
        {
            ResetSprite();
           
        } 
    }

    private void ResetSprite()
    {
        if (Time.time > DisguisTime)
        {
            DisguisTime = Time.time + DisguiseRate / 1000;
            state = RobState.Normal;
            hasDisguiseEquipped = false;
        }
       
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
            Debug.Log(gameState.ToString());
        }
    }
}
