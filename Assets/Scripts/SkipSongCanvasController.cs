using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SkipSongCanvasController : MonoBehaviour
{

    public GameObject SkipHolder;
    public RawImage SkipTxtImage;
    public RawImage SongTxtImage;


    private float _SkipTxtEndXPos;
    private float _SongTxtEndXPos;
    private float _SkipTxtStartXPos;
    private float _SongTxtStartXPos;
    private CanvasGroup _SkipHolderCanvas;
    private CanvasGroup _SkipCanvasGroup;
    private CanvasGroup _SongCanvasGroup;


    private void Awake()
    {
        if (SkipHolder == null)
            throw new System.Exception("A SkipHolder must be defined in SkipSongCanvasController");
        if (SkipTxtImage == null)
            throw new System.Exception("A SkipTxtImage must be defined in SkipSongCanvasController");
        if (SongTxtImage == null)
            throw new System.Exception("A SongTxtImage must be defined in SkipSongCanvasController");

        _SkipHolderCanvas = SkipHolder.GetComponent<CanvasGroup>();
        _SkipCanvasGroup = SkipTxtImage.GetComponent<CanvasGroup>();
        _SongCanvasGroup = SongTxtImage.GetComponent<CanvasGroup>();

        _SkipTxtEndXPos = SkipTxtImage.transform.localPosition.x;
        _SongTxtEndXPos = SongTxtImage.transform.localPosition.x;
        _SkipTxtStartXPos = SkipTxtImage.transform.localPosition.x + 20.0f;
        _SongTxtStartXPos = SongTxtImage.transform.localPosition.x + 20.0f;

        SkipHolder.SetActive(false);
        SkipTxtImage.gameObject.SetActive(false);
        SongTxtImage.gameObject.SetActive(false);
    }

    private void SkipSong()
    {
        _SkipCanvasGroup.alpha = 0;
        _SongCanvasGroup.alpha = 0;
        SkipHolder.SetActive(true);
        SkipTxtImage.gameObject.SetActive(true);
        SongTxtImage.gameObject.SetActive(true);
        //tweens
        SkipTxtImage.transform.DOLocalMoveX(_SkipTxtStartXPos, 0.0f);
        SongTxtImage.transform.DOLocalMoveX(_SongTxtStartXPos, 0.0f);
        _SkipCanvasGroup.DOFade(1, 0.4f);
        _SongCanvasGroup.DOFade(1, 0.4f).SetDelay(0.2f);
        SkipTxtImage.transform.DOLocalMoveX(_SkipTxtEndXPos, 0.4f).SetEase(Ease.OutQuad);
        SongTxtImage.transform.DOLocalMoveX(_SongTxtEndXPos, 0.4f).SetDelay(0.2f).SetEase(Ease.OutQuad);
        StartCoroutine(MoveOn(2.0f));
    }

    private IEnumerator MoveOn(float waitSeconds = 2.0f)
    {
        yield return new WaitForSeconds(waitSeconds);
        _SkipCanvasGroup.DOFade(0, 0.4f);
        _SongCanvasGroup.DOFade(0, 0.4f).SetDelay(0.2f);
        _SongCanvasGroup.DOFade(0, 0.4f).SetDelay(0.4f);
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
}
