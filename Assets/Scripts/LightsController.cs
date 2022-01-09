using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightsController : MonoBehaviour
{

    public List<RawImage> LightList;

    private int _CurLightCount = 0;

    private void Awake()
    {
        StartCoroutine(AnimLights());
    }

    private IEnumerator AnimLights()
    {
        yield return new WaitForSeconds(0.7f);
        for(int i=0;i<LightList.Count;i++)
        {
            RawImage curLight = LightList[i];
            curLight.gameObject.SetActive(false);
        }
        RawImage activeLight = LightList[_CurLightCount];
        activeLight.gameObject.SetActive(true);
        _CurLightCount++;
        if (_CurLightCount >= LightList.Count)
            _CurLightCount = 0;

        StartCoroutine(AnimLights());
    }
}
