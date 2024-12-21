using System.ComponentModel.DataAnnotations;
using myfinance_web_netcore.Domain;

namespace myfinance_web_netcore.Models
{
    public class RegistroTransacoesModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A data é obrigatória.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O histórico é obrigatório.")]
        [StringLength(100, ErrorMessage = "O histórico não pode ter mais que 100 caracteres.")]
        public string Historico { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório.")]
        [RegularExpression("D|R", ErrorMessage = "O tipo deve ser 'D' (Despesa) ou 'R' (Receita).")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O plano de conta é obrigatório.")]
        public int PlanoContaId { get; set; }
    }
}
