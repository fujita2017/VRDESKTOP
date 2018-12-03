using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WebcamOverlay : MonoBehaviour
{

    public int Width = 1920;
    public int Height = 1080;
    public int FPS = 30;
    public int CamDeviceNo = 1;
    public float Alpha = 0.5f;

    private RectTransform hoge;


    // Use this for initialization
    void Start()
    {
        RawImage rawImage;
        rawImage = this.GetComponents<RawImage>()[0];
        hoge = rawImage.GetComponent<RectTransform>();

        WebCamDevice[] devices = WebCamTexture.devices;

        for (var i = 0; i < devices.Length; i++)
        {
            Debug.Log(i.ToString() + ":" + devices[i].name);
        }

        WebCamTexture webcamTexture = new WebCamTexture(devices[CamDeviceNo].name, Width, Height, FPS);
        webcamTexture.Play();

        rawImage.texture = webcamTexture;
        rawImage.material.mainTexture = webcamTexture;
        rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, Alpha);

//        hoge.sizeDelta = new Vector2(20, 10);
//        hoge.localPosition = new Vector3(0, 0, 0);　//動いた！
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            hoge.sizeDelta = new Vector2(20, 10);
            hoge.localPosition = new Vector3(0, 0, 0);　//動いた！
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            hoge.sizeDelta = new Vector2(4 ,2);
            hoge.localPosition = new Vector3(-6, 0, 0);　//動いた！
        }
    }
}
