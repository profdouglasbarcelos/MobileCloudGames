using System.Collections;
using UnityEngine;
using UnityEngine.Monetization;

public class RewardedVideoAds : MonoBehaviour {

    string gameId = "2919836";
    bool testMode = true;

    // Use this for initialization
    void Start()
    {
        Monetization.Initialize(gameId, testMode);
    }

    public void AssistirVideoRecompensa_Click()
    {
        StartCoroutine(CarregarVideoRecompensa());
    }

    private IEnumerator CarregarVideoRecompensa()
    {
        while (!Monetization.IsReady("rewardedVideo"))
        {
            yield return new WaitForSeconds(0.25f);
        }

        ShowAdPlacementContent video = null;

        video = Monetization.GetPlacementContent("rewardedVideo") as ShowAdPlacementContent;

        if(video != null)
        {
            video.Show(FimExecucaoVideo_Callback);
        }
    }

    void FimExecucaoVideo_Callback(ShowResult result)
    {
        if(result == ShowResult.Finished)
        {
            Debug.Log("Parabens, ganhou mais uns 30s de jogo por ter assistido o video");
        }
    }
}
