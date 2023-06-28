using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicSlot : MonoBehaviour
{
    public Track track;

    MusicPlayer jukebox;

    public Image cover;
    public TextMeshProUGUI textTrackName;

    void Start()
    {
        jukebox = GameObject.Find("Jukebox").GetComponent<MusicPlayer>();

        cover.sprite = track.cover;
        textTrackName.text = track.trackName;
    }

    public void PlaySpecTrack()
    {
        jukebox.PlayNextTrack(track.trackSlotNumber - jukebox.selectedTrack);
    }
}