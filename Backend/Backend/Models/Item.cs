namespace Backend.Models
{
    public class Item
    {
        public int ItemID { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        // relacionamento TipoItem <--> Item

        public int TipoItem { get; set; }

        public virtual TipoItem _TipoItem { get; set; }

    }
}