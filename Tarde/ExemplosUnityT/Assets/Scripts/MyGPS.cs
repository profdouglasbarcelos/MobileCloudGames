using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyGPS : MonoBehaviour 
{
    // Singleton
    public static MyGPS MyGPSInstance { get; set; }

    public float latitude;
    public float longitude;

    public Text coordenadasHUD;

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
            SendInformation("Usuario nao permitiu compartilhamento da localizacao");
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
            SendInformation("Timeout GPS");
            yield break;
        }


        // houve falha ao inicializar o servico
        if(Input.location.status == LocationServiceStatus.Failed)
        {
            SendInformation("Nao foi possivel determinar sua localizacao");
            yield break;
        }
        else
        {
            // Acesso garantio a localizacao do dispositivo
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;

            string coordenadas = "Lat: " + latitude + ", Lon: " + longitude;

            SendInformation(coordenadas);

            coordenadasHUD.text = coordenadas;
        }
    }

    private void SendInformation(string msg)
    {
        Debug.Log(msg);
        coordenadasHUD.text = msg;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
