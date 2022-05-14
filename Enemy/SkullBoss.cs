using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullBoss : MonoBehaviour
{
    public Rigidbody2D boss;
    private float speed = 4f;
    private int direction = 1;
    void Start()
    {
        InvokeRepeating("BossMovement", 0f, 3f);
    }
    void BossMovement()
    {
        boss.velocity = new Vector2(direction * speed, boss.velocity.y);
        direction *= -1;
    }
}