using Microsoft.AspNetCore.Mvc;
using RevisaoProva.Models;
using RevisaoProva.Repository;

namespace RevisaoProva.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RevisaoController : ControllerBase
    {
        private readonly IRevisaoRepository _revisaoRepository;

        public RevisaoController(IRevisaoRepository revisaoRepository)
        {
            _revisaoRepository = revisaoRepository;
        }

        [HttpPost]
        public IActionResult CadastrarJogador([FromBody] Jogador jogador)
        {
            string[] posicoes = { "GL", "ZA", "LD", "LE", "VO", "MD", "AT" };

            if (!posicoes.Contains(jogador.Posicao))
            {
                return BadRequest("Posição inválida. Use GL, ZA, LD, LE, VO, MD ou AT.");
            }

            if (!_revisaoRepository.CadastrarJogador(jogador))
            {
                return BadRequest("Já existe um jogador cadastrado com este CPF.");
            }

            return Ok("Jogador cadastrado com sucesso!");
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            return Ok(_revisaoRepository.ObterTodos());
        }

        [HttpPost("resultado")]
        public IActionResult RegistrarResultado([FromBody] Peneira resultado)
        {
            Jogador jogador = _revisaoRepository.ObterPorCPF(resultado.CPF);

            if (jogador == null)
            {
                return NotFound("Jogador não encontrado. O resultado não pode ser registrado.");
            }

            if (jogador.Aprovado != null)
            {
                return BadRequest("O resultado deste jogador já foi registrado.");
            }

            _revisaoRepository.RegistrarResultado(resultado);

            return Ok("Resultado registrado com sucesso!");
        }

        [HttpGet("aprovados")]
        public IActionResult ObterAprovados()
        {
            return Ok(_revisaoRepository.ObterAprovados());
        }
    }
}