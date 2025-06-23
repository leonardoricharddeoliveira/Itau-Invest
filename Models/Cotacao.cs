using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Itau_invest.Models
{
    [Table("cotacoes")]
    public class Cotacao
    {
        [Key]
        [Column("id_cotacao")]
        public int IdCotacao { get; set; }

        [Column("id_ativo")]
        public int IdAtivo { get; set; }
        public Ativo Ativo { get; set; }

        [Column("preco_unit")]
        public decimal PrecoUnitario { get; set; }

        [Column("data_hora")]
        public DateTime DataHora { get; set; }

        // Contrutor Padrão
        public Cotacao() { }

        // Contrutor para criação 
        public Cotacao(int idAtivo, decimal precoUnitario, DateTime dataHora)
        {
            IdAtivo = idAtivo;
            PrecoUnitario = precoUnitario;
            DataHora = dataHora;
        }

        // Construtor completo
        public Cotacao(int idCotacao, int idAtivo, decimal precoUnitario, DateTime dataHora)
        {
            IdCotacao = idCotacao;
            IdAtivo = idAtivo;
            PrecoUnitario = precoUnitario;
            DataHora = dataHora;
        }
    }
}