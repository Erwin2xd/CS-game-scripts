using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThunderBolt : MonoBehaviour
{
    public GameObject thunderboltObject;
    public Animator thunderboltAnimation;
    private bool canShoot = true;
    public float damage = 300f;
    public CircleCollider2D circleCollider;
    [SerializeField] private LayerMask enemiesLayerMask;
    public Transform parent;
    public Renderer thunderboltShadow;
    public Joystick joystick;
    public static bool touchingJoystick = false;
    public TextMeshProUGUI cd;
    void Start()
    {
        thunderboltShadow.material.color = new Color(1f, 1f, 1f, 0f);
        circleCollider.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHP hp = collision.GetComponent<EnemyHP>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }
        PlayerHP playerHP = collision.GetComponent<PlayerHP>();
        if (playerHP != null)
        {
            playerHP.TakeDamage(damage);
        }
    }
    public void ThunderboltFire()
    {
        if (canShoot)
        {
            transform.localPosition = new Vector3(0, 0);
            transform.parent = null;
            canShoot = false;
            StartCoroutine(Delay());
        }
    }
    IEnumerator ThunderboltCooldown()
    {
        cd.transform.parent.gameObject.SetActive(true);
        for (float c = 10f; c > 0f; c--)
        {
            cd.text = "" + c / 10f;
            yield return new WaitForSeconds(.1f);
        }
        cd.transform.parent.gameObject.SetActive(false);
        canShoot = true;
    }
    IEnumerator AnimationLength()
    {
        yield return new WaitForSeconds(.4f);
        transform.parent = parent;
        transform.localPosition = new Vector3(0, 0);
    }
    IEnumerator TakingDamage()
    {
        yield return new WaitForSeconds(.15f);
        circleCollider.enabled = true;
        yield return new WaitForSeconds(.1f);
        circleCollider.enabled = false;
    }
    IEnumerator Delay()
    {
        for (float opacity = 0f; opacity < 1f; opacity += .05f)
        {
            thunderboltShadow.material.color = new Color(1f, 1f, 1f, opacity);
            yield return new WaitForSeconds(.05f);
        }
        thunderboltShadow.material.color = new Color(1f, 1f, 1f, 0f);
        thunderboltAnimation.Play("ThunderboltW1", 0, 0f);
        StartCoroutine(TakingDamage());
        StartCoroutine(ThunderboltCooldown());
        StartCoroutine(AnimationLength());
    }
}