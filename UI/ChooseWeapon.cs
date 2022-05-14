using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseWeapon : MonoBehaviour
{
    private string main = "Main";
    public static string weapon;
    public static string subweapon;
    public void Play()
    {
        SceneManager.LoadScene(main);
    }
    public void Thunderbolt()
    {
        weapon = "thunderbolt";
    }
    public void AirStrike()
    {
        weapon = "airstrike";
    }
    public void Gun()
    {
        weapon = "gun";
    }
    public void Sword()
    {
        subweapon = "sword";
    }
    public void Dash()
    {
        subweapon = "dash";
    }
    public void Freeze()
    {
        subweapon = "freeze";
    }
}
