using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AcelerometerInput : MonoBehaviour {

    void Update()
    {
        float x = Input.acceleration.x;
        float z = -Input.acceleration.z;

        transform.Translate(new Vector3(x, 0f, z) * Time.deltaTime);

        Debug.Log("Acc: " + Input.acceleration);
    }
}
