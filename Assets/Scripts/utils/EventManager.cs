using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{

    protected EventManager() { }


    public delegate void SongRecognitionAction(string jsonResultStr);
    public static event SongRecognitionAction OnSongRecognized;

    public delegate void ArtistSongRecognizedAction(string artistStr, string songStr);
    public static event ArtistSongRecognizedAction OnArtistAndSongRecognized;


    public delegate void SkipSongAction();
    public static event SkipSongAction OnSkipSong;


    public void SongRecognized(string jsonResultStr = null)
    {
        OnSongRecognized?.Invoke(jsonResultStr);
    }

    public void ArtistSongRecognized(string artistStr, string songStr)
    {
        OnArtistAndSongRecognized?.Invoke(artistStr,songStr);
    }

    public void SkipSong()
    {
        OnSkipSong?.Invoke();
    }
}
