using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

using UnityEngine.UI;

public class SetImage2 : MonoBehaviour {

    [SerializeField]
    private Image _Image;
    public Image Image1
    {
        get
        {
            return _Image;
        }
        set
        {
            _Image = value;
        }
    }
    private Sprite sprite;
    private float impulseMagnitude;

    // Use this for initialization
    void Start () {
        this.impulseMagnitude = 50.0f;
    }

    // Update is called once per frame
    void Update () {
		
	}
    // 重なり判定
    private void OnTriggerEnter(Collider other)
    {
        //対象オブジェクトがピンチの場合　処理中断
        if (other.gameObject.tag == "SELECT")
        {
            sprite = Resources.Load<Sprite>("IMG1");
            _Image.sprite = sprite;


        }
    }
}
