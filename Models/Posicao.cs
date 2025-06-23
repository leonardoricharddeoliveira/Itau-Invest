using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Itau_invest.Models
{
    [Table("posicoes")]
    public class Posicao
    {
        [Key]
        [Column("id_pos")]
        public int IdPosicao { get; set; }

        [Column("id_user")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [Column("id_ativo")]
        public int IdAtivo { get; set; }
        public Ativo Ativo { get; set; }

        [Column("qtd")]
        public int Quantidade { get; set; }

        [Column("preco_med")]
        public decimal PrecoMedio { get; set; }

        [Column("p_l")]
        public decimal PnL { get; set; }

        // Contrutor Padrão
        public Posicao() { }

        // Contrutor para criação
        public Posicao(int idUsuario, int idAtivo, int quantidade, decimal precoMedio, decimal pnl)
        {
            IdUsuario = idUsuario;
            IdAtivo = idAtivo;
            Quantidade = quantidade;
            PrecoMedio = precoMedio;
            PnL = pnl;
        }

        // Construtor completo
        public Posicao(int idPosicao, int idUsuario, int idAtivo, int quantidade, decimal precoMedio, decimal pnl)
        {
            IdPosicao = idPosicao;
            IdUsuario = idUsuario;
            IdAtivo = idAtivo;
            Quantidade = quantidade;
            PrecoMedio = precoMedio;
            PnL = pnl;
        }
    }
}