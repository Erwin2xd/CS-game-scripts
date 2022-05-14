using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBombs : MonoBehaviour
{
    public GameObject bombPrefab;
    public Transform boss;
    void Start()
    {
        InvokeRepeating("SpawnBombs", 3f, 3f);
    }
    void SpawnBombs()
    {
        Instantiate(bombPrefab, boss.position, boss.rotation);
    }
}