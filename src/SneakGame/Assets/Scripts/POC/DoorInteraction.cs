using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    private GameObject Player; //Should this be public? Or make a scriptable object?
    public GameManager gameMan;

    void Start()
    {
        Player = GameObject.Find("RobTheBlob");
    }

    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Player)
        {
            this.gameObject.SetActive(false);          
            gameMan.ChangeRoom();
        }
    }
}
