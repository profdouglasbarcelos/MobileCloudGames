using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamInput : MonoBehaviour {

    void Start()
    {
        WebCamTexture webCamTexture = new WebCamTexture();
        GetComponent<MeshRenderer>().material.mainTexture = webCamTexture;
        webCamTexture.Play();

        // detectar todas cameras do dispositivo
        WebCamDevice[] cameras = WebCamTexture.devices;

        foreach (WebCamDevice cam in cameras)
        {
            Debug.Log("Camera: " + cam.name);
        }
    }

    // Update is called once per frame
    void Update () {
        
	}
}
