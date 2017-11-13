using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mic : MonoBehaviour
{
    public AudioSource audioSource;

    float[] samples;

    public int frequency = 1024;
	
    // Use this for initialization
	void Start ()
    {
        audioSource = GetComponent<AudioSource>();

        samples = new float[frequency];

        string[] microfones = Microphone.devices;

        Debug.Log("Microfone: " + Microphone.devices[0]);

        audioSource.Stop();

        audioSource.clip = Microphone.Start(null, true, 100, frequency);
        audioSource.Play();
	}  
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = transform.parent.position - transform.up * Volume();	
	}


    private float Volume()
    {
        float vol = 0;

        if(audioSource.isPlaying)
        {
            for(int canal = 0; canal < 1; canal++)
            {
                audioSource.GetOutputData(samples, canal);

                for (int i = 0; i < frequency; i++)
                {
                    vol += Mathf.Abs(samples[i]);
                }
            }

            vol = vol / frequency;
        }

        return vol;
    }
}
