using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSpeedController : MonoBehaviour
{
    public AudioSource ScrubAudioSource;
    public Slider ScrubSlider;

    private float _AnimAudioTime;
    private float _CurAudioTime = 0.0f;
    private void Awake()
    {
        if (ScrubAudioSource == null)
            throw new System.Exception("A ScrubAudioSource must be defined in AudioSpeedController");

        if (ScrubSlider == null)
            throw new System.Exception("A ScrubSlider must be defined in AudioSpeedController");

        _AnimAudioTime = ScrubAudioSource.clip.length;

        ScrubAudioSource.Play();
        ScrubAudioSource.Pause();
        _CurAudioTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //******
        /* change via time
        float newAudioTime = ScrubSlider.value * _AnimAudioTime;
        _CurAudioTime += (newAudioTime - _CurAudioTime) * 0.01f;
        ScrubAudioSource.time = _CurAudioTime;
        if (Mathf.Abs(newAudioTime - _CurAudioTime) < 0.1f)
        {
            ScrubAudioSource.Pause();
        }
        else
        {
            ScrubAudioSource.UnPause();
        }
        */
    }
}
