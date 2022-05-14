using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem
{
    private int level;
    private int experience;
    private int experienceToNextLevel;

    public LevelSystem()
    {
        level = 1;
        experience = 0;
        experienceToNextLevel = 100;
    }
    public void AddExperience(int amount)
    {
        experience += amount;
        while(experience >= experienceToNextLevel)
        {
            level++;
            experience -= experienceToNextLevel;
        }
    }
    public int GetLevelNumber()
    {
        return level;
    }
    public int GetExp()
    {
        return experience;
    }
    public int GetExpNeeded()
    {
        return experienceToNextLevel;
    }
    public void SetLevelNumber(int levelToSet)
    {
        level = levelToSet;
    }
    public void SetExp(int expToSet)
    {
        experience = expToSet;
    }
    public void SetExpNeeded(int expNeededToSet)
    {
        experienceToNextLevel = expNeededToSet;
    }
}