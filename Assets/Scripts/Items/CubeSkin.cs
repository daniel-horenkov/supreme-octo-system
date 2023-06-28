using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Purchasable/CubeSkin")]
public class CubeSkin : ScriptableObject
{
    public string skinName;
    public Sprite preview;
    public Material material;
    public int cost = 5000;
    public bool owned = false;
}