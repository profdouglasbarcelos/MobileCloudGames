using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcelerometroInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.acceleration.x;
        float z = -Input.acceleration.z;

        //Debug.Log(Input.acceleration);

        //transform.Translate(new Vector3(x , 0f, z) * Time.deltaTime);
        transform.Rotate(new Vector3(x, 0f, z) * 100 );
    }
}
