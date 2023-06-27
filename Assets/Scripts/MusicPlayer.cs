using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    public int selectedTrack = 0;
    public Image displayCover, pauseButton;
    public TextMeshProUGUI trackName;
    public Track[] musicTrackList;

    private AudioSource ost;
    public Sprite play, pause;

    void Start()
    {
        ost = GameObject.Find("OST").GetComponent<AudioSource>();
        PlayNextTrack(0);
    }

    public void PlayNextTrack(int i)
    {
        ost.Stop();
        selectedTrack += i;

        if (selectedTrack > musicTrackList.Length - 1) selectedTrack = 0;
        if (selectedTrack < 0) selectedTrack = musicTrackList.Length - 1;

        displayCover.sprite = musicTrackList[selectedTrack].cover;
        trackName.text = musicTrackList[selectedTrack].trackName;

        ost.clip = musicTrackList[selectedTrack].musicTrack;

        ost.Play();
    }

    public void Pause()
    {
        if (ost.isPlaying)
        {
            ost.Pause(); pauseButton.sprite = pause;
        }
        else
        {
            ost.Play(); pauseButton.sprite = play;
        }
    }
}
