using System;

[Serializable]
public class Item
{
    public int ItemID { get; set; }

    public string Nome { get; set; }

    public string Descricao { get; set; }

    // relacionamento TipoItem <--> Item

    public int TipoItem { get; set; }
}
