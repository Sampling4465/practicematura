using Microsoft.Extensions.DependencyInjection;
using Spg.Fachtheorie.Domain.Model;
using Spg.Fachtheorie.Test.Core;

namespace Spg.Fachtheorie.Api.Test
{
    [Collection("Sequential")]
    public class StorageRoomControllerTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;

        public StorageRoomControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Beispiel für einen Integration Test einer Controller-Methode für einen GET-Request.
        /// </summary>
        /// <returns>async void = Task</returns>
        [Fact]
        public async Task GET_StorageRoom_ReturnsSuccess_And_StatusCode_Ok()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<RoomCt>();

                DatabaseUtilities.ReinitializeDbForTests(db);
            }
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client
                .GetAsync("/api/StorageRoom");
            // Hier der Response als string, falls du damit arbeiten möchtest.
            string jsonResult = new StreamReader(response.Content.ReadAsStream())
                .ReadToEnd();

            //TODO: Assert. Je mehr und detaillierter, desto besser.
            // Assert (Tipp: Du kannst Databaseutilities verwenden um mit dem manuellen Seeding zu vergleichen
            //         Achtung! Wenn du 2 Objekte (Dto's) vergleichst, wird nur die Speicheradresse verglichen.
            //         Finde für dieses Problem eine Lösung.
            Assert.True(false);
        }

        /// <summary>
        /// Beispiel für einen Integration Test einer Controller-Methode für einen GET-Request.
        /// </summary>
        /// <returns>async void = Task</returns>
        [Fact]
        public async Task POST_StorageRoom_ReturnsSuccessAndStatusCode_Created()
        {
            // Arrange
            using (var scope = _factory.Services.CreateScope())
            {
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<RoomCt>();

                DatabaseUtilities.ReinitializeDbForTests(db);
            }
            // TODO: Korrigiere die Datentypen in der nächsten Zeile!
            var content = new { Building = "Test Building 01", Floor = "Test Floor 01", RoomNumber = "123" };
            HttpClient client = _factory.CreateClient();

            // Act
            HttpResponseMessage response = await client
                .PostAsync("/api/StorageRoom", TestHelpers.GetJsonStringContent(content));
            // Hier der Response als string, falls du damit arbeiten möchtest.
            string jsonResult = new StreamReader(response.Content.ReadAsStream())
                .ReadToEnd();

            // Assert
            //TODO: Assert. Je mehr und detaillierter, desto besser.
            // Assert (Tipp: Du kannst Databaseutilities verwenden um mit dem manuellen Seeding zu vergleichen
            //         Achtung! Wenn du 2 Objekte (Dto's) vergleichst, wird nur die Speicheradresse verglichen.
            //         Finde für dieses Problem eine Lösung.
            Assert.True(false);
        }

        //TODO: Weitere Unit Tests
    }
}
