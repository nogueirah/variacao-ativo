using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using variacao_ativo.Model;

namespace variacao_ativo
{
    public class FinanceAPI
    {
        private HttpClient client = new HttpClient();

        public async Task<List<PrecoAtivoDTO>> GetRegisters()
        {
            var response = await client.GetAsync("https://query2.finance.yahoo.com/v8/finance/chart/PETR4.SA?interval=1d&range=1mo");
            response.EnsureSuccessStatusCode();

            var jsonResponse = JObject.Parse(await response.Content.ReadAsStringAsync());
            var jsonResult = jsonResponse["chart"]["result"].FirstOrDefault();
            var jsonTimestamp = (JArray)jsonResult["timestamp"];
            var jsonOpen = (JArray)jsonResult["indicators"]["quote"].FirstOrDefault()["open"];

            var listPreco = new List<PrecoAtivoDTO>(jsonTimestamp.Zip(jsonOpen).Select(s => new PrecoAtivoDTO(s.First, s.Second)));

            return listPreco;
        }
    }
}
