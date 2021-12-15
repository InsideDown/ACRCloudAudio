using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource MyAudioSource;
    public List<AudioClip> MyAudioClips; 


    private void Awake()
    {
        if (MyAudioSource == null)
            throw new System.Exception("A MyAudioSource must be defined in AudioController");
    }

    private void OnEnable()
    {
        EventManager.OnSkipSong += EventManager_OnSkipSong;
    }

    private void OnDisable()
    {
        EventManager.OnSkipSong -= EventManager_OnSkipSong;
    }

    private void EventManager_OnSkipSong()
    {
        SkipSong();
    }

    private void SkipSong()
    {
        Debug.Log("SKIP THIS SONG");
        int ranInt = Random.Range(0, MyAudioClips.Count);
        AudioClip ranClip = MyAudioClips[ranInt];
        MyAudioSource.clip = ranClip;
        MyAudioSource.Play();
    }
}
