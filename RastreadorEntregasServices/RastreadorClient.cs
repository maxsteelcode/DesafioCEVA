using RastreadorEntregasEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RastreadorEntregasServices
{
    public class RastreadorClient : IRastreadorClient
    {
        public HttpClient _client;
        private const string _apiUrl = "/WCFOrionMobilityMilkRun/Servicos/SincronizarService.svc/SincronizarCutOff";
        private readonly JsonSerializerOptions _options;
        private ViagemMilkrunResponse _viagemMilkRunResponse;
        private const string _host = "qa1orionbr.cevalogistics.com";

        public RastreadorClient()
        {
            try
            {
                _client = new HttpClient
                {
                    BaseAddress = new Uri("https://qa1orionbr.cevalogistics.com"),
                    Timeout = new TimeSpan(0, 0, 30)
                };
                _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ViagemMilkrunResponse> Post(int viagem)
        {
            try
            {
                // 0002528460
                _client.DefaultRequestHeaders.Host = _host;
                _client.DefaultRequestHeaders.Add("Viagem", "erqer"); //viagem.ToString());                

                using (var response = await _client.PostAsync(_apiUrl, null))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStreamAsync();
                        _viagemMilkRunResponse = await JsonSerializer.DeserializeAsync<ViagemMilkrunResponse>(apiResponse, _options);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return _viagemMilkRunResponse;
        }
    }
}
