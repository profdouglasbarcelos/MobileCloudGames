using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ClientAPI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string uri = "https://api.hgbrasil.com/weather/?format=debug&woeid=455822";

        StartCoroutine(RecuperarDadosClima(uri));
	}
	
    IEnumerator RecuperarDadosClima(string uri)
    {
        UnityWebRequest request = UnityWebRequest.Get(uri);

        yield return request.SendWebRequest();

        if(request.isHttpError || request.isNetworkError)
        {
            Debug.Log("NOK");
        }
        else
        {
            string response = request.downloadHandler.text;

            Debug.Log(response);

            //RootObject info = JsonUtility.FromJson<RootObject>(response);

            //Debug.Log("Info (cidade): " + info.results.city_name);
        }
    }
	
}
