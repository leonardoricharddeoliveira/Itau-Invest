using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Itau_invest.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id_user")]
        public int IdUsuario { get; set; }

        [Required]
        [Column("nome")]
        [MaxLength(50)]
        public string Nome { get; set; }

        [Required]
        [Column("email")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [Column("pct_corret")]
        public decimal PercentualCorretagem { get; set; }

        // Contrutor Padrão
        public Usuario() { }

        // Contrutor para criação de usuario
        public Usuario(string nome, string email, decimal percentualCorretagem)
        {
            Nome = nome;
            Email = email;
            PercentualCorretagem = percentualCorretagem;
        }

        // Construtor completo
        public Usuario(int idUsuario, string nome, string email, decimal percentualCorretagem)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Email = email;
            PercentualCorretagem = percentualCorretagem;
        }
    }
}