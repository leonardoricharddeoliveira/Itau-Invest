namespace Itau_invest.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public decimal PercentualCorretagem { get; set; }

        // Construtor padrão 
        public Usuario() { }

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