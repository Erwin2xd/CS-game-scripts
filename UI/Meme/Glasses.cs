using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Glasses : MonoBehaviour
{
    public Image flash;
    public GameObject playAgain;
    private float opacity = 0f;
    private bool counter = false;
    private string menu = "Menu";
    void FixedUpdate()
    {
        if (transform.localPosition.y >= 3.1f && !counter)
        {
            transform.localPosition += new Vector3(0, -3f);
        }
        else if (transform.localPosition.y < 3.1f && opacity < 1f && !counter)
        {
            flash.color = new Color(255, 255, 255, opacity);
            opacity += .01f;
            flash.transform.Rotate(0, 0, 1f);
        }
        else
        {
            counter = true;
            flash.color = new Color(255, 255, 255, opacity);
            opacity -= .01f;
            flash.transform.Rotate(0, 0, -1f);
            playAgain.SetActive(true);
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(menu);
    }
}
