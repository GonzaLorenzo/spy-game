using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    public int language;
    public float playerSpeed;
    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    static public LevelData FromJson(string JsonData)
    {
        return JsonUtility.FromJson<LevelData>(JsonData);
    }
}
