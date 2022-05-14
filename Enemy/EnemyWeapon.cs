using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public Transform enemyFirePoint;
    public GameObject enemyBulletPrefab;
    public int secondToShoot;
    void Start()
    {
        StartCoroutine(ShootingWaiter());
    }
    void Update()
    {
        
    }
    void Shoot()
    {
        EnemyHP enemyClass = gameObject.GetComponent<EnemyHP>();
        if (!enemyClass.isFreezed)
            Instantiate(enemyBulletPrefab, enemyFirePoint.position, enemyFirePoint.rotation);
    }
    IEnumerator ShootingWaiter()
    {
        for (; ; )
        {
            secondToShoot = Random.Range(10, 20);
            yield return new WaitForSeconds(secondToShoot/10);
            Shoot();
        }
    }
}
