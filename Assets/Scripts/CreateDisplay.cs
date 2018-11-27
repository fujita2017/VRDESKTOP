using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class CreateDisplay : MonoBehaviour {

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
    public GameObject MagicDisplayPrefab;
    private Transform MagicDisplayInstance;
    private Vector3 DisplaySize;
    public float RelativeDisplayScale = 0.05f;

    // Pinch settings
    public float minimumPinchDistance = 0.01f;
    private bool pinchStatus = false;

    // Use this for initialization
    void Start () {
        // Set display size.
        DisplaySize = new Vector3(1.92f, 1.08f, 1.00f) * RelativeDisplayScale;
    }

    // Update is called once per frame
    void Update () {
        // Release pinchHolding
        if (_pinchDetector_L.DidRelease || _pinchDetector_R.DidRelease)
        {
            pinchStatus = false;
        }

        // 画面サイズを変更中は新規作成を停止する。
        //if (GameObject.Find("HandAttachments-L").GetChild("Palm").Cube2Status == true)
        //{
        //    return;
        //}


        // Keep pinchHolding
            if (_pinchDetector_L != null && _pinchDetector_L.IsActive &&
            _pinchDetector_R != null && _pinchDetector_R.IsActive &&
            _pinchDetector_L.IsHolding && _pinchDetector_R.IsHolding)
        {

            Vector3 pinchDetector_L_pos = _pinchDetector_L.Position;
            Vector3 pinchDetector_R_pos = _pinchDetector_R.Position;
            Quaternion pinchDetector_L_rot = _pinchDetector_L.Rotation;
            Quaternion pinchDetector_R_rot = _pinchDetector_R.Rotation;

            if (pinchStatus == true)
            {
                MagicDisplayInstance.position = (pinchDetector_L_pos + pinchDetector_R_pos) / 2.0f;
                // MagicDisplayInstance.rotation = Quaternion.Lerp(pinchDetector_L_rot, pinchDetector_R_rot, 0.5f);
                MagicDisplayInstance.rotation = GameObject.Find("CenterEyeAnchor").transform.rotation;
                MagicDisplayInstance.localScale = DisplaySize * Vector3.Distance(pinchDetector_L_pos, pinchDetector_R_pos);
            }
            else if (pinchStatus == false)
            {
                float pinchDistance = Vector3.Distance(pinchDetector_L_pos, pinchDetector_R_pos);
                if (pinchDistance < minimumPinchDistance)
                {
                    GameObject newDisplay = (GameObject)Instantiate(MagicDisplayPrefab);
                    newDisplay.tag = "DISPLAY";
                    MagicDisplayInstance = newDisplay.transform;
                    MagicDisplayInstance.position = (pinchDetector_L_pos + pinchDetector_R_pos) / 2.0f;
                    // MagicDisplayInstance.rotation = Quaternion.Lerp(pinchDetector_L_rot, pinchDetector_R_rot, 0.5f);
                    MagicDisplayInstance.rotation = GameObject.Find("CenterEyeAnchor").transform.rotation;
                    MagicDisplayInstance.localScale = DisplaySize * Vector3.Distance(pinchDetector_L_pos, pinchDetector_R_pos);
                    pinchStatus = true;
                }
            }
        }
    }
}
