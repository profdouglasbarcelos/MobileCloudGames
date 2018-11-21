using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour {

    string gameID = "2917751";
    bool testMode = true;

	// Use this for initialization
	void Start () {
        Advertisement.Initialize(gameID, testMode);
        StartCoroutine(MostrarBanner());
	}
	
	IEnumerator MostrarBanner()
    {
        while (!Advertisement.IsReady("banner"))
        {
            yield return new WaitForSeconds(0.5f);
        }

        Debug.Log("Exibir o banner");

        Advertisement.Banner.Show("banner");
    }
}
