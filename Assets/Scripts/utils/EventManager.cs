using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{

    protected EventManager() { }


    public delegate void SongRecognitionAction(string jsonResultStr);
    public static event SongRecognitionAction OnSongRecognized;



    public void SongRecognized(string jsonResultStr = null)
    {
        OnSongRecognized?.Invoke(jsonResultStr);
    }
}