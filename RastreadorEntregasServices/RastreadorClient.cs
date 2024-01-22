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
        private const string _apiUrl = "https://qa1orionbr.cevalogistics.com/WCFOrionMobilityMilkRun/Servicos/SincronizarService.svc/SincronizarCutOff/";
        private readonly JsonSerializerOptions _options;
        private ViagemMilkrunResponse _viagemMilkRunResponse;

        public RastreadorClient()
        {
            _client = new HttpClient();
            //_client.BaseAddress = new Uri("https://qa1orionbr.cevalogistics.com/WCFOrionMobilityMilkRun/Servicos/SincronizarService.svc/");
            _client.Timeout = new TimeSpan(0, 0, 10);
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ViagemMilkrunResponse> Post(int viagem)
        {
            try
            {

                string apiUrl = "https://qa1orionbr.cevalogistics.com/WCFOrionMobilityMilkRun/Servicos/SincronizarService.svc/SincronizarCutOff";
                Uri uri = new Uri(apiUrl);
                string host = uri.Host;

                // Set the Host header
                _client.DefaultRequestHeaders.Host = host;
                _client.DefaultRequestHeaders.Add("Viagem", viagem.ToString());
                HttpContent content = new StringContent("", System.Text.Encoding.UTF8, "application/json");

                using (var response = await _client.PostAsync(apiUrl, null))
                {

                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStreamAsync();
                        _viagemMilkRunResponse = await JsonSerializer.DeserializeAsync<ViagemMilkrunResponse>(apiResponse, _options);
                    }

                }

            }
            catch (Exception e)
            {

                throw;
            }

            return _viagemMilkRunResponse;
        }
    }
}
