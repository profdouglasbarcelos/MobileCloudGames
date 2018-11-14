using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSInput : MonoBehaviour {

    // Singleton
    public static GPSInput MyGpsInstance { get; set; }
    public float latitude;
    public float longitude;
    //public Text txtLat;
    //public Text txtLon;
    // Use this for initialization
    void Start()
    {
        MyGpsInstance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartGpsService());
    }
    private IEnumerator StartGpsService()
    {
        // verificar se o usuario habilitou/permitiu localizacao
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("usuario nao habilitou GPS");
            yield break;
        }

        // Inicializar servico
        Input.location.Start();

        // aguardando o servico inicializar
        int tempoEspera = 20;
        while (Input.location.status == LocationServiceStatus.Initializing
                && tempoEspera > 0)
        {
            yield return new WaitForSeconds(1);
            tempoEspera--;
        }
        // time out
        if (tempoEspera < 1)
        {
            Debug.Log("Time out");
            yield break;
        }


        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Erro ao inicializar GPS");
            yield break;
        }
        else
        {
            // acesso garantido as informacoes do GPS
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            //txtLat.text = "LAT: " + latitude;
            //txtLon.text = "LON: " + longitude;

            Debug.Log("Lat: " + latitude);
            Debug.Log("Long: " + longitude);
        }
    }
}
