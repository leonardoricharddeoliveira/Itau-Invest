namespace Itau_invest.Models
{
    public class Posicao
    {
        public int IdPosicao { get; set; }

        // FK: Usuario
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        // FK: Ativo
        public int IdAtivo { get; set; }
        public Ativo Ativo { get; set; }

        public int Quantidade { get; set; }
        public decimal PrecoMedio { get; set; }
        public decimal PnL { get; set; } // Lucro/Prejuízo

        // Construtor padrão
        public Posicao() { }

        // Construtor para criação (sem ID)
        public Posicao(int idUsuario, int idAtivo, int quantidade, decimal precoMedio, decimal pnl)
        {
            IdUsuario = idUsuario;
            IdAtivo = idAtivo;
            Quantidade = quantidade;
            PrecoMedio = precoMedio;
            PnL = pnl;
        }

        // Construtor completo (com ID)
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
