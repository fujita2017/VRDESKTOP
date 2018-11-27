using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(transform.position.z);
        if (transform.position.z > 3 || transform.position.z < -3 || 
            transform.position.y > 3 || transform.position.y < -3 || 
            transform.position.z > 3 || transform.position.z < -3)
        {
            DestroyWin();
        }
	}
    void DestroyWin()
    {
        //このScriptを削除する
        Destroy(gameObject);
    }
}
