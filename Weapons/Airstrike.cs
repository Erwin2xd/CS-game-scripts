using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Airstrike : MonoBehaviour
{
    public Transform airStrikePoint;
    public GameObject airStrikePrefab;
    private bool canShoot = true;
    private float speed = 10f;
    public GameObject StartingPoint;
    public Joystick joystick;
    public GameObject ray;
    public GameObject noRay;
    [SerializeField] private LayerMask platformsLayerMask;
    public TextMeshProUGUI cd;
    void Update()
    {
        if (joystick.Horizontal > .2f && transform.localPosition.x <= WeaponsChoosed.halfWidth - 0.5f)
        {
            transform.localPosition += new Vector3(joystick.Horizontal * Time.deltaTime * speed, 0);
        }
        if (joystick.Horizontal < -.2f && transform.localPosition.x >= -WeaponsChoosed.halfWidth + 0.5f)
        {
            transform.localPosition += new Vector3(joystick.Horizontal * Time.deltaTime * speed, 0);
        }
        ray.transform.localScale = new Vector3(ray.transform.localScale.x, Ray());
        ray.transform.localPosition = new Vector3(ray.transform.localPosition.x, Ray() / -2f + 2f);
        if (ray.transform.localScale.y > 2f)
        {
            noRay.SetActive(false);
        }
        else
        {
            noRay.SetActive(true);
        }
    }
    private float Ray()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(airStrikePoint.transform.position + new Vector3(0f, 2f), new Vector2(1f, .01f), 0f, Vector2.down, 50f, platformsLayerMask);
        return raycastHit2D.distance;
    }
    void Shoot()
    {
        if (ray.transform.localScale.y > 2f)
        {
            Instantiate(airStrikePrefab, airStrikePoint.position + new Vector3(0f, 1f), airStrikePoint.rotation);
            StartCoroutine(AirStrikeCooldown());
        }
        else
        {
            //Text Animation: "Obstacle on the way"
        }
    }
    public void ButtonShot()
    {
        if (canShoot)
        {
            Shoot();
        }
    }
    IEnumerator AirStrikeCooldown()
    {
        canShoot = false;
        cd.transform.parent.gameObject.SetActive(true);
        for (float c = 20f; c > 0f; c--)
        {
            cd.text = ""+c/10f;
            yield return new WaitForSeconds(.1f);
        }
        cd.transform.parent.gameObject.SetActive(false);
        canShoot = true;
    }
}
