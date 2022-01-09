using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioBoxController : MonoBehaviour
{

    public GameObject AudioBoxHolder;
    public AudioBoxItem AudioBoxItemPrefab;

    [Serializable]
    public struct AudioBoxArtist
    {
        public int ManualTimesPlayedInt;
        public string ArtistStr;
        public string SongTitleStr;
        public bool IsRed;
    }

    public List<AudioBoxArtist> AudioBoxItemList = new List<AudioBoxArtist>();

    private int _Spacing = 165;

    private void Awake()
    {
        if (AudioBoxHolder == null)
            throw new System.Exception("An AudioBoxHolder must be defined in AudioBoxController");

        if (AudioBoxHolder == null)
            throw new System.Exception("An AudioBoxHolder must be defined in AudioBoxController");
    }
    private void Start()
    {
        SetupBoxes();    
    }

    private void SetupBoxes()
    {
        bool isOdd = true;
        int counter = 0;
        foreach(AudioBoxArtist boxItem in AudioBoxItemList)
        {
            AudioBoxItem curAudioBox = Instantiate(AudioBoxItemPrefab, AudioBoxHolder.transform, false);
            curAudioBox.Init(isOdd, boxItem.ManualTimesPlayedInt, boxItem.ArtistStr, boxItem.SongTitleStr, boxItem.IsRed);
            if(isOdd)
            {
                isOdd = false;
            }else
            {
                isOdd = true;
            }
            curAudioBox.transform.localPosition = new Vector3(curAudioBox.transform.localPosition.x, curAudioBox.transform.localPosition.y - (counter * _Spacing), curAudioBox.transform.localPosition.z);
            counter++;
        }
    }
}
