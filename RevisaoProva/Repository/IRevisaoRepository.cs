using RevisaoProva.Models;

namespace RevisaoProva.Repository
{
    public interface IRevisaoRepository
    {
        bool CadastrarJogador(Jogador jogador);
        List<Jogador> ObterTodos();
        bool RegistrarResultado(Peneira resultado);
        List<Jogador> ObterAprovados();
        Jogador ObterPorCPF(string cpf);
    }
}
