using RevisaoProva.Models;

namespace RevisaoProva.Repository
{
    public class RevisaoRepository : IRevisaoRepository
    {
        private static List<Jogador> jogadores = new List<Jogador>();

        public bool CadastrarJogador(Jogador jogador)
        {
            if (jogadores.Any(x => x.CPF == jogador.CPF))
            {
                return false;
            }

            jogadores.Add(jogador);
            return true;
        }

        public List<Jogador> ObterTodos()
        {
            return jogadores;
        }

        public Jogador ObterPorCPF(string cpf)
        {
            return jogadores.FirstOrDefault(x => x.CPF == cpf);
        }

        public bool RegistrarResultado(Peneira resultado)
        {
            Jogador jogador = ObterPorCPF(resultado.CPF);

            if (jogador == null)
            {
                return false;
            }

            if (jogador.Aprovado != null)
            {
                return false;
            }

            jogador.Aprovado = resultado.Aprovado;

            return true;
        }

        public List<Jogador> ObterAprovados()
        {
            return jogadores
                .Where(x => x.Aprovado == true)
                .ToList();
        }
    }
}
