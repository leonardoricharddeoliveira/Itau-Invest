namespace Itau_invest.Models
{
    public class Ativo
    {
        public int IdAtivo { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }

        // Construtor Padrão
        public Ativo() { }

        // Contrutor para adicionar ativo
        public Ativo(string codigo, string nome)
        {
            Codigo = codigo;
            Nome = nome;
        }

        // Contrutor Completo
        public Ativo(int idAtivo, string codigo, string nome)
        {
            IdAtivo = idAtivo;
            Codigo = codigo;
            Nome = nome;
        }   
    }
}
