using System.Collections;
using UnityEngine;
using UnityEngine.Monetization;

public class VideoAds : MonoBehaviour {

//#if UNITY_ANDROID
    string gameID = "2920087";
    bool testMode = true;
//#endif

    // Use this for initialization
    void Start () {
        // Inicializar monetizacao
        Monetization.Initialize(gameID, testMode);
	}
	
    public void btnVideo_Click()
    {
        StartCoroutine(MostrarVideoAds());
    }

    private IEnumerator MostrarVideoAds()
    {
        while(!Monetization.IsReady("video"))
        {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent video = Monetization.GetPlacementContent("video") as ShowAdPlacementContent;

        if(video != null)
        {
            video.Show();
        }
    }
}
