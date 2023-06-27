using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    public int selectedTrack = 0;
    public Image displayCover;
    public TextMeshProUGUI trackName;
    public Track[] musicTrackList;

    public MusicSlot slot;

    private AudioSource ost;

    void Start()
    {
        ost = GameObject.Find("OST").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (selectedTrack > musicTrackList.Length - 1) selectedTrack = 0;
        if (selectedTrack < 0) selectedTrack = musicTrackList.Length - 1;

        displayCover.sprite = musicTrackList[selectedTrack].cover;
        trackName.text = musicTrackList[selectedTrack].trackName;

        ost.clip = musicTrackList[selectedTrack].musicTrack;
    }

    public void PlayNextTrack()
    {
        ost.Stop();
        selectedTrack++;
        ost.Play();
    }

    public void PlayPrevTrack()
    {
        ost.Stop();
        selectedTrack--;
        ost.Play();
    }
}
