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

    private MainPlayerController RobTheBlob;

    // Start is called before the first frame update
    void Start()
    {
        RobTheBlob = GameObject.Find("RobTheBlob").GetComponent<MainPlayerController>();
        
        SetDisguise(enemyState);
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player") && RobTheBlob.state == disguiseState )
        {
            Debug.Log("Ignore");
        }
        else
        {
            RobTheBlob.gameState = MainPlayerController.ConditionState.Caught;
            Debug.Log($"{RobTheBlob.gameState}");
        }
    }
}
