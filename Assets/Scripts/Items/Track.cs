using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Purchasable/Track")]
public class Track : ScriptableObject
{
    public string trackName;
    public int trackSlotNumber;
    public Sprite cover;
    public AudioClip musicTrack;
}