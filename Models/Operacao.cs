using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Itau_invest.Models
{
    [Table("operacoes")]
    public class Operacao
    {
        [Key]
        [Column("id_operacao")]
        public int IdOperacao { get; set; }

        [Column("id_usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [Column("id_ativo")]
        public int IdAtivo { get; set; }
        public Ativo Ativo { get; set; }

        [Column("tipo_opr")]
        public string TipoOperacao { get; set; }

        [Column("quant")]
        public decimal Quantidade { get; set; }

        [Column("preco_unit")]
        public decimal PrecoUnitario { get; set; }

        [Column("data_hora")]
        public DateTime DataOperacao { get; set; }

        [Column("corretagem")]
        public decimal Corretagem { get; set; }

        // Contrutor Padrão
        public Operacao() { }

        // Construtor completo
        public Operacao(int idUsuario, int idAtivo, string tipoOperacao, decimal quantidade, decimal precoUnitario, decimal corretagem, DateTime dataOperacao)
        {
            IdUsuario = idUsuario;
            IdAtivo = idAtivo;
            TipoOperacao = tipoOperacao;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            Corretagem = corretagem;
            DataOperacao = dataOperacao;
        }
    }
}