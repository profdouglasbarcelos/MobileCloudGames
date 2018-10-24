using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class BackendClient : MonoBehaviour
{

    public string uri = "http://localhost:50765/api/itens";
    // Use this for initialization
    void Start()
    {
        StartCoroutine(CarregardadosInventario());
    }

    IEnumerator CarregardadosInventario()
    {
        UnityWebRequest request = new UnityWebRequest(uri);
        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
            Debug.Log("Erro Http/rede");
        else
        {
            Debug.Log("OK.");
            Debug.Log("request.responseCode: " + request.responseCode);
            Debug.Log("request.downloadedBytes: " + request.downloadedBytes);


            string responseJson = request.downloadHandler.text;
            Debug.Log(responseJson);

            Item[] itens = JsonHelper.getJsonArray<Item>(responseJson);
        }
    }
}
