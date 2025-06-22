using System;

namespace Itau_invest.Models
{
    public class Operacao
    {
        public int IdOperacao { get; set; }

        // Chave estrangeira: Usuario
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        // Chave estrangeira: Ativo
        public int IdAtivo { get; set; }
        public Ativo Ativo { get; set; }

        public string TipoOperacao { get; set; } 
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public DateTime DataOperacao { get; set; }

        // Construtor padrão
        public Operacao() { }

        // Construtor completo 
        public Operacao(int idUsuario, int idAtivo, string tipoOperacao, decimal quantidade, decimal precoUnitario, DateTime dataOperacao)
        {
            IdUsuario = idUsuario;
            IdAtivo = idAtivo;
            TipoOperacao = tipoOperacao;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
            DataOperacao = dataOperacao;
        }
    }
}