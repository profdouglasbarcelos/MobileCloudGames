using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Monetization;

public class VideoRecompensaAds : MonoBehaviour {

    string gameID = "2920087";
    bool testMode = true;

	// Use this for initialization
	void Start () {
        //Monetization.Initialize(gameID, testMode);
	}

    public void MostrarVideoRecompensa_Click()
    {
        StartCoroutine(CarregarVideoRecompensa());
    }
	
    private IEnumerator CarregarVideoRecompensa()
    {
        while(!Monetization.IsReady("rewardedVideo"))
        {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent videoRecompensa = Monetization.GetPlacementContent("rewardedVideo") as ShowAdPlacementContent;

        if(videoRecompensa != null)
        {
            videoRecompensa.Show(EntregarRecomensa);
        }
    }

    private void EntregarRecomensa(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Failed:
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Finished:
                Debug.Log("Parabéns, você ganhou mais 20s de jogo");
                break;
            default:
                break;
        }
    }
}
