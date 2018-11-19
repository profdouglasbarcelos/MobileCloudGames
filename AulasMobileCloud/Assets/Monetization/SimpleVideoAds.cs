using System.Collections;
using UnityEngine;
using UnityEngine.Monetization;

public class SimpleVideoAds : MonoBehaviour {

    string gameId = "2919836";
    bool testMode = true;

	// Use this for initialization
	void Start () {
        Monetization.Initialize(gameId, testMode);
	}
	
	public void ShowAds()
    {
        StartCoroutine(ShowAdsVideo());
    }

    private IEnumerator ShowAdsVideo()
    {
        while(!Monetization.IsReady("video"))
        {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent content = null;

        content = Monetization.GetPlacementContent("video") as ShowAdPlacementContent;

        if(content != null)
        {
            content.Show();
        }
    }
}
