using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSaves : MonoBehaviour
{
    public CubeSkin[] skinList;

    private void Start()
    {
        try
        {
            SkinSaves save = JsonUtility.FromJson<SkinSaves>(PlayerPrefs.GetString("skinSaves"));
            skinList = save.skinList;
        }
        catch { }
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("skinSaves", json);
    }
}