using System.ComponentModel.DataAnnotations;

namespace FaturamentoService.Models
{
    public class NotaFiscal
    {
        [Key]
        public int Id { get; set; }
        public int NumeroNota { get; set; }
        public string CodigoProduto { get; set; }
        public int Quantidade { get; set; }
        public string Status { get; set; } = "Aberta"; // Aberta ou Fechada
    }
}