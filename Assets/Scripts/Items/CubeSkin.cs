using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Purchasable/CubeSkin")]
public class CubeSkin : ScriptableObject
{
    public string skinName;
    public Sprite preview;
    public Material material;
    public int cost = 5000;
    public bool owned = false;

    private void Awake()
    {
        owned = PlayerPrefs.GetInt(skinName, 0) == 1;
    }

    public void SaveOwn()
    {
        owned = true;
        PlayerPrefs.SetInt(skinName, 1);
    }
}