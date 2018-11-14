using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ApiClient : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        string uri = "https://api.hgbrasil.com/weather/?format=debug&woeid=455822";
        StartCoroutine(CarregarDadosClima(uri));
    }

    IEnumerator CarregarDadosClima(string uri)
    {
        UnityWebRequest request = UnityWebRequest.Get(uri);

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log("Erro ao conectar API");
        }
        else
        {
            if (request.isDone)
            {
                string response = request.downloadHandler.text;
                Debug.Log(response);

                RootObject info = JsonUtility.FromJson<RootObject>(response);
                //RootObject[] info = JsonHelper.getJsonArray<RootObject>(response);

                //Debug.Log(info);

                //Debug.Log("Cidade: " + info.results.city_name);
                //Debug.Log("Temperatura: " + infoClima.results.temp);
            }
        }
    }

}
