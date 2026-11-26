using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextTransformer.Services
{
    public class OpenAiService
    {
        private string _apiKey { get; set; } 
        
        public OpenAiService()
        {
            _apiKey = System.Environment.GetEnvironmentVariable("OPENAI_API_KEY");
        }
        
        public async Task<string> GetEdit(string input, string instruction)
        {
            using var httpClient = new HttpClient();
            
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var requestContent = new 
            {
                model = "text-davinci-edit-001",
                input = input.Replace("\n","\\n").Replace("\r",""),
                instruction = input.Replace("\n","\\n").Replace("\r",""),
                temperature = 1,
                n = 1,
                top_p = 1,
            };

            var jsonRequestContent = JsonSerializer.Serialize(requestContent);
            var response = await httpClient.PostAsync("https://api.openai.com/v1/edits", 
                new StringContent(jsonRequestContent, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            await using var responseStream = await response.Content.ReadAsStreamAsync();
            
            var jsonDocument = await JsonDocument.ParseAsync(responseStream);
            var jsonResponse = jsonDocument.RootElement.GetProperty("choices")[0].GetProperty("text").GetString().Trim();

            return jsonResponse;
        }
    }

}