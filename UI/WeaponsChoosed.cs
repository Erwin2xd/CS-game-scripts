using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsChoosed : MonoBehaviour
{
    private Camera cam;
    public static float halfHeight;
    public static float halfWidth;
    private GameObject weapon;
    private GameObject weaponUI;
    private GameObject subweapon;
    private GameObject subweaponUI;
    public GameObject thunderbolt;
    public GameObject thunderboltUI;
    public GameObject airStrike;
    public GameObject airStrikeUI;
    public GameObject plasmaGun;
    public GameObject plasmaGunUI;
    public GameObject sword;
    public GameObject swordUI;
    public GameObject dash;
    public GameObject dashUI;
    public GameObject freeze;
    public GameObject freezeUI;
    void Start()
    {
        cam = Camera.main;
        halfHeight = cam.orthographicSize;
        halfWidth = halfHeight * cam.aspect;
        if (ChooseWeapon.weapon == "thunderbolt")
        {
            weapon = thunderbolt;
            weaponUI = thunderboltUI;
        }
        if (ChooseWeapon.weapon == "airstrike")
        {
            weapon = airStrike;
            weaponUI = airStrikeUI;
        }
        if (ChooseWeapon.weapon == "gun")
        {
            weapon = plasmaGun;
            weaponUI = plasmaGunUI;
        }
        if (ChooseWeapon.subweapon == "sword")
        {
            subweapon = sword;
            subweaponUI = swordUI;
        }
        if (ChooseWeapon.subweapon == "dash")
        {
            subweapon = dash;
            subweaponUI = dashUI;
        }
        if (ChooseWeapon.subweapon == "freeze")
        {
            subweapon = freeze;
            subweaponUI = freezeUI;
        }
        if (weapon != null & weaponUI != null)
        {
            weapon.SetActive(true);
            weaponUI.SetActive(true);
        }
        if (subweapon != null & subweaponUI != null)
        {
            subweapon.SetActive(true);
            subweaponUI.SetActive(true);
        }
        PlayerHP playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>();
        playerHP.LoadPlayer();
    }
}