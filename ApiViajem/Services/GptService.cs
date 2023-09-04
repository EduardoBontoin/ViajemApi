using ApiViajem.Models.ModelsIntegracaoOpenIa;
using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ApiViajem.Services
{
    public class GptService
    {
        public async Task<string> ComunicaComGpt(string pais)
        {


            var client = new HttpClient();
            //TODO: Colocar chave no banco ou criar Secret
            client.DefaultRequestHeaders.Add("Authorization", "Bearer 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");


            RequestData requestData = new RequestData
            {
                model = "gpt-3.5-turbo",
                messages = new Message[]
                {
                    new Message
                    {
                        role = "system",
                        content = "Você é um modelo de linguagem?"
                    },
                    new Message
                    {
                        role = "user",
                        content = $"Faça um texto sobre comidas tipicas do {pais} com 50 palavras"
                    }
                }
            };

            try
            {

                var json = JsonConvert.SerializeObject(requestData);

                var httpResponse = await client.PostAsync("https://api.openai.com/v1/chat/completions", new StringContent(json, Encoding.UTF8, "application/json"));

                var responseContent = await httpResponse.Content.ReadAsStringAsync();


                var responseObject = JsonConvert.DeserializeObject<ApiResponse>(responseContent);
                var ContentGpt = responseObject.Choices[0].Message.content.ToString();

                if (ContentGpt is null)
                {
                    throw new SystemException("Houve um erro ao comunicar com ChatGpt");
                }
                else return (ContentGpt);

            }

            catch (Exception ex)
            {
                return ($"Houve um erro ao consultar o GPT - {ex.Message}");
            }


        } 
    }
}
