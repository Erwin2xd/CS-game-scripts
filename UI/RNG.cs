using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RNG : MonoBehaviour
{
    public static bool RNGPaused = false;
    public GameObject RNGMenuUI;
    //private float result;
    //private float elementsToRNG = 5;
    public Text textObject;

    public IEnumerator Waiter(System.Action<bool> callback)
    {
        Pause();
        bool trueOrFalse = (Random.value > 0.5f);
        yield return new WaitForSecondsRealtime(2f);
        if (trueOrFalse)
        {
            textObject.text = "POSITIVE";
            textObject.color = new Color(0, 255, 0);
        }
        else
        {
            textObject.text = "NEGATIVE";
            textObject.color = new Color(255, 0, 0);
        }
        //result = Random.Range(1, elementsToRNG);
        yield return new WaitForSecondsRealtime(2f);
        textObject.text = "?";
        textObject.color = new Color(255, 255, 255);
        callback(trueOrFalse);
        Resume();
    }
    public void Resume()
    {
        RNGMenuUI.SetActive(false);
        Time.timeScale = 1f;
        RNGPaused = false;
    }
    void Pause()
    {
        RNGMenuUI.SetActive(true);
        Time.timeScale = 0f;
        RNGPaused = true;
    }
}
