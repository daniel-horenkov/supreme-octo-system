using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Purchasable/Track")]
public class Track : ScriptableObject
{
    public Sprite preview;
    public AudioClip musicTrack;
    public int cost = 2500;
    public bool owned = false;
}