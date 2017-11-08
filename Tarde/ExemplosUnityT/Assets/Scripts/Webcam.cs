using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webcam : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
            Debug.Log(devices[i].name);

        WebCamTexture imagemWebCam = new WebCamTexture();

        GetComponent<MeshRenderer>().material.mainTexture = imagemWebCam;

        imagemWebCam.Play();
    }
}
