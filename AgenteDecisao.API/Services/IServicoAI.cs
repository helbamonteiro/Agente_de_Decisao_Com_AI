namespace AgenteDecisao.API.Services
{
    //CONTRATO PARA SERVIÇOS DE INTELIGENCIA ARTIFICAL QUE PODEM SER UTILIZADOS PELO AGENDE DE DECISAO
    public interface IServicoAI
    {
        Task<string> ExecutarAsync(string prompt);
    }
}
