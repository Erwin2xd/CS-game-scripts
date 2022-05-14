using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyingBulletAI : MonoBehaviour
{
    private GameObject player;
    private Transform target;
    private float damage = 100f;
    private float speed = 400000f;
    private float nextWaypointDistance = 1f;
    public Transform enemyGFX;
    Path path;
    int currentWaypoint = 0;
    //bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if(player != null)
            target = player.GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        Destroy(gameObject, 5f);
    }
    void UpdatePath()
    {
        if(seeker.IsDone() && target != null)
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerHP playerHP = collision.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            playerHP.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (collision.tag == "Respawn")
            Destroy(gameObject);
    }
    void Update()
    {
        if (path == null)
            return;

        if(currentWaypoint >= path.vectorPath.Count)
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

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if(rb.velocity.x >= 0.01f && force.x > 0f)
        {
            enemyGFX.localScale = new Vector3(-0.2f, 0.2f, 1f);
        }
        else if(rb.velocity.x <= -0.01f && force.x < 0f)
        {
            enemyGFX.localScale = new Vector3(0.2f, 0.2f, 1f);
        }
    }
}