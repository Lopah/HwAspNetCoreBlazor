using HwAspNetCoreBlazor.Core.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Services
{
    public class RoomService
    {
        private readonly HttpClient _client;

        public RoomService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://localhost");
            client.DefaultRequestHeaders.Add("Accept", "application / frontend");
            client.DefaultRequestHeaders.Add("User-Agent", "BlazorFrontEndSample");

            _client = client;
        }

        public async Task<IEnumerable<RoomModel>> GetRoomsFromApi()
        {
            var response = await _client.GetAsync("/Rooms");

            response.EnsureSuccessStatusCode();

            using var resourceStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<RoomModel>>(resourceStream);
        }
    }
}
