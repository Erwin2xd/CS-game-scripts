using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Victory : MonoBehaviour
{
    //private string victory = "Victory";
    public GameObject finishPanel;
    public TextMeshProUGUI expGained;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            finishPanel.SetActive(true);
            Time.timeScale = 0f;
            StartCoroutine(ExpGaining());

            //SceneManager.LoadScene(victory);
        }
    }
    IEnumerator ExpGaining()
    {
        int experienceGained = EnemyHP.experienceGained;
        PlayerHP playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>();
        LevelSystem levelSystem = playerHP.levelSystem;
        for (int i = 1; i <= experienceGained; i++)
        {
            expGained.text = "" + i;
            levelSystem.AddExperience(1);
            playerHP.levelBar.SetLevelSystem(levelSystem);
            yield return new WaitForSecondsRealtime(.02f);
        }
        playerHP.SavePlayer();
    }
}