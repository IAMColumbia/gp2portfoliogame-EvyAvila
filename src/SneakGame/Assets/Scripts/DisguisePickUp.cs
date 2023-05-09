using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DisguisePickUp : MonoBehaviour
{
    public enum DisguiseObjects { Plant, Hat, Coat}
    public DisguiseObjects disguiseObjects;

    private MainPlayerController RobTheBlob;

    // Start is called before the first frame update
    void Start()
    {
        RobTheBlob = GameObject.Find("RobTheBlob").GetComponent<MainPlayerController>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            RobTheBlob.hasDisguise.Add(this.gameObject);

            this.gameObject.SetActive(false);
        }
    }

    
}
