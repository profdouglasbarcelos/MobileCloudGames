using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ApiClient : MonoBehaviour
{
    const string baseUrl = "http://localhost:52258/API";

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(PostItemApiAsync());
        StartCoroutine(GetItensApiAsync());
        
	}

    private IEnumerator PostItemApiAsync()
    {
        WWWForm form = new WWWForm();

        form.AddField("Nome", "ItemFromUnity 2");
        form.AddField("Descricao", "Item enviado por POST para Unity3d (2)");
        form.AddField("DanoMaximo", "50");
        form.AddField("Raridade", "9");
        form.AddField("TipoItemID", "1");

        using (UnityWebRequest request = UnityWebRequest.Post(baseUrl + "/Itens", form))
        {
            // obsoleto (Unity 2017.1)
            //yield return request.Send();

            // (Unity 2017.2)
            yield return request.SendWebRequest();


            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log("Envio do item efetuado com sucesso");
            }

        }
    }

    IEnumerator GetItensApiAsync()
    {
        UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Itens");
        
        // obsoleto (Unity 2017.1)
        //yield return request.Send();

        // (Unity 2017.2)
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string response = request.downloadHandler.text;
            //Debug.Log(response);

            //byte[] bytes = request.downloadHandler.data;

            Item[] itens = JsonHelper.getJsonArray<Item>(response);

            foreach (Item i in itens)
            {
                ImprimirItem(i);
            }

        }
    }

    private void ImprimirItem(Item i)
    {
        Debug.Log("======= Dados Objeto ==========");

        Debug.Log("Id: " + i.ItemID);
        Debug.Log("Nome: " + i.Nome);
        Debug.Log("Descrição: " + i.Descricao);
        Debug.Log("Dano Máximo: " + i.DanoMaximo);
        Debug.Log("Raridade: " + i.Raridade);
        Debug.Log("TipoItemID: " + i.TipoItemID);
    }
}
