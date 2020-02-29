using HwAspNetCoreBlazor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Services
{
    public class ReservationService
    {
        private readonly HttpClient _client;

        public ReservationService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost");
            client.DefaultRequestHeaders.Add("Accept", "application / frontend");
            client.DefaultRequestHeaders.Add("User-Agent", "BlazorFrontEndSample");

            _client = client;
        }

        public async Task<IEnumerable<ReservationModel>> GetAllReservations()
        {
            var response = await _client.GetAsync("/Reservations");

            response.EnsureSuccessStatusCode();

            using var resourceStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<ReservationModel>>(resourceStream);
        }
    }
}
