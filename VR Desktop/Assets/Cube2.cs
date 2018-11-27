﻿using System.Collections;
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

    private float impulseMagnitude;

    // Use this for initialization
    void Start()
    {
        this.impulseMagnitude = 50.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Cube
    // 重なり判定
    private void OnTriggerEnter(Collider other)
    {
    }

    // 重なり中の判定
    private void OnTriggerStay(Collider other)
    {
        //対象オブジェクトがピンチの場合　処理中断
        if (other.gameObject.tag == "Pinch")
        {
            return;
        }

        Debug.Log(other.name + "Stay");
        if (_pinchDetector_L.IsActive)
        {
            //var impulse = (other.transform.position - transform.parent.position).normalized * this.impulseMagnitude;
            //other.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Force);
            //this.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            //this.transform.GetChild(0).gameObject.SetActive(true);
            //
other.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1), ForceMode.Force);

            //var impulse = (other.transform.position - transform.parent.position).normalized * this.impulseMagnitude;
            //other.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Force);

            //transform.position = other.transform.position;
            other.gameObject.transform.position = transform.position;
        }
    }

    // 重なり離脱の判定
    private void OnTriggerExit(Collider other)
    {
    }

}
