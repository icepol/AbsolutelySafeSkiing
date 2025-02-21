using System;
using System.Collections;
using pixelook;
using UnityEngine;
using UnityEngine.UI;

public class LiveCam : MonoBehaviour
{
    [SerializeField] private Texture faceNormal;
    [SerializeField] private Texture faceAngry;
    [SerializeField] private Texture faceBang;

    private RawImage _rawImage;
    
    private void Awake()
    {
        _rawImage = GetComponent<RawImage>();
    }

    IEnumerator WaitAndReset()
    {
        yield return new WaitForSeconds(1);
        
        Reset();
    }
    
    private void Reset()
    {
        _rawImage.texture = faceNormal;
    }
    
    public void SetAngryFace()
    {
        Reset();
        
        _rawImage.texture = faceAngry;

        StartCoroutine(WaitAndReset());
    }
    
    public void SetBangFace()
    {
        Reset();
        
        _rawImage.texture = faceBang;

        StartCoroutine(WaitAndReset());
    }
}
