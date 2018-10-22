using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendGame.Models
{
    public class Item
    {
        public int ItemID { get; set;}

        public string Nome { get; set; }
        public string Descricao { get; set; }

        // Relacionamento entre TipoItem e Item
        public int TipoItemID { get; set; }
        public virtual TipoItem _TipoItem { get; set; }

    }
}