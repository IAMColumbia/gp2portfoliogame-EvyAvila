using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //Extract to higher level class
    public float MovementSpeed { get; set; }
    public float DefaultSpeed { get; set; }
    public BoxCollider2D boxCollider { get; set; }
    public Rigidbody2D rigidBody { get; set; }
   
    public Vector2 Direction;
}
