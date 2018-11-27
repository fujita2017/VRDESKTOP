using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinchCursor : MonoBehaviour
{

    public void pinchOn()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            this.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void pinchOff()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}