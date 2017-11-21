using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int ItemID;
    public string Nome;

    //public int ItemID
    //{
    //    get
    //    { return _itemID; }
    //    set { _itemID = value; }
    //}

    //public string Nome
    //{
    //    get { return nome; }
    //    set { nome = value; }
    //}

    //public string Descricao
    //{
    //    get { return _descricao; }
    //    set { _descricao = value; }
    //}

    private int defesa;

    public int Defesa
    {
        get { return defesa; }
        set { defesa = value; }
    }

    private int forca;

    public int Forca
    {
        get { return forca; }
        set { forca = value; }
    }

    private int agilidade;

    public int Agilidade
    { 
        get { return agilidade; }
        set { agilidade = value; }
    }

    private int tipoItemID;

    public int TipoItemID
    {
        get { return tipoItemID; }
        set { tipoItemID = value; }
    }

    //private TipoItem _tipoItem;

    //public TipoItem _TipoItem
    //{
    //    get { return _tipoItem; }
    //    set { _tipoItem = value; }
    //}
}
