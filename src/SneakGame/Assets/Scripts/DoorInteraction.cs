using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    private GameObject Player;
    public GameManager gameMan;

    void Start()
    {
        Player = GameObject.Find("RobTheBlob");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Player)
        {
            this.gameObject.SetActive(false);          
            gameMan.ChangeRoom(); //I prob don't need this anymore?
            Player.GetComponent<MainPlayerController>().GoToNextLocation();
        }
    }
}
