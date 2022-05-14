using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TextMeshProUGUI levelText;
    private LevelSystem levelSystem;
    public void SetExpNeeded(int exp)
    {
        slider.maxValue = exp;
    }
    public void SetExp(int exp)
    {
        slider.value = exp;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void SetLevelNumber(int levelNumber)
    {
        levelText.text = "" + levelNumber;
    }
    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        SetLevelNumber(levelSystem.GetLevelNumber());
        SetExp(levelSystem.GetExp());
        SetExpNeeded(levelSystem.GetExpNeeded());
    }
}