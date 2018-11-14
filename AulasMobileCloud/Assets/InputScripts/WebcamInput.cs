using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebcamInput : MonoBehaviour {

	// Use this for initialization
	void Start () {
        WebCamTexture imagem = new WebCamTexture();
        GetComponent<MeshRenderer>().material.mainTexture = imagem;

        imagem.Play();

        WebCamDevice[] cameras = WebCamTexture.devices;

        for (int i = 0; i < cameras.Length; i++)
        {
            Debug.Log(cameras[i].name);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
