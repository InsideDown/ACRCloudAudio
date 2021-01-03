using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SongRecognizer
{

    [Serializable]
    public class AudioJSON
    {
        public Status status;
        public Metadata metadata;
    }

    [Serializable]
    public class Status
    {
        public string msg;
        public int code;
        public string version;
    }

    [Serializable]
    public class Metadata
    {
        public List<Music> music;
    }

    [Serializable]
    public class Music
    {
        public string release_date;
        public string title;
        public List<Artist> artists;
    }

    [Serializable]
    public class Artist
    {
        public string name;
    }

    public class SongReconitionController : MonoBehaviour
    {
        public TextMeshProUGUI ArtistTxt;
        public TextMeshProUGUI SongTitleTxt;

        //https://console-v2.acrcloud.com/avr?region=eu-west-1#/projects/online
        //private string _JSONSTR = "{\"status\":{\"msg\":\"Success\",\"code\":0,\"version\":\"1.0\"},\"metadata\":{\"music\":[{\"release_date\":\"Success\",\"code\":0,\"title\":\"Jesus of Suburbia\"}]}}";
        //private string _SongToSkip = "jesus of suburbia";

        private void Awake()
        {
            //ParseSongJSON(_JSONSTR);
            if (ArtistTxt == null) throw new System.Exception("An ArtistTxt must be defined in SongReconitionController");
            if (SongTitleTxt == null) throw new System.Exception("An ArtistTxt must be defined in SongReconitionController");    
        }

        private IEnumerator ListSongAndArtist(string artistStr, string titleStr)
        {
            if (titleStr == "Wonderful Christmastime - Reamstered")
                titleStr = "Wonderful Christmastime - Remastered";

            if (!string.IsNullOrEmpty(artistStr))
                ArtistTxt.text = artistStr;

            if (!string.IsNullOrEmpty(titleStr))
                SongTitleTxt.text = titleStr;

            Debug.Log("artistStr: " + artistStr);
            Debug.Log("songStr: " + titleStr);

            EventManager.Instance.ArtistSongRecognized(artistStr, titleStr);

            yield return null;
        }

        public void ParseSongJSON(string jsonResultStr)
        {

            //Debug.Log(jsonResultStr);

            //AudioJSON myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 

            Debug.Log("----");
            AudioJSON audioJSON = JsonUtility.FromJson<AudioJSON>(jsonResultStr);

            //Debug.Log("my message: " + audioJSON.status.msg.ToLower());

            if(audioJSON.status.msg.ToLower() == "success")
            {
                if (audioJSON.metadata.music.Count > 0)
                {
                    string artist = audioJSON.metadata.music[0].artists[0].name;
                    string title = audioJSON.metadata.music[0].title;

                    UnityMainThreadDispatcher.Instance().Enqueue(ListSongAndArtist(artist, title));


                    //if (artist.ToLower() == _SongToSkip)
                    //{
                    //    SkipSong();
                    //}
                }
            }
        }

        //private void OnEnable()
        //{
        //    EventManager.OnArtistAndSongRecognized += EventManager_OnArtistAndSongRecognized;
        //}

        //private void OnDisable()
        //{
        //    EventManager.OnArtistAndSongRecognized -= EventManager_OnArtistAndSongRecognized;
        //}

        //private void EventManager_OnArtistAndSongRecognized(string artistStr, string songStr)
        //{
        //    ListSongAndArtist(artistStr, songStr);
        //}

        private void SkipSong()
        {
            Debug.Log("you were our skipped song");
        }
    }
}
