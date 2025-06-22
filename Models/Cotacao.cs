using System;

namespace Itau_invest.Models
{
    public class Cotacao
    {
        public int IdCotacao { get; set; }

        // Chave estrangeira: Ativo
        public int IdAtivo { get; set; }
        public Ativo Ativo { get; set; }

        public decimal PrecoUnitario { get; set; }
        public DateTime DataHora { get; set; }

        // Contrutor Padrão
        public Cotacao() { }

        // Contrutor para adicionar cotação
        public Cotacao(int idAtivo, decimal precoUnitario, DateTime dataHora)
        {
            IdAtivo = idAtivo;
            PrecoUnitario = precoUnitario;
            DataHora = dataHora;
        }

        //Contrutor completo
        public Cotacao(int idCotacao, int idAtivo, decimal precoUnitario, DateTime dataHora)
        {
            IdCotacao = idCotacao;
            IdAtivo = idAtivo;
            PrecoUnitario = precoUnitario;
            DataHora = dataHora;
        }

    }
}
