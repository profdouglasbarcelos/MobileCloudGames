using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class TipoItem
    {
        [Key]
        public int TipoItemID { get; set; }

        public string Nome { get; set; }
    }
}