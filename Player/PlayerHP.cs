using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    private string menu = "Menu";
    public float maxHealth = 100f;
    public float health;
    public HealthBar healthBar;
    public LevelSystem levelSystem = new LevelSystem();
    public LevelBar levelBar;
    public GameObject RNGCanvas;
    public GameObject respawn;
    void Start()
    {
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
            StartCoroutine(RNGCanvas.GetComponent<RNG>().Waiter(trueOrFalse =>
                {
                    if (trueOrFalse)
                    {
                        health = 0.5f * maxHealth;
                        healthBar.SetHealth(health);
                        StartCoroutine(Respawn());
                    }
                    else
                    {
                        Die();
                    }
                }));
        }
    }
    public void Die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(menu);
    }
    IEnumerator Respawn()
    {
        respawn.SetActive(true);
        yield return new WaitForSeconds(1f);
        respawn.SetActive(false);
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        healthBar.SetHealth(health);
        levelSystem.SetLevelNumber(data.level);
        levelSystem.SetExp(data.exp);
        levelSystem.SetExpNeeded(data.expNeeded);
        levelBar.SetLevelSystem(levelSystem);
    }
}