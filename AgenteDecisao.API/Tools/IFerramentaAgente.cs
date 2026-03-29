using AgenteDecisao.API.Models;

namespace AgenteDecisao.API.Tools
{
    /// <summary>
    /// Define um contrato para ferramentas que podem ser utilizadas por um agente.    /// 
    /// </summary>
    public interface IFerramentaAgente
    {
        /// <summary>
        /// Retornar o nome da ferramenta, que será utilizado para identificar 
        /// a ferramenta e chamar a função correspondente.
        /// </summary>
        string Nome { get; }

        /// <summary>
        /// Executa uma operação assíncrona de decisão utilizando o contexto fornecido.
        /// </summary>

        Task ExecutarAsync(ContextoDecisao contexto);
    }
}
