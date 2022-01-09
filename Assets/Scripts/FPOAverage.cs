using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPOAverage : MonoBehaviour
{

    public GameObject CubeHolder;
    public GameObject CubePrefab;

    public GameObject StartingCube;
    public GameObject StoppingCube;

    private int _TotalPlacedCubes = 5;
    private Vector3 _EndPoint;
    private Vector3 _StartPoint;
    private float _XDist;
    private float _YDist;
    private float _ZDist;

    private void Awake()
    {
        if (CubeHolder == null)
            throw new System.Exception("A CubeHolder must be defined in FPOAverage");

        if (CubePrefab == null)
            throw new System.Exception("A CubePrefab must be defined in FPOAverage");

        _EndPoint = StoppingCube.transform.position;
        _StartPoint = StartingCube.transform.position;

        _XDist = (_EndPoint.x - _StartPoint.x)/_TotalPlacedCubes;
        _YDist = (_EndPoint.y - _StartPoint.y)/_TotalPlacedCubes;
        _ZDist = (_EndPoint.z - _StartPoint.z)/_TotalPlacedCubes;

    }

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < _TotalPlacedCubes; i++)
        {
            GameObject curCube = Instantiate(CubePrefab, CubeHolder.transform, false);
            float xPos = (_XDist * (i+1)) + _StartPoint.x;
            float yPos = (_YDist * (i + 1)) + _StartPoint.y;
            float zPos = (_ZDist * (i + 1)) + _StartPoint.z;
            curCube.transform.position = new Vector3(xPos, yPos, zPos);
        }

    }
}
