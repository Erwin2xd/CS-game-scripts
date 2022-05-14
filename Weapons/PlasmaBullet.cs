using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBullet : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = 1f;
    private float damage = 10f;
    private float TimeToLive = 1f;

    void Start()
    {
        Destroy(gameObject, TimeToLive);
    }
    void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
        transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime);
        damage += 1.5f;
        speed += .5f;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHP hp = collision.GetComponent<EnemyHP>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}