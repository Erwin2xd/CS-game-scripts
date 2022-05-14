using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private string chooseWeapon = "ChooseWeapon";
    public void Play()
    {
        SceneManager.LoadScene(chooseWeapon);
        Time.timeScale = 1f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
