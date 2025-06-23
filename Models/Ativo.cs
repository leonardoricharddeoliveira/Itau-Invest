using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Itau_invest.Models
{
    [Table("ativos")]
    public class Ativo
    {
        [Key]
        [Column("id_ativo")]
        public int IdAtivo { get; set; }

        [Column("cod")]
        public string Codigo { get; set; }

        [Column("nome")]
        public string Nome { get; set; }

        // Contrutor Padrão
        public Ativo() { }

        // Contrutor para criação de ativo
        public Ativo(string codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        // Construtor completo
        public Ativo(int idAtivo, string codigo, string nome)
        {
            IdAtivo = idAtivo;
            Codigo = codigo;
            Nome = nome;
        }
    }
}
