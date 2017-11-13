using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebCam : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        WebCamTexture camTexture = new WebCamTexture();
        GetComponent<SkinnedMeshRenderer>().material.mainTexture = camTexture;
        camTexture.Play();

        // detectar todas cameras do dispositivo
        WebCamDevice[] cameras = WebCamTexture.devices;

        foreach (WebCamDevice cam in cameras)
        {
            Debug.Log("Camera: " + cam.name);
        }
    }
	
}
