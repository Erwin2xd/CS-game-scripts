using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirMissle : MonoBehaviour
{
    private float speed = 2f;
    private float damage = 60f;
    public Rigidbody2D airstrike;
    public CapsuleCollider2D capsuleCollider;
    public CircleCollider2D circleCollider;
    public GameObject airMissleBoom;
    public GameObject airMissleGFX;
    private float boomSize;
    private float timeToLive = 5f;
    private bool isWorking = false;
    private bool dealingDamage = false;
    void Start()
    {
        Destroy(airstrike, timeToLive);
    }
    private void FixedUpdate()
    {
        damage += 2.5f;
        speed += .4f;
        airstrike.velocity = -transform.up * speed;
        boomSize += .025f;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isWorking)
            StartCoroutine(Boom());
        EnemyHP hp = collision.GetComponent<EnemyHP>();
        if (hp != null && dealingDamage)
        {
            hp.TakeDamage(damage);
        }
        PlayerHP playerHP = collision.GetComponent<PlayerHP>();
        if (playerHP != null && dealingDamage)
        {
            playerHP.TakeDamage(damage);
        }
        dealingDamage = true;
    }
    IEnumerator Boom()
    {
        isWorking = true;
        airstrike.constraints = RigidbodyConstraints2D.FreezeAll;
        capsuleCollider.enabled = false;
        Destroy(airMissleGFX);
        airMissleBoom.transform.localScale = new Vector2(airMissleBoom.transform.localScale.x + boomSize, airMissleBoom.transform.localScale.y + boomSize);
        airMissleBoom.SetActive(true);
        yield return new WaitForSeconds(.1f);
        circleCollider.enabled = false;
        yield return new WaitForSeconds(.4f);
        Destroy(gameObject);
    }
}