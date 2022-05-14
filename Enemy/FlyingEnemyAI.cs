using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingEnemyAI : MonoBehaviour
{
    private GameObject player;
    private Transform target;
    private float speed = 400000f;
    private float nextWaypointDistance = 3f;
    public Transform enemyGFX;
    Path path;
    int currentWaypoint = 0;
    //bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;
    public GameObject bulletPrefab;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            target = player.GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        InvokeRepeating("Shot", 0f, 1f);
    }
    void Shot()
    {
        Instantiate(bulletPrefab, enemyGFX.transform.position, enemyGFX.transform.rotation);
    }
    void UpdatePath()
    {
        if (seeker.IsDone() && target != null)
            seeker.StartPath(rb.position, target.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    void Update()
    {
        enemyGFX.transform.right = target.position - enemyGFX.transform.position;
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            //reachedEndOfPath = true;
            return;
        }
        else
        {
            //reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
