using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPManager : MonoBehaviour {
    
    public void ComprouItem(string item)
    {
        Debug.Log("Item comprado: " + item);
    }

    public void FalhaAoComprarItem(string item)
    {
        Debug.Log("Falha ao tentar comprar item: " + item);
    }
}
