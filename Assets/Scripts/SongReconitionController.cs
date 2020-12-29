using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SongRecognizer
{
    //public class AudioJSON
    //{
    //    public StatusItem status;
    //}

    [Serializable]
    public class AudioJSON
    {
        public Status status;
        public Metadata metadata;
        //public Metadata metadata { get; set; }
        //public double cost_time { get; set; }
        //public int result_type { get; set; }
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
    }



    public class SongReconitionController : MonoBehaviour
    {
        private string _JSONSTR = "{\"status\":{\"msg\":\"Success\",\"code\":0,\"version\":\"1.0\"},\"metadata\":{\"music\":[{\"release_date\":\"Success\",\"code\":0,\"title\":\"Jesus of Suburbia\"}]}}";
        private string _SongToSkip = "jesus of suburbiaa";

        private void Awake()
        {
            ParseSongJSON(_JSONSTR);
        }

        public void ParseSongJSON(string jsonResultStr)
        {

            //Debug.Log(jsonResultStr);

            //AudioJSON myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 


            Debug.Log("----");
            AudioJSON audioJSON = JsonUtility.FromJson<AudioJSON>(jsonResultStr);

            Debug.Log("my message: " + audioJSON.status.msg.ToLower());
            
            if(audioJSON.status.msg.ToLower() == "success")
            {
                if (audioJSON.metadata.music.Count > 0)
                {
                    Debug.Log("my title: " + audioJSON.metadata.music[0].title.ToLower());
                    if (audioJSON.metadata.music[0].title.ToLower() == _SongToSkip)
                    {
                        SkipSong();
                    }
                }
            }

            //Debug.Log(audioJSON);
            //Debug.Log(audioJSON.metadata);
            //Debug.Log(audioJSON.metadata.music.Count);
            //Debug.Log(audioJSON.metadata.music[0].title);
        }

        private void SkipSong()
        {
            Debug.Log("you were our skipped song");
        }

        //private void OnEnable()
        //{
        //    EventManager.OnSongRecognized += EventManager_OnSongRecognized;
        //}
        //private void OnDisable()
        //{
        //    EventManager.OnSongRecognized -= EventManager_OnSongRecognized;
        //}

        //private void EventManager_OnSongRecognized(string jsonResultStr)
        //{
        //    ParseSongJSON(jsonResultStr);
        //}
    }
}
