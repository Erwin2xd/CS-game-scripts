using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D enemy;
    private float speed = 4f;
    private float jumpHeight = 17f;
    private bool jumpOrNot;
    private bool flipOrNot;
    private int direction = 1;
    [SerializeField] private LayerMask platformsLayerMask;
    public EdgeCollider2D edgeCollider;
    public EdgeCollider2D childEdgeCollider;
    public Transform enemyHPCanvas;
    void Start()
    {
        StartCoroutine(EnemyJump());
        StartCoroutine(EnemyFlip());
        StartCoroutine(Direction());
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EnemyHP enemyClass = gameObject.GetComponent<EnemyHP>();
            if(!enemyClass.isFreezed)
                enemy.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EnemyHP enemyClass = gameObject.GetComponent<EnemyHP>();
            if (!enemyClass.isFreezed)
                enemy.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(edgeCollider.bounds.center, Vector2.down, edgeCollider.bounds.extents.y + 2.5f, platformsLayerMask);
        Color rayColor;
        if(raycastHit2D.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(edgeCollider.bounds.center, Vector2.down * (edgeCollider.bounds.extents.y + 2.5f), rayColor);
        return raycastHit2D.collider != null;
    }
    private bool WallChecker()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(childEdgeCollider.bounds.center, Vector2.right * direction, childEdgeCollider.bounds.extents.x + 1.5f, platformsLayerMask);
        Color rayColor;
        if (raycastHit2D.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(childEdgeCollider.bounds.center, Vector2.right * direction * (childEdgeCollider.bounds.extents.x + 1.5f), rayColor);
        return raycastHit2D.collider != null;
    }
    public IEnumerator EnemyJump()
    {
        for (; ; ) {

            yield return new WaitForSeconds(1f);
            if (jumpOrNot = (Random.value > 0.5f))
            {
                enemy.velocity = Vector2.up * jumpHeight;
                enemy.velocity = new Vector2(direction * speed, enemy.velocity.y);
            }
        }
    }
    public IEnumerator EnemyFlip()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(3.01f);
            if (flipOrNot = (Random.value > 0.5f))
            {
                Flip();
            }
        }
    }
    public IEnumerator Direction()
    {
        for (; ; )
        {
            enemy.velocity = new Vector2(direction * speed, enemy.velocity.y);
            if (!IsGrounded() || WallChecker())
            {
                Flip();
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    private void Flip()
    {
        enemyHPCanvas.transform.Rotate(0f, 180f, 0f);
        enemy.transform.Rotate(0f, 180f, 0);
        direction *= -1;
    }
}