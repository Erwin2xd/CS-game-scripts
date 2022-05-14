using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Sword : MonoBehaviour
{
    public Button swordButton;
    public float damage;
    public CircleCollider2D attackRange;
    public Animator animator;
    private bool canAttack = true;
    public TextMeshProUGUI cd;
    private void Start()
    {
        attackRange.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyHP hp = collision.GetComponent<EnemyHP>();
        if (hp != null)
        {
            hp.TakeDamage(damage);
        }
    }
    public void MeleeAttack()
    {
        if (canAttack)
        {
            animator.SetBool("Attack", true);
            StartCoroutine(Hit());
            StartCoroutine(AttackCooldown());
        }
    }
    IEnumerator AttackCooldown()
    {
        canAttack = false;
        swordButton.interactable = false;
        cd.transform.parent.gameObject.SetActive(true);
        for (float c = 5f; c > 0f; c--)
        {
            cd.text = "" + c / 10f;
            yield return new WaitForSeconds(.1f);
        }
        cd.transform.parent.gameObject.SetActive(false);
        swordButton.interactable = true;
        canAttack = true;
    }
    IEnumerator Hit()
    {
        attackRange.enabled = true;
        yield return new WaitForSeconds(.1f);
        attackRange.enabled = false;
        animator.SetBool("Attack", false);
    }
    private void OnEnable()
    {
        canAttack = true;
        swordButton.interactable = true;
    }
    private void OnDisable()
    {
        canAttack = false;
    }
}