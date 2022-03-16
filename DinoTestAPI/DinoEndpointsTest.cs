using DinoDataAccess.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace DinoTestAPI
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Program>
    {
        //TODO: Use separate database (DinoTestDB) for the tests and populate it with dinosaurs
        protected override void ConfigureWebHost(IWebHostBuilder builder) {}
    }

    public class DinoEndpointsTests : IClassFixture<ApiWebApplicationFactory>
    {
        private readonly ApiWebApplicationFactory _factory;
        private readonly HttpClient _client;

        public DinoEndpointsTests(ApiWebApplicationFactory fixture)
        {
            this._factory = fixture;
            this._client = this._factory.CreateClient();
        }

        [Fact]
        public async Task GetAllDinosaurs()
        {
            IEnumerable<DinosaurModel>? result = await this._client.GetFromJsonAsync<IEnumerable<DinosaurModel>>("/dinosaurs");
            Assert.NotNull(result);
            Assert.True(result.Count() > 0);
        }

        [Fact]
        public async Task GetDinosaur()
        {
            DinosaurModel? result = await this._client.GetFromJsonAsync<DinosaurModel>("/dinosaur/1");
            Assert.NotNull(result);
        }

        [Fact]
        public async Task SearchDinosaurs()
        {
            IEnumerable<DinosaurModel>? result = await this._client.GetFromJsonAsync<IEnumerable<DinosaurModel>>("/dinosaurs/a");
            Assert.NotNull(result);
            Assert.True(result.Count() > 0);
        }
    }
}