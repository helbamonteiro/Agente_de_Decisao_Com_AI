namespace AgenteDecisao.API.Models
{
    //representa o resultado da decisão tomada pelo agente de IA, ou seja, as ações a serem executadas com base na
    //análise do contexto de decisão. Ele pode incluir informações como as ações recomendadas,
    //os recursos a serem alterados, e quaisquer outras instruções relevantes para a execução da decisão.
    public class ResultadoDecisao
    {
        public string Decisao { get; set; }
        public double Confianca { get; set; }
        public string Justificativa { get; set; }
    }
}
