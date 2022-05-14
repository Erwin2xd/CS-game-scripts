using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int exp;
    public int expNeeded;
    public PlayerData (PlayerHP player)
    {
        level = player.levelSystem.GetLevelNumber();
        exp = player.levelSystem.GetExp();
        expNeeded = player.levelSystem.GetExpNeeded();
    }
}