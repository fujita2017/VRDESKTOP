using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;

public class Cube : MonoBehaviour {

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

    private float impulseMagnitude;

    // Use this for initialization
    void Start () {
        this.impulseMagnitude = 50.0f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Cube
    // 重なり判定
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + "Stay");
        if (_pinchDetector_R.IsActive)
        {
            //var impulse = (other.transform.position - transform.parent.position).normalized * this.impulseMagnitude;
            //other.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Force);
        }
        else
        {

            var rigid = other.gameObject.GetComponent<Rigidbody>();
            if (rigid)
            {
                var impulse = (rigid.position - transform.position).normalized * impulseMagnitude;
                //var impulse = (rigid.position - transform.parent.position).normalized * this.impulseMagnitude;
                rigid.AddForce(impulse, ForceMode.Force);

                //other.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1), ForceMode.Force);

                //transform.position = other.transform.position;
                //other.transform.position = transform.position;
            }
        }
    }

    // 重なり中の判定
    private void OnTriggerStay(Collider other)
    {
    }

    // 重なり離脱の判定
    private void OnTriggerExit(Collider other)
    {
    }

}
