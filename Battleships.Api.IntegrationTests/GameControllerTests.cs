using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Battleships.Api.IntegrationTests.Helpers;
using Battleships.Application.Game.Commands.StartGame;
using Battleships.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace Battleships.Api.IntegrationTests
{
    public class GameControllerTests
    {
        private readonly HttpClient _client;
        private const string _validShipsPlacementJsonFile = "ValidShipsPlacement.json";
        public GameControllerTests()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _client = appFactory.CreateClient();
        }

        [Fact]
        public async Task StartNewGame_Return_ValidationError_When_Empty_Ships()
        {
            var request = new
            {
                Url = "api/Game",
                Body = new StartNewGameCommand
                {
                   Ships = new List<Ship>()
                }
            };

            var response = await _client.PostAsync(request.Url, ContentHelper.Serialize(request.Body));

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task StartNewGame_Return_Guid_()
        {
            StartNewGameCommand commmand;
            using (StreamReader r = new StreamReader(_validShipsPlacementJsonFile))
            {
                string json = r.ReadToEnd();
                commmand = JsonConvert.DeserializeObject<StartNewGameCommand>(json);
            }
            var request = new
            {
                Url = "api/Game",
                Body = commmand
            };

            var response = await _client.PostAsync(request.Url, ContentHelper.Serialize(request.Body));
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseDeserialized = ContentHelper.Deserialize<Guid>(responseContent);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.IsType<Guid>(responseDeserialized);
        }
    }
}
