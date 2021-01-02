using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AudioBoxItem : MonoBehaviour
{
    public GameObject BackgroundImageDark;
    public GameObject BackgroundImageLight;
    public TextMeshProUGUI ArtistTxt;
    public TextMeshProUGUI SongTitleTxt;

    private void Awake()
    {
        if (BackgroundImageDark == null) throw new System.Exception("An BackgroundImageDark must be defined in AudioBoxItem");
        if (BackgroundImageLight == null) throw new System.Exception("An BackgroundImageLight must be defined in AudioBoxItem");
        if (ArtistTxt == null) throw new System.Exception("An ArtistTxt must be defined in AudioBoxItem");
        if (SongTitleTxt == null) throw new System.Exception("An SongTitleTxt must be defined in AudioBoxItem");
    }

    public void Init(bool useDarkBackground, string artistStr, string songStr)
    {

        BackgroundImageDark.gameObject.SetActive(useDarkBackground);
        BackgroundImageLight.gameObject.SetActive(!useDarkBackground);

        ArtistTxt.text = artistStr;
        SongTitleTxt.text = songStr;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
