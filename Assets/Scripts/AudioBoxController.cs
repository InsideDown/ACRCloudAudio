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
        public string ArtistStr;
        public string SongTitleStr;

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
            Debug.Log(boxItem.ArtistStr);
            Debug.Log(boxItem.SongTitleStr);
            AudioBoxItem curAudioBox = Instantiate(AudioBoxItemPrefab, AudioBoxHolder.transform, false);
            curAudioBox.Init(isOdd, boxItem.ArtistStr, boxItem.SongTitleStr);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
