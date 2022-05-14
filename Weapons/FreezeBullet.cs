using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = 20f;
    private float damage = 50f;
    private float TimeToLive = 1f;
    private float duration = 2f;
    void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
    void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHP hp = collision.GetComponent<EnemyHP>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
            hp.Freeze(duration);
        }
        Destroy(gameObject);
    }
}