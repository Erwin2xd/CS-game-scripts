using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float maxHealth;
    private float health;
    public HealthBar healthBar;
    public GameObject iceCube;
    public bool isFreezed = false;
    public static int experienceGained;
    void Start()
    {
        experienceGained = 0;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(health);
}
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }
    public void Freeze(float duration)
    {
        if (gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            iceCube.SetActive(true);
            isFreezed = true;
            StartCoroutine(Unfreeze(duration));
        }
    }
    void Die()
    {
        if (gameObject.layer == LayerMask.NameToLayer("Enemies"))
        {
            experienceGained += 120;
            Instantiate(Resources.Load("Items/AirstrikeDefault"), transform.localPosition, Quaternion.identity);
        }
        else if (gameObject.layer == LayerMask.NameToLayer("Boss"))
        {
            experienceGained += 300;
        }
        Destroy(gameObject);
    }
    IEnumerator Unfreeze(float duration)
    {
        yield return new WaitForSeconds(duration);
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
        isFreezed = false;
        iceCube.SetActive(false);
    }
}