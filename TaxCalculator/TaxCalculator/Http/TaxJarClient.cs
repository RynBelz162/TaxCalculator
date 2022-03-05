﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaxCalculator.Models.TaxJar;

namespace TaxCalculator.Http
{
    public class TaxJarClient : ITaxJarClient
    {
        private readonly HttpClient _httpClient;

        public TaxJarClient(HttpClient httpClient, TaxJarSettings taxJarSettings)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(taxJarSettings.Uri);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", taxJarSettings.ApiKey);
        }

        public async Task<TaxRateResult> GetLocationTaxRates(string zip)
        {
            var httpRequest = await _httpClient.GetAsync($"rates/{zip}");
            httpRequest.EnsureSuccessStatusCode();

            var rawResult = await httpRequest.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<TaxRateResult>(rawResult);
        }

        public async Task<OrderResponse> CalculateOrderTax(OrderRequest request)
        {
            var content = CreateContent(request);
            var httpRequest = await _httpClient.PostAsync("taxes", content);
            httpRequest.EnsureSuccessStatusCode();

            var rawResult = await httpRequest.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<OrderResponse>(rawResult);
        }

        private static StringContent CreateContent<T>(T content)
        {
            var myContent = JsonSerializer.Serialize(content);
            return new StringContent(myContent, Encoding.UTF8, MediaTypeNames.Application.Json); 
        }
    }
}