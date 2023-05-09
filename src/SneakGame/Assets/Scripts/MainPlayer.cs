using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public float MovementSpeed { get; set; }
    public float DefaultSpeed { get; set; }
    public BoxCollider2D boxCollider { get; set; }
    public Rigidbody2D rigidBody { get; set; }
    public SpriteRenderer spriteRen { get; set; }

    public Vector2 Direction;
}
