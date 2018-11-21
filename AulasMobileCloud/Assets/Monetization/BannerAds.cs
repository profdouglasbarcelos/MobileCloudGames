using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour {

    private string gameID = "";
    private bool testMode = true;

    private void Start()
    {
        StartCoroutine(ShowBanner());
    }

    IEnumerator ShowBanner()
    {
        while(!Advertisement.IsReady("banner"))
        {
            yield return new WaitForSeconds(0.5f);
        }

        Advertisement.Banner.Show("banner");
    }
}
