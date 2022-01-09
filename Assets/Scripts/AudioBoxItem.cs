using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class AudioBoxItem : MonoBehaviour
{
    public GameObject BackgroundImageRed;
    public GameObject BackgroundImageDark;
    public GameObject BackgroundImageLight;
    public TextMeshProUGUI ArtistTxt;
    public TextMeshProUGUI SongTitleTxt;
    public TextMeshProUGUI SongCountTxt;
    public TextMeshProUGUI SongLimitTxt;

    private int _SongPlayedCount = 0;
    private int _SongLimitCount = 0;
    private string _MySongStr;
    private string _MyArtistStr;

    private void Awake()
    {
        if (BackgroundImageRed == null) throw new System.Exception("An BackgroundImageRed must be defined in AudioBoxItem");
        if (BackgroundImageDark == null) throw new System.Exception("An BackgroundImageDark must be defined in AudioBoxItem");
        if (BackgroundImageLight == null) throw new System.Exception("An BackgroundImageLight must be defined in AudioBoxItem");
        if (ArtistTxt == null) throw new System.Exception("An ArtistTxt must be defined in AudioBoxItem");
        if (SongTitleTxt == null) throw new System.Exception("An SongTitleTxt must be defined in AudioBoxItem");
        if (SongCountTxt == null) throw new System.Exception("An SongCountTxt must be defined in AudioBoxItem");
        if (SongLimitTxt == null) throw new System.Exception("An SongLimitTxt must be defined in AudioBoxItem");

        BackgroundImageRed.SetActive(false);
    }

    public void Init(bool useDarkBackground, int timesPlayed, string artistStr, string songStr, bool isRed)
    {

        BackgroundImageDark.gameObject.SetActive(useDarkBackground);
        BackgroundImageLight.gameObject.SetActive(!useDarkBackground);

        _SongPlayedCount = timesPlayed;
        _MyArtistStr = artistStr;
        _MySongStr = songStr;

        SongCountTxt.text = timesPlayed.ToString();
        ArtistTxt.text = artistStr;
        SongTitleTxt.text = songStr;

        if (isRed)
            SetRed();
    }

    private void SetSongLimit(bool isUp = true)
    {
        if(isUp)
        {
            _SongLimitCount++;
        }else{
            _SongLimitCount--;
            if (_SongLimitCount <= 0)
                _SongLimitCount = 0;
        }

        SongLimitTxt.text = _SongLimitCount.ToString();
    }

    private void IncrementSongCount()
    {
        _SongPlayedCount++;
        SongCountTxt.text = _SongPlayedCount.ToString();
    }

    private void CheckIfTooManyPlayed()
    {
        if(_SongPlayedCount >= _SongLimitCount)
        {
            //TODO: play your alexa audio skip here
            EventManager.Instance.SkipSong();
            SetRed();
            this.gameObject.transform.DOScale(new Vector3(1.05f,1.05f,1.05f), 0.5f).SetEase(Ease.OutBack);
        }
    }

    private void SetRed()
    {
        BackgroundImageDark.gameObject.SetActive(false);
        BackgroundImageLight.gameObject.SetActive(false);
        BackgroundImageRed.gameObject.SetActive(true);
    }

    public void OnBtnUpClick()
    {
        SetSongLimit(true);
    }

    public void OnBtnDownClick()
    {
        SetSongLimit(false);
    }

    private void OnEnable()
    {
        EventManager.OnArtistAndSongRecognized += EventManager_OnArtistAndSongRecognized;
    }

    private void OnDisable()
    {
        EventManager.OnArtistAndSongRecognized -= EventManager_OnArtistAndSongRecognized;
    }

    private void EventManager_OnArtistAndSongRecognized(string artistStr, string songStr)
    {
        CheckSongMatch(artistStr, songStr);
    }

    private void CheckSongMatch(string artistStr, string songStr)
    {
        //only check artist match for now
        if(_MyArtistStr.ToLower() == artistStr.ToLower())
        {
            //if(_MySongStr.ToLower() == songStr.ToLower())
            //{
            IncrementSongCount();
            CheckIfTooManyPlayed();
            EventManager.Instance.SkipSong();
            //}
        }
    }
}
