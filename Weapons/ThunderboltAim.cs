using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderboltAim : MonoBehaviour
{
    private float speed = 15f;
    public Joystick joystick;

    private void Update()
    {
        if (joystick.Vertical > .2f && transform.localPosition.y <= WeaponsChoosed.halfHeight - 0.5f)
        {
            transform.localPosition += new Vector3(0, joystick.Vertical * Time.deltaTime * speed);
        }
        if (joystick.Vertical < -.2f && transform.localPosition.y >= -WeaponsChoosed.halfHeight + 0.5f)
        {
            transform.localPosition += new Vector3(0, joystick.Vertical * Time.deltaTime * speed);
        }
        if (joystick.Horizontal > .2f && transform.localPosition.x <= WeaponsChoosed.halfWidth - 0.5f)
        {
            transform.localPosition += new Vector3(joystick.Horizontal * Time.deltaTime * speed, 0);
        }
        if (joystick.Horizontal < -.2f && transform.localPosition.x >= -WeaponsChoosed.halfWidth + 0.5f)
        {
            transform.localPosition += new Vector3(joystick.Horizontal * Time.deltaTime * speed, 0);
        }
    }
}