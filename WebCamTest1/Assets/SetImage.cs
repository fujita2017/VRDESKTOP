using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SetImage : MonoBehaviour
{

    public Image image;
    private Sprite sprite;
    private RectTransform hoge1;
    private RectTransform hoge2;

    // Use this for initialization
    void Start()
    {
        
        sprite = Resources.Load<Sprite>("1");
        image = GameObject.Find("Image1").GetComponent<Image>();
        image.sprite = sprite;
        hoge1 = image.GetComponent<RectTransform>();


        sprite = Resources.Load<Sprite>("2");
        image = GameObject.Find("Image2").GetComponent<Image>();
        image.sprite = sprite;
        hoge2 = image.GetComponent<RectTransform>();

//        hoge1.sizeDelta = new Vector2(2, 1);
//        hoge1.localPosition = new Vector3(-5, 0, 0); //動いた！

//        hoge2.sizeDelta = new Vector2(2, 1);
//        hoge2.localPosition = new Vector3(-4, 0, 0);　//動いた！
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            hoge1.sizeDelta = new Vector2(4, 2);
            hoge1.localPosition = new Vector3(-5, -3, 0);　//動いた！

            hoge2.sizeDelta = new Vector2(4, 2);
            hoge2.localPosition = new Vector3(-4, -3, 0);　//動いた！
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            hoge1.sizeDelta = new Vector2(20, 10);
            hoge1.localPosition = new Vector3(0, 0, 0); //動いた！

            hoge2.sizeDelta = new Vector2(4 ,2);
            hoge2.localPosition = new Vector3(-4, 0, 0);　//動いた！
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            hoge1.sizeDelta = new Vector2(4, 2);
            hoge1.localPosition = new Vector3(-5, 0, 0); //動いた！

            hoge2.sizeDelta = new Vector2(4, 2);
            hoge2.localPosition = new Vector3(0, 0, 0);　//動いた！
        }

    }
}
