using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public float damage = 10000f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHP hp = collision.GetComponent<EnemyHP>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }
        PlayerHP playerHP = collision.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            playerHP.Die();
        }
    }
}