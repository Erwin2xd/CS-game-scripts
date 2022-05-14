using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Freeze : MonoBehaviour
{
    public Button freezeButton;
    public Transform firePoint;
    public GameObject freezePrefab;
    private bool canShoot = true;
    public TextMeshProUGUI cd;
    void Shoot()
    {
        if (firePoint != null)
            Instantiate(freezePrefab, firePoint.position, firePoint.rotation);
    }
    public void ButtonFreeze()
    {
        if (canShoot)
        {
            Shoot();
            StartCoroutine(Cooldown());
        }
    }
    IEnumerator Cooldown()
    {
        canShoot = false;
        freezeButton.interactable = false;
        cd.transform.parent.gameObject.SetActive(true);
        for (float c = 30f; c > 0f; c--)
        {
            cd.text = "" + c / 10f;
            yield return new WaitForSeconds(.1f);
        }
        cd.transform.parent.gameObject.SetActive(false);
        freezeButton.interactable = true;
        canShoot = true;
    }
}