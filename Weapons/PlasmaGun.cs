using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlasmaGun : MonoBehaviour
{
    public Transform plasmaGun;
    public GameObject bulletPrefab;
    private bool canShoot = true;
    public TextMeshProUGUI cd;
    void Shoot()
    {
        if(plasmaGun != null)
            Instantiate(bulletPrefab, plasmaGun.position, plasmaGun.rotation);
    }
    public void ButtonShoot()
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
        cd.transform.parent.gameObject.SetActive(true);
        for (float c = 5f; c > 0f; c--)
        {
            cd.text = "" + c / 10f;
            yield return new WaitForSeconds(.1f);
        }
        cd.transform.parent.gameObject.SetActive(false);
        canShoot = true;
    }
}
