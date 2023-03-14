using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum RobState { Plant, Security, Scientist, Normal}
public class MainPlayerController : MainPlayer
{
    private RobState state;
    public Sprite plant;
    public Sprite Security;
    public Sprite Scientist;
    private Sprite Normal;

    private float DisguiseRate = 5000f; //milliseconds -> 5 seconds 

    private float DisguisTime;


    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();

        MovementSpeed = 4;
        DefaultSpeed = MovementSpeed;
        Normal = this.GetComponent<SpriteRenderer>().sprite;
        state = RobState.Normal;
        
    }

    
    void FixedUpdate()
    {
        PlayerController();
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

        if(Input.GetKey(KeyCode.A))
        {
            state = RobState.Plant;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            state = RobState.Security;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            state = RobState.Scientist;
        }
        /*
        else if (Input.GetKey(KeyCode.W))
        {
            state = RobState.Normal;
        }*/
        ChangeAppearance(state);
        //Direction = keyDirection;
        Direction.Normalize();

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
                break;
            case RobState.Security:
                this.GetComponent<SpriteRenderer>().sprite = Security;
                break;
            case RobState.Scientist:
                this.GetComponent<SpriteRenderer>().sprite = Scientist;
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
        }
    }


}
