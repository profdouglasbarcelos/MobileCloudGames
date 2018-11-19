using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSInput : MonoBehaviour {

    void Start()
    {
        StartCoroutine(CarregarGPS());
    }

    IEnumerator CarregarGPS()
    {
        if(!Input.location.isEnabledByUser)
        {
            Debug.Log("Localização não compartilhada pelo jogador");
            yield break;
        }

        // Inicializacao do servico
        Input.location.Start();

        int tempoEspera = 20;

        while (Input.location.status == LocationServiceStatus.Initializing
                && tempoEspera > 0)
        {
            yield return new WaitForSeconds(1);
            --tempoEspera;
        }

        if(tempoEspera < 1)
        {
            Debug.Log("Timeout aguardando inicializacao do GPS");
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Falha ao carregar GPS");
            yield break;
        }
        else
        {
            // acesso aos dados do GPS
            float lat = Input.location.lastData.latitude;
            float lon = Input.location.lastData.longitude;
        }
    }
}
