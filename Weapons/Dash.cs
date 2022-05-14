using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dash : MonoBehaviour
{
    public Button dashButton;
    public Rigidbody2D player;
    private BoxCollider2D dashHitbox;
    public static bool imDashing = false;
    private int direction = 1;
    private float dashSpeed = 40f;
    private float damage = 100f;
    private bool canDash = true;
    public TextMeshProUGUI cd;
    void Start()
    {
        dashHitbox = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (player.velocity.x > 0f)
            direction = 1;
        else if (player.velocity.x < 0f)
            direction = -1;
    }
    public void ButtonDash()
    {
        if(canDash)
            StartCoroutine(DashProcess());
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHP hp = collision.GetComponent<EnemyHP>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }
    }
    IEnumerator DashProcess()
    {
        StartCoroutine(DashCooldown());
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemies"), LayerMask.NameToLayer("Player"), true);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Bullets"), LayerMask.NameToLayer("Player"), true);
        imDashing = true;
        dashHitbox.enabled = true;
        player.velocity = new Vector2(direction * dashSpeed, 0f);
        yield return new WaitForSeconds(.2f);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemies"), LayerMask.NameToLayer("Player"), false);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Bullets"), LayerMask.NameToLayer("Player"), false);
        player.velocity = new Vector2(0f, player.velocity.y);
        imDashing = false;
        dashHitbox.enabled = false;
    }
    IEnumerator DashCooldown()
    {
        dashButton.interactable = false;
        canDash = false;
        cd.transform.parent.gameObject.SetActive(true);
        for (float c = 30f; c > 0f; c--)
        {
            cd.text = "" + c / 10f;
            yield return new WaitForSeconds(.1f);
        }
        cd.transform.parent.gameObject.SetActive(false);
        canDash = true;
        dashButton.interactable = true;
    }
    private void OnDisable()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemies"), LayerMask.NameToLayer("Player"), false);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Bullets"), LayerMask.NameToLayer("Player"), false);
        player.velocity = new Vector2(0f, player.velocity.y);
        imDashing = false;
        dashHitbox.enabled = false;
    }
}