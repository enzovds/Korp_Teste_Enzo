using System.ComponentModel.DataAnnotations;

namespace EstoqueService.Models
{
    public class Produto
    {
        [Key]
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public int Saldo { get; set; }
    }
}