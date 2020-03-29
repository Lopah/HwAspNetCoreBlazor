using HwAspNetCoreBlazor.API;
using HwAspNetCoreBlazor.Core.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using System.Linq;
using System.Collections.Generic;
using HwAspNetCoreBlazor.Data;
using System.Text.Json;
using HwAspNetCoreBlazor.Data.Entities;
using NUnit.Framework;
using System.Threading.Tasks;

namespace HwAspNetCoreBlazor.Tests.IntegrationTests
{
    [TestFixture]
    public class ApiIntegrationTests
    {
        private HttpClient _client;

        [OneTimeSetUp]
        public void Initialize()
        {
            var factory = new TestAPIFactory<Startup>();
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Test]
        public async Task TestGetRoomWithId()
        {
            HttpResponseMessage response = _client.GetAsync($"/api/Rooms/1").Result;
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            var room = JsonSerializer.Deserialize<RoomModel>(json, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            Assert.IsTrue(room.Name == "UCL1");
        }
    }
}
