using DesafioWebmotors.Application.Interfaces;
using DesafioWebmotors.Application.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DesafioWebmotors.Infra.ExternalServices
{
    public class ExternalService : IExternalService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private const string UrlWebmotors = "OnlineChallenge/{0}";

        public ExternalService(IConfiguration configuration, IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient();
            _configuration = configuration;
        }

        public async Task<IEnumerable<Base>> GetMakesAsync()
        {
            var url = _configuration["Webmotors:UrlDefault"] + string.Format(UrlWebmotors, "Make");
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };

            var response = await _httpClient.SendAsync(request);
            return JsonConvert.DeserializeObject<IEnumerable<Base>>(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<IEnumerable<Model>> GetModelsAsync(int makeId)
        {
            var urlModel = string.Format("Model?MakeID={0}", makeId);
            var url = _configuration["Webmotors:UrlDefault"] + string.Format(UrlWebmotors, urlModel);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };

            var response = await _httpClient.SendAsync(request);
            return JsonConvert.DeserializeObject<IEnumerable<Model>>(response.Content.ReadAsStringAsync().Result);
        }

        public async Task<IEnumerable<Application.Models.Version>> GetVersionsAsync(int modelId)
        {
            var urlVersion = string.Format("Version?ModelID={0}", modelId);
            var url = _configuration["Webmotors:UrlDefault"] + string.Format(UrlWebmotors, urlVersion);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url)
            };

            var response = await _httpClient.SendAsync(request);
            return JsonConvert.DeserializeObject<IEnumerable<Application.Models.Version>>(response.Content.ReadAsStringAsync().Result);
        }
    }
}
