namespace AgenteDecisao.API.Models
{
    //representa os dados que alimentam a nossa decisão, ou seja, o estado do recurso que pode ser alterado pelo agente de IA
    public class Cliente
    {
        public string Nome { get; set; } = string.Empty;
        public int DiasInadimplente { get; set; }
    }
}
