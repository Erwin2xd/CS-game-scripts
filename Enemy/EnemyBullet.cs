using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float damage = 50f;
    public Rigidbody2D rb;
    public float TimeToLive = 1f;

    void Start()
    {
        speed = Random.Range(8, 16);
        rb.velocity = transform.right * speed;
        Destroy(gameObject, TimeToLive);
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerHP playerHP = hitInfo.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            playerHP.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
