using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class Cube2 : MonoBehaviour
{

    [SerializeField]
    private PinchDetector _pinchDetector_L;
    public PinchDetector PinchDetector_L
    {
        get
        {
            return _pinchDetector_L;
        }
        set
        {
            _pinchDetector_L = value;
        }
    }

    [SerializeField]
    private PinchDetector _pinchDetector_R;
    public PinchDetector PinchDetector_R
    {
        get
        {
            return _pinchDetector_R;
        }
        set
        {
            _pinchDetector_R = value;
        }
    }

    // Magic Display settings
    //public GameObject MagicDisplayPrefab;
    private Transform MagicDisplayInstance;
    public float RelativeDisplayScale = 0.05f;

    private Vector3 DisplaySize;

    public bool Cube2Status = false;


    // Use this for initialization
    void Start()
    {
        DisplaySize = new Vector3(1.92f, 1.08f, 1.00f) * RelativeDisplayScale;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Cube
    // 重なり判定
    private void OnTriggerEnter(Collider other)
    {
        //対象オブジェクトがピンチの場合　処理中断
        if (other.gameObject.tag != "DISPLAY")
        {
            return;
        }

        for (int i = 0; i < transform.childCount; ++i)
        {
            this.transform.GetChild(i).gameObject.SetActive(true);
            Cube2Status = true;
        }
    }

    // 重なり中の判定
    private void OnTriggerStay(Collider other)
    {
        //対象オブジェクトがピンチの場合　処理中断
        if (other.gameObject.tag != "DISPLAY")
        {
            return;
        }

/*        //両手で掴んだか判定
        if (_pinchDetector_L.DidReleas || _pinchDetector_R.DidRelease )
        {
            return;
        }
*/

        //var rigid = other.gameObject.GetComponent();
        if (_pinchDetector_L != null && _pinchDetector_L.IsActive &&
            _pinchDetector_R != null && _pinchDetector_R.IsActive )
        {

            Vector3 pinchDetector_L_pos = _pinchDetector_L.Position;
            Vector3 pinchDetector_R_pos = _pinchDetector_R.Position;
            Quaternion pinchDetector_L_rot = _pinchDetector_L.Rotation;
            Quaternion pinchDetector_R_rot = _pinchDetector_R.Rotation;

            other.gameObject.transform.position = (pinchDetector_L_pos + pinchDetector_R_pos) / 2.0f;
            // MagicDisplayInstance.rotation = Quaternion.Lerp(pinchDetector_L_rot, pinchDetector_R_rot, 0.5f);
            other.gameObject.transform.rotation = GameObject.Find("CenterEyeAnchor").transform.rotation;
            other.gameObject.transform.localScale = DisplaySize * Vector3.Distance(pinchDetector_L_pos, pinchDetector_R_pos);

        }
        if (_pinchDetector_L != null && _pinchDetector_L.IsActive)
        {
            other.gameObject.transform.position = transform.position;
        }

    }

    // 重なり離脱の判定
    private void OnTriggerExit(Collider other)
    {
        //対象オブジェクトがピンチの場合　処理中断
        if (other.gameObject.tag != "DISPLAY")
        {
            return;
        }
        for (int i = 0; i < transform.childCount; ++i)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
            Cube2Status = false;
        }

    }

}
