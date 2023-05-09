using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public enum EnemyState { Garderner, Security, Scientist}
public class EnemyController : Enemy
{
    public RobState disguiseState;
    public EnemyState enemyState;

    private enum MovementState { Horizontal, Vertical, StandBy }

    [SerializeField]
    private MovementState moveState;

    private MainPlayerController RobTheBlob;

    // Start is called before the first frame update
    void Start()
    {
        RobTheBlob = GameObject.Find("RobTheBlob").GetComponent<MainPlayerController>();
        
        SetDisguise(enemyState);
        SetMovement(moveState);

        MovementSpeed = 8;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * MovementSpeed * Time.deltaTime);
    }

    void SetDisguise(EnemyState state)
    {
        switch (state)
        {
            case EnemyState.Garderner:
                disguiseState = RobState.Security;
                break;
            case EnemyState.Security:
                disguiseState= RobState.Scientist;
                
                break;
            case EnemyState.Scientist:
                disguiseState = RobState.Plant;
                break;
            default:
                disguiseState = RobState.Normal;
                break;
        }

    }

    void SetMovement(MovementState state)
    {
        switch (state)
        {
            case MovementState.Horizontal:
                Direction.x = 1;
                break;
            case MovementState.Vertical:
                Direction.y = 1;
                break;
        }

    }

    private void ChangeDirection(MovementState state)
    {
        switch (state)
        {
            case MovementState.Horizontal:
                Direction.x = -Direction.x;
                break;
            case MovementState.Vertical:
                Direction.y = -Direction.y;
                break;
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && RobTheBlob.state != disguiseState)
        {
            RobTheBlob.gameState = MainPlayerController.ConditionState.Caught;
            MovementSpeed = 0;
            //Debug.Log($"{RobTheBlob.gameState}");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall") || collision.gameObject.name == "RoomShort" || collision.gameObject.name == "RoomLong")
        {
            ChangeDirection(moveState);
        }
    }
}
