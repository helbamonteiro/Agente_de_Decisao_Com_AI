using System.Text.Json;

namespace AgenteDecisao.API.Services
{
    /// <summary>
    /// Integração com a API do OpenAI para fornecer funcionalidades 
    /// de Inteligência Artificial (IA)
    /// </summary>
    public class ServicoOpenAI(HttpClient http) : IServicoAI
    {
        public async Task<string> ExecutarAsync(string prompt)
        {
            //Requisição para a OpenAI
            var requisicao = new
            {
                model = "gpt-4o",
                messages = new[] {
                    new { role = "user", content = prompt }
                }
            };

            //Fazendo a chamada para a API do OpenAI
            var response = await http.PostAsJsonAsync
                ("https://api.openai.com/v1/chat/completions", requisicao);

            //Deserializar a resposta da OpenAI
            var json = await response.Content.ReadFromJsonAsync<JsonElement>();

            //Retornar o texto da resposta
            return json
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString()!;
        }
    }
}

