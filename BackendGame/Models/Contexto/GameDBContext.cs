using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendGame.Models.Contexto
{
    public class GameDBContext : DbContext
    {
        public GameDBContext() : base("stringConexao")
        {

        }

        public DbSet<TipoItem> TipoItens { get; set; }
        public DbSet<Item>  Itens { get; set; }
    }
}