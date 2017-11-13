﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGPS : MonoBehaviour 
{
    // Singleton
    public static MyGPS MyGPSInstance { get; set; }

    public float latitude;
    public float longitude;

    public Text latitudeHUD;
    public Text longitudeHUD;

	// Use this for initialization
	void Start ()
    {
        MyGPSInstance = this;
        DontDestroyOnLoad(gameObject);

        StartCoroutine(StartGpsService());
	}

    private IEnumerator StartGpsService()
    {
        if(!Input.location.isEnabledByUser)
        {
            SendInformation(lat: "Usuario nao permitiu compartilhamento da localizacao", lon: string.Empty);
            yield break;
        }

        // Inicializar o servico
        Input.location.Start();

        // Aguardando o dispositivo ficar pronto
        int maxWait = 20;

        while (Input.location.status == LocationServiceStatus.Initializing 
            && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Testando se o servico nao inicializou
        if(maxWait < 1)
        {
            SendInformation("Timeout GPS", string.Empty);
            yield break;
        }


        // houve falha ao inicializar o servico
        if(Input.location.status == LocationServiceStatus.Failed)
        {
            SendInformation("Nao foi possivel determinar sua localizacao", string.Empty);
            yield break;
        }
        else
        {
            // Acesso garantio a localizacao do dispositivo
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;

            string lat = "Lat: " + latitude;
            string lon = "Lon: " + longitude;

            SendInformation(lat, lon);
        }
    }

    private void SendInformation(string lat, string lon)
    {
        Debug.Log(lat + lon);
        latitudeHUD.text = lat;
        longitudeHUD.text = lon;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
